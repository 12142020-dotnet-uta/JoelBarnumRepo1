using System;
using System.ComponentModel.DataAnnotations;

namespace P0_JoelBarnum
{
    public class Customer
    {
        

        [Key]
        public Guid CustomerId { get; set; } = Guid.NewGuid();
        
        public string firstName { get; set; }
        public string lastName { get; set; }

        /// <summary>
        /// customer constructor with first and last name prams to be passed in
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        public Customer(string fName, string lName)
        {
            this.firstName = fName;
            this.lastName = lName;
    }
    /// <summary>
    /// empty customer constructor
    /// </summary>
    public Customer(){

    }


    }
    
    
}