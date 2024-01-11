using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Actors
{
    internal class Person
    {
        private const long serialVersionUID = 1L;

        private readonly String name;
	private readonly String firstname;
	private readonly DateTime birthDate;
	
	public String getName()
        {
            return name;
        }

        public String getFirstname()
        {
            return firstname;
        }

        public String getBirthDate()
        {
            DateTime dateFormat = new DateTime();
            dateFormat.GetDateTimeFormats(birthDate);
            dateFormat.setTimeZone(birthDate.getTimeZone());
            return dateFormat.format(birthDate.getTime());

            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(birthDate.TimeZone.Id);
            DateTime birthDateTime = TimeZoneInfo.ConvertTimeFromUtc(birthDate.UtcDateTime, timeZone);
            string formattedDate = birthDateTime.ToString("dd-MM-yyyy");
            return formattedDate;
        }


        public Person(String name, String firstname, Calendar birthDate)
        {
            this.name = name;
            this.firstname = firstname;
            this.birthDate = birthDate;
        }

    public String toString()
        {
            SimpleDateFormat dateFormat = new SimpleDateFormat("dd-MM-yyyy");
            dateFormat.setTimeZone(birthDate.getTimeZone());
            return "Person [name = " + name + ", firstname = " + firstname + ", birthDate =  " + getBirthDate() + "]";
        }
    }
}
