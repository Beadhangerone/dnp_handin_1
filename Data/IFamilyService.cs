using System.Collections.Generic;
using Models;

namespace h1.Data
{
    public interface IFamilyService
    {
        void CreateFamily();
        List<Family> GetFamilies();
        void RemoveFamily(int id);

        Family GetFamilyById(int id);
        Family GetFamilyById(string id);
        Adult GetAdultById(string id);
        Child GetChildById(string id);
        Pet GetPetById(string id);

        void SaveData();
    }
}