using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelloFlexOffer
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // I assume that object could be anything, not only numeric, but could be castable into or not e.g "5" is string by castable to numeric 
            ArrayList list =  new ArrayList{"0", 2 ,"flex", "44", "offer", 15, 5.5, 11, 22, "dog" };

            double lo = 2;
            double hi = 5.5;

            DivideCollection(list, lo, hi);

            Console.ReadLine();
        }

        static void DivideCollection(ArrayList collection, double lo, double hi)
        {

            var summary = new List<string>();  // summary collects result of lo and hi divisions 

            foreach (object obj in collection)
            {
                double value;

                if (Double.TryParse(obj.ToString(), out value))  //  check if object is convertable to double
                {
                    string word = (IsDivisable(value, lo, ref summary) ? "Fizz" : "") + (IsDivisable(value, hi, ref summary) ? "Buzz" : "");

                    if (!word.Equals(""))
                        Console.WriteLine(word);
                }
                else
                {
                    summary.Add(obj.ToString() + " - N/A");
                }
            }

            foreach (string line in summary) // output summary result
                Console.WriteLine(line);
        }

        static bool IsDivisable(double numerator, double denominator, ref List<string> summary)
        {
            if (denominator == 0)
            {
                summary.Add(numerator.ToString() + "/0 - N/A");

                return false;
            }
            else
            {
                double result = numerator / denominator;

                summary.Add("Divided: " + numerator.ToString() + " by " + denominator.ToString() );

                return (result == Convert.ToInt64(result));  // if result has not decimal points i.e. rounded value stays the same

            }
        }

    }
}
