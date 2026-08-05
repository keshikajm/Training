// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2026.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Program to implement a number guessing game with random number generation, user input
// validation, guessing hints, and quit functionality.
// ------------------------------------------------------------------------------------------------
using static System.Console;

int randomNum = new Random ().Next (1, 101), guess = 0;
const int quit = -1;
WriteLine ("Welcome to the Guess Game! Guess the number between 1 and 100.\n" +
           "Enter -1 anytime to quit and reveal the secret number.\n");
for (int i = 1; guess != randomNum && guess != quit; i++) {
   Write ("Enter a number between 1 and 100: ");
   if (!int.TryParse (ReadLine (), out guess) || guess < 1 || guess > 100) {
      WriteLine (guess == quit ? $"The game ended. The number is {randomNum}" : $"Invalid input!");
      i--; continue;
   }
   WriteLine (guess == randomNum ? "You guessed correctly"
                                 : guess > randomNum ? "Your guess is too high"
                                                     : "Your guess is too low");
   if (i >= 7 && guess != randomNum && guess != quit)
      WriteLine ("You are exceeding the minimum number of guesses.\n" +
                 "Guess soon or enter -1 to quit!");
}