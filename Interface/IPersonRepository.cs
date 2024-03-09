using System;
using System.Collections.Generic;

public interface IPersonRepository
{
    Task<IEnumerable<Person>> GetAll();
    Task<Person> GetPersonByName(string name);
    Task<IEnumerable<Person>> GetPersonByPersonType(string personType);
    Task<IEnumerable<Person>> GetPersonByNameAndPersonType(string name, string personType);
}