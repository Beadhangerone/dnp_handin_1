using System.Collections.Generic;
using System.Linq;
using Models;
 

namespace h1.Data.Impl
{
    public class FilterService : IFilterService
    {
        public IFamilyService familyService;
        public FilterService(IFamilyService _familyService)
        {
            familyService = _familyService;
        }
        
        public List<Person> findPersonByName(string searchString)
        {
            List<Family> families = familyService.GetFamilies(); 
            List<Person> persons = new List<Person>();
            foreach (Family family in families)
            {
                persons.AddRange(family.Adults.Where(a => $"{a.FirstName} {a.LastName}".Contains(searchString) || $"{a.LastName} {a.FirstName}".Contains(searchString)));
                persons.AddRange(family.Children.Where(a => $"{a.FirstName} {a.LastName}".Contains(searchString) || $"{a.LastName} {a.FirstName}".Contains(searchString)));
            }
            return persons;
        }
    }
}