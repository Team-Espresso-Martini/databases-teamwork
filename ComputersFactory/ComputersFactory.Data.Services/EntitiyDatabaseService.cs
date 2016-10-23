using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using ComputersFactory.Data.Services.Contracts;

namespace ComputersFactory.Data.Services
{
    public class EntitiyDatabaseService : IDatabaseService
    {
        private readonly DbContext entityContext;
        private readonly IDictionary<string, Type> contextSetsNames;

        public EntitiyDatabaseService(DbContext entityContext)
        {
            if (entityContext == null)
            {
                throw new ArgumentNullException(nameof(entityContext));
            }

            this.entityContext = entityContext;
            this.contextSetsNames = this.ResolveEntityContextSetsNames(entityContext);
        }

        public void SaveDataToDatabase<ModelType>(IEnumerable<ModelType> data)
        {
            throw new NotImplementedException();
        }

        private IDictionary<string, Type> ResolveEntityContextSetsNames(DbContext entityContext)
        {
            var result = new Dictionary<string, Type>();

            var contextProperties = entityContext.GetType().GetProperties();
            foreach (var property in contextProperties)
            {
                var propertyType = property.PropertyType;
                var genericType = propertyType.GetGenericArguments().FirstOrDefault();

                var genericTypeExists = genericType != null;
                if (genericTypeExists)
                {
                    var generictTypeName = genericType.Name;
                    result.Add(generictTypeName, propertyType);
                }
            }

            return result;
        }
    }
}
