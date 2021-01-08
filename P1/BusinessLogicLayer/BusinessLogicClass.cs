using System;
using System.Collections.Generic;
using ModelLayer;
using RepositoryLayer;
using ModelLayer.ViewModels;

namespace BusinessLogicLayer
{
    public class BusinessLogicClass
    {
        Repository rs = new Repository();
        //CustomerStorelocationProductsViewModel customerStorelocationProductsViewModel = new ModelLayer.ViewModels.CustomerStorelocationProductsViewModel();
        static Customer loggedInCustBLC = new Customer();
        static List<Inventory> currentStoreInventory = new List<Inventory>();
        static StoreLocation currentStore = new StoreLocation();
        static List<Product> allProducts = new List<Product>();
        static List<Product> currentCartProducts = new List<Product>();
        public void PopulateDb()
        {
            rs.PopulateProducts();
        }

        public Customer ValidateCust(string firstName, string lastName)
        {
            Customer LoggedInCustomer = rs.ValidateUserExists(firstName, lastName);
            loggedInCustBLC = LoggedInCustomer;
            return LoggedInCustomer;
        }
        public Customer GetLoggedInCustBLC()
        {
            return loggedInCustBLC;
        }



        public Customer CreatNewReturnIfExistsBC(string firstName, string lastName)
        {
            Customer c1 = rs.CreateNewOrLoginIfExistsRS(firstName, lastName);
            return c1;
        }

        public void AddItemsToCart(CustomerStorelocationProductsViewModel customerStorelocationProductsViewModel)
        {
            List<Product> allProducts = GetAllProducts();
            List<Product> cartProducts = new List<Product>();
            for (int i = 0; i < customerStorelocationProductsViewModel.quantityToAddToCart; i++)
            {
                foreach (var item in allProducts)
                {
                    if(item.productName == customerStorelocationProductsViewModel.VMproductName)
                    {
                        cartProducts.Add(item);
                    }
                }
            }
            currentCartProducts = cartProducts;
            
        }

        /// <summary>
        /// changes the store abreviation to the locationName and gets the store from the repository
        /// </summary>
        string locationName;
        public StoreLocation getStoreLocationByAbreviation(string storeAbreviation)
        {
            //if (storeAbreviation == "HB")
            //{
            //     locationName = "Huntington Beach";
            //}else if (storeAbreviation == "DP")
            //{
            //    locationName = "Dana Point";
            //}
            //else if (storeAbreviation == "IV")
            //{
            //    locationName = "Irvine";
            //}

          StoreLocation storeLocation = rs.GetStoreLocationsByName(storeAbreviation);
            currentStore = storeLocation;
            return storeLocation;
        }
        
        public List<Inventory> GetInventoryByStoreId(Guid StoreId)
        {
            List<Inventory> storeInventory = new List<Inventory>();
            List<Inventory> allIventory = rs.GetAllInventory();
            foreach(var item in allIventory)
            {
                if(item.storeId == StoreId)
                {
                    storeInventory.Add(item);
                }
            }
            //currentStoreInventory = storeInventory;
            return storeInventory;
        }
        public Customer GetCustById(Guid custId)
        {
            Customer cust = GetCustById(custId);
            return cust;
        }
        /// <summary>
        /// returns a list of all products
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts()
        {
            
            return rs.GetProducts();
        }
        public StoreLocation GetCurrentStoreLocation()
        {
            return currentStore;
        }
    }
}
