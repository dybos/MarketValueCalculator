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
            Price[] prices = GetPrices();
            Position[] positions = GetPositions();

            // Assumptions: in the list of Price, there is only one price for each ProductKey. If the product key would be repeated in Price[], Dictionary would use price which appear first.
            // ToDo: we could add statement which could check also the date of the object. Reason for this solution could be dynamic changing price for our financial product, but in this task we
            // assume that price is constant for

            // new assumptions 02.05 - In the list of Price, there is only one price for each ProductKey on each date.





/*
 






            Dictionary<Position, decimal> marketValuesByPosition = new Dictionary<Position, decimal>();

            foreach (Position position in positions)
            {
                Price price = prices.FirstOrDefault(p => p.ProductKey == position.ProductKey);
                if (price != null)
                {
                    decimal marketValueByPosition = price.Value * position.Amount;
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
       
         */   
           
            var priceValueByDateAndProductKey = prices.ToDictionary(price => $"{price.Date:dd-MM-yyyy}_{price.ProductKey}", price => price.Value);
            var amountValueByDateAndProductKey = positions.ToDictionary(pos => $"{pos.Date:dd-MM-yyyy}_{pos.ProductKey}", pos => pos.Amount);

            foreach ( var productKey in amountValueByDateAndProductKey)
            {
                var amount = productKey.Value;
                var price = priceValueByDateAndProductKey[productKey.Key];
                Console.WriteLine($"Market value:{price * amount} for {productKey.Key}");

            }
            Console.ReadKey();
        }












        private static Position[] GetPositions()
        {
            Position[] positions = new Position[5];
            positions[0] = new Position { Date = DateTime.Today, Amount = 1, ProductKey = "A" };
            positions[1] = new Position { Date = DateTime.Today, Amount = 2, ProductKey = "B" };
            positions[2] = new Position { Date = DateTime.Today, Amount = 3, ProductKey = "C" };
            positions[3] = new Position { Date = DateTime.Today, Amount = 4, ProductKey = "D" };
            positions[4] = new Position { Date = DateTime.Today, Amount = 5, ProductKey = "E" };
            return positions;
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


        static Price[] GetPrices()
        {
            Price[] prices = new Price[5];
            prices[0] = new Price { Date = DateTime.Today, Value = 1, ProductKey = "A" };
            prices[1] = new Price { Date = DateTime.Today, Value = 2, ProductKey = "B" };
            prices[2] = new Price { Date = DateTime.Today, Value = 3, ProductKey = "C" };
            prices[3] = new Price { Date = DateTime.Today, Value = 4, ProductKey = "D" };
            prices[4] = new Price { Date = DateTime.Today, Value = 5, ProductKey = "E" };

            return prices;
            //Random random = new Random();
            //string[] productKeys = Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => ((char)c).ToString()).ToArray();
            //int valueRange = 1000;
            //int numPrices = 4000;

            //Price[] prices = new Price[numPrices];

            //for (int i = 0; i < numPrices; i++)
            //{
            //    DateTime date = DateTime.Today.AddDays(i - numPrices);
            //    for (int j = 0; j < productKeys.Length; j++)
            //         {
            //            decimal value = random.Next(1, valueRange + 1);
            //            string productKey = productKeys[j];
            //            prices[i * productKeys.Length + j] = new Price { Date = date, Value = value, ProductKey = productKey };
            //         }
            //}

            //return prices;
        }

    }
}



