using System;
using System.Net;
using WebApplication.Contracts;
using WebApplication.Utils;

namespace WebApplication.Sources
{
    public class DataSource : ISource
    {
        public DataSource()
        {
        }

        public string GetDataFromSource(string url)
        {
            string result = "";
            WebClient client = new WebClient();

            try
            {
                result = client.DownloadString(url);
            }
            catch(Exception e)
            {
                Log.Write(e.Message);
            }

            return result;
        }
    }
}
