using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();

            //Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise5();
            //Exercise6();
            //Exercise7();
            //Exercise8();
            //Exercise9();
            //Exercise10();
            //Exercise11();
            //Exercise12();
            //Exercise13();
            //Exercise14();
            //Exercise15();
            //Exercise16();
            //Exercise17();
            //Exercise18();
            //Exercise19();
            //Exercise20();
            //Exercise21();
            //Exercise22();
            //Exercise23();
            //Exercise24();
            //Exercise25();
            //Exercise26();
            //Exercise27();
            //Exercise28();
            //Exercise29();
            Exercise30();
            //Exercise31();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            var allProducts = DataLoader.LoadProducts();

            var filtered = allProducts.Where(p => p.UnitsInStock == 0);

            PrintProductInformation(filtered);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            var allProducts = DataLoader.LoadProducts();

            var threeDollarInStock = allProducts.Where(p => p.UnitsInStock > 0).Where(m => m.UnitPrice > 3m);

            PrintProductInformation(threeDollarInStock);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            var washingtonCustomers = from c in DataLoader.LoadCustomers()
                                      where c.Region == "WA"
                                      select c;

            PrintCustomerInformation(washingtonCustomers);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            var allProducts = DataLoader.LoadProducts();
            var productNames = from p in allProducts
                               select new
                               {
                                   p.ProductName
                               };
            foreach (var name in productNames)
            {
                Console.WriteLine(name);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            var allProducts = DataLoader.LoadProducts();
            var adjustedPrices = from p in allProducts
                                 select new
                                 {
                                     p.ProductID,
                                     p.ProductName,
                                     p.Category,
                                     UnitPrice = p.UnitPrice + (p.UnitPrice / 4),
                                     p.UnitsInStock
                                 };

            foreach (var product in adjustedPrices)
            {
                Console.WriteLine(product);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            var allProducts = DataLoader.LoadProducts();
            var productsInUpper = from p in allProducts
                                  select new
                                  {
                                      ProductName = p.ProductName.ToUpper(),
                                      Category = p.Category.ToUpper()
                                  };
            foreach (var product in productsInUpper)
            {
                Console.WriteLine(product);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// </summary>
        static void Exercise7()
        {
            var allProducts = DataLoader.LoadProducts();

            var withReOrder = from p in allProducts
                          select new
                          {
                              p,
                              ReOrder = p.UnitsInStock < 3
                          };

            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var order in withReOrder)
            {

                Console.WriteLine(line, order.p.ProductID, order.p.ProductName, order.p.Category,
                    order.p.UnitPrice, order.p.UnitsInStock + " " + order.ReOrder);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            var allProducts = DataLoader.LoadProducts();

            var withStockValue = from p in allProducts
                                 select new
                                 {
                                     p,
                                     StockValue = p.UnitPrice * p.UnitsInStock
                                 };

            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5,12}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "Stock Price");
            Console.WriteLine("====================================================================================");

            foreach (var o in withStockValue)
            {
                Console.WriteLine(line, o.p.ProductID, o.p.ProductName, o.p.Category,
                    o.p.UnitPrice, o.p.UnitsInStock, o.StockValue);
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            var onlyEvens = DataLoader.NumbersA.Where(n => n % 2 == 0);

            foreach(int n in onlyEvens)
            {
                Console.WriteLine(n);
            }
            
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            var customersWithOrders = DataLoader.LoadCustomers().Where(c => c.Orders.Length > 0);

            var brokeCustomers = from c in customersWithOrders
                                 where c.Orders.Max(o => o.Total < 500M)
                                 select c;

            PrintCustomerInformation(brokeCustomers);
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            var firstThreeOdds = DataLoader.NumbersC.Where(n => n % 2 == 1).Take(3);

            foreach (int o in firstThreeOdds)
            {
                Console.WriteLine(o);
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            var nobodyLikesTheFirst3 = DataLoader.NumbersB.Skip(3);

            foreach (int i in nobodyLikesTheFirst3)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            var washingtonOrders = DataLoader.LoadCustomers().Where(c => c.Region == "WA");

            foreach (Customer c in washingtonOrders)
            {
                string company = c.CompanyName;
                Order order = c.Orders.Last();
                Console.WriteLine(company + ", " + order.OrderID + ", " + order.OrderDate + ", " + order.Total);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            var lessThanSix = DataLoader.NumbersC.TakeWhile(n => n < 6);

            foreach (int n in lessThanSix)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            var allNumbers = DataLoader.NumbersC;

            var afterFirstDivisibleByThree = allNumbers.SkipWhile(n => n % 3 != 0);

            foreach (int n in afterFirstDivisibleByThree)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            var allProducts = DataLoader.LoadProducts();

            var alphabeticalOrder = allProducts.OrderBy(p => p.ProductName);

            PrintProductInformation(alphabeticalOrder);
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            var allProducts = DataLoader.LoadProducts();

            var descendingUnitsInStock = allProducts.OrderByDescending(p => p.UnitsInStock);

            PrintProductInformation(descendingUnitsInStock);
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            var allProducts = DataLoader.LoadProducts();

            var orderByCategoryByPrice = allProducts.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);

            PrintProductInformation(orderByCategoryByPrice);
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            var numbersB = DataLoader.NumbersB.Reverse();

            foreach (int n in numbersB)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            var allCategories = from p in DataLoader.LoadProducts()
                             orderby p.Category, p.ProductName
                             group p by p.Category;

            foreach (var c in allCategories)
            {
                Console.WriteLine(c.Key);
                Console.WriteLine("----------------------------------");
                foreach (var p in c)
                {
                    Console.WriteLine(p.ProductName);
                }
                Console.WriteLine("__________________________________");
            }
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {
            var allCustomers = DataLoader.LoadCustomers();

            var allOrders = allCustomers.SelectMany(p => p.Orders);

            string decider = "";

            foreach (Customer c in allCustomers)
            {
                Console.WriteLine(c.CompanyName);
                foreach (Order o in allOrders)
                {
                    if (c.Orders.Contains(o))
                    {
                        if (o.OrderDate.Year.ToString() != decider)
                        {
                            Console.WriteLine(o.OrderDate.Year);
                            decider = o.OrderDate.Year.ToString();
                        }
                        Console.WriteLine("    " + o.OrderDate.Month + " - " + o.Total);
                    }
                }
                decider = "";
            }
        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            var allCategories = DataLoader.LoadProducts().OrderBy(c => c.Category).GroupBy(p => p.Category);

            foreach (var category in allCategories)
            {
                Console.WriteLine(category.Key);
            }
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            var allProducts = DataLoader.LoadProducts();

            var productQuery = from p in allProducts
                               where p.ProductID == 789
                               select p;

            if (productQuery.Count() > 0)
            {
                Console.WriteLine("Yes it does.");
            }
            else
            {
                Console.WriteLine("No it does not.");
            }
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            var allCategories = DataLoader.LoadProducts().GroupBy(p => p.Category);

            var outOfStockCategories = from c in allCategories
                                       where c.Any(p => p.UnitsInStock == 0)
                                       select c;

            foreach (var c in outOfStockCategories)
            {
                Console.WriteLine(c.Key);
            }
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            var allProducts = DataLoader.LoadProducts().GroupBy(p => p.Category);

            var allCategories = allProducts.Where(c => c.All(p => p.UnitsInStock != 0));

            foreach (var category in allCategories)
            {
                Console.WriteLine(category.Key);
            }
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            var numbersA = DataLoader.NumbersA;

            var count = numbersA.Where(n => n % 2 == 1).Count();

            Console.WriteLine(count);
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            var allCustomers = DataLoader.LoadCustomers();

            var theStuff = from c in allCustomers
                           select new
                           {
                               c.CustomerID,
                               OrderCount = c.Orders.Length
                           };

            foreach (var stuff in theStuff)
            {
                Console.WriteLine(stuff);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            var allCategories = DataLoader.LoadProducts().GroupBy(p => p.Category);

            var theStuff = from c in allCategories
                           select new
                           {
                               Category = c.Key,
                               Count = c.Count()
                           };

            List<string> list = new List<string>();
            
            foreach (var stuff in theStuff)
            {
                list.Add(stuff.ToString());
            }

            foreach (string stuff in list)
            {
                Console.WriteLine(stuff);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            var allCategories = DataLoader.LoadProducts().GroupBy(p => p.Category);

            var theStuff = from g in allCategories
                           select new
                           {
                               Category = g.Key,
                               Count = g.Sum(p => p.UnitsInStock)
                           };

            List<string> allTheStuffInTheStuff = new List<string>();

            foreach (var stuff in theStuff)
            {
                allTheStuffInTheStuff.Add(stuff.ToString());
            }

            foreach (string stuff in allTheStuffInTheStuff)
            {
                Console.WriteLine(stuff);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            var allCategories = DataLoader.LoadProducts().GroupBy(p => p.Category);
            var theStuff = from g in allCategories
                           orderby g.Min(p => p.UnitPrice)
                           select new
                           {
                               Category = g.Key,
                               LowestPricedItem = g.OrderBy(p => p.UnitPrice).First()
                           };

            List<string> allTheStuffYouWant = new List<string>();

            foreach (var stuff in theStuff)
            {
                allTheStuffYouWant.Add(stuff.Category + " : " + stuff.LowestPricedItem.ProductID 
                    + " : " + stuff.LowestPricedItem.ProductName + " : " + stuff.LowestPricedItem.UnitPrice 
                    + " : " + stuff.LowestPricedItem.UnitsInStock);
            }

            foreach (string str in allTheStuffYouWant)
            {
                Console.WriteLine(str);
            }
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            var allProducts = DataLoader.LoadProducts();
            var allCategories = allProducts.GroupBy(p => p.Category);
            var results = allCategories.OrderByDescending(c => c.Average(p => p.UnitPrice)).Take(3);

            foreach (var result in results)
            {
                Console.WriteLine(result.Key);
            }
        }
    }
}
