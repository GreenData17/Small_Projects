﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sys = Cosmos.System;

namespace CubyOS
{
    public class UserManager
    {
        public void Login()
        {
            if (!Directory.Exists(@"0:\System"))
            {
                Setup();
            }
            else
            {
                Console.Clear();
                string[] s = Directory.GetDirectories(@"0:\");
                foreach(string st in s)
                {
                    Console.WriteLine(st);
                }
                Console.WriteLine("# LOGIN #");
                Console.WriteLine();
                Console.Write("Username: ");
                string u = Console.ReadLine();
                if(u == "F12_55") { Directory.Delete(@"0:\System", true); Sys.Power.Reboot(); }
                Console.Clear();
                Console.WriteLine("# LOGIN #");
                Console.WriteLine();
                Console.Write("Password: ");
                string p = Console.ReadLine();

                string[] us = File.ReadAllLines(@"0:\System\users.sys");  //Problem on reading is here!
                if (us[0] != $"{u} {p}")
                { 
                    Sys.Power.Reboot();
                }
                else
                {
                    Console.WriteLine(File.ReadAllText(@"0:\System\welcome.txt"));
                }
            }    
        }

        public void Setup()
        {
            Console.Clear();
            Console.WriteLine("# SETUP #");
            Console.WriteLine();
            Console.Write("Username: ");
            string u = Console.ReadLine();
            if (u == "F12_55") { Sys.Power.Reboot(); }
            Console.Clear();
            Console.WriteLine("# SETUP #");
            Console.WriteLine();
            Console.Write("Password: ");
            string p = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("# SETUP #");
            Console.WriteLine();
            Console.Write("repeat Password: ");
            string rp = Console.ReadLine();

            if(p != rp)
            {
                Sys.Power.Reboot();
            }

            Directory.CreateDirectory(@"0:\System");
            File.WriteAllText(@"0:\System\users.sys", $"{u} {p}");
            File.WriteAllText(@"0:\System\welcome.txt", "Welcome to CubyOS!");
            Directory.CreateDirectory($@"0:\{u}\dokument");
            Console.Write("Press any Key to Reboot...");
            Sys.Power.Reboot();
        }
    }
}
