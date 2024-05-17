using System;
using Microsoft.Extensions.Configuration;

namespace SIS.util
{
	public static class DbConnUtil
	{
        private static IConfiguration _iconfiguration;

        public static string GetConnectionString()
        {
            return _iconfiguration.GetConnectionString("LocalConnectionString");
        }

        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            _iconfiguration = builder.Build();
        }



        static DbConnUtil()
        {
            GetAppSettingsFile();
        }

    }
}

