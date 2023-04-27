using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task
{
    static class Program
    {
        static void Main()
        {
            Price[] prices = GetPrices();
            Position[] positions = GetPositions();

            // Assumptions: in the list of Price, there is only one price for each ProductKey. If the product key would be repeated in Price[], Dictionary would use price which appear first.
            // ToDo: we could add statement which could check also the date of the object. Reason for this solution could be dynamic changing price for our financial product, but in this task we
            // assume that price is constant for



            Dictionary<Position, decimal> marketValuesByPosition = new Dictionary<Position, decimal>();

            foreach (Position position in positions)
            {
                Price price = prices.FirstOrDefault(p => p.ProductKey == position.ProductKey);
                if (price != null)
                {
                    decimal marketValueByPosition = price.Value * Convert.ToDecimal(position.Amount);
                    marketValuesByPosition[position] = marketValueByPosition;
                }
            }

            foreach (var kvp in marketValuesByPosition)
            {
                Console.WriteLine($"Position {kvp.Key.Amount} of product {kvp.Key.ProductKey} has market value {kvp.Value:C} on date {kvp.Key.Date}");
            }



            
             Dictionary<string, decimal> marketValuesByProduct = new Dictionary<string, decimal>();

             foreach (Position position in positions)
                {
                Price price = prices.FirstOrDefault(p => p.ProductKey == position.ProductKey);
                if (price != null)
                {
                    decimal marketValue = price.Value * position.Amount;

                    if (marketValuesByProduct.ContainsKey(position.ProductKey))
                    {
                         marketValuesByProduct[position.ProductKey] += marketValue;
                    }
                    else
                    {
                        marketValuesByProduct[position.ProductKey] = marketValue;
                    }
                }
            }

        foreach (var kvp in marketValuesByProduct)
        {
            Console.WriteLine($"Product {kvp.Key} has market value {kvp.Value:C}");
        }

            Console.WriteLine("Click any button to exit");
            Console.ReadKey();
        }









        /*private static Position[] GetPositions()
        {
            return new[]
        {
            new Position { Date = DateTime.Today, Amount = 1000, ProductKey = "A" },
            new Position { Date = DateTime.Today, Amount = 50, ProductKey = "B" },
            new Position { Date = DateTime.Today.AddDays(-1), Amount = 20, ProductKey = "C" },
            new Position { Date = DateTime.Today, Amount = 20, ProductKey = "C" }
        };
        }
        */

        private static Position[] GetPositions()
        {
            Random random = new Random();
            string[] productKeys = Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => ((char)c).ToString()).ToArray();
            int dateRange = 100;
            int amountRange = 10000;
            int numPositions = 100000;

            Position[] positions = new Position[numPositions];

            for (int i = 0; i < numPositions; i++)
            {
                int daysOffset = random.Next(-dateRange, dateRange + 1);
                DateTime date = DateTime.Today.AddDays(daysOffset);
                int amount = random.Next(1, amountRange + 1);
                string productKey = productKeys[random.Next(productKeys.Length)];

                positions[i] = new Position { Date = date, Amount = amount, ProductKey = productKey };
            }

            return positions;
        }

        /*private static Price[] GetPrices()
    {

        return new[]
    {

        new Price { Date = DateTime.Today.AddDays(-1), Value = 10.0m, ProductKey = "A" },
        new Price { Date = DateTime.Today.AddDays(-1), Value = 20.0m, ProductKey = "B" },
        new Price { Date = DateTime.Today, Value = 25.0m, ProductKey = "C" },
        new Price { Date = DateTime.Today.AddDays(-1), Value = 15.0m, ProductKey = "A" },
    };
    }
        */
        static Price[] GetPrices()
        {
            Random random = new Random();
            string[] productKeys = Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => ((char)c).ToString()).ToArray();
            int dateRange = 100;
            int valueRange = 1000;
            int numPrices = 1000000;

            Price[] prices = new Price[numPrices];

            for (int i = 0; i < numPrices; i++)
            {
                int daysOffset = random.Next(-dateRange, dateRange + 1);
                DateTime date = DateTime.Today.AddDays(daysOffset);
                decimal value = random.Next(1, valueRange + 1);
                string productKey = productKeys[random.Next(productKeys.Length)];

                prices[i] = new Price { Date = date, Value = value, ProductKey = productKey };
            }

            return prices;
        }

    }
}



