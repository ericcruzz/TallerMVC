﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TallerMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TallerEntities : DbContext
    {
        public TallerEntities()
            : base("name=TallerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Coche> Coche { get; set; }
        public virtual DbSet<EstadoAuto> EstadoAuto { get; set; }
        public virtual DbSet<HojaServicio> HojaServicio { get; set; }
        public virtual DbSet<Refaccion> Refaccion { get; set; }
        public virtual DbSet<Servicio> Servicio { get; set; }
    }
}
