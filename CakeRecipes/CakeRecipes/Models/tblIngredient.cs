//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CakeRecipes.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblIngredient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblIngredient()
        {
            this.tblIngredientAmounts = new HashSet<tblIngredientAmount>();
            this.tblIngredientStorages = new HashSet<tblIngredientStorage>();
            this.tblShoppingBaskets = new HashSet<tblShoppingBasket>();
        }
    
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblIngredientAmount> tblIngredientAmounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblIngredientStorage> tblIngredientStorages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblShoppingBasket> tblShoppingBaskets { get; set; }
    }
}
