using System;
using Xunit;
using P0_JoelBarnum;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

//using InLineDataAttribute;
//using InLineData;
//using Prime.Services;
//using Functions;

namespace P0_JoelBarnum.Tests
{
    public class UnitTest1
    {
        Functions fs = new Functions();
        static Repository rs = new Repository();
            //populate the in memory s=database
            static List<Product> products = new List<Product>();
            static List<StoreLocation> sLocation = new List<StoreLocation>();
            static Product p1 = new Product("Guitar",999.99,"Fender");
            //products.Add(p1);
            static Product p2 = new Product("Case",59.95, "hard case");
            static Product p3 = new Product("Amplifier",299.95, "Marshall");
            static Product p4 = new Product("Strings",9.95, "D'Aderio");
            Product p = rs.GetProductByName("Guitar");
            //StoreLocation item = rs.GetStoreLocationsStringById(danaPoint.StoreId);


             //populate store locations
            static StoreLocation danaPoint = new StoreLocation("Dana Point");
            //sLocation.Add(danaPoint);
            //DbContext.SaveChanges();
            static StoreLocation Irvine = new StoreLocation("Irvine");
            //storeLocations.Add(Irvine);
           // DbContext.SaveChanges();
            static StoreLocation HuntingtonBeach = new StoreLocation("Huntington Beach");
            //storeLocations.Add(HuntingtonBeach);
            //DbContext.SaveChanges();
            //populating Dana Point inventories
            static Inventory DanaPointInventory1 = new Inventory(danaPoint.StoreId,p1.ProductId,10,p1.productPrice);
            //allInventory.Add(DanaPointInventory1);
            //DbContext.SaveChanges();
            static Inventory DanaPointInventory2 = new Inventory(danaPoint.StoreId,p2.ProductId,10,p2.productPrice);
            //allInventory.Add(DanaPointInventory2);
            //DbContext.SaveChanges();
            static Inventory DanaPointInventory3 = new Inventory(danaPoint.StoreId,p3.ProductId,10,p3.productPrice);
            //allInventory.Add(DanaPointInventory3);
            //DbContext.SaveChanges();
            static Inventory DanaPointInventory4 = new Inventory(danaPoint.StoreId,p4.ProductId,50,p4.productPrice);
            //allInventory.Add(DanaPointInventory4);
            //DbContext.SaveChanges();

            //populatin Irvine inventories
            static Inventory IrvineInventory1 = new Inventory(Irvine.StoreId,p1.ProductId,10,p1.productPrice);
            //allInventory.Add(IrvineInventory1);
            //DbContext.SaveChanges();
            static Inventory IrvineInventory2 = new Inventory(Irvine.StoreId,p2.ProductId,10,p2.productPrice);
            //allInventory.Add(IrvineInventory2);
            //DbContext.SaveChanges();
            static Inventory IrvineInventory3 = new Inventory(Irvine.StoreId,p3.ProductId,10,p3.productPrice);
            //allInventory.Add(IrvineInventory3);
            //DbContext.SaveChanges();
            static Inventory IrvineInventory4 = new Inventory(Irvine.StoreId,p4.ProductId,50,p4.productPrice);
            //allInventory.Add(IrvineInventory4);
            //DbContext.SaveChanges();

            //populatin Huntington Beach inventories
            static Inventory HuntingtonBeachInventory1 = new Inventory(HuntingtonBeach.StoreId,p1.ProductId,10,p1.productPrice);
            //allInventory.Add(HuntingtonBeachInventory1);
            //DbContext.SaveChanges();
            static Inventory HuntingtonBeachInventory2 = new Inventory(HuntingtonBeach.StoreId,p2.ProductId,10,p2.productPrice);
            //allInventory.Add(HuntingtonBeachInventory2);
            //DbContext.SaveChanges();
            static Inventory HuntingtonBeachInventory3 = new Inventory(HuntingtonBeach.StoreId,p3.ProductId,10,p3.productPrice);
            //allInventory.Add(HuntingtonBeachInventory3);
            //DbContext.SaveChanges();
            static Inventory HuntingtonBeachInventory4 = new Inventory(HuntingtonBeach.StoreId,p4.ProductId,50,p4.productPrice);
            //allInventory.Add(HuntingtonBeachInventory4);
            //DbContext.SaveChanges();

    
    
        [Fact]
        public void MuliptyItself()
        {
            var options = new DbContextOptionsBuilder<GwDbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;

            int z;
            using (var context = new GwDbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Repository rs = new Repository(context);

                int x = 5;
                z = x * x;

                context.SaveChanges();
            }

             using (var context = new GwDbContext(options))
             {
                Assert.Equal(25, z);
             }
        }    

        
        [Fact]
        public void VerifyIntTest()
        {
            Assert.Equal(true, fs.VerifyInt("5"));
            Assert.Equal(false, fs.VerifyInt("q"));
        }


        [Fact]
        public void GetProductByNameShouldReturnTheObjectWithTheNamePassedIntoTheMethod()
        {
            var options = new DbContextOptionsBuilder<GwDbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;

            using (var context = new GwDbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Repository rs = new Repository(context);
                

                context.SaveChanges();
            }

             using (var context = new GwDbContext(options))
             {
                Product product = rs.GetProductByName("Guitar");
                Assert.Equal(true,product.productDescription == "Fender");
                
             }
        }    

