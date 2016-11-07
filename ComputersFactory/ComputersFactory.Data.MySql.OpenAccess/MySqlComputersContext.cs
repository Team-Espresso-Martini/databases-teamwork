using System.Linq;

using ComputersFactory.Models;

using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;

namespace ComputersFactory.Data.MySql.OpenAccess
{
    public class MySqlComputersContext
    {
        public partial class FluentModel : OpenAccessContext
        {
            private static string connectionStringName = @"ComputersFactoryMySql";

            private static BackendConfiguration backend = GetBackendConfiguration();

            private static MetadataSource metadataSource = new MySqlReportsMetadataSource();

            public FluentModel()
                : base(connectionStringName, backend, metadataSource)
            { }

            public IQueryable<MySqlReport> Reports
            {
                get
                {
                    return this.GetAll<MySqlReport>();
                }
            }

            public static BackendConfiguration GetBackendConfiguration()
            {
                BackendConfiguration backend = new BackendConfiguration();
                backend.Backend = "MySql";
                backend.ProviderName = "MySql.Data.MySqlClient";

                return backend;
            }
        }
    }
}
