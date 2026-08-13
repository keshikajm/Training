// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2026.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Program to guess a user's number using high,low and correct respones.
// ------------------------------------------------------------------------------------------------
using static System.Console;

WriteLine ("Think of a number between 1 and 100. I'll try to guess it.\n" +
           "Enter H if my guess is low, L if my guess is high, C if correct or R to restart!");
int low = 1, high = 100;
while (low <= high) {
   int guess = (low + high) / 2;
   Write ($"Is your number {guess}? ");
   ConsoleKey answer = ReadKey (true).Key;
   switch (answer) {
      case ConsoleKey.H:
         PrintText ("H", ConsoleColor.Magenta);
         low = guess + 1; break;
      case ConsoleKey.L:
         PrintText ("L", ConsoleColor.Yellow);
         high = guess - 1; break;
      case ConsoleKey.R:
         PrintText ("R", ConsoleColor.DarkGray);
         low = 1; high = 100;
         WriteLine ("The game is starting over.");
         continue;
      case ConsoleKey.C:
         PrintText ("C", ConsoleColor.Green);
         PrintText ($"I guessed your number.The number is {guess}", ConsoleColor.Cyan);
         return;
      default:
         PrintText ("Invalid input!", ConsoleColor.Red);
         break;
   }
}

void PrintText (string text, ConsoleColor color) {
   ForegroundColor = color;
   WriteLine (text);
   ResetColor ();
}
