// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2026.
// Copyright (c) Metamation India.
// -----------------------------------------------------------------------s------------------------
// Program.cs
// Program to guess a user's number using high, low, correct responses, restart the game in case
// of inconsistent responses and allow the user to play again or exit the game.
// ------------------------------------------------------------------------------------------------
using static System.Console;

bool showInstructions = true;
while (true) {
   bool restart = PlayGame (ref showInstructions);
   if (restart) continue;
   if (!PlayAgain (ref showInstructions)) return;
}

bool PlayGame (ref bool showInstructions) {
   var range = (low: 1, high: 100);
   bool restart = false;
   if (showInstructions) {
      WriteLine ("Think of a number between 1 and 100. I'll try to guess it.\n" +
                 "Enter H if your number is higher than my guess,\n" +
                 "      L if your number is lower than my guess,\n" +
                 "      C if my guess is correct, or\n" +
                 "      R to restart the game!\n");
      showInstructions = false;
   }
   while (range.low <= range.high) {
      int guess = (range.low + range.high) / 2;
      Write ($"Is your number {guess}? ");
      ConsoleKey answer = ReadKey (true).Key;
      switch (answer) {
         case ConsoleKey.H:
            PrintText ("H", ConsoleColor.Magenta);
            range.low = guess + 1; break;
         case ConsoleKey.L:
            PrintText ("L", ConsoleColor.Yellow);
            range.high = guess - 1; break;
         case ConsoleKey.R:
            PrintText ("R\n", ConsoleColor.DarkGray);
            WriteLine ("The game is starting over.\n");
            restart = true; range = (0, -1); break;
         case ConsoleKey.C:
            PrintText ("C", ConsoleColor.Green);
            PrintText ($"I guessed your number. The number is {guess}.\n", ConsoleColor.Cyan);
            restart = false; range = (0, -1); break;
         default:
            PrintText ("Invalid input!", ConsoleColor.Red);
            continue;
      }
      if (range.low > range.high && !restart && answer != ConsoleKey.C) {
         WriteLine ("Your responses are inconsistent. No number satisfies the responses.\n");
         break;
      }
   }
   return restart;
}

bool PlayAgain (ref bool showInstructions) {
   while (true) {
      Write ("Play again?(Y/N): ");
      ConsoleKey playAgain = ReadKey (true).Key;
      switch (playAgain) {
         case ConsoleKey.Y:
            PrintText ("Y\n", ConsoleColor.Blue);
            showInstructions = true; return true;
         case ConsoleKey.N:
            PrintText ("N", ConsoleColor.DarkBlue);
            return false;
         default:
            PrintText ("Invalid input!", ConsoleColor.Red);
            continue;
      }
   }
}

void PrintText (string text, ConsoleColor color) {
   ForegroundColor = color;
   WriteLine (text);
   ResetColor ();
}
