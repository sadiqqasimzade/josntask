using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using WorkingWithJson.Models;

namespace WorkingWithJson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product cpu = new Product { Id = 1, Name = "Ryzen 5 5600x", Price = 290 };
            Product gpu = new Product { Id = 2, Name = "RTX 3060TI", Price = 999 };
            Product mobo = new Product { Id = 3, Name = "Gigabyte b550 Aourus Pro rev v1", Price = 200 };
            Product ram = new Product { Id = 4, Name = "16gb Corsair Rgb", Price = 150 };
            Product psu = new Product { Id = 5, Name = "750w SeaSonic", Price = 150 };

            OrderItem item1 = new OrderItem { Id = 1, Product = cpu, Count = 1 };
            item1.TotalPrice = cpu.Price * item1.Count;
            OrderItem item2 = new OrderItem { Id = 2, Product = gpu, Count = 1 };
            item2.TotalPrice = gpu.Price * item2.Count;
            OrderItem item3 = new OrderItem { Id = 3, Product = mobo, Count = 1};
            item3.TotalPrice = mobo.Price * item3.Count;
            OrderItem item4 = new OrderItem { Id = 4, Product = ram, Count = 2 };
            item4.TotalPrice = ram.Price * item4.Count;
            OrderItem item5 = new OrderItem { Id = 5, Product = psu, Count = 1 };
            item5.TotalPrice = psu.Price * item5.Count;

            List<OrderItem> orderItems1 = new List<OrderItem>();

            orderItems1.Add(item1);
            orderItems1.Add(item2);
            orderItems1.Add(item3);
            orderItems1.Add(item4);
            orderItems1.Add(item5);

            Order order1 = new Order { Id = 1, OrderItems = orderItems1 };


            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
  

            while (directoryInfo.Name!= typeof(Program).Namespace)
            {
                directoryInfo = directoryInfo.Parent;
            }

            #region Serialize
            var jsonObj = JsonConvert.SerializeObject(order1);
            Console.WriteLine(jsonObj);
            using (StreamWriter sw = new StreamWriter(directoryInfo + @"\json1.json")) 
            sw.WriteLine(jsonObj);
            #endregion


            Console.WriteLine("--------------------------");


            #region DeSerialize
            string result;
            using (StreamReader sr = new StreamReader(directoryInfo + @"\semseddin.json"))
                result = sr.ReadToEnd();

            Order o1 = JsonConvert.DeserializeObject<Order>(result);
            foreach (var element in o1.OrderItems)
            {
                Console.WriteLine("Id:" + element.Id);
                Console.WriteLine("Product:"+element.Product.Name);
                Console.WriteLine("Total Price:" + element.TotalPrice);
            }
            #endregion
        
        }

      
    }
}
