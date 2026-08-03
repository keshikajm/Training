// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2026.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Program to implement a number guessing game with random number generation, user input
// validation, guessing hints, and quit functionality.
// ------------------------------------------------------------------------------------------------
using static System.Console;

int randomNumber = new Random ().Next (1, 101);
WriteLine ("Welcome to the Guess Game! Guess the number between 1 and 100.\n" +
           "Enter 0 anytime to quit and reveal the secret number.\n");
int guess = -1;
for (int i = 1; guess != randomNumber && guess != 0; i++) {
   Write ("Enter a number between 1 and 100: ");
   if (!int.TryParse (ReadLine (), out int parsedGuess) || parsedGuess < 0 || parsedGuess > 100) {
      WriteLine ("Invalid input! Enter a whole number between 1 and 100, or 0 to quit.");
      i--; continue;
   }
   guess = parsedGuess;
   if (guess == 0) WriteLine ($"The game ended. The number is {randomNumber}");
   else WriteLine (guess == randomNumber ? "You guessed correctly"
                                         : guess > randomNumber ? "Your guess is too high"
                                                                : "Your guess is too low");
   if (i >= 7 && guess != randomNumber && guess != 0)
      WriteLine ("You are exceeding the minimum number of guesses.\n" +
                 "Guess soon or enter 0 to quit!");
}