using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using Sharpotify;

namespace Sharpotify
{
    class Program
    {
        private static bool exit = false;
        public static bool Exit { get { return exit; } set { exit = value; } }
        [STAThread()]
        static void Main(string[] args)
        {
            try
            {
                Application.EnableVisualStyles();
                Thread thrd = Thread.CurrentThread;
                thrd.Priority = ThreadPriority.Highest;
                if (args.Length > 0)
                {
                    if (args[0].ToLower() == "/allowdownloads")
                        Properties.Settings.Default.AllowDownloads = true;
                }
                //Forms.TestForm testForm = new Forms.TestForm();
                //Application.Run(testForm);
                Facade.Init();
                Forms.LoginForm loginForm = new Forms.LoginForm();
                MainForm mainForm = new MainForm();
                Application.Run(loginForm);
                if (!exit)
                    Application.Run(mainForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Unhandled exception");
            }
        }
        //static void Test()
        //{
        //    int clientVersion = 0x31700;
        //    int clientRevision = -789823211;//0xEC4115;
        //    //Console.Write("clientRevision: ");
        //    //string aux = Console.ReadLine();
        //    //if (!string.IsNullOrEmpty(aux))
        //    //    clientRevision = int.Parse(aux);
        //    SpotifyConnection connection = new SpotifyConnection(/*clientVersion, clientRevision,*/ new Sharpotify.Cache.FileCache(), new TimeSpan(0, 1, 0));
        //    Console.Write("Username: ");
        //    string username = Console.ReadLine();
        //    Console.Write("Password: ");
        //    string password = Console.ReadLine();
        //    try
        //    {
        //        connection.Login(username, password);
        //    }
        //    catch (Sharpotify.Exceptions.AuthenticationException ex)
        //    {
        //        Console.WriteLine("Unable to login: " + ex.Message);
        //        connection.Close();
        //        Console.ReadKey();
        //        return;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Unspected Exception: " + ex.Message);
        //        connection.Close();
        //        Console.ReadKey();
        //        return;
        //    }

           

        //    Sharpotify.Media.User user; 
        //    try
        //    {
        //        user = connection.User();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("TimeOut? " + ex.Message);
        //        connection.Close();
        //        Console.ReadKey();
        //        return;
        //    }
        //    if (user != null)
        //    {
        //        Console.WriteLine("USER INFO");
        //        Console.Write("Name: ");
        //        Console.WriteLine(user.Name);
        //        Console.Write("Country: ");
        //        Console.WriteLine(user.Country);
        //        Console.Write("Is premium: ");
        //        Console.WriteLine(user.IsPremium);
        //    }
        //    Sharpotify.Media.Result result = null;

        //    Console.Write("Search key: ");
        //    string searchKey = Console.ReadLine();

        //    bool success = false;
        //    Exception lastException = null;
        //    for (int i = 0; i < 3; i++)
        //    {
        //        try
        //        {
        //            result = connection.Search(searchKey); //rihanna
        //            success = true;
        //            break;
        //        }
        //        catch (Exception ex)
        //        {
        //            lastException = ex;
        //            Thread.Sleep(500);
        //        }
        //    }
        //    if (!success)
        //    {
        //        Console.WriteLine("Unable to search");
                
        //        if (lastException != null)
        //            Console.WriteLine(lastException.Message + "\n" + lastException.StackTrace);

        //        connection.Close();
        //        Console.ReadKey();
        //        return;
        //    }

        //    Console.WriteLine("SEARCH RESULT");
        //    Console.Write("Total no of tracks: ");
        //    Console.WriteLine(result.TotalTracks);

        //    for (int i = 0; i < 10 && i < result.TotalTracks; i++)
        //    {
        //        System.Console.WriteLine(result.Tracks[i].ToString());
        //    }

        //    int trackNo = 0;
        //    Console.Write("Select one track index: ");
        //    string aux = Console.ReadLine();
        //    if (!string.IsNullOrEmpty(aux))
        //        trackNo = int.Parse(aux);

        //    var playTrack = result.Tracks[trackNo];
        //    var trackResult = connection.Browse(playTrack);

        //    Console.WriteLine();
        //    Console.WriteLine("Playing track " + trackNo + ": " + trackResult.Artist.Name + " - " + trackResult.Title);

        //    try
        //    {
        //        var musicStream = connection.GetMusicStream(trackResult, trackResult.Files[0], new TimeSpan(0, 1, 0));



        //        Console.WriteLine("Wait for stream to fill ... press any key when bored");
        //        //Console.ReadKey();

        //        while (musicStream.AvailableLength < musicStream.Length || musicStream.Length == 0)
        //        {
        //            Console.WriteLine("Caching data : " + musicStream.AvailableLength + " / " + musicStream.Length);
        //            System.Threading.Thread.Sleep(1000);
        //        }
        //        Console.WriteLine("All cached");

        //        File.WriteAllBytes(@"test3.ogg", musicStream.GetBuffer());

        //        /*
        //        result = connection.Toplist(Sharpotify.Enums.ToplistType.TRACK, "SE", null);
        //        Console.WriteLine("TOPLIST RESULT");
        //        Console.Write("Top song in SE: ");
        //        Console.WriteLine(result.Tracks[0].ToString());

        //        Sharpotify.Media.PlaylistContainer playlists = connection.Playlists();
        //        Sharpotify.Media.Playlist playlist1 = connection.Playlist(playlists.Playlists[0].Id);
        //        var result2 = connection.Browse(playlist1.Tracks);
        //        var img = connection.Image("e4e4a70cedf5dbc18f69946f326fa34e206922b7");
        //        img.Save(@"c:\temp\img1.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
        //        */

        //        if (musicStream != null)
        //            musicStream.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Unable to download: " + ex.Message);
        //        Console.WriteLine(ex.StackTrace);
        //    }

        //    connection.Close();

        //    Console.ReadKey();
        //}
    }
}
