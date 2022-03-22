using CompositionChallange.Entities;
using CompositionChallange.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CompositionChallange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client Data: ");
            Console.Write("Name : ");
            string name = Console.ReadLine();
            Console.Write("Email : ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY) : ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Client client = new Client(name, email, birthDate);
            Console.WriteLine("Enter order data: ");
            Console.Write("Status : ");
            OrderStatus status; 
            Enum.TryParse(Console.ReadLine(),out status);
            Console.Write("How many items to this order?");
            int n = int.Parse(Console.ReadLine());
            Order order = new Order(client,status);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter #" + (i+1) + " item data:");
                Console.Write("Product Name : ");
                string productName = Console.ReadLine();
                Console.Write("Product Price : ");
                double price = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                Console.Write("Quantity : ");
                int quantity = int.Parse(Console.ReadLine());
                Product product = new Product(productName, price);
                order.AddItem(new OrderItem(product,quantity));
            }
            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY: ");
            Console.WriteLine(order);
            Console.ReadKey();

        }
    }
}
