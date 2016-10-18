using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workshop2
{
    class Program
    {
        static void Main(string[] args)
        {

            Model.MemberDatabase database = new Model.MemberDatabase();

            database.initializeDatabase();

            View.ConsoleProgram userInterface = new View.ConsoleProgram();

            userInterface.start(database);
            database.saveDatabase();


        }
    }
}
