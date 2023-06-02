using HXINTL_HFT_2022232.Logic;
using HXINTL_HFT_2022232.Models;
using HXINTL_HFT_2022232.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXINTL_HFT_2022232.Test
{
    [TestFixture]
    public class Tester
    {
        RentMotorcycleLogic rentmotorlogic;
        MotorcycleLogic motorlogic;
        BrandLogic brandlogic;

        [SetUp]
        public void Setup()
        {
            Mock<IRepository<RentMotorcycle>> mockRentMotorRepo = new Mock<IRepository<RentMotorcycle>>();
            Mock<IRepository<Motorcycle>> mockMotorRepo = new Mock<IRepository<Motorcycle>>();
            Mock<IRepository<Brand>> mockBrandRepo = new Mock<IRepository<Brand>>();

            mockRentMotorRepo.Setup(x => x.Read(It.IsAny<int>())).Returns(
                new RentMotorcycle()
                {
                    Id = 1,
                    BuyerName = "Tanya",
                    BuyDate = 2000,
                    BuyerGender = "female",
                    IsFirstMotorcycle = false,
                    Motorcycle_id = 1,
                });

            mockRentMotorRepo.Setup(x => x.ReadAll()).Returns(FakeRentMotorObject);
            mockMotorRepo.Setup(x => x.ReadAll()).Returns(FakeMotorObject);
            mockBrandRepo.Setup(x => x.ReadAll()).Returns(FakeBrandObject);

            rentmotorlogic = new RentMotorcycleLogic(mockBrandRepo.Object, mockMotorRepo.Object, mockRentMotorRepo.Object);
            brandlogic = new BrandLogic(mockBrandRepo.Object, mockMotorRepo.Object, mockRentMotorRepo.Object);
            motorlogic = new MotorcycleLogic(mockMotorRepo.Object);

        }


        [Test]
        public void GetOneRentMotorcycleBuyerName()
        {
            Assert.That(rentmotorlogic.Read(1).BuyerName, Is.EqualTo("Tanya"));
        }

        [Test]
        public void GetOneRentMotorcycleBuyDate()
        {
            Assert.That(rentmotorlogic.Read(1).BuyDate, Is.EqualTo(2000));
        }

        [Test]
        public void GetOneRentMotorcycleBuyerGender()
        {
            Assert.That(rentmotorlogic.Read(1).BuyerGender, Is.EqualTo("female"));
        }

        [Test]
        public void GetAllRentMotorcycle_ReturnsExactNumberOfInstances()
        {
            Assert.That(this.rentmotorlogic.ReadAll().Count, Is.EqualTo(4));
        }

        [Test]
        public void GetRentMotorcycleAtTokyo_ReturnsCorrectInstance()
        {
            Assert.That(rentmotorlogic.GetRentMotorcycleAtBMWBrand().Count, Is.EqualTo(4));
        }


        [Test]
        public void GetRentMotorcycleWhereModelNameBMW1_ReturnsCorrectInstance()
        {
            Assert.That(rentmotorlogic.GetRentMotorcycleWhereMotorModelNameIsBMWMotorcycle1().First().Motorcycle.IsElectricMotorcycle, Is.EqualTo(true));
        }

        [Test]
        public void GetRentMotorcycleWhereModelNameBMW2_ReturnsCorrectInstance()
        {
            Assert.That(rentmotorlogic.GetRentMotorcycleWhereCarModelNameIsBMWMotorcycle2().First().Motorcycle.IsElectricMotorcycle, Is.EqualTo(true));
        }

        [Test]
        public void GetBrandName()
        {
            Assert.That(brandlogic.GetBrandWithSanya().Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetOneRentMotorcycleIsFirstMotorcycle()
        {
            Assert.That(rentmotorlogic.Read(1).IsFirstMotorcycle, Is.EqualTo(false));
        }

        [Test]
        public void GetOneRentMotorcycleMotorcycle_id()
        {
            Assert.That(rentmotorlogic.Read(1).Motorcycle_id, Is.EqualTo(1));
        }


        private IQueryable<RentMotorcycle> FakeRentMotorObject()
        {
            Brand Brand1 = new Brand() { Id = 1, BrandName = "BMW", BrandCountry = "Japan", BrandYear = 2001 };
            Brand Brand2 = new Brand() { Id = 2, BrandName = "Toyota", BrandCountry = "Japan", BrandYear = 2005 };
            Brand Brand3 = new Brand() { Id = 3, BrandName = "Ferrari", BrandCountry = "Italy", BrandYear = 2010 };


            Brand1.Motorcycle = new List<Motorcycle>();
            Brand2.Motorcycle = new List<Motorcycle>();
            Brand3.Motorcycle= new List<Motorcycle>();

            // -------------------------------------------------------------------------------------------------------

            Motorcycle Motorcycle1 = new Motorcycle() { Id = 1, MotorcycleName = "BMW Motorcycle1", MotorcycleType = "Swift", MotorcyclePrice = 1, NewOrUsed = "new", MotorcycleReleaseYear = 2000, MotorcycleColor = "black", MotorcycleSeatNumber = 4, IsLeftWheel = true, FuelType = "diesel", IsElectricMotorcycle = true, Brand_id = 1 };
            Motorcycle Motorcycle2 = new Motorcycle() { Id = 2, MotorcycleName = "BMW Motorcycle2", MotorcycleType = "Ignis", MotorcyclePrice = 3, NewOrUsed = "new", MotorcycleReleaseYear = 2005, MotorcycleColor = "white", MotorcycleSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricMotorcycle = true, Brand_id = 1 };
            Motorcycle Motorcycle3 = new Motorcycle() { Id = 3, MotorcycleName = "BMW Motorcycle3", MotorcycleType = "Swift", MotorcyclePrice = 15, NewOrUsed = "used", MotorcycleReleaseYear = 2020, MotorcycleColor = "red", MotorcycleSeatNumber = 6, IsLeftWheel = false, FuelType = "gasoline", IsElectricMotorcycle = false, Brand_id = 1 };
            Motorcycle Motorcycle4 = new Motorcycle() { Id = 4, MotorcycleName = "BMW Motorcycle4", MotorcycleType = "Vitara", MotorcyclePrice = 1, NewOrUsed = "used", MotorcycleReleaseYear = 1990, MotorcycleColor = "green", MotorcycleSeatNumber = 4, IsLeftWheel = false, FuelType = "diesel", IsElectricMotorcycle = false, Brand_id = 1 };
            Motorcycle Motorcycle5 = new Motorcycle() { Id = 5, MotorcycleName = "Toyota Motorcycle1", MotorcycleType = "Yaris", MotorcyclePrice = 4, NewOrUsed = "new", MotorcycleReleaseYear = 2020, MotorcycleColor = "red", MotorcycleSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricMotorcycle = true, Brand_id = 2 };
            Motorcycle Motorcycle6 = new Motorcycle() { Id = 6, MotorcycleName = "Toyota Motorcycle2", MotorcycleType = "Corolla", MotorcyclePrice = 1, NewOrUsed = "used", MotorcycleReleaseYear = 2000, MotorcycleColor = "green", MotorcycleSeatNumber = 3, IsLeftWheel = true, FuelType = "diesel", IsElectricMotorcycle = false, Brand_id = 2 };


            Motorcycle1.Brand = Brand1;
            Motorcycle2.Brand = Brand1;
            Motorcycle3.Brand = Brand2;
            Motorcycle4.Brand = Brand2;
            Motorcycle5.Brand = Brand3;
            Motorcycle6.Brand = Brand3;

            Motorcycle1.Brand_id = Brand1.Id; Brand1.Motorcycle.Add(Motorcycle1);
            Motorcycle2.Brand_id = Brand1.Id; Brand1.Motorcycle.Add(Motorcycle2);
            Motorcycle3.Brand_id = Brand2.Id; Brand2.Motorcycle.Add(Motorcycle3);
            Motorcycle4.Brand_id = Brand2.Id; Brand2.Motorcycle.Add(Motorcycle4);
            Motorcycle5.Brand_id = Brand3.Id; Brand3.Motorcycle.Add(Motorcycle5);
            Motorcycle6.Brand_id = Brand3.Id; Brand3.Motorcycle.Add(Motorcycle6);

            Motorcycle1.RentMotorcycle = new List<RentMotorcycle>();
            Motorcycle2.RentMotorcycle = new List<RentMotorcycle>();
            Motorcycle3.RentMotorcycle = new List<RentMotorcycle>();
            Motorcycle4.RentMotorcycle = new List<RentMotorcycle>();
            Motorcycle5.RentMotorcycle = new List<RentMotorcycle>();
            Motorcycle6.RentMotorcycle = new List<RentMotorcycle>();

            // -------------------------------------------------------------------------------------------------------


            RentMotorcycle RentMotorcycle1 = new RentMotorcycle() { Id = 1, BuyerName = "Sanya", BuyDate = 2020, BuyerGender = "male", IsFirstMotorcycle = false, Motorcycle_id = 1 };
            RentMotorcycle RentMotorcycle2 = new RentMotorcycle() { Id = 2, BuyerName = "Erik", BuyDate = 2022, BuyerGender = "male", IsFirstMotorcycle = true, Motorcycle_id = 2 };
            RentMotorcycle RentMotorcycle3 = new RentMotorcycle() { Id = 3, BuyerName = "Evelin", BuyDate = 2022, BuyerGender = "female", IsFirstMotorcycle = true, Motorcycle_id = 3 };
            RentMotorcycle RentMotorcycle4 = new RentMotorcycle() { Id = 4, BuyerName = "Erzsi", BuyDate = 2018, BuyerGender = "female", IsFirstMotorcycle = false, Motorcycle_id = 4 };

            RentMotorcycle1.Motorcycle = Motorcycle1;
            RentMotorcycle2.Motorcycle = Motorcycle1;
            RentMotorcycle3.Motorcycle = Motorcycle2;
            RentMotorcycle4.Motorcycle = Motorcycle2;


            RentMotorcycle1.Motorcycle_id = Motorcycle1.Id; Motorcycle1.RentMotorcycle.Add(RentMotorcycle1);
            RentMotorcycle2.Motorcycle_id = Motorcycle1.Id; Motorcycle1.RentMotorcycle.Add(RentMotorcycle2);
            RentMotorcycle3.Motorcycle_id = Motorcycle2.Id; Motorcycle2.RentMotorcycle.Add(RentMotorcycle3);
            RentMotorcycle4.Motorcycle_id = Motorcycle2.Id; Motorcycle2.RentMotorcycle.Add(RentMotorcycle4);


            // -------------------------------------------------------------------------------------------------------

            List<RentMotorcycle> RentMotorcycle = new List<RentMotorcycle>();
            RentMotorcycle.Add(RentMotorcycle1);
            RentMotorcycle.Add(RentMotorcycle2);
            RentMotorcycle.Add(RentMotorcycle3);
            RentMotorcycle.Add(RentMotorcycle4);

            return RentMotorcycle.AsQueryable();
        }

        private IQueryable<Motorcycle> FakeMotorObject()
        {
            Brand Brand1 = new Brand() { Id = 1, BrandName = "Suzuki", BrandCountry = "Japan", BrandYear = 1909 };
            Brand Brand2 = new Brand() { Id = 2, BrandName = "Toyota", BrandCountry = "Japan", BrandYear = 1909 };
            Brand Brand3 = new Brand() { Id = 3, BrandName = "Ferrari", BrandCountry = "Italy", BrandYear = 1941 };

            Brand1.Motorcycle = new List<Motorcycle>();
            Brand2.Motorcycle = new List<Motorcycle>();
            Brand3.Motorcycle = new List<Motorcycle>();

            // -------------------------------------------------------------------------------------------------------

            Motorcycle Motorcycle1 = new Motorcycle() { Id = 1, MotorcycleName = "BMW Motorcycle1", MotorcycleType = "Swift", MotorcyclePrice = 1, NewOrUsed = "new", MotorcycleReleaseYear = 2000, MotorcycleColor = "black", MotorcycleSeatNumber = 4, IsLeftWheel = true, FuelType = "diesel", IsElectricMotorcycle = true, Brand_id = 1 };
            Motorcycle Motorcycle2 = new Motorcycle() { Id = 2, MotorcycleName = "BMW Motorcycle2", MotorcycleType = "Ignis", MotorcyclePrice = 3, NewOrUsed = "new", MotorcycleReleaseYear = 2005, MotorcycleColor = "white", MotorcycleSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricMotorcycle = true, Brand_id = 1 };
            Motorcycle Motorcycle3 = new Motorcycle() { Id = 3, MotorcycleName = "BMW Motorcycle3", MotorcycleType = "Swift", MotorcyclePrice = 15, NewOrUsed = "used", MotorcycleReleaseYear = 2020, MotorcycleColor = "red", MotorcycleSeatNumber = 6, IsLeftWheel = false, FuelType = "gasoline", IsElectricMotorcycle = false, Brand_id = 1 };
            Motorcycle Motorcycle4 = new Motorcycle() { Id = 4, MotorcycleName = "Suzuki Motorcycle4", MotorcycleType = "Vitara", MotorcyclePrice = 1, NewOrUsed = "used", MotorcycleReleaseYear = 1990, MotorcycleColor = "green", MotorcycleSeatNumber = 4, IsLeftWheel = false, FuelType = "diesel", IsElectricMotorcycle = false, Brand_id = 1 };
            Motorcycle Motorcycle5 = new Motorcycle() { Id = 5, MotorcycleName = "Toyota Motorcycle1", MotorcycleType = "Yaris", MotorcyclePrice = 4, NewOrUsed = "new", MotorcycleReleaseYear = 2020, MotorcycleColor = "red", MotorcycleSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricMotorcycle = true, Brand_id = 2 };
            Motorcycle Motorcycle6 = new Motorcycle() { Id = 6, MotorcycleName = "Toyota Motorcycle2", MotorcycleType = "Corolla", MotorcyclePrice = 1, NewOrUsed = "used", MotorcycleReleaseYear = 2000, MotorcycleColor = "green", MotorcycleSeatNumber = 3, IsLeftWheel = true, FuelType = "diesel", IsElectricMotorcycle = false, Brand_id = 2 };

            Motorcycle1.Brand = Brand1;
            Motorcycle2.Brand = Brand1;
            Motorcycle3.Brand = Brand2;
            Motorcycle4.Brand = Brand2;
            Motorcycle5.Brand = Brand3;
            Motorcycle6.Brand = Brand3;

            Motorcycle1.Brand_id = Brand1.Id; Brand1.Motorcycle.Add(Motorcycle1);
            Motorcycle2.Brand_id = Brand1.Id; Brand1.Motorcycle.Add(Motorcycle2);
            Motorcycle3.Brand_id = Brand2.Id; Brand2.Motorcycle.Add(Motorcycle3);
            Motorcycle4.Brand_id = Brand2.Id; Brand2.Motorcycle.Add(Motorcycle4);
            Motorcycle5.Brand_id = Brand3.Id; Brand3.Motorcycle.Add(Motorcycle5);
            Motorcycle6.Brand_id = Brand3.Id; Brand3.Motorcycle.Add(Motorcycle6);

            Motorcycle1.RentMotorcycle = new List<RentMotorcycle>();
            Motorcycle2.RentMotorcycle = new List<RentMotorcycle>();
            Motorcycle3.RentMotorcycle = new List<RentMotorcycle>();
            Motorcycle4.RentMotorcycle = new List<RentMotorcycle>();
            Motorcycle5.RentMotorcycle = new List<RentMotorcycle>();
            Motorcycle6.RentMotorcycle = new List<RentMotorcycle>();

            // -------------------------------------------------------------------------------------------------------

            RentMotorcycle RentMotorcycle1 = new RentMotorcycle() { Id = 1, BuyerName = "Sanya", BuyDate = 2020, BuyerGender = "male", IsFirstMotorcycle = false, Motorcycle_id = 1 };
            RentMotorcycle RentMotorcycle2 = new RentMotorcycle() { Id = 2, BuyerName = "Erik", BuyDate = 2022, BuyerGender = "male", IsFirstMotorcycle = true, Motorcycle_id = 2 };
            RentMotorcycle RentMotorcycle3 = new RentMotorcycle() { Id = 3, BuyerName = "Evelin", BuyDate = 2022, BuyerGender = "female", IsFirstMotorcycle = true, Motorcycle_id = 3 };
            RentMotorcycle RentMotorcycle4 = new RentMotorcycle() { Id = 4, BuyerName = "Erzsi", BuyDate = 2018, BuyerGender = "female", IsFirstMotorcycle = false, Motorcycle_id = 4 };

            RentMotorcycle1.Motorcycle = Motorcycle1;
            RentMotorcycle2.Motorcycle = Motorcycle1;
            RentMotorcycle3.Motorcycle = Motorcycle2;
            RentMotorcycle4.Motorcycle = Motorcycle2;


            RentMotorcycle1.Motorcycle_id = Motorcycle1.Id; Motorcycle1.RentMotorcycle.Add(RentMotorcycle1);
            RentMotorcycle2.Motorcycle_id = Motorcycle1.Id; Motorcycle1.RentMotorcycle.Add(RentMotorcycle2);
            RentMotorcycle3.Motorcycle_id = Motorcycle2.Id; Motorcycle2.RentMotorcycle.Add(RentMotorcycle3);
            RentMotorcycle4.Motorcycle_id = Motorcycle2.Id; Motorcycle2.RentMotorcycle.Add(RentMotorcycle4);
            // -------------------------------------------------------------------------------------------------------

            List<Motorcycle> Motorcycles = new List<Motorcycle>();
            Motorcycles.Add(Motorcycle1);
            Motorcycles.Add(Motorcycle2);
            Motorcycles.Add(Motorcycle3);
            Motorcycles.Add(Motorcycle4);
            Motorcycles.Add(Motorcycle5);
            Motorcycles.Add(Motorcycle6);
            return Motorcycles.AsQueryable();

        }
        private IQueryable<Brand> FakeBrandObject()
        {
            Brand Brand1 = new Brand() { Id = 1, BrandName = "BMW", BrandCountry = "Japan", BrandYear = 1909 };
            Brand Brand2 = new Brand() { Id = 2, BrandName = "Toyota", BrandCountry = "Japan", BrandYear = 1909 };
            Brand Brand3 = new Brand() { Id = 3, BrandName = "Ferrari", BrandCountry = "Italy", BrandYear = 1941 };


            Brand1.Motorcycle = new List<Motorcycle>();
            Brand2.Motorcycle = new List<Motorcycle>();
            Brand3.Motorcycle = new List<Motorcycle>();

            // -------------------------------------------------------------------------------------------------------
            Motorcycle Motorcycle1 = new Motorcycle() { Id = 1, MotorcycleName = "BMW Motorcycle1", MotorcycleType = "Swift", MotorcyclePrice = 1, NewOrUsed = "new", MotorcycleReleaseYear = 2000, MotorcycleColor = "black", MotorcycleSeatNumber = 4, IsLeftWheel = true, FuelType = "diesel", IsElectricMotorcycle = true, Brand_id = 1 };
            Motorcycle Motorcycle2 = new Motorcycle() { Id = 2, MotorcycleName = "BMW Motorcycle2", MotorcycleType = "Ignis", MotorcyclePrice = 3, NewOrUsed = "new", MotorcycleReleaseYear = 2005, MotorcycleColor = "white", MotorcycleSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricMotorcycle = true, Brand_id = 1 };
            Motorcycle Motorcycle3 = new Motorcycle() { Id = 3, MotorcycleName = "BMW Motorcycle3", MotorcycleType = "Swift", MotorcyclePrice = 15, NewOrUsed = "used", MotorcycleReleaseYear = 2020, MotorcycleColor = "red", MotorcycleSeatNumber = 6, IsLeftWheel = false, FuelType = "gasoline", IsElectricMotorcycle = false, Brand_id = 1 };
            Motorcycle Motorcycle4 = new Motorcycle() { Id = 4, MotorcycleName = "BMW Motorcycle4", MotorcycleType = "Vitara", MotorcyclePrice = 1, NewOrUsed = "used", MotorcycleReleaseYear = 1990, MotorcycleColor = "green", MotorcycleSeatNumber = 4, IsLeftWheel = false, FuelType = "diesel", IsElectricMotorcycle = false, Brand_id = 1 };
            Motorcycle Motorcycle5 = new Motorcycle() { Id = 5, MotorcycleName = "Toyota Motorcycle1", MotorcycleType = "Yaris", MotorcyclePrice = 4, NewOrUsed = "new", MotorcycleReleaseYear = 2020, MotorcycleColor = "red", MotorcycleSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricMotorcycle = true, Brand_id = 2 };
            Motorcycle Motorcycle6 = new Motorcycle() { Id = 6, MotorcycleName = "Toyota Motorcycle2", MotorcycleType = "Corolla", MotorcyclePrice = 1, NewOrUsed = "used", MotorcycleReleaseYear = 2000, MotorcycleColor = "green", MotorcycleSeatNumber = 3, IsLeftWheel = true, FuelType = "diesel", IsElectricMotorcycle = false, Brand_id = 2 };

            Motorcycle1.Brand = Brand1;
            Motorcycle2.Brand = Brand1;
            Motorcycle3.Brand = Brand2;
            Motorcycle4.Brand = Brand2;
            Motorcycle5.Brand = Brand3;
            Motorcycle6.Brand = Brand3;

            Motorcycle1.Brand_id = Brand1.Id; Brand1.Motorcycle.Add(Motorcycle1);
            Motorcycle2.Brand_id = Brand1.Id; Brand1.Motorcycle.Add(Motorcycle2);
            Motorcycle3.Brand_id = Brand2.Id; Brand2.Motorcycle.Add(Motorcycle3);
            Motorcycle4.Brand_id = Brand2.Id; Brand2.Motorcycle.Add(Motorcycle4);
            Motorcycle5.Brand_id = Brand3.Id; Brand3.Motorcycle.Add(Motorcycle5);
            Motorcycle6.Brand_id = Brand3.Id; Brand3.Motorcycle.Add(Motorcycle6);

            Motorcycle1.RentMotorcycle = new List<RentMotorcycle>();
            Motorcycle2.RentMotorcycle = new List<RentMotorcycle>();
            Motorcycle3.RentMotorcycle = new List<RentMotorcycle>();
            Motorcycle4.RentMotorcycle = new List<RentMotorcycle>();
            Motorcycle5.RentMotorcycle = new List<RentMotorcycle>();
            Motorcycle6.RentMotorcycle = new List<RentMotorcycle>();

            // -------------------------------------------------------------------------------------------------------

            RentMotorcycle RentMotorcycle1 = new RentMotorcycle() { Id = 1, BuyerName = "Sanya", BuyDate = 2020, BuyerGender = "male", IsFirstMotorcycle = false, Motorcycle_id = 1 };
            RentMotorcycle RentMotorcycle2 = new RentMotorcycle() { Id = 2, BuyerName = "Erik", BuyDate = 2022, BuyerGender = "male", IsFirstMotorcycle = true, Motorcycle_id = 2 };
            RentMotorcycle RentMotorcycle3 = new RentMotorcycle() { Id = 3, BuyerName = "Evelin", BuyDate = 2022, BuyerGender = "female", IsFirstMotorcycle = true, Motorcycle_id = 3 };
            RentMotorcycle RentMotorcycle4 = new RentMotorcycle() { Id = 4, BuyerName = "Erzsi", BuyDate = 2018, BuyerGender = "female", IsFirstMotorcycle = false, Motorcycle_id = 4 };

            RentMotorcycle1.Motorcycle = Motorcycle1;
            RentMotorcycle2.Motorcycle = Motorcycle1;
            RentMotorcycle3.Motorcycle = Motorcycle2;
            RentMotorcycle4.Motorcycle = Motorcycle2;


            RentMotorcycle1.Motorcycle_id = Motorcycle1.Id; Motorcycle1.RentMotorcycle.Add(RentMotorcycle1);
            RentMotorcycle2.Motorcycle_id = Motorcycle1.Id; Motorcycle1.RentMotorcycle.Add(RentMotorcycle2);
            RentMotorcycle3.Motorcycle_id = Motorcycle2.Id; Motorcycle2.RentMotorcycle.Add(RentMotorcycle3);
            RentMotorcycle4.Motorcycle_id = Motorcycle2.Id; Motorcycle2.RentMotorcycle.Add(RentMotorcycle4);


            List<Brand> Brands = new List<Brand>();
            Brands.Add(Brand1);
            Brands.Add(Brand2);
            Brands.Add(Brand3);
            return Brands.AsQueryable();

        }
    }
}
