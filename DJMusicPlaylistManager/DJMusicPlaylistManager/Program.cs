using DJMusicPlaylistManager.Exceptions;
using DJMusicPlaylistManager.MusicEntities;
using DJMusicPlaylistManager.Entities;
using System;
using DJMusicPlaylistManager.Interface;

class Program
{
    static void Main()
    {
        TextInterface textInterface = new TextInterface();
        PlayListManager playlistManager = new PlayListManager();
        Playlist playlist = new Playlist("MyPlaylist");

        try
        {
            textInterface.MainMenu(playlistManager, playlist, textInterface);
        }
        catch (PlaylistException ex)
        {
            Console.WriteLine($"Playlist Exception: {ex.Message} ");
        }
        catch (UnavailableTrackException ex) 
        {
            Console.WriteLine($"Unavailable Track Exception: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error occured: {ex.Message}");
        }
    }
}