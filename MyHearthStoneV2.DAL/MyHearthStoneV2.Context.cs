﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using MyHearthStoneV2.Model;
namespace MyHearthStoneV2.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyHearthStoneV2Context : DbContext
    {
        public MyHearthStoneV2Context()
            : base("name=myhearthstonev2Entities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<hs_game> hs_game { get; set; }
        public virtual DbSet<hs_gamerecord> hs_gamerecord { get; set; }
        public virtual DbSet<hs_usercardgroup> hs_usercardgroup { get; set; }
        public virtual DbSet<hs_users> hs_users { get; set; }
        public virtual DbSet<hs_invitation> hs_invitation { get; set; }
    }
}
