using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace P0_JoelBarnum
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; } = Guid.NewGuid();
        public Guid CustomerId { get; set; }
        public Guid StoreId { get; set; }
        public DateTime dateTime { get; set; } = DateTime.Now;
        //public List<Product>  purchasedProducts { get; set; }
        //List<Product> purchasedProducts = new List<Product>();
        Repository repository = new Repository();

        /// <summary>
        /// empty order constructor
        /// </summary>
        public Order()
        {

        }

        /// <summary>
        /// adds a product to the list of products property
        /// </summary>
        /// <param name="item"></param>
        // public void AddPurchasedProduct(Product item)
        // {
        //     purchasedProducts.Add(item);

        // }
        
        // public List<Product> GetProductsFromOrder(Guid orderId)
        // {
        //     //Console.WriteLine("---this is just inside of the GetProducts() method");
        //     List<Product> p = new List<Product>();

        //     foreach (var item in purchasedProducts)
        //     {
                
        //             p.Add(item);
                
        //     }
        //     return p.ToList();
        // }   
        /// <summary>
        /// prints the contents of the orderid that is passed into the method and then prints the product names,
        ///  descriptions, and prices and total cost of the order
        /// </summary>
        /// <param name="orderId"></param>
        // public void PrintOrder(Guid orderId)
        // {
            
        //     double total = 0;
        //     Console.WriteLine($"\nThis is your order:\n");
        //     foreach (var item in purchasedProducts)
        //     {
                
        //         Console.WriteLine($"{item.productName}-{item.productDescription}  {item.productPrice}");
        //         total += item.productPrice;
        //     }
            	
        //     Console.Write($"Date: {dateTime}. Total = ");
        //     Console.WriteLine(total.ToString("0,0.00", CultureInfo.InvariantCulture));
        // } 
        /// <summary>
        /// sets the customer id of the order
        /// </summary>
        /// <param name="currentCustId"></param>
        public void SetCustomerId(Guid currentCustId)
        {
            this.CustomerId = currentCustId;
        }
        /// <summary>
        /// sets the store id of the order
        /// </summary>
        /// <param name="storeId"></param>
        public void SetStoreId(Guid storeId)
        {
            this.StoreId = storeId;
        }
        /// <summary>
        /// sets the order id of an order with a new guid
        /// </summary>
        public void SetOrderId()
        {
            OrderId = Guid.NewGuid();
        }
        /// <summary>
        /// returns the store id Guid
        /// </summary>
        /// <returns></returns>
        public Guid GetStoreIdGuid()
        {
            return StoreId;
        }
        
    }
}