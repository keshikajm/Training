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
   ConsoleKey answer = ReadKey ().Key;
   WriteLine ();
   switch (answer) {
      case ConsoleKey.Y:
         number += remainder; break;
      case ConsoleKey.N:
         break;
      default:
         WriteLine ("Invalid input!");
         i--; continue;
   }
   divisor *= 2; remainder *= 2;
}
WriteLine ($"The number you thought of is {number}");