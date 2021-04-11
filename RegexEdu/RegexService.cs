using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RegexEdu
{
    public class RegexService
    {
        public void BasicCharSetMatch_CaseSensitive(string stringToTest)
        {
            // Create a pattern for a word that starts with letter "M"
            // \b => start to match pattern after whitespace or at beginning of checked string
            // [M] => the "character group" to match - CURRENTLY CASE SENSITIVE
            // \w => matches ANY character
            // + => matches a character one or more times
            string pattern = $@"\b[M]\w+";
            // The Regex class needs to be initialiazed with the pattern we want to match to.
            Regex rg = new Regex(pattern);

            // Get all matches, where matches are reported in their own class again.  
            MatchCollection matchedAuthors = rg.Matches(stringToTest);
            // Print all matched items
            Console.WriteLine("Printing results of {0}:\n", nameof(RegexService.BasicCharSetMatch_CaseSensitive));
            for (int count = 0; count < matchedAuthors.Count; count++)
                Console.WriteLine(matchedAuthors[count].Value);
        }

        public void BasicCharSetMatch_CaseInSensitive(string stringToTest)
        {
            string pattern = $@"\b[M]\w+";
            // Initialize the regex class but disable case sentitivity
            Regex rg = new Regex(pattern, RegexOptions.IgnoreCase);

            // Get all matches, where matches are reported in their own class again.  
            MatchCollection matchedAuthors = rg.Matches(stringToTest);
            // Print all matched items
            Console.WriteLine("Printing results of {0}:\n", nameof(RegexService.BasicCharSetMatch_CaseInSensitive));
            for (int count = 0; count < matchedAuthors.Count; count++)
                Console.WriteLine(matchedAuthors[count].Value);
        }

        public string Replace(string input, string patternToReplace, string replacement)
        {
            return Regex.Replace(input, patternToReplace, replacement);
        }

        public void Split()
        {
            // Spilt a string on alphabetic character  
            string azpattern = "[a-z]+";
            string str = "Asd2323b0900c1234Def5678Ghi9012Jklm";
            string[] result = Regex.Split(str, azpattern,
            RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(500));
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write("'{0}'", result[i]);
                if (i < result.Length - 1)
                    Console.Write(", ");
            }
        }

        public void TestProgram()
        {
            Regex r = new Regex(@"^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}");
            // ^ => matching must start at the beginning 
                // \+ => match the character "+"
                // ? => matches the previous element zero or one time.
            // \+? => an optional "+" sign
                // \d => matches any decimal digit
                // {0, 2 } => Matches the previous element at least 0 times, but no more than 2 times. 
            // \d{0,2} thus => zero, one two decimal digits
            // \-? => one or zero "-" signs
            // \d{4,5} thus => four to five decimal digits
            // \-? => one or zero "-" signs
            // \d{5,6} thus => five to six decimal digits



            //class Regex Repesents an immutable regular expression.

            string[] str = { "+91-9678967101", "9678967101", "+91-9678-967101", "+91-96789-67101", "+919678967101", "+99-111111-22222" };
            //Input strings for Match valid mobile number.  
            foreach (string s in str)
            {
                Console.WriteLine("{0} {1} a valid mobile number.", s,
                r.IsMatch(s) ? "is" : "is not");
                //The IsMatch method is used to validate a string or  
                //to ensure that a string conforms to a particular pattern.
            }


        }
    }
}
