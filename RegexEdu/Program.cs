using System;
using System.Text;
using System.Text.RegularExpressions;

namespace RegexEdu
{
    class Program
    {
        static void Main(string[] args)
        {
            // Validate MAC addresses

            string[] MacsToValidate = new string[] { "b9:h3:b1:aa:90:49", "99:11:22:aa:bb:cc", "10:11:a0:b6:555:ff", "57:bc:dd:99:11:77" };
            string MacPattern = "([a-fA-F0-9]{2}:?){6}";
            StringBuilder sb = new StringBuilder();
            foreach (string address in MacsToValidate)
                sb.Append(address + " ");

            Regex MacRegex = new Regex(MacPattern);
            Console.WriteLine("MAC Matches:");
            MatchCollection matchResults = MacRegex.Matches(sb.ToString());
            foreach (Match match in matchResults)
                Console.WriteLine(match.Value);


            Console.WriteLine();

            // Mail validity check

            // Invalid addresses: "mike@technology@miami.edu" (more than one @), 
            // "tom@invalid_domain.io" (no underscores allowed in domain part)
            string[] testMails = { "mike@technology@miami.edu", "max.master.mann@yahoo.com", "jeff@amazon.com", "tim.mayer@example-site.org", "tom@invalid_domain.io" };
            StringBuilder sb2 = new StringBuilder();
            foreach (string mail in testMails)
                sb2.Append(mail + " ");

            string mailPattern = "\\s+([a-zA-Z0-9]+[\\.-]?){1,}@([a-zA-Z0-9]+[\\.-]?){1,}\\.[a-zA-Z]+";
            Regex MailRegex = new Regex(mailPattern);

            var validMailAddresses = MailRegex.Matches(sb2.ToString());
            Console.WriteLine("Valid eMails:");
            foreach (var match in validMailAddresses)
                Console.WriteLine(match.ToString().Trim());
            Console.WriteLine();


            ////////// Split and Replace

            // Split example
            string alphanumbericString = "max2tim3kathy834784237438terry0karl";
            Console.WriteLine("Input: {0}\n", alphanumbericString);
            string numberPattern = "\\d+";
            Regex splitRegex = new Regex(numberPattern);
            Console.WriteLine("Split results:");
            string[] splitText = splitRegex.Split(alphanumbericString);
            foreach (string match in splitText)
                Console.WriteLine(match);
            Console.WriteLine();

            // Repalce example
            // => replace all numbers in the string of the split example
            string replacementStr = "-";
            string replacedString = Regex.Replace(alphanumbericString, numberPattern, replacementStr);
            Console.WriteLine("Replaced String");
            Console.WriteLine(replacedString);

            // Keep window open
            Console.ReadKey();

        }
    }
}
