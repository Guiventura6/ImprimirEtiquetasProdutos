using System;
using System.Collections.Generic;
using System.Globalization;
using ImprimirEtiquetas.Entities;

namespace ImprimirEtiquetas
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo CI = CultureInfo.InvariantCulture;
            List<Product> list = new List<Product>();
            
            Console.Write("Enter the number of products: ");
            int nProduct = int.Parse(Console.ReadLine());
            for (int i = 1; i <= nProduct; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Common, used or imported (c/u/i)? ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CI);

                Product product = null; 
                if (ch == 'c')
                {
                    product = new Product(name, price);
                }
                else if (ch == 'u')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime manufactureDate = DateTime.Parse(Console.ReadLine());
                    product = new UsedProduct(name, price, manufactureDate);
                }
                else if (ch == 'i')
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CI);
                    product = new ImportedProduct(name, price, customsFee);
                }
                
                list.Add(product);
            }
            Console.WriteLine();
            Console.WriteLine("PRICE TAGS:");
            foreach (Product prod in list)
            {
                Console.WriteLine(prod.PriceTag());
            }
        }
    }
}
