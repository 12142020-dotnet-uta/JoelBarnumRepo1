using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using BusinessLogicLayer;
using ModelLayer.ViewModels;

namespace P1_JoelBarnum.Controllers
{
    public class StoreLocationController : Controller
    {
         
        BusinessLogicClass blc = new BusinessLogicClass();
        // GET: StoreLocationController
        public ActionResult Choice(string LocationAbreviation)
        {

            Customer cust = blc.GetLoggedInCustBLC();
            StoreLocation stLocation = blc.getStoreLocationByAbreviation(LocationAbreviation);
            List<Inventory> inv = blc.GetInventoryByStoreId(stLocation.StoreId);
            List<Product> pro = blc.GetAllProducts();
            int qty = 0;
            string VMproductName = "";
            var customerStorelocationProductsViewModel = new CustomerStorelocationProductsViewModel(cust, stLocation, inv, pro, qty, VMproductName);

            return View("StoreLocation2", customerStorelocationProductsViewModel);
            // return View();
        }
        public ActionResult AddToCart(CustomerStorelocationProductsViewModel customerStorelocationProductsViewModel)
        {
            blc.AddItemsToCart(customerStorelocationProductsViewModel);

            StoreLocation local = blc.GetCurrentStoreLocation();
            string locationString = local.location;
            return RedirectToAction("Choice", locationString);
            
        }
        public ActionResult GetCart(int id)
        {
            CartViewModel cartViewModel = new CartViewModel();
            return View("DisplayCart", cartViewModel);
        }

        // GET: StoreLocationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StoreLocationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreLocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreLocationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StoreLocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreLocationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoreLocationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
