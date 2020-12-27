using System;
using System.ComponentModel.DataAnnotations;

namespace P0_JoelBarnum
{
    public class Product
    {
       [Key]
        public Guid ProductId { get; set; } = Guid.NewGuid();
        public string productName { get; set; }
        public double productPrice { get; set; }
        public string productDescription { get; set; }
        
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="productPrice"></param>
        /// <param name="productDescription"></param>
        public Product(string productName, double productPrice, string productDescription){
            this.productName = productName;
            this.productPrice = productPrice;
            this.productDescription = productDescription;
        }
        /// <summary>
        /// empty constructor
        /// </summary>
        public Product()
        {

        }
    }
}