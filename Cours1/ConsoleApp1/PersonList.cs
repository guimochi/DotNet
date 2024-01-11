using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class PersonList
    {
        private static PersonList _instance;
        private readonly IDictionary<string, Person> _personDict;

        private PersonList()
        {
            _personDict = new Dictionary<string, Person>();
        }

        public static PersonList Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PersonList();
                }
                return _instance;
            }
        }

        public void AddPerson(Person person)
        {
            if (person == null)
                throw new ArgumentException();
            _personDict.Add(person.Name, person);
        }

        public IEnumerator<Person> personList() 
        {
            return _personDict.Values.GetEnumerator();
        }

    }
}
