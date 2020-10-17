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
                LastName = "Brownie",
                Sex = "Male",
                Weight = 69.420f
            });
            f1.AddPet(new Pet()
            {
                Name = "Boris",
                Age = 12,
                Species = "Cat",
            });
            
            AddFamily(f1);
        }

        public void AddFamily(Family family)
        {
            family.Id = families.Any() ? families.Max(thisFamily => thisFamily.Id) + 1 : 0;
            families.Add(family);
            SaveData();
        }

        public List<Family> GetFamilies()
        {
            return families;
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
            int myFamilyId = Int32.Parse(id);
            return GetFamilyById(myFamilyId);
        }

        public Adult GetAdultById(int familyId, int id)
        {
            Family myFamily = families.Find(x => x.Id == familyId);
            if (myFamily != null)
            {
                return myFamily.Adults.Find(x => x.Id == id);   
            }

            return null;
        }

        public Adult GetAdultById(string familyId, string id)
        {
            int myFamilyId = Int32.Parse(familyId);
            int myAdultId = Int32.Parse(id);
            return GetAdultById(myFamilyId, myAdultId);
        }

        public void SaveData()
        {
            persistence.WriteList(families);
        }
    }
}