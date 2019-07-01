using LearnCSharp.Database.Commands;
using System;

namespace LearnCSharp.Database
{
    public class DBAccess
    {
        private static readonly Lazy<DBAccess> lazy = new Lazy<DBAccess>(() => new DBAccess());

        public static DBAccess Instance { get { return lazy.Value; } }

        private DBAccess() {}

        public bool Execute(ICommand cmd)
        {
            return cmd.Execute();
        }

        // Commands
        public bool AddAccount(string username, string password)
        {
            return Execute(new AddAccount(username, password));
        }

        public bool CheckAccount(string username, string password)
        {
            return Execute(new CheckAccount(username, password));
        }
    }
}
