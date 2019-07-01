using System.Data;
using System.Data.SqlClient;

namespace LearnCSharp.Database.Commands
{
    public class CheckAccount : ICommand
    {
        string Username = "";
        string Password = "";

        public CheckAccount(string username, string password)
        {
            Username = username;
            Password = password;
        }

        protected override bool DoExecute()
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = string.Format("SELECT count(*) FROM account WHERE username = '{0}' AND password = '{1}'", Username, Password),
                CommandType = CommandType.Text,
                Connection = connection
            };

            int result = (int)cmd.ExecuteScalar();

            if (result == 1) return true;

            return false;
        }
    }
}
