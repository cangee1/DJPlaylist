using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJMusicPlaylistManager.Exceptions
{
    public class PlaylistException : Exception
    {
        public PlaylistException() : base("An error occurred in the playlist")
        {
            Console.WriteLine("Test PlayListExeption");
        }

        public PlaylistException(string message) : base(message)
        {
            Console.WriteLine(message);     //Message from base exception will be out putted
        }
    }
}
