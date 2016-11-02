using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using ComputersFactory.Data.SalesReports.Converters.Contracts;

namespace ComputersFactory.Data.SalesReports.Converters
{
    public class ModelConverter : IModelConverter
    {
        public IList<TModelOut> Convert<TModelIn, TModelOut>(IEnumerable<TModelIn> inputData)
            where TModelOut : new()
        {
            if (inputData == null)
            {
                throw new ArgumentNullException(nameof(inputData));
            }

            var modelInProperties = this.GetCommonProperties(typeof(TModelIn), typeof(TModelOut));
            var modelOutProperties = this.GetCommonProperties(typeof(TModelOut), typeof(TModelIn));

            var resultingCollection = this.InitializeCollection<TModelOut>();
            foreach (var item in inputData)
            {
                var nextModelOutInstance = new TModelOut();
                foreach (var property in modelInProperties)
                {
                    var matchingModelOutProperty = modelOutProperties
                        .Where(prop => prop.Name == property.Name)
                        .FirstOrDefault();

                    if (matchingModelOutProperty == null)
                    {
                        throw new ArgumentNullException(nameof(matchingModelOutProperty));
                    }

                    try
                    {
                        var propertyValue = property.GetValue(item);
                        matchingModelOutProperty.SetValue(nextModelOutInstance, propertyValue);
                    }
                    catch (ArgumentException)
                    {
                        // It's a collection.
                    }
                }

                resultingCollection.Add(nextModelOutInstance);
            }

            return resultingCollection;
        }

        private IList<T> InitializeCollection<T>()
        {
            return new List<T>();
        }

        private IEnumerable<PropertyInfo> GetCommonProperties(Type getPropertiesFromType, Type commonPropertiesWithType)
        {
            var secondPropertiesNames = commonPropertiesWithType.GetProperties().Select(prop => prop.Name);

            var firstProperties = getPropertiesFromType.GetProperties()
                .Where(prop => secondPropertiesNames.Contains(prop.Name))
                .OrderBy(prop => prop.Name);

            return firstProperties;
        }
    }
}
