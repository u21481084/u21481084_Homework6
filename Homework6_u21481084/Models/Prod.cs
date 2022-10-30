using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Homework6_u21481084.Models
{
    public class Prod
    {
         [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prod()
        {
            this.order_items = new HashSet<order_items>();
            this.stocks = new HashSet<stock>();
        }
    
        public int product_id { get; set; }
        [Display(Name ="Name")]
        public string product_name { get; set; }
        public int brand_id { get; set; }
        public int category_id { get; set; }
        [Display(Name ="Year")]
        public short model_year { get; set; }
        [Display(Name ="Price")]
        public decimal list_price { get; set; }
        [Display(Name ="Brand")]
        public virtual brand brand { get; set; }
        [Display(Name ="Category")]
        public virtual category category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_items> order_items { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<stock> stocks { get; set; }
      
    }
}