using System.Text.Json;
using System.Text.Json.Serialization;

namespace FizzBuzz.Services
{
    public class FizzBuzzService: IFizzBuzzService
    {
        public List<List<string>> ProcessFizzBuzz(object[] objects)
        {
            List<List<string>> fizzBuzzResultList = new List<List<string>>();
            foreach (object obj in objects)
            {
                List<string> currentResult = new List<string>();
                if (obj != null)
                {
                    int number;
                    if (int.TryParse(obj.ToString(), out number) == false)
                    {
                        currentResult.Add("Invalid Item");
                        fizzBuzzResultList.Add(currentResult);
                        continue;
                    }
                    if (number % 3 == 0 && number % 5 == 0)
                    {
                        currentResult.Add("FizzBuzz");
                    }
                    else if (number % 3 == 0)
                    {
                        currentResult.Add("Fizz");
                    }
                    else if (number % 5 == 0)
                    {
                        currentResult.Add("Buzz");
                    }
                    else
                    {
                        currentResult.Add((number / 3).ToString());
                        currentResult.Add((number / 5).ToString());
                    }
                }
                else
                {
                    currentResult.Add("Invalid Item");
                }
                fizzBuzzResultList.Add(currentResult);
            }
            return fizzBuzzResultList;
        }
    }
}
