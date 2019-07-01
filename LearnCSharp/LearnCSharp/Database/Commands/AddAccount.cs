using System.Data;
using System.Data.SqlClient;

namespace LearnCSharp.Database.Commands
{
    public class AddAccount : ICommand
    {
        string Username = "";
        string Password = "";

        public AddAccount(string username, string password)
        {
            Username = username;
            Password = password;
        }

        protected override bool DoExecute()
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = string.Format("INSERT INTO account (username, password) VALUES ('{0}', '{1}')", Username, Password),
                CommandType = CommandType.Text,
                Connection = connection
            };

            int result = cmd.ExecuteNonQuery();

            if (result < 0) return false;

            return true;
        }
    }
}
