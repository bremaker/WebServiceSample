using System;
using System.Collections.Generic;
using System.IO;

namespace WebApplication.Repositories
{
    /// <summary>
    /// Implements rates persistence
    /// </summary>
    public class RatesRepo : BasicRepo
    {
        private const string REPOSITORY_NAME = "rates.txt";

        public RatesRepo() : base(REPOSITORY_NAME)
        {
        }
    }
}
