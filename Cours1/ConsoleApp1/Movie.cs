using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Movie
    {
        private string _title;
        private int _releaseYear;
        private readonly List<Actor> _actors;
        private Director _director;

        public Movie(string title, int releaseYear)
        {
            this._title = title;
            this._releaseYear = releaseYear;
            _actors = new List<Actor>();
        }

        public string Title { get => _title; set => _title = value; }
        public int ReleaseYear { get => _releaseYear; set => _releaseYear = value; }
        public Director Director { 
            get => _director; 
            set {
                if (value == null)
                {
                    return;
                }
                _director = value;
                value.AddMovie(this);
            } 
        }

        public bool AddActor(Actor actor)
        {
            if (_actors.Contains(actor))
                return false;

            _actors.Add(actor);
            if (!actor.ContainsMovie(this))
                actor.AddMovie(this);

            return true;
        }

        public bool ContainsActor(Actor actor)
        { return _actors.Contains(actor); }

        public override string ToString()
        {
            return "Movie [title = " + Title + ", releaseYear = " + ReleaseYear + "]";
        }
    }
}
