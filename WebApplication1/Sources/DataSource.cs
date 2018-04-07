using System;
using System.Net;
using WebApplication1.Contracts;

namespace WebApplication1.Sources
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
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return result;
        }
    }
}
