using System;

namespace RegexEdu
{
    class Program
    {
        static void Main(string[] args)
        {
            RegexService rx = new();

            // string for testing
            string authors = "Mahesh Chand, Raj Kumar, Mike Gold, Allen O'Neill, Marshal Troll, mini michael";

            // Match a basic character or char set
            //rx.BasicCharSetMatch_CaseSensitive(authors);
            //rx.BasicCharSetMatch_CaseInSensitive(authors);
            //rx.Split();
            rx.TestProgram();
            Console.ReadKey();
        }
    }
}
