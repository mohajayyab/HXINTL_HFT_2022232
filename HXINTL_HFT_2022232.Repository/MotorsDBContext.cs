using HXINTL_HFT_2022232.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXINTL_HFT_2022232.Repository
{
    public class MotorsDBContext: DbContext
    {
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Models.Motorcycle> Motors { get; set; }
        public virtual DbSet<RentMotorcycle> RentMotors { get; set; }

        public MotorsDBContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {

                builder.UseLazyLoadingProxies();
                builder.UseInMemoryDatabase("Motor");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Models.Motorcycle>(entity =>
            {
                entity.HasOne(Motorcycle => Motorcycle.Brand)
                    .WithMany(Brand => Brand.Motorcycle)
                    .HasForeignKey(Motorcycle => Motorcycle.Brand_id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<RentMotorcycle>(entity =>
            {
                entity.HasOne(RentMotorcycle => RentMotorcycle.Motorcycle)
                    .WithMany(Motorcycle => Motorcycle.RentMotorcycle)
                    .HasForeignKey(RentMotorcycle => RentMotorcycle.Motorcycle_id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            Brand Brand1 = new Brand() { Id = 1, BrandName = "BMW", BrandCountry = "Japan", BrandYear = 1909 };
            Brand Brand2 = new Brand() { Id = 2, BrandName = "Toyota", BrandCountry = "Japan", BrandYear = 1909 };
            Brand Brand3 = new Brand() { Id = 3, BrandName = "Ferrari", BrandCountry = "Italy", BrandYear = 1941 };
            Brand Brand4 = new Brand() { Id = 4, BrandName = "Porsche", BrandCountry = "Germany", BrandYear = 1931 };

            Models.Motorcycle Motorcycle1 = new Models.Motorcycle() { Id = 1, MotorcycleName = "BMW Motorcycle1", MotorcycleType = "Swift", MotorcyclePrice = 1, NewOrUsed = "new", MotorcycleReleaseYear = 2000, MotorcycleColor = "black", MotorcycleSeatNumber = 4, IsLeftWheel = true, FuelType = "diesel", IsElectricMotorcycle = true, Brand_id = 1 };
            Models.Motorcycle Motorcycle2 = new Models.Motorcycle() { Id = 2, MotorcycleName = "BMW Motorcycle2", MotorcycleType = "Ignis", MotorcyclePrice = 3, NewOrUsed = "new", MotorcycleReleaseYear = 2005, MotorcycleColor = "white", MotorcycleSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricMotorcycle = true, Brand_id = 1 };
            Models.Motorcycle Motorcycle3 = new Models.Motorcycle() { Id = 3, MotorcycleName = "BMW Motorcycle3", MotorcycleType = "Swift", MotorcyclePrice = 15, NewOrUsed = "used", MotorcycleReleaseYear = 2020, MotorcycleColor = "red", MotorcycleSeatNumber = 6, IsLeftWheel = false, FuelType = "gasoline", IsElectricMotorcycle = false, Brand_id = 1 };
            Models.Motorcycle Motorcycle4 = new Models.Motorcycle() { Id = 4, MotorcycleName = "BMW Motorcycle4", MotorcycleType = "Vitara", MotorcyclePrice = 1, NewOrUsed = "used", MotorcycleReleaseYear = 1990, MotorcycleColor = "green", MotorcycleSeatNumber = 4, IsLeftWheel = false, FuelType = "diesel", IsElectricMotorcycle = false, Brand_id = 1 };
            Models.Motorcycle Motorcycle5 = new Models.Motorcycle() { Id = 5, MotorcycleName = "Toyota Motorcycle1", MotorcycleType = "Yaris", MotorcyclePrice = 4, NewOrUsed = "new", MotorcycleReleaseYear = 2020, MotorcycleColor = "red", MotorcycleSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricMotorcycle = true, Brand_id = 2 };
            Models.Motorcycle Motorcycle6 = new Models.Motorcycle() { Id = 6, MotorcycleName = "Toyota Motorcycle2", MotorcycleType = "Corolla", MotorcyclePrice = 1, NewOrUsed = "used", MotorcycleReleaseYear = 2000, MotorcycleColor = "green", MotorcycleSeatNumber = 3, IsLeftWheel = true, FuelType = "diesel", IsElectricMotorcycle = false, Brand_id = 2 };
            Models.Motorcycle Motorcycle7 = new Models.Motorcycle() { Id = 7, MotorcycleName = "Toyota Motorcycle3", MotorcycleType = "Yaris", MotorcyclePrice = 2, NewOrUsed = "new", MotorcycleReleaseYear = 2010, MotorcycleColor = "white", MotorcycleSeatNumber = 4, IsLeftWheel = true, FuelType = "diesel", IsElectricMotorcycle = false, Brand_id = 2 };
            Models.Motorcycle Motorcycle8 = new Models.Motorcycle() { Id = 8, MotorcycleName = "Toyota Motorcycle4", MotorcycleType = "Sienna", MotorcyclePrice = 10, NewOrUsed = "new", MotorcycleReleaseYear = 2017, MotorcycleColor = "black", MotorcycleSeatNumber = 4, IsLeftWheel = true, FuelType = "gasoline", IsElectricMotorcycle = true, Brand_id = 2 };
            Models.Motorcycle Motorcycle9 = new Models.Motorcycle() { Id = 9, MotorcycleName = "Ferrari Motorcycle1", MotorcycleType = "Ferrari 488", MotorcyclePrice = 10, NewOrUsed = "new", MotorcycleReleaseYear = 2011, MotorcycleColor = "black", MotorcycleSeatNumber = 6, IsLeftWheel = true, FuelType = "gasoline", IsElectricMotorcycle = true, Brand_id = 3 };
            Models.Motorcycle Motorcycle10 = new Models.Motorcycle() { Id = 10, MotorcycleName = "Ferrari Motorcycle2", MotorcycleType = "Ferrari 488", MotorcyclePrice = 15, NewOrUsed = "used", MotorcycleReleaseYear = 2018, MotorcycleColor = "red", MotorcycleSeatNumber = 4, IsLeftWheel = true, FuelType = "diesel", IsElectricMotorcycle = false, Brand_id = 3 };
            Models.Motorcycle Motorcycle11 = new Models.Motorcycle() { Id = 11, MotorcycleName = "Ferrari Motorcycle3", MotorcycleType = "Ferrari 458 Italia", MotorcyclePrice = 20, NewOrUsed = "new", MotorcycleReleaseYear = 2015, MotorcycleColor = "white", MotorcycleSeatNumber = 4, IsLeftWheel = true, FuelType = "gasoline", IsElectricMotorcycle = false, Brand_id = 3 };
            Models.Motorcycle Motorcycle12 = new Models.Motorcycle() { Id = 12, MotorcycleName = "Ferrari Motorcycle4", MotorcycleType = "Ferrari Portofino", MotorcyclePrice = 22, NewOrUsed = "new", MotorcycleReleaseYear = 2020, MotorcycleColor = "black", MotorcycleSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricMotorcycle = true, Brand_id = 3 };
            Models.Motorcycle Motorcycle13 = new Models.Motorcycle() { Id = 13, MotorcycleName = "Porsche Motorcycle1", MotorcycleType = "Porsche 911", MotorcyclePrice = 10, NewOrUsed = "new", MotorcycleReleaseYear = 2017, MotorcycleColor = "black", MotorcycleSeatNumber = 4, IsLeftWheel = true, FuelType = "gasoline", IsElectricMotorcycle = true, Brand_id = 4 };
            Models.Motorcycle Motorcycle14 = new Models.Motorcycle() { Id = 14, MotorcycleName = "Porsche Motorcycle2", MotorcycleType = "Porsche 968 Turbo S", MotorcyclePrice = 100, NewOrUsed = "new", MotorcycleReleaseYear = 2016, MotorcycleColor = "white", MotorcycleSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricMotorcycle = true, Brand_id = 4 };
            Models.Motorcycle Motorcycle15 = new Models.Motorcycle() { Id = 15, MotorcycleName = "Porsche Motorcycle3", MotorcycleType = "Porsche 999", MotorcyclePrice = 40, NewOrUsed = "used", MotorcycleReleaseYear = 2005, MotorcycleColor = "black", MotorcycleSeatNumber = 6, IsLeftWheel = true, FuelType = "diesel", IsElectricMotorcycle = false, Brand_id = 4 };
            Models.Motorcycle Motorcycle16 = new Models.Motorcycle() { Id = 16, MotorcycleName = "Porsche Motorcycle4", MotorcycleType = "Porsche 999", MotorcyclePrice = 35, NewOrUsed = "new", MotorcycleReleaseYear = 2019, MotorcycleColor = "red", MotorcycleSeatNumber = 4, IsLeftWheel = true, FuelType = "gasoline", IsElectricMotorcycle = true, Brand_id = 4 };

            RentMotorcycle RentMotorcycle1 = new RentMotorcycle() { Id = 1, BuyerName = "Sanya", BuyDate = 2020, BuyerGender = "male", IsFirstMotorcycle= false, Motorcycle_id = 1 };
            RentMotorcycle RentMotorcycle2 = new RentMotorcycle() { Id = 2, BuyerName = "Erik", BuyDate = 2022, BuyerGender = "male", IsFirstMotorcycle = true, Motorcycle_id = 8 };
            RentMotorcycle RentMotorcycle3 = new RentMotorcycle() { Id = 3, BuyerName = "Evelin", BuyDate = 2022, BuyerGender = "female", IsFirstMotorcycle = true, Motorcycle_id = 14 };
            RentMotorcycle RentMotorcycle4 = new RentMotorcycle() { Id = 4, BuyerName = "Erzsi", BuyDate = 2018, BuyerGender = "female", IsFirstMotorcycle = false, Motorcycle_id = 4 };


            modelBuilder.Entity<Brand>().HasData(Brand1, Brand2, Brand3, Brand4);
            modelBuilder.Entity<Models.Motorcycle>().HasData(Motorcycle1, Motorcycle2, Motorcycle3, Motorcycle4, Motorcycle6, Motorcycle7, Motorcycle8, Motorcycle9, Motorcycle10, Motorcycle11, Motorcycle12, Motorcycle13, Motorcycle14, Motorcycle15, Motorcycle16);
            modelBuilder.Entity<RentMotorcycle>().HasData(RentMotorcycle1, RentMotorcycle2, RentMotorcycle3, RentMotorcycle4);

        }
    }
}
