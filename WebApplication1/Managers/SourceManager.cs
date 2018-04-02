using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class SourceManager
    {
        private const string DATA_SOURCE = ".\\Data\\";

        private WebClient _client;
        private string _url;
        private string _path;

        public SourceManager(string url, string fileName)
        {
            _client = new WebClient();
            _url = url;
            _path = DATA_SOURCE + fileName;
        }

        public void LoadData()
        {
            string result;

            result = _client.DownloadString(_url);

            if (!Directory.Exists(DATA_SOURCE))
            {
                Directory.CreateDirectory(DATA_SOURCE);
            }
            File.WriteAllText(_path, result);
        }

        public string GetData()
        {
            string result = "";

            if (File.Exists(_path))
            {
                result = File.ReadAllText(_path);
            }

            return result;
        }
    }
}
