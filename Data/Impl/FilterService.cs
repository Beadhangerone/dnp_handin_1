using System;
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
            Console.WriteLine(families.Count);
            List<Person> persons = new List<Person>();
            searchString = searchString.ToLower();
            foreach (Family family in families)
            {
                persons.AddRange(family.Adults.Where(a => $"{a.FirstName} {a.LastName}".ToLower().Contains(searchString) || $"{a.LastName} {a.FirstName}".ToLower().Contains(searchString)).ToList());
                persons.AddRange(family.Children.Where(a => $"{a.FirstName} {a.LastName}".ToLower().Contains(searchString) || $"{a.LastName} {a.FirstName}".ToLower().Contains(searchString)).ToList());
            }
            return persons;
        }
    }
}