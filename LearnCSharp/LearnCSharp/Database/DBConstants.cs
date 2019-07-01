using System;

namespace LearnCSharp.Database
{
    public class DBConstants
    {
        public static string GetConnectionString()
        {
            //string basepath = AppDomain.CurrentDomain.BaseDirectory;
            string basepath = "E:\\TargetSettings\\TargetSettings\\LearnCSharp\\LearnCSharp\\";
            string db_path = basepath + "Database\\MyDatabase.mdf;";
            string connection_string = "Data Source = (LocalDB)\\MSSQLLocalDB;" +
            "AttachDbFilename=" + db_path +
            "Integrated Security = True";

            return connection_string;
        }
    }
}
