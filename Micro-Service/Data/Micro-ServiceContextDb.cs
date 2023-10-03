using Micro_Service.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Micro_Service.Data
{
    public class Micro_ServiceContextDb:DbContext
    {
        public Micro_ServiceContextDb(DbContextOptions<Micro_ServiceContextDb> options)
           : base(options)
        { }

        public DbSet<BankAccount> BankAccounts  { get; set; }
        public DbSet<Clients> Client { get; set; }
        public DbSet<Suburb> Suburbs { get; set; }
        public DbSet<City> Cities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City
                {
                    CityID = 1,
                    Name = "Port Elizabeth"
                },
                new City
                {
                    CityID = 2,
                    Name = "Durban"
                },
                new City
                {
                    CityID = 3,
                    Name = "Cape Town"
                }
                );

            modelBuilder.Entity<Suburb>().HasData(
                new Suburb
                {
                    SuburbID = 1,
                    CityID = 1,
                    Name = "Humewood"
                    
                },
                new Suburb
                {
                    SuburbID = 2,
                    CityID = 1,
                    Name="Summerstrand"
                },

                new Suburb
                {
                    SuburbID= 3,
                    CityID = 2,
                    Name="Kwamashu"
                }
                );
            modelBuilder.Entity<Clients>().HasData(
                
                new Clients
                {
                    CLientID = 1,
                    FirtName = "George",
                    Surname = "Molala",
                    MobileNumber = 0799897632,
                    IdNumber = 9908095812087,
                    EmailAddress = "Gert.Molala@mandela.ac.za",
                    AddressLine1= "25 Nelson Mandela",
                    AddressLine2 = "",
                    CityID = 1,
                    SuburbID = 2
                },
                new Clients
                {
                    CLientID = 2,
                    FirtName = "Mary",
                    Surname = "Nkuna",
                    MobileNumber = 0799890980,
                    IdNumber = 9506205812087,
                    EmailAddress = "MaryNkuna@gmail.com",
                    AddressLine1 = "19 Perkins",
                    AddressLine2 = "",
                    CityID = 2,
                    SuburbID = 3

                }
            );

            modelBuilder.Entity<BankAccount>().HasData(

                new BankAccount
                {
                    AccountID = 1,
                    AccounNumer = "29484676",
                    ClientID = 1,
                    AccountType = "Savings",
                    Name = "FNB",
                    Status= "Active",
                    Balance = 23000
                },
                   new BankAccount
                   {
                       AccountID = 2,
                       AccounNumer = "75656478",
                       ClientID = 2,
                       AccountType = "Cheque",
                       Name = "Standard",
                       Status = "Active",
                       Balance = 20000
                   }
                   ,
                   new BankAccount
                   {
                       AccountID =3,
                       AccounNumer = "348575894",
                       ClientID = 2,
                       AccountType = "Savings",
                       Name = "Standard",
                       Status = "Active",
                       Balance = 68000
                   }
                );
         
        }

    }
}
