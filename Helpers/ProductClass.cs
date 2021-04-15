using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace net.helpers
{
    public class ProductClass
    {
        public string ProductDesc { get; set; } = null;     // Product description 
        public string ProductId { get; set; } = null;   // Product Id
        public string ProductPrice { get; set; } = null;    // Product Price
        public string ProductPhotoURL { get; set; } = null; //Product Photo url for show to user.
        public string ProductTitle { get; set; } = null;    // Product title.

    }
}