// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2026.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Program to guess a user's number using binary remainder logic and yes/no questions.
// ------------------------------------------------------------------------------------------------
using static System.Console;

WriteLine ("Think of a number between 0 and 127, I'll guess it!\n" +
           "Type 'Y' for yes and 'N' for no!");
int number = 0, divisor = 2, remainder = 1, i = 0;
for (; i < 7; i++) {
   Write ($"When divided by {divisor}, is the remainder >= {remainder} ? ");
   ConsoleKey answer = ReadKey (true).Key;
   switch (answer) {
      case ConsoleKey.Y:
         StringColor ("Y", ConsoleColor.Yellow);
         number += remainder; break;
      case ConsoleKey.N:
         StringColor ("N", ConsoleColor.Cyan);
         break;
      default:
         StringColor ("Invalid Input", ConsoleColor.Red); WriteLine ();
         i--; continue;
   }
   WriteLine ();
   divisor *= 2; remainder *= 2;
}
StringColor ($"The number you thought of is {number}", ConsoleColor.Green);
void StringColor (string text, ConsoleColor color) {
   ForegroundColor = color;
   Write (text);
   ResetColor ();
}