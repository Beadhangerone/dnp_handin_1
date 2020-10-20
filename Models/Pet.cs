using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Pet
    {
        public enum PetSpecies
        {
            Cat,
            Dog,
            Turtle,
            Parrot,
            DrunkFriend
        }
        public int Id { get; set; }
        [Required] public string Species { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int Age { get; set; }

        public void setPet(Pet pet)
        {
            Species = pet.Species;
            Name = pet.Name;
            Age = pet.Age;
        }
    }
}