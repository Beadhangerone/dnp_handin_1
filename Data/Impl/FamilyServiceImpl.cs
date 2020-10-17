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
                Id = 5,
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
                Id = 0,
                JobTitle = Adult.JobTitles.Captain.ToString(),
                LastName = "Brownie",
                Sex = "Male",
                Weight = 69.420f
            });
            f1.AddChild(new Child()
            {
                Age = 31,
                EyeColor = "Brown",
                FirstName = "Mike",
                HairColor = "Blue",
                Height = 180,
                Id = 1,
                LastName = "Brownie",
                Sex = "Male",
                Weight = 69.420f
            });
            f1.AddPet(new Pet()
            {
                Name = "Boris",
                Age = 12,
                Species = "Cat",
                Id = 1
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

        public void RemoveFamily(int id)
        {
            families.Remove(families.Find(x => x.Id == id));
            SaveData();
        }

        public Family GetFamilyById(int id)
        {
            return families.Find(x => x.Id == id);
        }

        public Family GetFamilyById(string id)
        {
            return families.Find(x => x.Id == Int32.Parse(id));
        }

        public Adult GetAdultById(string id)
        {
            int adultId = Int32.Parse(id);
            return families[adultId].Adults.Find(x => x.Id == Int32.Parse(id));
        }
        
        public Child GetChildById(string id)
        {
            return families[Int32.Parse(id)].Children.Find(x => x.Id == Int32.Parse(id));
        }
        
        public Pet GetPetById(string id)
        {
            return families[Int32.Parse(id)].Pets.Find(x => x.Id == Int32.Parse(id));
        }

        public void SaveData()
        {
            persistence.WriteList(families);
        }
    }
}