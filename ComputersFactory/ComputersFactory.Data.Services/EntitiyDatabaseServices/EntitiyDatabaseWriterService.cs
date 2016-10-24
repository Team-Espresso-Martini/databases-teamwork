using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

using ComputersFactory.Data.Services.Contracts;

namespace ComputersFactory.Data.Services.EntitiyDatabaseServices
{
    public class EntitiyDatabaseWriterService : IDatabaseReaderService
    {
        private readonly DbContext entityContext;
        private readonly MethodInfo dbSetAddMethod;
        private readonly IDictionary<string, MethodInfo> contextSetsAddMethods;
        private readonly IDictionary<string, PropertyInfo> contextProperties;

        public EntitiyDatabaseWriterService(DbContext entityContext)
        {
            if (entityContext == null)
            {
                throw new ArgumentNullException(nameof(entityContext));
            }

            this.entityContext = entityContext;
            this.dbSetAddMethod = this.ResolveDbSetAddMethod(entityContext);
            this.contextProperties = this.ResolveEntityContextSetsProperties(entityContext);
            this.contextSetsAddMethods = this.ResolveEntityContextSetsAddMethods(entityContext);
        }

        public void SaveDataToDatabase<ModelType>(IEnumerable<ModelType> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var validDataItems = data.Where(item => item != null).ToList();

            var contextAddMethod = this.ResolveModelTypeToMatchingContextAddMethod(typeof(ModelType));
            var contextMatchingDbSetProperty = this.ResolveModelTypeToMatchingContextProperty(typeof(ModelType));
            var contextInstanceMatchingDbSet = contextMatchingDbSetProperty.GetValue(this.entityContext);

            foreach (var item in validDataItems)
            {
                var nextValueToAdd = new object[] { item };
                contextAddMethod.Invoke(contextInstanceMatchingDbSet, nextValueToAdd);
            }

            this.entityContext.SaveChanges();
        }

        private MethodInfo ResolveDbSetAddMethod(DbContext entityContext)
        {
            var contextProperties = entityContext.GetType().GetProperties();
            var property = contextProperties
                .Where(prop => prop.PropertyType.IsGenericType)
                .FirstOrDefault();

            if (property == null)
            {
                throw new ArgumentException("invalid context, property not found");
            }

            var dbSetAddMethodInfo = property.PropertyType.GetMethod("Add");
            if (dbSetAddMethodInfo == null)
            {
                throw new ArgumentException("invalid context, method not found");
            }

            return dbSetAddMethodInfo;
        }

        private MethodInfo ResolveModelTypeToMatchingContextAddMethod(Type modelType)
        {
            MethodInfo contextSet;
            var modelTypeName = modelType.Name;
            var contextSetIsFound = this.contextSetsAddMethods.TryGetValue(modelTypeName, out contextSet);
            if (!contextSetIsFound)
            {
                throw new ArgumentException("Invalid model type");
            }

            return contextSet;
        }

        private PropertyInfo ResolveModelTypeToMatchingContextProperty(Type modelType)
        {
            PropertyInfo contextProperty;
            var modelTypeName = modelType.Name;
            var contextPropertyIsFound = this.contextProperties.TryGetValue(modelTypeName, out contextProperty);
            if (!contextPropertyIsFound)
            {
                throw new ArgumentException("Invalid model type");
            }

            return contextProperty;
        }

        private IDictionary<string, MethodInfo> ResolveEntityContextSetsAddMethods(DbContext entityContext)
        {
            var result = new Dictionary<string, MethodInfo>();

            var contextProperties = entityContext.GetType().GetProperties();
            foreach (var property in contextProperties)
            {
                var propertyType = property.PropertyType;
                var genericType = propertyType.GetGenericArguments().FirstOrDefault();

                var genericTypeExists = genericType != null;
                if (genericTypeExists)
                {
                    var generictTypeName = genericType.Name;
                    var addMethod = propertyType.GetMethod("Add");
                    result.Add(generictTypeName, addMethod);
                }
            }

            return result;
        }

        private IDictionary<string, PropertyInfo> ResolveEntityContextSetsProperties(DbContext entityContext)
        {
            var result = new Dictionary<string, PropertyInfo>();

            var contextProperties = entityContext.GetType().GetProperties();
            foreach (var property in contextProperties)
            {
                var propertyType = property.PropertyType;
                var genericType = propertyType.GetGenericArguments().FirstOrDefault();

                var genericTypeExists = genericType != null;
                if (genericTypeExists)
                {
                    var generictTypeName = genericType.Name;
                    result.Add(generictTypeName, property);
                }
            }

            return result;
        }
    }
}
