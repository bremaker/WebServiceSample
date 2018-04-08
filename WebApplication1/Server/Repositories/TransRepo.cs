using System;
using System.Collections.Generic;
using System.IO;

namespace WebApplication.Repositories
{
    /// <summary>
    /// Implements transaction persistence
    /// </summary>
    public class TransRepo : BasicRepo
    {
        private const string REPOSITORY_NAME = "trans.txt";

        public TransRepo() : base(REPOSITORY_NAME)
        {
        }
    }
}
