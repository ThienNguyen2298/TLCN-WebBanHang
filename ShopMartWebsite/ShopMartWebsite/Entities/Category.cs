using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopMartWebsite.Entities
{
    [Table("category")]
    public class Category
    {
        
        public Category()
        {
            Products = new List<Product>();
        }
        public Category(string Name, bool Status)
        {
            
            name = Name;
            status = Status;
        }
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public bool status { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
    }
}
