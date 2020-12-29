using System;
using System.Collections.Generic;

namespace P0_JoelBarnum
{
    public class Functions
    {
        Repository rs = new Repository();
        Customer LoggedInCust = new Customer();
        static GwDbContext DbContext = new GwDbContext();

        /// <summary>
        /// returns a boolean value of true if the string passed into the method can be parsed to an int, returns false if not
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Boolean VerifyInt(string x)
        {
            int y;
            bool isInt = int.TryParse(x, out y);
        if (isInt == true)
        {
            return true;
        }
        return false;
        }
/// <summary>
/// Returns a boolean to either quit or login
/// </summary>
/// <returns></returns>
        public bool WelcomeMenu()
        {
            bool userInputIsIntBoolean;
            int loginChoice = 0;
            do
            {
            Console.WriteLine("Welcome to Guitar World!");
            
            Console.WriteLine("Enter: 1 to log in. \nEnter: 2 to exit the program.");
            string userInput = Console.ReadLine();
            userInputIsIntBoolean = VerifyInt(userInput);
            if (userInputIsIntBoolean == true)
            {
                loginChoice = int.Parse(userInput);
                //Console.WriteLine($"the loginChoice was {loginChoice}");
                if (loginChoice <1 || loginChoice >2)
                {
                    Console.WriteLine("Please enter a valid number.");
                }else if (loginChoice == 2)
                {
                    return true;
                }else{
                    return false;
                    }
            }
            }
             while ((userInputIsIntBoolean == false) || (loginChoice < 1) || (loginChoice > 2));
            {
                if (loginChoice == 1)
            {
                //todo call amd make method to enter the login logic
            }else if(loginChoice == 2){
                return true;
            }else{
                return true;
            }
              return true;
            }
            
        }
        /// <summary>
        /// this prints out the store location choice menu, takes in the user input,
        ///  verifies the input is parsable, validates it si a valid choice and returns the int the user chose
        /// </summary>
        /// <returns></returns>
        public int StoreLocationChoiceMenu()
        {
            bool userInputIsIntBoolean;
            int storeChoice = 0;
            do{
            Console.WriteLine("Chose location of Guitar world thet you would like to shop at."+
            "\n\t1: Dana point\n\t"+
            "2: Irvine\n\t"+
            "3: Huntington Beach\n");
            string userInput = Console.ReadLine();
            userInputIsIntBoolean = VerifyInt(userInput);
            storeChoice = 0;
            if (userInputIsIntBoolean == true)
            {
                storeChoice = int.Parse(userInput);
               // Console.WriteLine($"the storeChoice was {storeChoice}");
            } 
            }while ((userInputIsIntBoolean == false) || (storeChoice < 1) || (storeChoice > 4));
            {
                return storeChoice;
            }
                
        }
        /// <summary>
        /// calls the GoToStore Method of the user choice in that is passed into the method 
        /// </summary>
        /// <param name="x"></param>
        public void StoreMenu(int x)
        {
            
               switch (x)
                {
                    case 1:
                        
                        GoToStore("Dana Point");
                        break;
                    case 2:
                        
                        GoToStore("Irvine");
                        break;
                    case 3:
                        
                        GoToStore("Huntington Beach");
                        break;
                    case 4:
                        return;
                       
                    
                } 
        }
        static Inventory currentInventory = new Inventory();
        /// <summary>
        /// this method has the functionality of the store navigaion and purchasing of products
        /// </summary>
        /// <param name="locationName"></param>
        public void GoToStore(string locationName)
        {
            
            StoreLocation currentLocation = rs.GetStoreLocations(locationName);
            Console.WriteLine(currentLocation.location);
            Console.WriteLine($"Hello {LoggedInCust.firstName}! Welcome to the {currentLocation.location} Guitar World\n" );
            bool continueBool = true;
            bool userInputIsIntBoolean;
            int storeChoice = 0;
            
            
            do
            {
                
                List<Product> cart = new List<Product>();
                PrintInStoreMenu();
                string userInput = Console.ReadLine();
                userInputIsIntBoolean = VerifyInt(userInput);
            if (userInputIsIntBoolean == true)
            {
                storeChoice = int.Parse(userInput);
            } 
            
                List<Product> prodList = new List<Product>();
                prodList = rs.GetProducts();
                //Console.WriteLine($"-----there are {prodList.Count} products in the list");
                
                bool done = false;

               switch (storeChoice)
               {
                    case 1:
                    do{
                        if(cart.Count != 0)
                        {
                            Console.WriteLine("Your cart contains:");
                            foreach (var x in cart)
                                    {
                                        Console.WriteLine($"name = {x.productName}, Description = {x.productDescription}, price = {x.productPrice}");
                                    }
                         
                        }
                        Console.WriteLine($"\nHere is the list of store products at {currentLocation.location}\n");

                        foreach (var item in prodList)
                        {
                            int InventoryCount = rs.GetSecificInventoryQuantity(currentLocation.StoreId, item);
                            Console.WriteLine($"name = {item.productName}, Description = {item.productDescription}, price = {item.productPrice}\nQuatity in store inventory = {InventoryCount}");
                        }
                        
                        Console.WriteLine("\tEnter a number from the menue to add an item to your cart.\n"+
                                            "Enter: 1 to chose Guitar.\n"+
                                            "Enter: 2 to chose Case\n"+
                                            "Enter: 3 to chose Amplifier\n"+
                                            "Enter: 4 to chose Strings\n"+
                                            "Enter: back to go back to the store menu\n "+
                                            "Enter: checkout to place your order");
                        string productChoice = Console.ReadLine();
                        Console.WriteLine($"your choice was {productChoice}");
                        if(productChoice == "back")
                        {
                            foreach (var item in cart)
                            {
                                Inventory inv = rs.GetInventoryByStIdPrId(currentLocation.StoreId,item.ProductId);
                                            inv.incrementInventory();
                                            DbContext.SaveChanges();
                            }
                            cart = new List<Product>();
                            done = true;
                        }else if (productChoice != null && productChoice != "checkout")
                        {
                                    if (productChoice == "1")
                                    {
                                        productChoice = "Guitar";
                                    }else if (productChoice == "2")
                                    {
                                        productChoice = "Case";
                                    }else if (productChoice == "3")
                                    {
                                        productChoice = "Amplifier";
                                    }else if (productChoice == "4")
                                    {
                                        productChoice = "Strings";
                                    }
                            Product chosenProduct = new Product();
                            foreach (var item in prodList)
                            {
                                //Console.WriteLine($" 2nd name = {item.productName}, Description = {item.productDescription}, price = {item.productPrice}");
                                if(item.productName == productChoice)
                                {
                                    bool validInput = false; 
                                    int quantity = 0;
                                    do{
                                    Console.WriteLine("Enter valid item quantity number:");
                                    string quantityInput = Console.ReadLine();
                                    bool isInt = VerifyInt(quantityInput);
                                    if (isInt == false)
                                    {
                                       Console.WriteLine("input is not an int");
                                    }
                                    if (isInt == true)
                                    {
                                        quantity = int.Parse(quantityInput);
                                        //add method to get available inventory quantity
                                        

                                        Console.WriteLine($"quatity = {quantity}");
                                    }
                                    int invQty = rs.GetSecificInventoryQuantity(currentLocation.StoreId, item);
                                    Console.WriteLine($"the inventory available is = {invQty}");
                                    if (invQty == 0)
                                    {
                                        break;
                                    }else if((productChoice == "Guitar" || productChoice == "Case" || productChoice == "Amplifier") && (quantity > 1)) 
                                    {
                                        Console.WriteLine("That quantity is unusual.\nYou are only aloud to add 1 of those to your cart at a time");
                                        break;
                                    }
                                    if (quantity > 0  && quantity <= invQty)//add > inventory number
                                    {
                                            //Console.WriteLine($"made it through validation quantity = {quantity}");
                                            validInput = true;
                                    
                                        for (int i = 1; i <= quantity; i++)
                                        {
                                            cart.Add(item);
                                            Inventory inv = rs.GetInventoryByStIdPrId(currentLocation.StoreId,item.ProductId);
                                            inv.decrementInventory();
                                            DbContext.SaveChanges();
                                            
                                        }
                                            
                                    }
                                    }while((validInput == false));
                                    
                                        
                                    
                                }
                            }  
                        }
                        else if(productChoice == "checkout")
                        {
                                        Order newOrder = new Order();
                                        newOrder.SetCustomerId(LoggedInCust.CustomerId);
                                        newOrder.SetStoreId(currentLocation.StoreId);
                                        
                                        List<Inventory> allInvList = rs.GetAllInventory();
                                        List<Inventory> StoreIventroy = new List<Inventory>();
                                        
                                        foreach (var item in allInvList)
                                        {
                                            if (item.storeId == currentLocation.StoreId)
                                            {
                                                StoreIventroy.Add(item);
                                                
                                            }
                                        }
                                    //Console.WriteLine($"there are {StoreIventroy.Count} invetntory posibilities");

                            foreach (var x in cart)
                            {
                                //Console.WriteLine($"the x productId is {x.ProductId}");
                                // foreach (var item in StoreIventroy)
                                // {
                                //     // Console.WriteLine($"the inventory product id is {item.productId}");
                                //     // Console.WriteLine($"the x product id is {x.ProductId}");
                                //     if (x.ProductId == item.productId)
                                //     {
                                //         item.decrementInventory();
                                //         currentInventory = item;
                                        
                                //     }
                                // }
                                PurchasedProducts purchasedProducts = new PurchasedProducts(newOrder.OrderId, x.ProductId);
                                rs.AddPurchasedProduct(purchasedProducts);
                                DbContext.SaveChanges();
                                //newOrder.AddPurchasedProduct(x);

                            } 
                                //rs.PrintAllInvTotals();
                                        rs.AddOrderToHistory(newOrder);
                                        DbContext.SaveChanges();
                                        //Console.WriteLine($"At the {currentLocation} store your order is:");
                                        rs.PrintOrder(newOrder.OrderId);
                                    done = true;
                        }
                    }while(done == false); 
                        break;
                    case 2:
                        List<Order> OrderHistory = new List<Order>();
                        OrderHistory = rs.GetOrderHistory(LoggedInCust);
                        //Console.WriteLine($"OrderHistorey list has {OrderHistory.Count} in it");
                        Console.WriteLine($"Your purchase history is:");

                        List<Order> thisLocationOderAndCustHistory = new List<Order>();
                            foreach (var item in OrderHistory)
                            {
                                if (item.StoreId == currentLocation.StoreId)
                                {
                                    thisLocationOderAndCustHistory.Add(item);
                                }
                            }

                        if((OrderHistory.Count == 0) || (thisLocationOderAndCustHistory.Count == 0))
                        {
                            Console.WriteLine("you have no purchase history at this location");
                        }else 
                        {
                            foreach (var item in thisLocationOderAndCustHistory)
                            {
                                //Guid g = item.StoreId;
                                //StoreLocation x = rs.GetStoreLocationsStringById(g); 
                                string locationString = currentLocation.location;
                                Console.WriteLine($"At the {locationString} location ");
                                rs.PrintOrder(item.OrderId);
                            }
                        }


                        break;
                    case 3:
                    
                        //List<Order> OrderHistory = new List<Order>();
                        OrderHistory = rs.GetOrderHistory(LoggedInCust);
                        //Console.WriteLine($"OrderHistorey list has {OrderHistory.Count} in it");
                        Console.WriteLine($"Your complete purchase history is:");
                        if(OrderHistory.Count == 0)
                        {
                            Console.WriteLine("you have no purchase history");
                        }
                        //List<Order> thisLocationOderAndCustHistory = new List<Order>();
                            foreach (var item in OrderHistory)
                            {
                                Guid stGuidFromOrder = item.GetStoreIdGuid();
                                StoreLocation loc = rs.GetStoreLocationsStringById(stGuidFromOrder) ;
                                string locationString = loc.location;
                                Console.WriteLine($"At the {locationString} location ");
                                rs.PrintOrder(item.OrderId);
                            }
                        break;
                    case 4:
                        return;
                    }
                 
                
            }while (continueBool == true);
            {
            }
        }
        /// <summary>
        /// prints the store menue to view products and purchase histories, and log out option
        /// </summary>
        public void PrintInStoreMenu()
        {
            Console.WriteLine("chose an option from the in store menu\n\tIN STORE MENU\n"+
            "\t1: View store products\n"+// todo write a do while loop to add products to the cart while in case 1
            "\t2: View your purchase history at this location\n"+
            "\t3: View your complete purchase history\n"+
            "\t4: Log out");

        }
        /// <summary>
        /// prints out the Customer id 
        /// </summary>
        /// <param name="c"></param>
        public void AddCustToRsLoggedInCust(Customer c)
        {
            LoggedInCust = c;
            Console.WriteLine(LoggedInCust.CustomerId);
        }
        
    }// class Functions end
     
}// namespace end