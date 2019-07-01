using System;
using System.Data.SqlClient;

namespace LearnCSharp.Database
{
    public abstract class ICommand
    {
        protected SqlConnection connection = new SqlConnection(DBConstants.GetConnectionString());

        protected abstract bool DoExecute();

        public bool Execute()
        {
            bool result = false;
            try
            {
                connection.Open();
                result = DoExecute();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
    }
}
