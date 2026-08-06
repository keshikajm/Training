// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2026.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Program to guess a user's number using binary remainder logic and yes/no questions.
// ------------------------------------------------------------------------------------------------
using static System.Console;

WriteLine ("Think of a number between 1 and 100, I'll guess it!\n" +
           "Type 'Y' for yes and 'N' for no!");
int number = 0, divisor = 2, remainder = 1, i = 0;
while (i < 7) {
   Write ($"Is the remainder when divided by {divisor} >= {remainder} ? ");
   string answer = (ReadLine () ?? "").ToUpper ();
   if (answer != "Y" && answer != "N") {
      WriteLine ("Invalid input!");
      continue;
   }
   if (answer == "Y") number += remainder;
   divisor *= 2;
   remainder *= 2;
   i++;
}
WriteLine ($"The number you thought of is {number}");