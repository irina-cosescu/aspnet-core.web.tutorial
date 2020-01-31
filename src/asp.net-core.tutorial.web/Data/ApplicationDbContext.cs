using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace asp.net_core.tutorial.web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); 

            builder.Entity<ProductValue>()
                 .HasKey(table => new
                 {
                     table.ProductId,
                     table.CurrencyId
                 });

            builder.Entity<Currency>().HasData(new Currency
            {
                Id = 1,
                Name = "Romanian New Leu",
                ShortCode = "RON"
            });
            builder.Entity<Currency>().HasData(new Currency
            {
                Id = 2,
                Name = "EU currency",
                ShortCode = "EUR"
            });
            builder.Entity<Currency>().HasData(new Currency
            {
                Id = 3,
                Name = "United States Dolar",
                ShortCode = "USD"
            });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        public DbSet<ProductValue> ProductValues { get; set; }
    }
    public class Currency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(3)]
        public string ShortCode { get; set; }
    }


    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required] [StringLength(5,MinimumLength =3)]
        [Display(Name="")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
    public class ProductValue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CurrencyId { get; set; }

        public virtual Product Product { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
