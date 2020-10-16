using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace h1.Data.Impl
{
    public class FamilyServiceImpl : IFamilyService
    {
        private IPersistenceService persistence;
        private readonly string familiesPath = "families.json";
        private List<Family> families;

        public FamilyServiceImpl()
        {
            Console.WriteLine("hello!");
            persistence = new JSONPersistenceService(familiesPath);
            families = persistence.ReadList<Family>();
            if (families.Count == 0)
            {
                FillFamilies();
                persistence.WriteList(families);
            }
        }

        public void FillFamilies()
        {
            Family f1 = new Family()
            {
                StreetName = "The Fuck Street",
                HouseNumber = 4
            };
            f1.AddAdult(new Adult()
            {
                Age = 31,
                EyeColor = "Brown",
                FirstName = "Mike",
                HairColor = "Blue",
                Height = 180,
                Id = 1,
                JobTitle = Adult.JobTitles.Captain.ToString(),
                LastName = "Brownie",
                Sex = "Male",
                Weight = 69.420f
            });
            families = new[]
            {
                f1
            }.ToList();
        }

        public List<Family> GetFamilies()
        {
            return families;
        }
        
        public void CreateFamily()
        {   
            
        }
    }
}