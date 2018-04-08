using System;
using System.Collections.Generic;
using System.IO;
using WebApplication1.Contracts;

namespace WebApplication1.Repositories
{
    public abstract class BasicRepo : IBasicRepo
    {
        protected const string DATA_SOURCE = "~/Data/";
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
                System.Diagnostics.Debug.WriteLine(e.Message);
                result = false;
            }

            return result;
        }

        public string ReadData()
        {
            string result = "";
            string fullPath = _path + _fileName;

            try
            {
                if (File.Exists(fullPath))
                {
                    result = File.ReadAllText(fullPath);
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return result;
        }
    }
}
