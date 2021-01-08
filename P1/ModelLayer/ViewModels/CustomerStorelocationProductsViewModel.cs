using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class CustomerStorelocationProductsViewModel
    {
        public Customer customer { get; set; }
        public StoreLocation storeLocation { get; set; }
        public List<Inventory> inventory { get; set; }
        public List<Product> products { get; set; }
        public int quantityToAddToCart { get; set; }
        public string VMproductName { get; set; }


        public CustomerStorelocationProductsViewModel(Customer cust, StoreLocation local, List<Inventory> inv, List<Product> pr, int qty, string productName)
        {
            customer = cust;
            storeLocation = local;
            inventory = inv;
            products = pr;
            quantityToAddToCart = qty;
            this.VMproductName = productName;

        }
        public CustomerStorelocationProductsViewModel()
        {

        }

    }

    
}
