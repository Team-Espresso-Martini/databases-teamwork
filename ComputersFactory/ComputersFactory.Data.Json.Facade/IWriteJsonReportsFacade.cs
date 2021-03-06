﻿using System.Collections.Generic;

using ComputersFactory.Models;

namespace ComputersFactory.Data.Json.Facade
{
    public interface IWriteJsonReportsFacade
    {
        IList<MySqlReport> GenerateJsonReports();
    }
}