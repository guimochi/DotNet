using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    internal class Actor : Person
    {
        private readonly long serialVersionUID = 1L;
        private readonly int _sizeInCentimeter;
        private readonly List<Movie> _movies;

        public Actor(string name, string firstname, DateTime birthDate, int sizeInCentimeter) : base(name, firstname, birthDate)
        {
            this._sizeInCentimeter = sizeInCentimeter;
            _movies = new List<Movie>();
        }

        public int SizeInCentimer { get { return _sizeInCentimeter; } }

        public override string ToString()
        {
            return base.ToString().Replace("birthdate", "sizeInCentimer = " + SizeInCentimer + ", birthdate");
        }

        
        public IEnumerator<Movie> Movies() { return _movies.GetEnumerator(); }

        public bool AddMovie(Movie movie)
        {
            if (movie == null || _movies.Contains(movie)) return false;

            if (!movie.ContainsActor(this)) return false;

            _movies.Add(movie);

            return true;
            
        }

        public bool ContainsMovie(Movie movie)
            { return _movies.Contains(movie); }

        public override string Name => base.Name.ToUpper();
    }
}
