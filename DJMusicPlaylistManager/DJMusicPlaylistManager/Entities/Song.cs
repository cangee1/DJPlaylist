using DJMusicPlaylistManager.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJMusicPlaylistManager.MusicEntities
{
    internal class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        
        public Genre Genre { get; set; }       

        public Song(string title, string artist, Genre genre, string album)
        {
            Title = title;
            Artist = artist;
            Album = album;
            Genre = genre;  
        }

        public void Play()
        {
            //Implementation to play a song
            Console.WriteLine($"Now playing: {Title} by {Artist}");
        }
    }
}
