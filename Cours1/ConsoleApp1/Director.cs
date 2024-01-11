using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    internal class Director : Person
    {
        private static readonly long serialVersionUID = 5952964360274024205L;
        private List<Movie> _directedMovies;

        public Director(string name, string firstname, DateTime birthDate) : base(name, firstname, birthDate)
        { 
            _directedMovies = new List<Movie>();
        }

        public bool AddMovie(Movie movie)
        {
            if (movie == null || _directedMovies.Contains(movie))
            {
                return false;
            }

            movie.Director ??= this;

            _directedMovies.Add(movie);
            return true;
        }

        public IEnumerator<Movie> Movies()
        {
            return _directedMovies.GetEnumerator();
        }

    }
}
