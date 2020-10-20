using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace h1.Data
{
    public interface IFamilyService
    {
        Task DBSync();
        Task AddFamily(Family family);
        List<Family> GetFamilies();
        Task RemoveFamily(int id);
        Family GetFamilyById(int id);
        Family GetFamilyById(string id);
        Adult GetAdultById(int familyId, int id);
        Adult GetAdultById(string familyId, string id);
        Pet GetFamilyPetById(string familyId, string id);
        Pet GetFamilyPetById(int familyId, int id);
        Task SaveData();
    }
}