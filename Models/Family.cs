using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Models {
public class Family {
    [Required]
    public int Id { get; set; }
    [Required]
    public Guid CreatedById { get; set; }
    [Required]
    public string StreetName { get; set; }
    [Required]
    public int HouseNumber{ get; set; }
    public List<Adult> Adults { get; set; }
    public List<Child> Children{ get; set; }
    public List<Pet> Pets{ get; set; }

    public Family()
    {
        Adults = new List<Adult>();
        Children = new List<Child>();
        Pets = new List<Pet>();
    }

        public Family(Guid createdById)
    {
        CreatedById = createdById;
        Adults = new List<Adult>();
        Children = new List<Child>();
        Pets = new List<Pet>();
    }

    public string ShowAddress()
    {
        return $"{StreetName}, {HouseNumber}";
    }

        public string GetFamilyName()
        {
            return Adults.Count != 0 ? Adults[0].LastName : "";
        }

        public int GetNumberOfAdults()
        {
            return Adults.Count;
        }

        public int GetNumberOfChildren()
        {
            return Children.Count;
        }

        public int GetNumberOfPets()
        {
            int numOfPets = 0;
            numOfPets += Pets.Count;

            Children.Select(c => numOfPets += c.Pets.Count);

            return Children.Count;
        }

        public void AddAdult(Adult adult)
    { 
        adult.Id = Adults.Any() ? adult.Id = Adults.Max(thisAdult => thisAdult.Id) + 1 : 0;
        Adults.Add(adult);
    }

    public void AddChild(Child child)
    {
        child.Id = Children.Any() ? Children.Max(thisChild => thisChild.Id) + 1 : 0;
        Children.Add(child);
    }

    public void AddPet(Pet pet)
    {
        pet.Id = Pets.Any() ? Pets.Max(thisPet => thisPet.Id) + 1 : 0;
        Pets.Add(pet);
    }
    
    public void RemoveAdult(string id)
    {
        int adultId = Int32.Parse(id);
        Adults.Remove(Adults.Find(x=>x.Id == adultId));
    }
    
    public void RemovePet(string id)
    {
        int petId = Int32.Parse(id);
        Pets.Remove(Pets.Find(x=>x.Id == petId));
    }

    public void RemoveChild(string id)
    {
        int childID = Int32.Parse(id);
        Children.Remove(Children.Find(x => x.Id == childID));
    }

    public bool IsEmpty()
    {
        return !(Adults.Any() || Children.Any() || Pets.Any() || !String.IsNullOrEmpty(StreetName));
    }
}
}