﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbprojectEntities : DbContext
    {
        public dbprojectEntities()
            : base("name=dbprojectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<area> areas { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<city> cities { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<productInShop> productInShops { get; set; }
        public virtual DbSet<history> histories { get; set; }
        public virtual DbSet<listDetail> listDetails { get; set; }
        public virtual DbSet<shop> shops { get; set; }
        public virtual DbSet<askUpdate> askUpdates { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<list> lists { get; set; }
    }
}
