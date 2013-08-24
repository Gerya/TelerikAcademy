using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

public static class Intro
{
    public static void printIntro()
    {
        int defaultWidth = Console.WindowWidth;
        int defaultHeight = Console.WindowHeight;

        Console.BufferWidth = Console.WindowWidth = 92;
        Console.BufferHeight = Console.WindowHeight = 53;
        int shiftRight = 15; //shuttle shift right
        List<string> introPicMain = readFile("IntroPicMain.txt");
        List<string> introPicFlames1 = readFile("IntroPicFlames_1.txt");
        List<string> introPicFlames2 = readFile("IntroPicFlames_2.txt");
        List<string> introText1 = readFile("IntroText1.txt");
        List<string> introText2 = readFile("IntroText2.txt");
        Console.ForegroundColor = ConsoleColor.White;                

        // ENTERING GAME TITLE

        //part 1
        //Console.SetCursorPosition(10, 19);

        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Clear();
        foreach (var line in introText1)
        {
            //Console.CursorLeft = 8;          
            Console.WriteLine(line.TrimEnd());
        }
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;

        //part 2
        Console.SetCursorPosition(20, 26);

        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Red;
        foreach (var line in introText2)
        {
            Console.CursorLeft = 20;
            Console.WriteLine(line.TrimEnd());
        }

        Console.CursorVisible = false;
        int row = Console.CursorTop;
        //press any key to start
        Console.ForegroundColor = ConsoleColor.White;
        for(int i = 1; ; i *= -1)
        {
            Console.SetCursorPosition(31, row+1);
            if (i == -1)
            {
                //Console.CursorLeft = 31;
                Console.WriteLine("Press any key to start...");
            }
            else
            {
                Console.WriteLine("                         ");
            }
            if (!Console.KeyAvailable)
            {
                Thread.Sleep(500);
            }
            else
            {
                break;
            }
        }
        //Console.ReadKey();
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();

        //Main image

        //Main shuttle
        //Console.BufferWidth = Console.WindowWidth = 66;
        //Console.BufferHeight = Console.WindowHeight = 53;                  
        
        byte bgFlagCounter = 1;
        foreach (var line in introPicMain)
	    {
                Console.CursorLeft = shiftRight;
                if (line.Any<char>(a => a == '='))
                {
                    foreach (var letter in line)
                    {
                        if (letter == '=')
                        {
                            if (bgFlagCounter == 1) Console.ForegroundColor = ConsoleColor.White;
                            if (bgFlagCounter == 2) Console.ForegroundColor = ConsoleColor.Green;
                            if (bgFlagCounter == 3) Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(letter);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(letter);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    bgFlagCounter++;
                    Console.WriteLine();
                }
                else Console.WriteLine(line);
            }                    

        //Flames animation
        for (int i = 0; i < 50; i++)
        {
            Console.SetCursorPosition(shiftRight, 44);
            if (i % 2 == 0)
            {
                foreach (var line in introPicFlames1)
                {
                    Console.CursorLeft = shiftRight;
                    if (line.Any<char>(a => a == '*'))
                    {
                        foreach (var letter in line)
                        {
                            if (letter == '*')
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(letter);

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(letter);
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                foreach (var line in introPicFlames2)
                {
                    Console.CursorLeft = shiftRight;
                    if (line.Any<char>(a => a == '*'))
                    {
                        foreach (var letter in line)
                        {
                            if (letter == '*')
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(letter);

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(letter);
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                    }
                }
            }
            Thread.Sleep(30);
        }
        Console.SetCursorPosition(0, 0);
        Console.BufferWidth = Console.WindowWidth = defaultWidth;
        Console.BufferHeight = Console.WindowHeight = defaultHeight;
        Console.Clear();
    }

    private static List<string> readFile(string fileName)
    {
        List<string> newList = new List<string>();

        using (StreamReader reader = new StreamReader(@"..\..\" + fileName))
        {

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                newList.Add(line);
            }
        }
        return newList;
    }
}

