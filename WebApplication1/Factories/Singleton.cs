using System;
using System.Net;
using WebApplication1.Contracts;
using WebApplication1.Repositories;

namespace WebApplication1.Sources
{
    public static class Singleton
    {
        public static IResultsFactory Factory = new ResultsFactory(new RatesRepo(), new TransRepo(), new DataSource());
    }
}
