using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class GameOver
{   
    public static void PrintGameOver()
    {
        Console.SetCursorPosition(0, Console.WindowHeight / 2-3);
        Console.ForegroundColor = ConsoleColor.Red;
        List<string> gameOverText = new List<string>();
        using (StreamReader reader = new StreamReader(@"..\..\GameOverText.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                gameOverText.Add(line);
            }
        }
        foreach (var line in gameOverText)
        {
            Console.WriteLine(line);
        }
        Console.CursorVisible = false;
        Console.ResetColor(); 
    }
}
