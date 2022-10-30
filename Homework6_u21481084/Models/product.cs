//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Homework6_u21481084.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
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
