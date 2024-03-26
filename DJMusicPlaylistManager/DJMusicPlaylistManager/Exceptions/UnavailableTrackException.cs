using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJMusicPlaylistManager.Exceptions
{
    internal class UnavailableTrackException : Exception
    {
        public UnavailableTrackException() : base("An error has occured")
        {
            Console.WriteLine("Sorry track not UnavaiableTrackException");
        }

        public UnavailableTrackException(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    }
}
