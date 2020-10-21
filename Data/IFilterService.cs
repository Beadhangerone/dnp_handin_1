using System.Collections.Generic;
using Models;

namespace h1.Data
{
    public interface IFilterService
    {
        List<Person> findPersonByName(string name);
    }
}