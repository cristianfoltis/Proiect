using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    UserName = "Mihai Stefanescu",
                    UserRole = "Web Developer",
                    UserLocation = "Cluj-Napoca"
                },
                new User
                {
                    UserId = 2,
                    UserName = "Ioana Maria",
                    UserRole = ".NET Developer",
                    UserLocation = "Cluj-Napoca"
                },
                new User
                {
                    UserId = 3,
                    UserName = "Mos Bogdan",
                    UserRole = "Java Developer",
                    UserLocation = "Brasov"
                }
                );

            builder.Entity<Device>().HasData(
                new Device
                {
                DeviceId = 1,
                DeviceName = "Smart001",
                Manufacturer = "Samsung",
                DeviceType = "Smartphone",
                DeviceOS = "Android",
                DeviceProcessor = "Exynos",
                DeviceRAM = "6GB"
                },
                new Device
                {
                    DeviceId = 2,
                    DeviceName = "Smart002",
                    Manufacturer = "Samsung",
                    DeviceType = "Smartphone",
                    DeviceOS = "Android",
                    DeviceProcessor = "Snapdragon",
                    DeviceRAM = "12GB"
                },
                new Device
                {
                    DeviceId = 3,
                    DeviceName = "Smart003",
                    Manufacturer = "Apple",
                    DeviceType = "Smartphone",
                    DeviceOS = "iOS",
                    DeviceProcessor = "A13 Bionic",
                    DeviceRAM = "4GB"
                }
                );


        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
