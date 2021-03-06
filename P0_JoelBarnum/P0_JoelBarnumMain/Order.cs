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
        //Repository repository = new Repository();

        /// <summary>
        /// empty order constructor
        /// </summary>
        public Order()
        {

        }

        
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