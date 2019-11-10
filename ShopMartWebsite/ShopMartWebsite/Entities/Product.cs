using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopMartWebsite.Entities
{
    [Table("product")]
    public class Product
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public bool status { get; set; }
        public Size? size { get; set; }
        public Color? color { get; set; }
        //foreign key
        public int? categoryId { get; set; }
        public Category category { get; set; }

        public ICollection<ImageProduct> Images { get; set; }
    }
}
