using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopMartWebsite.Entities
{
    [Table("images")]
    public class ImageProduct
    {
        public int id { get; set; }
        public string url { get; set; }
        public string alt { get; set; }
        //foreign key
        public int productId { get; set; }
        public Product product { get; set; }
    }
}
