using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P0_JoelBarnum
{
    public class StoreLocation
    {
        [Key]
        public Guid StoreId { get; set; } = Guid.NewGuid();
        public string location { get; set; }
        
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="location"></param>
        public StoreLocation(string location)
        {
            this.location = location;
        }
        /// <summary>
        /// empty storeLocation constructor
        /// </summary>
        public StoreLocation()
        {
        }
        /// <summary>
        /// returns the location string of the StoreLocation
        /// </summary>
        /// <returns></returns>
        public string GetStoreLocations()
        {
            return location;
        }
    }
}