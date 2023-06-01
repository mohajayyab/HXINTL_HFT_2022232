using ConsoleTools;

using HXINTL_HFT_2022232.Logic;
using HXINTL_HFT_2022232.Models;
using HXINTL_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXINTL_HFT_2022232.Client
{
    class Program
    {
        
        public static RestService rserv = new RestService("http://localhost:13104");
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);


            var menu = new ConsoleMenu()
               .Add("CRUD methods", () => CrudMenu())
               .Add("non-CRUD methods", () => NonCrudMenu())
               .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }

        private static void CrudMenu()
        {

            var menu = new ConsoleMenu()
                .Add("Create element", CreatePreMenu)
                .Add("Get one element", ReadPreMenu)
                .Add("Get all element", ReadAllPreMenu)
                .Add("Update element", UpdatePreMenu)
                .Add("Delete element", DeletePreMenu)
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }
        private static void NonCrudMenu()
        {
            var menu = new ConsoleMenu()
               .Add("Get RentMotor at the BMW Brand", GetRentMotorcycleAtBMWBrand)
               .Add("Get RentMotor where the Motor price is over 4K$", GetRentMotorcycleWhereMotorPriceIsOver4)
               .Add("Get RentMotor where the Motor name is BMW Motorcycle1", GetRentMotorcycleWhereMotorModelNameIsBMWMotorcycle1)
               .Add("Get Brands where remters name is Sanya", GetBrandWithSanya)
               .Add("Get Brands where renter is male", GetBrandWhereGenderIsMale)
               .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }

        private static void PreMenu(Action RentMotor, Action Motor, Action Brand)
        {
            var menu = new ConsoleMenu()
                .Add("RentMotor", RentMotor)
                .Add("Motor", Motor)
                .Add("Brand", Brand)
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }
        //-------------------------------------------------------------------------------------------------------------CRUD------------------------------------------------

        //---------------------Create-------------------------
        private static void CreatePreMenu()
        {
            PreMenu(CreateRentMotor, CreateMotor, CreateBrand);
        }

        private static void CreateBrand()
        {
            Console.WriteLine("BrandName: ");
            string brandname = Console.ReadLine();
            Console.WriteLine("Age:");
            int brandyear = int.Parse(Console.ReadLine());
            rserv.Post<Brand>(new Brand() { BrandName = brandname, BrandYear = brandyear }, "Brand");
        }

        private static void CreateMotor()
        {
            Console.WriteLine("Name: ");
            string motorcyclename = Console.ReadLine();
            Console.WriteLine("Type:");
            string motorcycletype = Console.ReadLine();
            Console.WriteLine("Brand id: ");
            int brandid = int.Parse(Console.ReadLine());
            rserv.Post<Motorcycle>(new Motorcycle() { MotorcycleName = motorcyclename , MotorcycleType = motorcycletype, Brand_id = brandid }, "Motorcycle");
        }

        private static void CreateRentMotor()
        {
            Console.WriteLine("Name: ");
            string buyername = Console.ReadLine();
            Console.WriteLine("Role name:");
            string buyergender = Console.ReadLine();
            Console.WriteLine("Motor id: ");
            int motorcycleid = int.Parse(Console.ReadLine());
            rserv.Post<RentMotorcycle>(new RentMotorcycle() { BuyerName = buyername, BuyerGender = buyergender, Motorcycle_id = motorcycleid }, "RentMotorcycle");
        }

        //---------------------END-Create-------------------





        //---------------------Read------------------------
        private static void ReadPreMenu()
        {
            PreMenu(ReadRentMotor, ReadMotor, ReadBrand);
        }

        private static void ReadBrand()
        {
            Console.WriteLine("Search for desired with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            var getBrand = rserv.Get<Brand>(id, "Brand");
            Console.WriteLine($"Id: {getBrand.Id}, BrandName: {getBrand.BrandName}, BrandYear: {getBrand.BrandYear}");
            Console.ReadLine();

        }

        private static void ReadMotor()
        {
            Console.WriteLine("Search for desired with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            var getMotor = rserv.Get<Motorcycle>(id, "Motorcycle");
            Console.WriteLine($"Id: {getMotor.Id}, MotorName: {getMotor.MotorcycleName}, MotorType: {getMotor.MotorcycleType}, BrandId: {getMotor.Brand_id}");
            Console.ReadLine();
        }

        private static void ReadRentMotor()
        {
            Console.WriteLine("Search for desired with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            var getRentMotor = rserv.Get<RentMotorcycle>(id, "RentMotorcycle");
            Console.WriteLine($"Id: {getRentMotor.Id}, BuyerName: {getRentMotor.BuyerName}, BuyerGender: {getRentMotor.BuyerGender}, MotorId: {getRentMotor.Motorcycle_id}");
            Console.ReadLine();
        }

        //---------------------END-Read-------------------





        //----------------------ReadAll----------------------
        private static void ReadAllPreMenu()
        {
            PreMenu(PrintAllRentMotor, PrintAllMotors, PrintAllBrands);
        }

        private static void PrintAllRentMotor()
        {
            var RentMotor = rserv.Get<RentMotorcycle>("RentMotorcycle");
            Console.WriteLine("-------------RentMotor-------------");
            RentMotorToConsole(RentMotor);
            Console.ReadLine();
        }
        private static void PrintAllMotors()
        {
            var Motors = rserv.Get<Motorcycle>("Motorcycle");
            Console.WriteLine("-------------Motors-------------");
            MotorToConsole(Motors);
            Console.ReadLine();
        }
        private static void PrintAllBrands()
        {
            var Brands = rserv.Get<Brand>("Brand");
            Console.WriteLine("-------------Brands-------------");
            BrandToConsole(Brands);
            Console.ReadLine();
        }
        //---------------END-ReadAll-------------------





        //-----------------Update-------------------
        private static void UpdatePreMenu()
        {
            PreMenu(UpdateRentMotor, UpdateMotor, UpdateBrand);
        }

        private static void UpdateBrand()
        {
            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("BrandName: ");
            string BrandName = Console.ReadLine();
            Console.WriteLine("BrandYear:");
            int brandyear = int.Parse(Console.ReadLine());
            Brand input = new Brand() { Id = id, BrandName = BrandName, BrandYear = brandyear };
            rserv.Put(input, "Brand");
        }

        private static void UpdateMotor()
        {
            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("MotorName: ");
            string teamname = Console.ReadLine();
            Console.WriteLine("MotorType:");
            string motortype = Console.ReadLine();
            Console.WriteLine("Brand id: ");
            int brandid = int.Parse(Console.ReadLine());
            Motorcycle input = new Motorcycle() { Id = id, MotorcycleName = teamname, MotorcycleType = motortype, Brand_id = brandid };
            rserv.Put(input, "Motorcycle");
        }

        private static void UpdateRentMotor()
        {
            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("BuyerName: ");
            string name = Console.ReadLine();
            Console.WriteLine("BuyDate:");
            int buydate = int.Parse(Console.ReadLine());
            Console.WriteLine("Car id: ");
            int motorid = int.Parse(Console.ReadLine());
            RentMotorcycle input = new RentMotorcycle() { Id = id, BuyerName = name, BuyDate = buydate, Motorcycle_id = motorid };
            rserv.Put(input, "RentMotorcycle");
        }

        //-----------------END-Update-------------





        //-----------------Delete--------------
        private static void DeletePreMenu()
        {
            PreMenu(DeleteRentMotor, DeleteMotor, DeleteBrand);
        }

        private static void DeleteBrand()
        {
            Console.WriteLine("Delete element with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            rserv.Delete(id, "Brand");
        }

        private static void DeleteMotor()
        {
            Console.WriteLine("Delete element with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            rserv.Delete(id, "Motorcycle");
        }

        private static void DeleteRentMotor()
        {
            Console.WriteLine("Delete element with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            rserv.Delete(id, "RentMotorcycle");
        }

        //-------------------END-Delete----------













        ////-------------------------------------------------------------------------------------------------------------non-CRUD------------------------------------------------
     
        private static void GetRentMotorcycleAtBMWBrand()
        {
            var output = rserv.Get<RentMotorcycle>("stat/GetRentMotorcycleAtBMWBrand");

            RentMotorToConsole(output);
            Console.ReadLine();
        }
        private static void GetRentMotorcycleWhereMotorPriceIsOver4()
        {
            var output = rserv.Get<RentMotorcycle>("stat/GetRentMotorcycleWhereMotorPriceIsOver4");
            RentMotorToConsole(output);
            Console.ReadLine();
        }

        private static void GetRentMotorcycleWhereMotorModelNameIsBMWMotorcycle1()
        {
            var output = rserv.Get<RentMotorcycle>("stat/GetRentMotorcycleWhereMotorModelNameIsBMWMotorcycle1");
            RentMotorToConsole(output);
            Console.ReadLine();
        }
        private static void GetRentMotorcycleWhereCarModelNameIsBMWMotorcycle()
        {
            var output = rserv.Get<Brand>("stat/GetRentMotorcycleWhereCarModelNameIsBMWMotorcycle");
            BrandToConsole(output);
            Console.ReadLine();
        }
        private static void GetBrandWithSanya()
        {
            var output = rserv.Get<Brand>("stat/GetBrandWithSanya");
            BrandToConsole(output);
            Console.ReadLine();
        }


        private static void GetBrandWhereGenderIsMale()
        {
            var output = rserv.Get<Brand>("stat/GetBrandWhereGenderIsMale");
            BrandToConsole(output);
            Console.ReadLine();
        }












        ////-------------------------------------------------------------------------------------------------------------ToConsole------------------------------------------------
        private static void RentMotorToConsole(IEnumerable<RentMotorcycle> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine($"Id: {item.Id}, BuyDate: {item.BuyDate}, BuyerName: {item.BuyerName}, MotorId: {item.Motorcycle_id}");
            }
        }
        private static void MotorToConsole(IEnumerable<Motorcycle> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine($"Id: {item.Id}, MotorName: {item.MotorcycleName}, MotorType: {item.MotorcycleType}, BrandId: {item.Brand_id}");
            }
        }
        private static void BrandToConsole(IEnumerable<Brand> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine($"Id: {item.Id}, BrandName: {item.BrandName}, BrandYear: {item.BrandYear}");
            }
        }
    }
            

    }  



            
 
