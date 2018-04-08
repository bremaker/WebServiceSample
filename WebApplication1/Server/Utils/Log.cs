using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebApplication.Contracts;
using WebApplication.Entities;

namespace WebApplication.Utils
{
    /// <summary>
    /// Logger
    /// </summary>
    public static class Log
    {
        private const string DIR = "~/Log/";
        private const string EXTENSION = ".log";

        /// <summary>
        /// Write a new entry on log file
        /// </summary>
        /// <param name="text">Text to write in log file</param>
        public static void Write(string text)
        {
            StreamWriter writer;
            string time = DateTime.Now.ToShortTimeString();
            string date = DateTime.Now.ToShortDateString().Replace('/','-');
            string path = System.Web.Hosting.HostingEnvironment.MapPath(DIR);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            writer = File.AppendText(path + date + EXTENSION);
            writer.WriteLine("[" + time + "] " + text);
            writer.Close();
        }
    }
}
