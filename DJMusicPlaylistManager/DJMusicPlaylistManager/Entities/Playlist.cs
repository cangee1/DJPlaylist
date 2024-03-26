using DJMusicPlaylistManager.Entities;

namespace DJMusicPlaylistManager.MusicEntities
{
    internal class Playlist
    {
        public string Name { get; set; }
    

        public Playlist(string name)
        {
            Name = name;
        }

        public List<Song> songs { get; set; } = new List<Song>();

        public List<Song> Songs
        {
            get { return songs; }
            set { songs = value; }
        }
        
        public Playlist(string name, List<Song> songs)
        {
            Name = name;
            Songs = songs;
        }
        public void AddSong(Song song)             
        {
            //Implementation to add a song to the playlist
            if (!songs.Contains(song))
            {
                songs.Add(song);
                Console.WriteLine($"Added {song.Title} to the playlist: {Name} ");         
            }
            else
            {
                Console.WriteLine($"The song {song.Title} is already in the playlist: {Name} ");
            }
        }

        public void RemoveSong(Song song)                       
        {
            //Implementation to remove a song from the playlist
            if (songs.Contains(song))
            {
                songs.Remove(song);
                Console.WriteLine($"Removed {song.Title} from the playlist: {Name} ");
            }
            else
            {
                Console.WriteLine($"The song {song.Title} is already in the playlist: {Name} ");
            }
        }
        public void Play()
        {
            //Implementation to play a playlist (play all songs)
            Console.WriteLine($"Now playing playlist: {Name}");
            foreach (var song in songs)
            {
                song.Play();
            }
        }

        public void ListAllSongs()
        {
            Console.WriteLine($"List of all your songs below:");
            foreach (var song in songs)
            {
                Console.WriteLine($"- {song.Title} by {song.Artist}");
            }
        }
    }
}
