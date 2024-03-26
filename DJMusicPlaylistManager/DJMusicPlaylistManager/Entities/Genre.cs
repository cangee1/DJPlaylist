using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJMusicPlaylistManager.Entities
{
    internal class Genre
    {
        //The name of the genre
        public string GenreName { get; }

        // Constructor for Genre 
        public Genre(string genreName)
        {
            GenreName = genreName;
        }
        
        // Check if the genre name is valid
        public static bool IsGenreValid(string genreName)
        {
            // Add your valid genres here
            string[] validGenres = { "Dance Hall", "Hip Hop", "Jazz", "Pop", "Reggae" };

            //Check in the given name if the genre is valid in the array
            return validGenres.Contains(genreName, StringComparer.OrdinalIgnoreCase);
        }
    }
}

