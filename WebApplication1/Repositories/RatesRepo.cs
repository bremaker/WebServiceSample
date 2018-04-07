using System;
using System.Collections.Generic;
using System.IO;

namespace WebApplication1.Repositories
{
    public class RatesRepo : BasicRepo
    {
        private const string REPOSITORY_NAME = "rates.txt";

        public RatesRepo() : base(REPOSITORY_NAME)
        {
        }
    }
}
