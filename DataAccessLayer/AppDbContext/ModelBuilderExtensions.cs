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
                new AppRole { Id = 1, Name = "Yönetici" },
                new AppRole { Id = 2, Name = "Personel" }
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

            //şifre bu --->   BuyukHarfli123-!     <---- şifre bu
            AppUser user1 = new AppUser { Id = 1, FirstName = "Jane", SecondName = "Doe", LastName = "Doe", TCNO = "12345678912", ImagePath = "face10.jpg", Gender = EntityLayer.Enums.Gender.Kadın, BirthDate = DateTime.Now.AddYears(-44), Address = "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", Status = true, Title = "Yönetici", EmploymentDate = DateTime.Now.AddYears(-5), GrossSalary = 10000, DepartmentID = 1, Email="jane.doe@sirketadi.com",PasswordHash = "c873586a09e16d54ef49b9ae978cd98db8edc49aaebdb4dcf460d83514321c38",PhoneNumber = "5325212112", PhoneNumberConfirmed = true };
            AppUser user2 = new AppUser { Id = 2, FirstName = "Ogün", SecondName = "Erkutay", LastName = "Erkutay", TCNO = "12345678912", ImagePath = "pic-1.jpg", Gender = EntityLayer.Enums.Gender.Erkek, BirthDate = DateTime.Now.AddYears(-26), Address = "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", Status = true, Title = "Memur", EmploymentDate = DateTime.Now.AddYears(-5), GrossSalary = 10000, DepartmentID = 2, Email = "ogun.erkutay@sirketadi.com", PasswordHash = "c873586a09e16d54ef49b9ae978cd98db8edc49aaebdb4dcf460d83514321c38", PhoneNumber = "5325212112", PhoneNumberConfirmed = true };
            AppUser user3 = new AppUser { Id = 3, FirstName = "Esra", SecondName = "Ezgi", LastName = "Erdoğan", TCNO = "12345678912", ImagePath = "pic-2.jpg", Gender = EntityLayer.Enums.Gender.Kadın, BirthDate = DateTime.Now.AddYears(-27), Address = "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", Status = true, Title = "Aşçı", EmploymentDate = DateTime.Now.AddYears(-5), GrossSalary = 10000, DepartmentID = 3, Email = "esraezgi.erdogan@sirketadi.com", PasswordHash = "c873586a09e16d54ef49b9ae978cd98db8edc49aaebdb4dcf460d83514321c38", PhoneNumber = "5325212112", PhoneNumberConfirmed = true };
            AppUser user4 = new AppUser { Id = 4, FirstName = "Sinem", SecondName = "", LastName = "Pamık", TCNO = "12345678912", ImagePath = "pic-2.jpg", Gender = EntityLayer.Enums.Gender.Kadın, BirthDate = DateTime.Now.AddYears(-28), Address = "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", Status = true, Title = "Çayçı", EmploymentDate = DateTime.Now.AddYears(-5), GrossSalary = 10000, DepartmentID = 4, Email = "sinem.pamik@sirketadi.com", PasswordHash = "c873586a09e16d54ef49b9ae978cd98db8edc49aaebdb4dcf460d83514321c38", PhoneNumber = "5325212112", PhoneNumberConfirmed = true };
            AppUser user5 = new AppUser { Id = 5, FirstName = "Ceren", SecondName = "Nur", LastName = "Genlik Kara", TCNO = "12345678912", ImagePath = "pic-2.jpg", Gender = EntityLayer.Enums.Gender.Kadın, BirthDate = DateTime.Now.AddYears(-29), Address = "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", Status = true, Title = "Reklamcı", EmploymentDate = DateTime.Now.AddYears(-5), GrossSalary = 10000, DepartmentID = 5, Email = "cerennur.genlikkara@sirketadi.com", PasswordHash = "c873586a09e16d54ef49b9ae978cd98db8edc49aaebdb4dcf460d83514321c38", PhoneNumber = "5325212112", PhoneNumberConfirmed = true };
            AppUser user6 = new AppUser { Id = 6, FirstName = "Berkay", SecondName = "Fettah", LastName = "Hacıoğlu", TCNO = "12345678912", ImagePath = "pic-1.jpg", Gender = EntityLayer.Enums.Gender.Erkek, BirthDate = DateTime.Now.AddYears(-30), Address = "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", Status = true, Title = "Pazarlamacı", EmploymentDate = DateTime.Now.AddYears(-5), GrossSalary = 10000, DepartmentID = 6, Email = "berkayfettah.hacioglu@sirketadi.com", PasswordHash = "c873586a09e16d54ef49b9ae978cd98db8edc49aaebdb4dcf460d83514321c38", PhoneNumber = "5325212112", PhoneNumberConfirmed = true };
            AppUser user7 = new AppUser { Id = 7, FirstName = "Mahmut", SecondName = "Mustafa", LastName = "Zekeriyaoğlu", TCNO = "12345678912", ImagePath = "pic-1.jpg", Gender = EntityLayer.Enums.Gender.Erkek, BirthDate = DateTime.Now.AddYears(-31), Address = "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", Status = true, Title = "Satışcı", EmploymentDate = DateTime.Now.AddYears(-5), GrossSalary = 10000, DepartmentID = 7, Email = "mahmutmustafa.zekeriyaoglu@sirketadi.com", PasswordHash = "c873586a09e16d54ef49b9ae978cd98db8edc49aaebdb4dcf460d83514321c38", PhoneNumber = "5325212112", PhoneNumberConfirmed = true };
            AppUser user8 = new AppUser { Id = 8, FirstName = "Ismael", SecondName = "Abraham", LastName = "McDoe", TCNO = "12345678912", ImagePath = "pic-1.jpg", Gender = EntityLayer.Enums.Gender.Erkek, BirthDate = DateTime.Now.AddYears(-32), Address = "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", Status = true, Title = "Gezici", EmploymentDate = DateTime.Now.AddYears(-5), GrossSalary = 10000, DepartmentID = 8, Email = "ismaelabraham.mcdoe@sirketadi.com", PasswordHash = "c873586a09e16d54ef49b9ae978cd98db8edc49aaebdb4dcf460d83514321c38", PhoneNumber = "5325212112", PhoneNumberConfirmed = true };
            AppUser user9 = new AppUser { Id = 9, FirstName = "Azazel", SecondName = "Christian", LastName = "MCDonald", TCNO = "12345678912", ImagePath = "pic-1.jpg", Gender = EntityLayer.Enums.Gender.Erkek, BirthDate = DateTime.Now.AddYears(-33), Address = "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", Status = false, Title = "Yiyici", EmploymentDate = DateTime.Now.AddYears(-5), GrossSalary = 10000, DepartmentID = 9, Email = "azazelchristian.mcdonald@sirketadi.com", PasswordHash = "c873586a09e16d54ef49b9ae978cd98db8edc49aaebdb4dcf460d83514321c38", PhoneNumber = "5325212112", PhoneNumberConfirmed = true };


            modelBuilder.Entity<AppUser>()
                .HasData(

                         user1, user2, user3, user4, user5, user6, user7, user8, user9
            );




        }

    }
}
