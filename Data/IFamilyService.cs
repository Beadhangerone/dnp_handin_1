using System.Collections.Generic;
using Models;

namespace h1.Data
{
    public interface IFamilyService
    {
        void AddFamily(Family family);
        List<Family> GetFamilies();
        void RemoveFamily(int id);
        Family GetFamilyById(int id);
        Family GetFamilyById(string id);
        Adult GetAdultById(int familyId, int id);
        Adult GetAdultById(string familyId, string id);
        void SaveData();
    }
}