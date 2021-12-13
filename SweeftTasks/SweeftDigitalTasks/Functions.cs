using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SweeftDigitalTasks
{
    public static class Functions
    {
        public static bool IsPalindrome(string text)
        {
            char[] temp = text.ToCharArray();

            Array.Reverse(temp);
            string revercsed = new string(temp);
            if (text.ToLower().Equals(revercsed.ToLower()))
                return true;
            

            return false;
        }

        public static int MinSplit(int amount)
        {
            int[] coinsStorage = { 50, 20, 10, 5, 1 };

            int coinCount = 0;
            int reminder = amount;
            for (int i = 0; i < coinsStorage.Length; i++)
            {
                coinCount += reminder / coinsStorage[i];
                reminder %= coinsStorage[i];
            }
            return coinCount;
        }

     

        public static int NoContains(int[] array)
        {
            Array.Sort(array);
            int expectedNumber = 1;
            for (int i = 0; i < array.Length; i++)
            {
                if (expectedNumber == array[i])
                    expectedNumber++;
            }
            return expectedNumber;

        }

        private static int Fib(int n)
        {
            if (n <= 1)
                return n;  
            else
                return Fib(n - 1) + Fib(n - 2);           
        }

        public static int StearsCount(int n)
        {
            return Fib(n + 1);
        }

        public static bool IsProperly(string sequence)
        {
            if (sequence[0] != '(')
                return false;
            

            var open = sequence.Count(x => x == '(');
            var close = sequence.Count(x => x == ')');
            if (open != close)
                return false;

            if (sequence.Contains(")("))
            {
                var temp = sequence;
                while (temp != "")
                {
                    temp = temp.Replace("()", "");
                    if (temp == ")(")
                   
                        return false;
                  
                }
            }

            return true;
        }

        public static async Task<decimal> ExchangeAsync(string currency1,string currency2)
        {

            try
            {
                var r1 = await TakeCurrncy(currency1);
                var r2 = await TakeCurrncy(currency2);

                var result = r1 / r2;
                Console.WriteLine(result);
                return result;
            }
            catch (Exception e)
            {

                
            }
            return 0;
        }

        private static async Task<decimal> TakeCurrncy(string currencyString)
        {
            HttpClient client = new HttpClient();

            var result = await client.GetAsync("http://www.nbg.ge/rss.php");
       
            var text = await result.Content.ReadAsStringAsync();


            XmlDocument doc = new XmlDocument();
            doc.LoadXml(text);

            XmlSerializer serializer = new XmlSerializer(typeof(Rss));
            Rss rss;
            using (XmlReader reader = new XmlNodeReader(doc))
            {
                rss = (Rss)serializer.Deserialize(reader);
            }

            var stringInfo = rss.Channel.Item.Description.Substring(rss.Channel.Item.Description.IndexOf($"<td>{currencyString}"), rss.Channel.Item.Description.IndexOf("</tr>"));
            var array = stringInfo.Split('>');
            var currency = decimal.Parse(array[5].Substring(0, 5));
            return currency;
        }

    }



}
