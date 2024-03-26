using DJMusicPlaylistManager.Entities;
using DJMusicPlaylistManager.MusicEntities;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJMusicPlaylistManager.Interface
{
    internal class TextInterface
    {

        public void MainMenu(PlayListManager playlistManager, Playlist playlist, TextInterface textInterface)
        {
            bool exit = false;

            while(!exit) 
            { 

            Console.WriteLine("Main Menu\n");
            Console.WriteLine("1 - Add Song");
            Console.WriteLine("2 - Delete Song From Songs");
            Console.WriteLine("3 - Lists All Songs");
            Console.WriteLine("4 - Create Playlist");
            Console.WriteLine("5 - Add Song To Playlist");
            Console.WriteLine("6 - Delete Song From Playlist");
            Console.WriteLine("7 - List All Playlists");
            Console.WriteLine("8 - Play Playlist");
            Console.WriteLine("9 - Play Song");
            Console.WriteLine("10 - Exit");

            string choice = GetUserInput("Please enter your choice (1-8): ");

                switch (choice)
                {
                    case "1":
                        AddSongByTitle(playlist);
                        break;
                    case "2":
                        RemoveSongByTitle(playlist);
                        break;
                    case "3":
                         playlist.ListAllSongs();
                        break;
                    case "4":
                        playlistManager.CreatePlaylist(textInterface);
                        break;
                    case "5":
                        playlistManager.AddSongToPlaylist(textInterface, playlistManager);                                        
                        break;
                    case "6":
                        playlistManager.DeleteSongFromPlaylist(textInterface, playlistManager);                                            
                        break;
                    case "7":
                        playlistManager.ListAllPlaylists();                                                   
                        break;
                    case "8":
                        playlistManager.PlaySongsFromPlaylist(textInterface, playlistManager);
                        break;
                    case "9":
                        PlaySongFile(playlistManager);
                        break;
                    case "10":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice please choose again");
                        break;
                }
            }
        }
        public string GetUserInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        public bool IsUserInput(string prompt)
        {
            Console.WriteLine(prompt);
            string userInput = Console.ReadLine().ToLower();
            return userInput == "yes";
        }

        public void AddSongByTitle(Playlist playlist)
        {
           // Genre genre = null;

            Console.WriteLine("Enter your song details below");
         
            //Get user infor
            string title = GetUserInput("Title: ");
            string artist = GetUserInput("Artist: ");
            string album = GetUserInput("Album: ");
                
            //Get valid genre
            Genre validGenre = GetValidGenre();

            // Add new song to the playlist
            Song newSong = new Song(title, artist, validGenre, album);

            playlist.AddSong(newSong);

        }
        
        public void RemoveSongByTitle(Playlist playlist)
        {
            string titleToRemove = GetUserInput("Enter the song you would like to remove from your song list");

            //Temp song object to provide title
            Song songToRemove = playlist.Songs.FirstOrDefault(song => song.Title.Equals(titleToRemove, StringComparison.OrdinalIgnoreCase));

            if (songToRemove != null)
            {
                playlist.RemoveSong(songToRemove);
            }
            else
            {
                Console.WriteLine($"Song '{titleToRemove}' not found in your songs");
            }
        }

        public void PlaySongFile(PlayListManager playlistManager)
        {
            string filePath = @"C:\\Users\\GeorgeCant\\source\\repos\\C#\\DJMusicPlaylistManager\\DJMusicPlaylistManager\\MusicFiles\\Closer.mp3";
            string titleToPlay = GetUserInput("Enter the title of the song to play: ");

            // check filname without extension
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
            if (titleToPlay.Equals(fileNameWithoutExtension, StringComparison.OrdinalIgnoreCase))
            {            
                playlistManager.PlaySongFromFolder(filePath);
            }
            else
            {
                playlistManager.PlaySongFromFolder(titleToPlay);
            }
        }
        
        // Get valid Genre
        public Genre GetValidGenre()
        {
            while (true)
            {
                // Get genre as string from user input
                string genreString = GetUserInput("Genre: ");

                // Convert genre string to Genre instance
                Genre genre = new Genre(genreString);

                if (Genre.IsGenreValid(genre.GenreName))
                {
                    return genre;
                }
                else
                {
                    Console.WriteLine("Invalid genre, Please select one of the following- Dance Hall, Hip Hop, Jazz, Pop, Reggae");
                }
            }
        }

        public void GetSongs(PlayListManager playlistManager)
        {
            Console.WriteLine("Enter your song details below");

            //Get user infor
            string title = GetUserInput("Title: ");
            string artist = GetUserInput("Artist: ");
            string album = GetUserInput("Album: ");

            //Get valid genre
            Genre validGenre = GetValidGenre();

            // Add new song to the playlist
            Song newSong = new Song(title, artist, validGenre, album);

            playlistManager.AddSong(newSong);       //Stores song to uniqueSongs
        }
    }
}