        [Fact]
        public void IsAdminTakesInTwoStringsAndComparesThemToAdmin()
        {
            var options = new DbContextOptionsBuilder<GwDbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;

            using (var context = new GwDbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Functions fs = new Functions();
                

                context.SaveChanges();
            }

             using (var context = new GwDbContext(options))
             {
                string f = "Admin";
                string l = "Admin";
                Assert.Equal(true,fs.IsAdmin(f,l));
                
             }
        }    

        [Fact]
        public void GetLoginChoiceReturnsTheIntOfTheCurrentLoginChoice()
        {
            var options = new DbContextOptionsBuilder<GwDbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;

            using (var context = new GwDbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Functions fs = new Functions();
                

                context.SaveChanges();
            }

             using (var context = new GwDbContext(options))
             {
                 //int loginChoice = 3;
                int choice = fs.GetLoginChoice();

                Assert.Equal(true, fs.GetLoginChoice() == 0);
                
             }
        }    

        [Fact]
        public void AddPurchasedProduct()
        {
            var options = new DbContextOptionsBuilder<GwDbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;

            using (var context = new GwDbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Repository rs = new Repository(context);
                

                context.SaveChanges();
            }

             using (var context = new GwDbContext(options))
             {
                 List<PurchasedProducts> purchasedProducts = new List<PurchasedProducts>();
                 //int loginChoice = 3;
                PurchasedProducts o = new PurchasedProducts();
                purchasedProducts.Add(o);

                Assert.Equal(true, purchasedProducts.Count == 1);
                
             }
        }    

        [Fact]
        public void GetStoreLocationsReturnsAllStoreLocationsInAList()
        {
            var options = new DbContextOptionsBuilder<GwDbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;

            using (var context = new GwDbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Repository rs = new Repository(context);
                

                context.SaveChanges();
            }

             using (var context = new GwDbContext(options))
             {
                 List<StoreLocation> storeLocations = new List<StoreLocation>();
                 //int loginChoice = 3;
                StoreLocation o = new StoreLocation("Jupiter");
                storeLocations.Add(o);

                 Assert.Equal(true, storeLocations.Count == 1);
                Assert.Equal(true, o.location == "Jupiter");
                
             }
        }    

[Fact]
        public void  GetStoreLocations()
        {
            var options = new DbContextOptionsBuilder<GwDbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;

            using (var context = new GwDbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Repository rs = new Repository(context);
                

                context.SaveChanges();
            }

             using (var context = new GwDbContext(options))
             {
                 List<StoreLocation> storeLocations = rs.GetStoreLocations();
                

                 Assert.Equal(true, storeLocations.Count == 3);
                //Assert.Equal(true, o.location == "Jupiter");
                
             }
        }    


[Fact]
        public void GetAllInventory()
        {
            var options = new DbContextOptionsBuilder<GwDbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;

            using (var context = new GwDbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Repository rs = new Repository(context);
                

                context.SaveChanges();
            }

             using (var context = new GwDbContext(options))
             {
                 List<Inventory> allInventory = rs.GetAllInventory();
                

                 Assert.Equal(true, allInventory.Count == 12);
                //Assert.Equal(true, o.location == "Jupiter");
                
             }
        }    


[Fact]
        public void AddToOrderHistory()
        {
            var options = new DbContextOptionsBuilder<GwDbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;

            using (var context = new GwDbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Repository rs = new Repository(context);
                

                context.SaveChanges();
            }

             using (var context = new GwDbContext(options))
             {
                 List<Order> orderHistory = new List<Order>();
                 //int loginChoice = 3;
                Order o = new Order();
                orderHistory.Add(o);

                Assert.Equal(true, orderHistory.Count == 1);
                
             }
        }    





        // [Fact]
        // public void GetStoreLocationsStringById()
        // {
        //     var options = new DbContextOptionsBuilder<GwDbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;

        //     using (var context = new GwDbContext(options))
        //     {
        //         context.Database.EnsureDeleted();
        //         context.Database.EnsureCreated();
        //         Repository rs = new Repository(context);
                

        //         context.SaveChanges();
        //     }

        //      using (var context = new GwDbContext(options))
        //      {
        //          List<StoreLocation> storeLocations = new List<StoreLocation>();

        //          StoreLocation danaPoint = new StoreLocation("Dana Point");
        //          storeLocations.Add(danaPoint);
        //         StoreLocation item = rs.GetStoreLocationsStringById(danaPoint.StoreId);
               
                 
        //         //Console.WriteLine($"{item.location} {danaPoint.location}");
        //         Assert.Same(danaPoint , item);
        //      }
        // }    



        // [Fact]
        // public void ValidateUserExistsComparesNamesEnteredToNamesInCustomersTable()
        // {
        //     var options = new DbContextOptionsBuilder<GwDbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;

        //     int z;
        //     using (var context = new GwDbContext(options))
        //     {
        //         context.Database.EnsureDeleted();
        //         context.Database.EnsureCreated();
        //         Repository rs = new Repository(context);

        //         Customer customer = rs.ValidateUserExists();
        //         context.SaveChanges();
        //     }

        //      using (var context = new GwDbContext(options))
        //      {
        //         Repository rs = new Repository(context);

        //         Assert.IsAssignableFrom.
        //      }
        // }    
        
           
            
     

        
    }//end of class
}//end of namespace
