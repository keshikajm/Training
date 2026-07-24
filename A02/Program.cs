using System;
int n = new Random ().Next (1, 101);
Console.WriteLine ("Welcome to the Guess Game!");
int k = -1;

for (int i = 1;k!=n && k!=0 ; i++) {
   Console.Write ("Enter a number between 1 and 100: ");
   k = int.Parse (Console.ReadLine ());
   if (k == 0) {
      Console.WriteLine ($"The gamed ended. The number is {n}");
      
   }
   else if (k == n) {
      Console.WriteLine ("You guessed correctly");
      
   } 
   else if (k > n) {
      Console.WriteLine ("Your guess is too high");

   } 
   else {
      Console.WriteLine ("Your guess is too low");
   }
   if (i >= 7 && k!=n && k!=0) {
      Console.WriteLine ("You are exceeding the minimum required number of guesses. Guess Soon!, If you want to end the game and know the number, enter 0");
   }

}
Console.WriteLine ("Press Enter to close the game");
Console.ReadLine ();
