

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace P0_JoelBarnum
{
    public class Repository
    {
        static GwDbContext DbContext = new GwDbContext();
        DbSet<Customer> customers = DbContext.customers;
        DbSet<Product> products = DbContext.products;
        DbSet<Order> orderHistory = DbContext.orderHistory;
        DbSet<StoreLocation> storeLocations = DbContext.storeLocations;
        DbSet<Inventory> allInventory = DbContext.allInventory;
        DbSet<PurchasedProducts> purchasedProducts = DbContext.purchasedProducts;

        //static List<Customer> customers = new List<Customer>();
        //static List<Product> products = new List<Product>();
        //static List<Order> orderHistory = new List<Order>();
        //static List<StoreLocation> storeLocations = new List<StoreLocation>();
        //static List<Inventory> allInventory = new List<Inventory>();

    

/// <summary>
/// validaies uniqeness and create customer and adds the customer to the customer List
/// </summary>
    public Customer LoginOrCreateCustomer()
    {
        int choice;
        bool customerCreationBool = false;
        do
        {
            Console.WriteLine("To log in, enter your name. If your new here, we will create a new account for you.");
            Console.Write("Pleas enter your first name: ");
            string fName = Console.ReadLine();
            Console.Write("Pleas enter your last name: ");
            string lName = Console.ReadLine();
            Console.WriteLine($"\nHello {fName} {lName}! Enjoy your shopping experience!\n");
            Customer c1 = new Customer();
            c1 = customers.Where(x => x.firstName == fName && x.lastName == lName).FirstOrDefault();
        if (c1 == null)
        {
            c1 = new Customer(fName,lName);
            customers.Add(c1);
            DbContext.SaveChanges();
            return c1;
        }
        return c1;
        customerCreationBool = true;
        } while (customerCreationBool == false);
        
    }
    //todo if bool is true logic
/// <summary>
/// Returns a list of all products
/// </summary>
/// <returns></returns>    
    public List<Product> GetProducts()
        {
            //Console.WriteLine("---this is just inside of the GetProducts() method");
            List<Product> p = new List<Product>();

            foreach (var item in products)
            {
                
                    p.Add(item);
                
            }
            return p.ToList();
            
        }
        /// <summary>
        /// return 1 product where the string property productName == the string passed into the method
        /// </summary>
        /// <param name="prName"></param>
        /// <returns></returns>
        public Product GetProductByName(string prName)
        {
            Product p = new Product();
            foreach (var item in products)
            {
                if (item.productName == prName)
                {
                    p = item;
                }
            }
                return p;
        }
        /// <summary>
        /// adds an order to the total orderHistory list
        /// </summary>
        /// <param name="item"></param>
        public void AddOrderToHistory(Order item)
        {
            orderHistory.Add(item);
            DbContext.SaveChanges();
            Console.WriteLine(orderHistory.Count());
        }
        /// <summary>
        /// returns all of the order histories of the customer passed into the method
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public List<Order> GetOrderHistory(Customer customer)
        {
            //Console.WriteLine(customer.firstName);
            List<Order> p = new List<Order>();

            foreach (var item in orderHistory)
            {
                if (item.CustomerId == customer.CustomerId)
                {
                    p.Add(item);
                }
            }

            //Console.WriteLine($"---there are {p.Count} orders in the history");
            return p.ToList();
            
        }
/// <summary>
/// Returns a StoreLocation by the string matching the locaitonName
/// </summary>
/// <param name="locationName"></param>
/// <returns></returns>        
        public StoreLocation GetStoreLocations(string  locationName)
        {
            

            foreach (var item in storeLocations)
            {
                if (item.location == locationName)
                {
                    return item;
                }
            }
            return null;
        }
        /// <summary>
        /// returns the storeLocation of the storeId that is passed into the method
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public StoreLocation GetStoreLocationsStringById(Guid  storeId)
        {
            

            foreach (var item in storeLocations)
            {
                if (item.StoreId == storeId)
                {
                    return item;
                }
            }
            return null;
        }
        /// <summary>
        /// return a list of all StoreLocations
        /// </summary>
        /// <returns></returns>
        public List<StoreLocation> GetStoreLocations()
        {
            
            List<StoreLocation> p = new List<StoreLocation>();
            foreach (var item in storeLocations)
            {
                p.Add(item);
            }
            return p;
        }
        /// <summary>
        /// returns a list of all invetntory items
        /// </summary>
        /// <returns></returns>
        public List<Inventory> GetAllInventory()
        {
            List<Inventory> p = new List<Inventory>();
            foreach (var item in allInventory)
            {
                p.Add(item);
            }
            return p.ToList();
        }
        
        /// <summary>
        /// a method to seed the database with porducts, StoerLocations, and Inventories
        /// </summary>
        public void PopulateProducts()
    {
            Product p1 = new Product("Guitar",999.99,"Fender");
            products.Add(p1);
            DbContext.SaveChanges();
            Product p2 = new Product("Case",59.95, "hard case");
            products.Add(p2);
            DbContext.SaveChanges();
            Product p3 = new Product("Amplifier",299.95, "Marshall");
            products.Add(p3);
            DbContext.SaveChanges();
            Product p4 = new Product("Strings",9.95, "D'Aderio");
            products.Add(p4);
            DbContext.SaveChanges();

            

            //populate store locations
            StoreLocation danaPoint = new StoreLocation("Dana Point");
            storeLocations.Add(danaPoint);
            DbContext.SaveChanges();
            StoreLocation Irvine = new StoreLocation("Irvine");
            storeLocations.Add(Irvine);
            DbContext.SaveChanges();
            StoreLocation HuntingtonBeach = new StoreLocation("Huntington Beach");
            storeLocations.Add(HuntingtonBeach);
            DbContext.SaveChanges();
            Console.WriteLine($"--after populating the storeLocations table there are {storeLocations.Count()} store locations");

            //populating Dana Point inventories
            Inventory DanaPointInventory1 = new Inventory(danaPoint.StoreId,p1.ProductId,10,p1.productPrice);
            allInventory.Add(DanaPointInventory1);
            DbContext.SaveChanges();
            Inventory DanaPointInventory2 = new Inventory(danaPoint.StoreId,p2.ProductId,10,p2.productPrice);
            allInventory.Add(DanaPointInventory2);
            DbContext.SaveChanges();
            Inventory DanaPointInventory3 = new Inventory(danaPoint.StoreId,p3.ProductId,10,p3.productPrice);
            allInventory.Add(DanaPointInventory3);
            DbContext.SaveChanges();
            Inventory DanaPointInventory4 = new Inventory(danaPoint.StoreId,p4.ProductId,50,p4.productPrice);
            allInventory.Add(DanaPointInventory4);
            DbContext.SaveChanges();

            //populatin Irvine inventories
            Inventory IrvineInventory1 = new Inventory(Irvine.StoreId,p1.ProductId,10,p1.productPrice);
            allInventory.Add(IrvineInventory1);
            DbContext.SaveChanges();
            Inventory IrvineInventory2 = new Inventory(Irvine.StoreId,p2.ProductId,10,p2.productPrice);
            allInventory.Add(IrvineInventory2);
            DbContext.SaveChanges();
            Inventory IrvineInventory3 = new Inventory(Irvine.StoreId,p3.ProductId,10,p3.productPrice);
            allInventory.Add(IrvineInventory3);
            DbContext.SaveChanges();
            Inventory IrvineInventory4 = new Inventory(Irvine.StoreId,p4.ProductId,50,p4.productPrice);
            allInventory.Add(IrvineInventory4);
            DbContext.SaveChanges();

            //populatin Huntington Beach inventories
            Inventory HuntingtonBeachInventory1 = new Inventory(HuntingtonBeach.StoreId,p1.ProductId,10,p1.productPrice);
            allInventory.Add(HuntingtonBeachInventory1);
            DbContext.SaveChanges();
            Inventory HuntingtonBeachInventory2 = new Inventory(HuntingtonBeach.StoreId,p2.ProductId,10,p2.productPrice);
            allInventory.Add(HuntingtonBeachInventory2);
            DbContext.SaveChanges();
            Inventory HuntingtonBeachInventory3 = new Inventory(HuntingtonBeach.StoreId,p3.ProductId,10,p3.productPrice);
            allInventory.Add(HuntingtonBeachInventory3);
            DbContext.SaveChanges();
            Inventory HuntingtonBeachInventory4 = new Inventory(HuntingtonBeach.StoreId,p4.ProductId,50,p4.productPrice);
            allInventory.Add(HuntingtonBeachInventory4);
            DbContext.SaveChanges();


            // foreach (var item in products)
            // {
            //     Console.WriteLine($"all 4 product ids are {item.ProductId}");
            // }
            
            // Console.WriteLine($"There are {allInventory.Count} total inventories");
            // foreach (var item in allInventory)
            // {
            //     Console.WriteLine($"all of the inventory productIds are {item.productId}");
            // }
            // foreach (var item in allInventory)
            // {
            //     Console.WriteLine(item.storeId);
            // }
    }
        /// <summary>
        /// returns an int of the quantity in the Iventory of the storeId and the product passed into the method
        /// </summary>
        /// <param name="stId"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        internal int GetSecificInventoryQuantity(Guid stId, Product x)
        {
            List<Inventory> StoreIventroy = new List<Inventory>();
                                        
                                        foreach (var item in allInventory)
                                        {
                                            if (item.storeId == stId)
                                            {
                                                StoreIventroy.Add(item);
                                                
                                            }
                                        }
                
                                //Console.WriteLine($"the x productId is {x.ProductId}");
                                foreach (var item in StoreIventroy)
                                {
                                    // Console.WriteLine($"the inventory product id is {item.productId}");
                                    // Console.WriteLine($"the x product id is {x.ProductId}");
                                    if (x.ProductId == item.productId)
                                    {
                                        Inventory currentInventory = item;
                                        int i = item.quantity;
                                         return i;
                                    }

                                }
           return -1;
        }
        /// <summary>
        /// this prints all of the inventory quantities
        /// </summary>
        public void PrintAllInvTotals()
    {
        foreach (var item in allInventory)
        {
            Console.WriteLine(item.quantity);
        }
    }
    /// <summary>
    /// this returns a specific Inventory with the storeId and productId that are passed into the method
    /// </summary>
    /// <param name="stId"></param>
    /// <param name="prId"></param>
    /// <returns></returns>
    public Inventory GetInventoryByStIdPrId(Guid stId, Guid prId)
    {
        Inventory i = new Inventory();
        foreach (var item in allInventory)
        {
            if (item.storeId == stId && item.productId == prId)
            {
                i = item;
                
            }

        }
        return i;
    }
    /// <summary>
        /// returns a list of all of the products for the order id that is passed into the method
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
    public List<Product> GetProductsFromOrder(Guid orderId)
        {
            //Console.WriteLine("---this is just inside of the GetProducts() method");
            List<PurchasedProducts> pur = new List<PurchasedProducts>();

            foreach (var item in purchasedProducts)
            {
                if(item.OrderId == orderId)
                {
                    pur.Add(item);
                }
                
            }
            List<Product> p = new List<Product>();
            foreach (var item in pur)
            {
                try
                {
                    Product prod = GetProductByProdId(item.productId);
                     p.Add(prod);
                }
                catch (System.NullReferenceException e)
                {
                    
                    Console.WriteLine("product is null", e);
                }
                
            }
            return p.ToList();
        }   

        /// <summary>
        /// prints the contents of the orderid that is passed into the method and then prints the product names,
        ///  descriptions, and prices and total cost of the order
        /// </summary>
        /// <param name="orderId"></param>
        public void PrintOrder(Guid orderId)
        {
            
            double total = 0;
            Console.WriteLine($"\nThis is your order:\n");

            List<Product> prodList = GetProductsFromOrder(orderId);


            foreach (var item in prodList)
            {
                
                Console.WriteLine($"{item.productName}-{item.productDescription}  {item.productPrice}");
                total += item.productPrice;
            }

            Order thisOrder = GetOrderById(orderId);
            	
            Console.Write($"Date: {thisOrder.dateTime}. Total = ");
            Console.WriteLine(total.ToString("0,0.00", CultureInfo.InvariantCulture));
        } 
        /// <summary>
        /// returns the product by the productId passed into the method
        /// </summary>
        /// <param name="prId"></param>
        /// <returns></returns>
        public Product GetProductByProdId(Guid prId)
        {
            foreach (var item in products)
            {
                if (item.ProductId == prId)
                {
                    return item;
                }
            }
            return null;
        }

        public Order GetOrderById(Guid orId)
        {
            foreach (var item in orderHistory)
            {
                if (item.OrderId == orId)
                {
                    return item;
                }
            }
            return null;
        }
        public void AddPurchasedProduct(PurchasedProducts pp)
        {
            purchasedProducts.Add(pp);
        }
  }
}