using System.Collections.Generic;
using System.Linq;
using h1.Models;

namespace Models {
public class Child : Person {
    
    public List<ChildInterests> ChildInterests { get; set; }
    public List<Pet> Pets { get; set; }

    public void Update(Child toUpdate) {
        base.Update(toUpdate);
        ChildInterests = toUpdate.ChildInterests;
        Pets = toUpdate.Pets;
    }
    
    public void AddPet(Pet pet)
    {
        pet.Id = Pets.Any() ? Pets.Max(thisPet => thisPet.Id) + 1 : 0;
        Pets.Add(pet);
    }

}
}