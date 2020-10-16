using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models {
public class Family {
    
    //public int Id { get; set; }
    [Required]
    public string StreetName { get; set; }
    [Required]
    public int HouseNumber{ get; set; }
    public List<Adult> Adults { get; set; }
    public List<Child> Children{ get; set; }
    public List<Pet> Pets{ get; set; }

    public Family() {
        Adults = new List<Adult>();     
    }

    public string ShowAddress()
    {
        return $"{StreetName}, {HouseNumber}";
    }

    public void AddAdult(Adult adult)
    {
        Adults.Add(adult);
    }

    public void AddChild(Child child)
    {
        Children.Add(child);
    }

    public void AddPet(Pet pet)
    {
        Pets.Add(pet);
    }
}


}