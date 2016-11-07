using Telerik.OpenAccess;

namespace ComputersFactory.Data.MySql.OpenAccess.ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            UpdateDatabase();
        }

        private static void UpdateDatabase()
        {
            using (var context = new MySqlComputersContext.FluentModel())
            {
                var schemaHandler = context.GetSchemaHandler();
                EnsureDB(schemaHandler);
            }
        }

        private static void EnsureDB(ISchemaHandler schemaHandler)
        {
            string script = null;
            if (schemaHandler.DatabaseExists())
            {
                script = schemaHandler.CreateUpdateDDLScript(null);
            }
            else
            {
                schemaHandler.CreateDatabase();
                script = schemaHandler.CreateDDLScript();
            }

            if (!string.IsNullOrEmpty(script))
            {
                schemaHandler.ExecuteDDLScript(script);
            }
        }
    }
}

