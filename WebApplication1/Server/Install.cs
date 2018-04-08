using System;
using System.Net;
using WebApplication.Contracts;
using WebApplication.Repositories;
using WebApplication.Factories;
using WebApplication.Sources;

namespace WebApplication
{
    /// <summary>
    /// Resolve IResultsFactory
    /// </summary>
    public static class Install
    {
        public static IResultsFactory Factory = new ResultsFactory(new RatesRepo(), new TransRepo(), new DataSource(), "EUR");
    }
}
