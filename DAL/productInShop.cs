//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class productInShop
    {
        public int Id { get; set; }
        public int Productld { get; set; }
        public int ShopId { get; set; }
        public int Price { get; set; }
    
        public virtual product product { get; set; }
        public virtual shop shop { get; set; }
    }
}