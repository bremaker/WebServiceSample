using System;
using System.Collections.Generic;
using System.IO;
using WebApplication.Contracts;
using WebApplication.Utils;

namespace WebApplication.Repositories
{
    /// <summary>
    /// Implements persistence
    /// </summary>
    public abstract class BasicRepo : IBasicRepo
    {
        protected const string DATA_SOURCE = "~/Data/";
        protected const string ERROR_TEXT = "No data to read in ";

        protected readonly string _path;
        protected readonly string _fileName;

        public BasicRepo(string fileName)
        {
            _path = System.Web.Hosting.HostingEnvironment.MapPath(DATA_SOURCE); 
            _fileName = fileName;
        }

        public bool StoreData(string data)
        {
            bool result = true;

            try
            {
                if (!Directory.Exists(_path))
                {
                    Directory.CreateDirectory(_path);
                }
                File.WriteAllText(_path + _fileName, data);
            }
            catch(Exception e)
            {
                Log.Write(e.Message);
                result = false;
                throw e;
            }

            return result;
        }

        public string ReadData()
        {
            string result = "";
            string error = "";
            string fullPath = _path + _fileName;

            try
            {
                if (File.Exists(fullPath))
                {
                    result = File.ReadAllText(fullPath);
                }
                else
                {
                    error = ERROR_TEXT + fullPath;
                    Log.Write(error);
                    throw new Exception(error);
                }
            }
            catch(Exception e)
            {
                Log.Write(e.Message);
                throw e;
            }

            return result;
        }
    }
}
