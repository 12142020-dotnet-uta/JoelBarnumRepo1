using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class CartViewModel
    {
        public string guitar { get; set; }
        public string strings { get; set; }
        public string Case { get; set; }
        public string amplifier { get; set; }
        public int totalPrice { get; set; }

        public CartViewModel()
        {

        }
    }
}
