using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppRole>()
                .HasData(
                new AppRole { Id = 1, Name = "Yonetici", NormalizedName = "YONETICI" },
                new AppRole { Id = 2, Name = "Personel", NormalizedName = "PERSONEL" }
            );

            modelBuilder.Entity<Department>()
                .HasData(
                new Department { DepartmentID = 1, DepartmentName = "Yönetim" },
                new Department { DepartmentID = 2, DepartmentName = "Üretim" },
                new Department { DepartmentID = 3, DepartmentName = "IT" },
                new Department { DepartmentID = 4, DepartmentName = "İnsan Kaynakları" },
                new Department { DepartmentID = 5, DepartmentName = "Muhasebe" },
                new Department { DepartmentID = 6, DepartmentName = "Pazarlama" },
                new Department { DepartmentID = 7, DepartmentName = "Satın Alma" },
                new Department { DepartmentID = 8, DepartmentName = "Lojistik" },
                new Department { DepartmentID = 9, DepartmentName = "Güvenlik" },
                new Department { DepartmentID = 10, DepartmentName = "Mühendislik" }
            );



            //Func<string> GenerateSecurityStamp = delegate ()
            //{
            //    var guid = Guid.NewGuid();
            //    return String.Concat(Array.ConvertAll(guid.ToByteArray(), b => b.ToString("X2")));
            //};

            ////Seeding a  'Administrator' role to AspNetRoles table
            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Administrator", NormalizedName = "ADMINISTRATOR".ToUpper() });


            ////a hasher to hash the password before seeding the user to the db
            //var hasher = new PasswordHasher<IdentityUser>();


            ////Seeding the User to AspNetUsers table
            //modelBuilder.Entity<IdentityUser>().HasData(
            //    new IdentityUser
            //    {
            //        Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
            //        UserName = "myuser",
            //        NormalizedUserName = "MYUSER",
            //        PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
            //    }
            //);




            //şifre bu --->   Jane123Aa!     <---- şifre bu
            AppUser user1 = new AppUser { Id = 1, FirstName = "Jane", SecondName = "Doe", LastName = "Doe", TCNO = "12345678912", ImagePath = "face10.jpg", Gender = EntityLayer.Enums.Gender.Kadın, BirthDate = DateTime.Now.AddYears(-44), Address = "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", Status = true, Title = "Yönetici", EmploymentDate = DateTime.Now.AddYears(-5), GrossSalary = 10000, DepartmentID = 1, UserName = "jane.doe", NormalizedUserName = "JANE.DOE", Email="jane.doe@sirketadi.com", NormalizedEmail = "JANE.DOE@SIRKETADI.COM", EmailConfirmed = true,PasswordHash = "AQAAAAEAACcQAAAAEC1hOVDCTECysOT/3bQJSr2CUJpsfusJMqa66HGAifWuB4LMMsvw/ImcUNHuphjrRQ==", PhoneNumber = "5325212112", PhoneNumberConfirmed = true, SecurityStamp = "65C5E7CD7F053342A01A595BFCD6E8BC" };
            AppUser user2 = new AppUser { Id = 2, FirstName = "Ogün", SecondName = "Erkutay", LastName = "Erkutay", TCNO = "12345678912", ImagePath = "pic-1.jpg", Gender = EntityLayer.Enums.Gender.Erkek, BirthDate = DateTime.Now.AddYears(-26), Address = "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", Status = true, Title = "Memur", EmploymentDate = DateTime.Now.AddYears(-5), GrossSalary = 10000, DepartmentID = 2, UserName = "ogun.erkutay", NormalizedUserName = "OGUN.ERKUTAY", Email = "ogun.erkutay@sirketadi.com", NormalizedEmail = "OGUN.ERKUTAY@SIRKETADI.COM", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAEBg+GoCve/4RkXw9Y8RJAQ/hoMTkFXQDd3yDl8rrbV/gZzmWP80QmhzbKlqCyXM+uw==", PhoneNumber = "5325212112", PhoneNumberConfirmed = true, SecurityStamp = "7ED842E82E049244B3ECCDC3030EABC8" };
            AppUser user3 = new AppUser { Id = 3, FirstName = "Esra", SecondName = "Ezgi", LastName = "Erdoğan", TCNO = "12345678912", ImagePath = "pic-2.jpg", Gender = EntityLayer.Enums.Gender.Kadın, BirthDate = DateTime.Now.AddYears(-27), Address = "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", Status = true, Title = "Aşçı", EmploymentDate = DateTime.Now.AddYears(-5), GrossSalary = 10000, DepartmentID = 3, UserName = "esraezgi.erdogan", NormalizedUserName = "ESRAEZGI.ERDOGAN", Email = "esraezgi.erdogan@sirketadi.com", NormalizedEmail = "ESRAEZGI.ERDOGAN@SIRKETADI.COM", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAEAKGQ3DYGBgOL6QDbt0m+Iturg9CqIqwyn7C8Z17/dcSkswX2osQXHmsm2iHQS25PQ==", PhoneNumber = "5325212112", PhoneNumberConfirmed = true, SecurityStamp = "BF8993B3A53E5749B4A4F5184CF2F1C9" };
            AppUser user4 = new AppUser { Id = 4, FirstName = "Sinem", SecondName = "", LastName = "Pamık", TCNO = "12345678912", ImagePath = "pic-2.jpg", Gender = EntityLayer.Enums.Gender.Kadın, BirthDate = DateTime.Now.AddYears(-28), Address = "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", Status = true, Title = "Çayçı", EmploymentDate = DateTime.Now.AddYears(-5), GrossSalary = 10000, DepartmentID = 4, UserName = "sinem.pamik", NormalizedUserName = "SINEM.PAMIK", Email = "sinem.pamik@sirketadi.com", NormalizedEmail = "SINEM.PAMIK@SIRKETADI.COM", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAEDxYS+dudQnARoCaCOe8azROOsyfYJUIYDoy5KM9bG1TCHGwXDNYVHuPVspTIW7uPw==", PhoneNumber = "5325212112", PhoneNumberConfirmed = true, SecurityStamp = "C36443C1AB5C8D438563464AE23FB6B5" };
            AppUser user5 = new AppUser { Id = 5, FirstName = "Ceren", SecondName = "Nur", LastName = "Genlik Kara", TCNO = "12345678912", ImagePath = "pic-2.jpg", Gender = EntityLayer.Enums.Gender.Kadın, BirthDate = DateTime.Now.AddYears(-29), Address = "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", Status = true, Title = "Reklamcı", EmploymentDate = DateTime.Now.AddYears(-5), GrossSalary = 10000, DepartmentID = 5, UserName = "cerennur.genlikkara", NormalizedUserName = "CERENNUR.GENLIK", Email = "cerennur.genlikkara@sirketadi.com", NormalizedEmail = "CERENNUR.GENLIKKARA@SIRKETADI.COM", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAENb4IMb6Dx7vyNiE+NcIgS9fU/Hc3EbIzx3005t/ZAaYB7mpGOevYI0O0qpSoTCQfQ==", PhoneNumber = "5325212112", PhoneNumberConfirmed = true, SecurityStamp = "526F881DF1023D4FA1D83FB427E755A8" };
            AppUser user6 = new AppUser { Id = 6, FirstName = "Berkay", SecondName = "Fettah", LastName = "Hacıoğlu", TCNO = "12345678912", ImagePath = "pic-1.jpg", Gender = EntityLayer.Enums.Gender.Erkek, BirthDate = DateTime.Now.AddYears(-30), Address = "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", Status = true, Title = "Pazarlamacı", EmploymentDate = DateTime.Now.AddYears(-5), GrossSalary = 10000, DepartmentID = 6, UserName = "berkayfettah.hacioglu", NormalizedUserName = "BERKAYFETTAH.HACIOGLU", Email = "berkayfettah.hacioglu@sirketadi.com", NormalizedEmail = "BERKAYFETTAH.HACIOGLU@SIRKETADI.COM", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAED+BhI3v8QwcGPruEq4sOfrcbukQvXAAZe2WhBNfS1ocqucgswPY2VisnxdcaTfJAg==", PhoneNumber = "5325212112", PhoneNumberConfirmed = true, SecurityStamp = "3728E22116F5864B8C857C6A81C1893F" };
            AppUser user7 = new AppUser { Id = 7, FirstName = "Mahmut", SecondName = "Mustafa", LastName = "Zekeriyaoğlu", TCNO = "12345678912", ImagePath = "pic-1.jpg", Gender = EntityLayer.Enums.Gender.Erkek, BirthDate = DateTime.Now.AddYears(-31), Address = "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", Status = true, Title = "Satışcı", EmploymentDate = DateTime.Now.AddYears(-5), GrossSalary = 10000, DepartmentID = 7, UserName = "mahmutmustafa.zekeriyaoglu", NormalizedUserName = "MAHMUTMUSTAFA.ZEKERIYEOGLU", Email = "mahmutmustafa.zekeriyaoglu@sirketadi.com", NormalizedEmail = "MAHMUTMUSTAFA.ZEKERIYAOGLU@SIRKETADI.COM", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAECk3s4g7RfcBa4tJOqJbHsPRl0U1iY/FJBoDsMGMrBSQMIindjr5bZR+Dq9yw0ob8Q==", PhoneNumber = "5325212112", PhoneNumberConfirmed = true, SecurityStamp = "1E1C4EB0861F3A4FA521A3117F93D7C1" };
            AppUser user8 = new AppUser { Id = 8, FirstName = "Ismael", SecondName = "Abraham", LastName = "McDoe", TCNO = "12345678912", ImagePath = "pic-1.jpg", Gender = EntityLayer.Enums.Gender.Erkek, BirthDate = DateTime.Now.AddYears(-32), Address = "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", Status = true, Title = "Gezici", EmploymentDate = DateTime.Now.AddYears(-5), GrossSalary = 10000, DepartmentID = 8, UserName = "ismaelabraham.mcdoe", NormalizedUserName = "ISMAELABRAHAM.MCDOE", Email = "ismaelabraham.mcdoe@sirketadi.com", NormalizedEmail = "ISMAELABRAHAM.MCDOE@SIRKETADI.COM", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAEH50QJ51oS+VW7g5Aef95B4CcJ91qm+0tyrag6NQPggIWHnI4QVjDxlRzVt4WdVpZg==", PhoneNumber = "5325212112", PhoneNumberConfirmed = true, SecurityStamp = "031121BF604BBF4EB17C3CEA8B0D866B" };
            


            modelBuilder.Entity<AppUser>()
                .HasData(

                         user1, user2, user3, user4, user5, user6, user7, user8
            );


            //Seeding the relation between our user and role to AspNetUserRoles table
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>
                {
                    RoleId = 1,
                    UserId = 1
                }
            );


        }
    }
}
