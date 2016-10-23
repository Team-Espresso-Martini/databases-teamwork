using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

using ComputersFactory.Data.Services.Contracts;

namespace ComputersFactory.Data.Services
{
    public class EntitiyDatabaseService : IDatabaseService
    {
        private readonly DbContext entityContext;
        private readonly MethodInfo dbSetAddMethod;
        private readonly IDictionary<string, MethodInfo> contextSetsNames;

        public EntitiyDatabaseService(DbContext entityContext)
        {
            if (entityContext == null)
            {
                throw new ArgumentNullException(nameof(entityContext));
            }

            this.entityContext = entityContext;
            this.dbSetAddMethod = this.ResolveDbSetAddMethod(entityContext);
            this.contextSetsNames = this.ResolveEntityContextSetsNames(entityContext);
        }

        public void SaveDataToDatabase<ModelType>(IEnumerable<ModelType> data)
        {
            var method = this.ResolveModelTypeToMatchingContextSet(typeof(ModelType));
            foreach (var item in data)
            {
                method.Invoke(this.entityContext.GetType().GetProperty("Memories").GetValue(entityContext), new object[] { item });
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

        private MethodInfo ResolveModelTypeToMatchingContextSet(Type modelType)
        {
            var modelTypeName = modelType.Name;
            var contextSet = this.contextSetsNames[modelTypeName];

            return contextSet;
        }

        private IDictionary<string, MethodInfo> ResolveEntityContextSetsNames(DbContext entityContext)
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
    }
}
