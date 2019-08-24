using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using EFDPusher.App;
using System.Threading;


namespace EFDPusher
{
    class Program
    {
        private MainController mainController;

        static void Main(string[] args)
        {
            //mainController = MainController;
            Console.WriteLine("\n ------------------------------------");
            Console.WriteLine("   EFD PUSHER\n   + By GrandMaster\n   + email:grand123grand1@gmail.com\n   + phone:+255688 059 688");
            Console.WriteLine("\n ------------------------------------");
            Console.WriteLine("\n Listening .. ");
            run();
            Console.Read();
        }
        static void run() {
            try {
                MainController mainController = new MainController();
                //watch a path
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = mainController.getConfigurations().source_path;
                watcher.Filter = "*.txt";

                //event handlers
                watcher.Created += new FileSystemEventHandler(new_watcher_Created);
                watcher.EnableRaisingEvents = true;
            }catch(Exception ex){
                Console.WriteLine("[ EXCEPTION ] " + ex.Message);
            }

        }

        static void new_watcher_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                //throw new NotImplementedException();
                Console.WriteLine("[ NEW ] " + e.Name + " :: " + e.FullPath);//e

                Thread.Sleep(1500);
                //read the content of the file and push
                string data = File.ReadAllText(e.FullPath);

                Pusher pusher = new Pusher();
                pusher.push(e.Name, e.FullPath, data);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ EXCEPTION ] " + ex.Message);
            }
            
        }


    }
}
