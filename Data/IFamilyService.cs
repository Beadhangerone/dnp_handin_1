using System.Collections.Generic;
using Models;

namespace h1.Data
{
    public interface IFamilyService
    {
        void CreateFamily();
        List<Family> GetFamilies();
        void RemoveFamily(int id);

    }
}