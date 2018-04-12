using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseApp.Data;
using Microsoft.EntityFrameworkCore;
using WarehouseApp.Domain;
using Warehouse.Data;
using System.Threading;

namespace WarehouseApp.Data
{
    class Program
    {

        static void OrderNumber1()
        {
            Console.WriteLine("Starting");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
        static void OrderNumber2()
        {
            Console.WriteLine("Starting");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }

        private static Context context = new Context();
        static void Main(string[] args)
        {
            //Thread On1 = new Thread(OrderNumber1);
            //On1.Start();

            //Thread On2 = new Thread(OrderNumber2);
            //On2.Start();

            //On1.Join();
            //On2.Join();

            //AddProduct();
            // Update();   
            //AddProducts();
            //AddOrder();
            //AddProductsToOrder();
            //AddCustomer();
            //AddCustomerToOrder();
            //AddOrderRow();
            //SelectRawSql();
            //AddProductToOrderObject();
            //DeleteOne();
            //AddCustomerToCustomerInformation();
            //AddCustomerToFavorite();
            

            var result = StaticTask();
            Console.WriteLine("Hej hopp va kul");
            Console.WriteLine(result.Result.Name);
        }

        public static async Task<Customer> StaticTask ()
        {

            var cont = new Context();
            var result = await cont.Customer.FirstAsync<Customer>(); 
            return result;
        }
    

        private static void AddCustomerToFavorite()
        {
            var product = context.Products.Find(2);
            var customer = context.Customer.Find(1);
            var favorite = new Favorite { CustomerId = customer.Id, ProductId = product.Id };
            context.Favorite.Add(favorite);
            context.SaveChanges();

           

        }

        private static void AddCustomerToCustomerInformation()
        {
            var customer = context.Customer.Find(1);
            var customerInformation = new CustomerInformation();
            customerInformation.CustomerId = customer.Id;
            customerInformation.Address = "Säffle";
            context.CustomerInformation.Add(customerInformation);
            context.SaveChanges();
        }

        private static void DeleteOne()
        {
            var product = context.Products.Find(1);
            context.Products.Remove(product);
            context.SaveChanges();

        }

       
        private static void AddProductToOrderObject()
        {
            var product = context.Products.Find(1);
            var order = new Order { Adress = "Göteborg", Product = new List<Product> { product } };
            context.Order.Add(order);
            context.SaveChanges();
        }

            private static void SelectRawSql()
        {
            var context = new Context();
            var order = context.Order.FirstOrDefault();
            var customerId = order.CustomerId;
            var products = order.Product;
            var customer = context.Customer.FirstOrDefault(a => a.Id == customerId);

        }

        private static void AddOrderRow()
        {
            var context = new Context();
            var order = context.Order.First();
            var products = context.Products.ToList();
            foreach (var product in products)
            {
                context.OrderRow.Add(new OrderRow { OrderId = order.Id, ProductId = product.Id });
            }
            context.SaveChanges();
        }

        private static void AddCustomer()
        {
            Customer customer = new Customer();
            customer.Name = "Sara";
            customer.Phonenumber = 0705031292;
            customer.Email = "sara.axelsson@hotmail.com";
            var context = new Context();
            context.Customer.Add(customer);
            context.SaveChanges();

            Customer customer1 = new Customer();
            customer1.Name = "Naomi";
            customer1.Phonenumber = 0752431597;
            customer1.Email = "naomi.larsson@gmail.com";
            var Context = new Context();
            context.Customer.Add(customer1);
            context.SaveChanges();

            Customer customer2 = new Customer();
            customer2.Name = "Jonathan";
            customer2.Phonenumber = 0754201598;
            customer2.Email = "jonte.a@gmail.com";
            var Ccontext = new Context();
            context.Customer.Add(customer2);
            context.SaveChanges();


        }
        private static void AddProductsToOrder()
        {
            List<Product> Products = new List<Product>();
            Products.Add(new Product { Price = 149, Name = "Kjol", Quantity = 1 });
            Products.Add(new Product { Price = 599, Name = "Byxor", Quantity = 1 });
            Products.Add(new Product { Price = 199, Name = "Hatt", Quantity = 1 });

            Order order = new Order();
            order.Product = Products;
            order.Adress = "Stockholm";


            using (Context PO = new Context())
            {

                PO.Order.Add(order);
                PO.SaveChanges();

            }

        }
        private static void AddOrder()
        {
            Order order1 = new Order();
            order1.Adress = "Göteborg";
            order1.CustomerId = 1;
            var context = new Context();
            context.Order.Add(order1);
            context.SaveChanges();
        }
        private static void AddProducts()
        {
            Product myProduct1 = new Product { Name = "Kjol" };
            Product myProduct2 = new Product { Name = "Byxor" };
            List<Product> myProduct = new List<Product> { myProduct1, myProduct2 };
            context.Products.AddRange(myProduct);
            context.SaveChanges();


        }
        private static void AddProduct()
        {

            Product myProduct1 = new Product();
            myProduct1.Name = "Kjol";
            //    myProduct.Id = 1;
            myProduct1.Price = 149;
            myProduct1.Quantity = 10;
            var context = new Context();
            context.Products.Add(myProduct1);
            context.SaveChanges();

            Product myProduct2 = new Product();
            myProduct2.Name = "Byxor";
            myProduct2.Price = 599;
            myProduct2.Quantity = 60;
            var Context = new Context();
            Context.Products.Add(myProduct2);
            Context.SaveChanges();

            Product myProduct3 = new Product();
            myProduct3.Name = "Hatt";
            myProduct3.Price = 199;
            myProduct3.Quantity = 20;
            var Ccontext = new Context();
            context.Products.Add(myProduct3);
            context.SaveChanges();
        }

        private static void Update()
        {
            var context = new Context();
            string TitelStart = "skirt";
            var products = context.Products.Where(p => p.Name.StartsWith(TitelStart)).ToList();
            foreach (var product in products)
            {
                product.Name = "skirt2";
            }

            context.SaveChanges();

        }
    }
}

