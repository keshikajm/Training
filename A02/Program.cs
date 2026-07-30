using static System.Console;
int n = new Random ().Next (1, 101);
WriteLine ("Welcome to the Guess Game!");
int k = -1;
for (int i = 1; k != n && k != 0; i++) {
   Write ("Enter a number between 1 and 100: ");
   string input = ReadLine ();
   int guess;
   if (!int.TryParse (input, out guess)) {
      WriteLine ("Invalid input! Please enter a whole number.");
      i--;
      continue;
   }
   if (guess < 0 || guess > 100) {
      WriteLine ("Invalid input! Enter a number between 1 and 100, or 0 to quit.");
      i--;    
      continue;
   }
   if (k == 0) WriteLine ($"The gamed ended. The number is {n}");
   else if (k == n) WriteLine ("You guessed correctly");
   else if (k > n) WriteLine ("Your guess is too high");
   else WriteLine ("Your guess is too low");
   if (i >= 7 && k != n && k != 0) WriteLine ("You are exceeding the minimum required number of guesses. Guess Soon!, " +
         "If you want to end the game and know the number, enter 0");
}
WriteLine ("Press Enter to close the game");
ReadLine ();
