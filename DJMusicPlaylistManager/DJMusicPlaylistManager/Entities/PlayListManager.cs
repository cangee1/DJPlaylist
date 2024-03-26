using DJMusicPlaylistManager.Exceptions;
using DJMusicPlaylistManager.Interface;
using DJMusicPlaylistManager.MusicEntities;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJMusicPlaylistManager.Entities
{
    internal class PlayListManager
    {
        private List<Playlist> playlists = new List<Playlist>();             //List to organise and manage playlist
        private HashSet<Song> uniqueSongs = new HashSet<Song>();             //Set to ensure a uniqueness of songs within playlists does not allow duplicates

        public void CreatePlaylist(TextInterface textInterface)
        {
            if (playlists.Count == 0)
            {
                Console.WriteLine("No playlist found. Please create a new playlist.");
                string playlistName = textInterface.GetUserInput("Enter the name of your new playlist:");

                Playlist newPlaylist = new Playlist(playlistName, new List<Song>());
                playlists.Add(newPlaylist);
                Console.WriteLine($"Playlist '{newPlaylist}' has been created.");
            }
            else
            {
                string playlistName = textInterface.GetUserInput("Ënter the name of your new playlist");

                if (playlists.Any(p => p.Name.Equals(playlistName, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine($"Playlist '{playlistName}' already exists.");
                    return;
                }

                Playlist newPlaylist = new Playlist(playlistName, new List<Song>());
                playlists.Add(newPlaylist);
                Console.WriteLine($"Playlist '{playlistName}' created");
            }
        }

        public void AddSongToPlaylist(TextInterface textInterface, PlayListManager playlistManager)
        {
            string playlistName = textInterface.GetUserInput("Enter the name of the playlist:");

            // Check if the playlist exists
            if (!playlistManager.DoesPlaylistExist(playlistName))
            {
                Console.WriteLine($"Playlist '{playlistName}' does not exist please create a playlist");
                return;
            }

            Console.WriteLine("Enter your song details below");

            //Get user infor
            string title = textInterface.GetUserInput("Title: ");
            string artist = textInterface.GetUserInput("Artist: ");
            string album = textInterface.GetUserInput("Album: ");

            //Get valid genre
            Genre validGenre = textInterface.GetValidGenre();

            // Assuming you have a method to create a new Song instance
            Song newSong = new Song(title, artist, validGenre, album);

            Playlist playlist = playlists.Find(p => p.Name.Equals(playlistName, StringComparison.OrdinalIgnoreCase));
            if (playlist != null)
            {
                playlist.AddSong(newSong);
                Console.WriteLine($"Song '{newSong.Title}' added to playlist '{playlistName}'.");
            }
            else
            {
                Console.WriteLine($"Playlist '{playlistName}' not found.");
            }
        }

        public void DeleteSongFromPlaylist(TextInterface textInterface, PlayListManager playlistManager)
        {
            string playlistName = textInterface.GetUserInput("Enter the name of the playlist:");

            // Check if the playlist exists
            if (!playlistManager.DoesPlaylistExist(playlistName))
            {
                Console.WriteLine($"Playlist '{playlistName}' does not exist please create a playlist");
                return;
            }

            Playlist playlist = playlists.Find(p => p.Name.Equals(playlistName, StringComparison.OrdinalIgnoreCase));
            if (playlist != null)
            {
                string titleToRemove = textInterface.GetUserInput("Enter the title of the song you want to remove:");
                Song songToRemove = playlist.Songs.FirstOrDefault(song => song.Title.Equals(titleToRemove, StringComparison.OrdinalIgnoreCase));
                if (songToRemove != null)
                {
                    playlist.RemoveSong(songToRemove);
                    Console.WriteLine($"Song '{titleToRemove}' removed from playlist '{playlistName}'.");
                }
                else
                {
                    Console.WriteLine($"Song '{titleToRemove}' not found in playlist '{playlistName}'.");
                }
            }
            else
            {
                Console.WriteLine($"Playlist '{playlistName}' not found.");
            }
        }

        public void PlaySongsFromPlaylist(TextInterface textInterface, PlayListManager playlistManager)
        {
            string playlistName = textInterface.GetUserInput("Enter the name of the playlist:");

            // Check if the playlist exists
            if (!playlistManager.DoesPlaylistExist(playlistName))
            {
                Console.WriteLine($"Playlist '{playlistName}' does not exist please create a playlist");
                return;
            }

            Playlist playlist = playlists.Find(p => p.Name.Equals(playlistName, StringComparison.OrdinalIgnoreCase));

            if (playlist != null)
            {
                playlist.Play();
            }
            else
            {
                Console.WriteLine($"Playlist '{playlistName}' not found");
            }
        }

        public bool DoesPlaylistExist(string playlistName)
        {
            return playlists.Any(p => p.Name.Equals(playlistName, StringComparison.OrdinalIgnoreCase));
        }

        public void ListAllPlaylists()
        {
            Console.WriteLine($"Below is the list of playlists");
            foreach (var playlist in playlists)
            {
                Console.WriteLine($"- {playlist.Name}");
            }
        }

        public async void PlaySongFromFolder(string filePath)
        {
            if (File.Exists(filePath))
            {
                // Use NAudio to play the MP3
                using (var audioFile = new AudioFileReader(filePath))
                using (var outputDevice = new WaveOutEvent())

                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();

                    Console.WriteLine($"Now playing: {filePath}");

                    // Wait until the song finished playing
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        await Task.Delay(1000);
                    }
                }
            }
            else
            {
                Console.WriteLine($"Song 'songTitle' could not be found");
            }
        }

        public void AddSong(Song song)  //Addsong to uniqueSongs
        {
            uniqueSongs.Add(song);
        }
    }
}
