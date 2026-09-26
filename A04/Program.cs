// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2026.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Program builds a letter frequency table from the word list using a Dictionary, then displays
// the 7 most frequently occurring letters in descending order.
// ------------------------------------------------------------------------------------------------
using static System.Console;

Dictionary<char, int> frequency = [];
foreach (string word in File.ReadLines ("spellbee_wordlist.txt")) {
   foreach (char c in word.ToUpper ()) {
      char upper = char.ToUpperInvariant (c);
      if (c >= 'A' && c <= 'Z') frequency[upper] = frequency.GetValueOrDefault (upper) + 1;
   }
}
foreach (var letter in frequency.OrderByDescending (x => x.Value).Take (7))
   WriteLine ($"{letter.Key} : {letter.Value}");
