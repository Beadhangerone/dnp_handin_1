using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using h1.Helpers;
using h1.Models;
using Models;

namespace h1.Data.Impl
{
    public class FamilyServiceImpl : IFamilyService
    {
        private IPersistenceService persistence;
        private readonly string familiesPath = "families.json";
        private List<Family> _families = new List<Family>();

        public FamilyServiceImpl()
        {
            ActionLog.Log("Data.FamilyServiceImpl Invoke");
            persistence = new JSONPersistenceService(familiesPath);
        }

        public async Task DBSync()
        {
            ActionLog.Log($"/Database/{familiesPath} DBSync()");
            
            // Check if the file "families.json" is created
            if (!File.Exists(persistence.Path))
            {
                await persistence.CreateFile();
                
                //await FillFamilies();

                // Save changes
                await SaveData();
            }

            // Get the data from the JSON file
            _families = await persistence.ReadList<Family>();
        }

        public Family CreateFamily(string json)
        {
            Guid createdById = GetUserIdFromJson(json);
            Family emptyFamily = _families.Find(x => x.IsEmpty());
            if (emptyFamily == null)
            {
                emptyFamily = new Family(createdById);
                AddFamily(emptyFamily);
            }
            emptyFamily.HouseNumber = 0;
            return emptyFamily;
        }

        private async Task FillFamilies()
        {/*
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
            
            await AddFamily(f1);*/
        }

        public async Task AddFamily(Family family)
        {
            family.Id = _families.Any() ? _families.Max(thisFamily => thisFamily.Id) + 1 : 0;
            _families.Add(family);
            await SaveData();
            ActionLog.Log("/Database/families.json modified (create)");
        }

        public List<Family> GetFamilies()
        {
            return _families;
        }

        public List<Family> GetFamiliesCreatedById(string json)
        {
            return _families.Where(f => f.CreatedById == GetUserIdFromJson(json)).ToList();
        }
        

        public async Task RemoveFamily(int id)
        {
            _families.Remove(_families.Find(x => x.Id == id));
            await SaveData();
            ActionLog.Log("/Database/families.json modified (delete)");
        }
        public Family GetFamilyById(int id)
        {
            return _families.Find(x => x.Id == id);
        }

        public Family GetFamilyById(string id)
        {
            int myFamilyId = Int32.Parse(id);
            return GetFamilyById(myFamilyId);
        }

        public Adult GetAdultById(int familyId, int id)
        {
            Family myFamily = _families.Find(x => x.Id == familyId);
            if (myFamily != null)
            {
                return myFamily.Adults.Find(x => x.Id == id);   
            }

            return null;
        }

        public Pet GetFamilyPetById(int familyId, int id)
        {
            Family myFamily = _families.Find(x => x.Id == familyId);
            if (myFamily != null)
            {
                return myFamily.Pets.Find(x => x.Id == id);   
            }

            return null;
        }
        
        public Child GetChildById(int familyId, int id)
        {
            Family myFamily = _families.Find(x => x.Id == familyId);
            if (myFamily != null)
            {
                return myFamily.Children.Find(x => x.Id == id);   
            }

            return null;
        }

        public Adult GetAdultById(string familyId, string id)
        {
            int myFamilyId = Int32.Parse(familyId);
            int myAdultId = Int32.Parse(id);
            return GetAdultById(myFamilyId, myAdultId);
        }

        public Pet GetFamilyPetById(string familyId, string id)
        {
            int myFamilyId = Int32.Parse(familyId);
            int myPetId = Int32.Parse(id);
            return GetFamilyPetById(myFamilyId, myPetId);
        }

        public Child GetChildById(string familyId, string id)
        {
            int myFamilyId = Int32.Parse(familyId);
            int myChildId = Int32.Parse(id);
            return GetChildById(myFamilyId, myChildId);
        }

        private Guid GetUserIdFromJson(string json)
        {
            return Guid.Parse(JsonSerializer.Deserialize<User>(json).Id);
        }

        public async Task SaveData()
        {
            await persistence.WriteList(_families);
        }
    }
}