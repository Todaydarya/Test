﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TestEntities : DbContext
    {
        public TestEntities()
            : base("name=TestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<GlassPackages> GlassPackages { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<view_modelcalc> view_modelcalc { get; set; }
        public DbSet<view_orderitem> view_orderitem { get; set; }
        public DbSet<view_orders> view_orders { get; set; }
    }
}
