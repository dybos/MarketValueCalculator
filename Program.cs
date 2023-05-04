using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarketValueCalculator
{
    static class Program
    {
        static void Main()
        {
            try
            {
                Price[] prices = GetPrices();
                Position[] positions = GetPositions();

                // Assumptions: in the list of Price, there is only one price for each ProductKey. For each pair in Date and ProductKey in Position there is one same pair in Price.
                // ToDo: we could add statement which could check also the date of the object. Reason for this solution could be dynamic changing price for our financial product, but in this task we
                // assume that price is constant for

                // new assumptions 02.05 - In the list of Price, there is only one price for each ProductKey on each date.

                var keyToPriceValues = prices.ToDictionary(price => $"{price.Date:dd-MM-yyyy}_{price.ProductKey}", price => price.Value);
                var keyToPositionAmounts = positions.ToDictionary(pos => $"{pos.Date:dd-MM-yyyy}_{pos.ProductKey}", pos => pos.Amount);

                foreach (var entry in keyToPositionAmounts)
                {
                    var amount = entry.Value;
                    var price = keyToPriceValues[entry.Key];
                    Console.WriteLine($"Market value:{price * amount} for {entry.Key}");

                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred:{ex.Message}");
                Console.ReadKey();
            }
        }

        private static Position[] GetPositions()
        {
            Position[] positions = new Position[]
            {
                new Position { Date = DateTime.Today, Amount = 1, ProductKey = "A" },
                new Position { Date = DateTime.Today.AddDays(-1), Amount = 2, ProductKey = "B" },
                new Position { Date = DateTime.Today.AddDays(-2), Amount = 3, ProductKey = "C" },
                new Position { Date = DateTime.Today.AddDays(-3), Amount = 4, ProductKey = "D" },
                new Position { Date = DateTime.Today.AddDays(-4), Amount = 5, ProductKey = "E" },
            };
            return positions;


            // TODO code for creating the data not working properly - appears some nulls in value, have to investigate or re-write.

            //Random random = new Random();
            //string[] productKeys = Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => ((char)c).ToString()).ToArray();
            //int dateRange = 100;
            //int amountRange = 10000;
            //int numPositions = 1000;

            //Position[] positions = new Position[numPositions];

            //for (int i = 0; i < numPositions; i++)
            //{
            //    DateTime date = DateTime.Today.AddDays(i - numPositions);
            //    int amount = random.Next(1, amountRange + 1);
            //    string productKey = productKeys[random.Next(productKeys.Length)];

            //    positions[i] = new Position { Date = date, Amount = amount, ProductKey = productKey };
            //}

            //return positions;
        }


        private static Price[] GetPrices()
        {
            Price[] prices = new Price[]
            {
                new Price { Date = DateTime.Today, Value = 1, ProductKey = "A" },
                new Price { Date = DateTime.Today.AddDays(-1), Value = 2, ProductKey = "B" },
                new Price { Date = DateTime.Today.AddDays(-2), Value = 3, ProductKey = "C" },
                new Price { Date = DateTime.Today.AddDays(-3), Value = 4, ProductKey = "D" },
                new Price { Date = DateTime.Today.AddDays(-4), Value = 5, ProductKey = "E" },
            };


            return prices;

        // TODO code for creating the data not working properly - appears some nulls in value, have to investigate or re-write.
        
            //    string[] productKeys = Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => ((char)c).ToString()).ToArray();
        //    int daysCount = 4000;

        //    var prices = new Price[daysCount * productKeys.Length];
             
        //    for (int i = 0; i < daysCount - 1; i++)
        //    {
        //        DateTime date = DateTime.Today.AddDays(-1*i);
        //        var pricesForDay = GetPricesForDay(productKeys, date);

        //        for (int j = 0; j < pricesForDay.Length - 1; j++)
        //        {
        //            prices[i * pricesForDay.Length + j] = pricesForDay[j];
        //        }

        //    }

        //    return prices;
        }


    }
}



