using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Models {
public class Family {
    [Required]
    public int Id { get; set; }
    [Required]
    public string StreetName { get; set; }
    [Required]
    public int HouseNumber{ get; set; }
    public List<Adult> Adults { get; set; }
    public List<Child> Children{ get; set; }
    public List<Pet> Pets{ get; set; }

    public Family() {
        Adults = new List<Adult>();     
        Children = new List<Child>();
        Pets = new List<Pet>();
    }

    
    
    public string ShowAddress()
    {
        return $"{StreetName}, {HouseNumber}";
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
        Adults.Remove(Adults[adultId]);
    }
    
}


}