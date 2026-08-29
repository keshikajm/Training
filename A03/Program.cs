// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2026.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Program to find all valid Spelling Bee words from a dictionary, calculate their scores,
// identify pangrams, and display the results in descending order of score.
// ------------------------------------------------------------------------------------------------
using static System.Console;

char[] letters = ['U', 'X', 'A', 'L', 'T', 'N', 'E'];
char req = letters[0];
string[] words = File.ReadAllLines ("spellbee_wordlist.txt");
List<(string word, int score, bool pangram)> results = [];

foreach (string line in words) {
   string word = line.Trim ().ToUpper ();
   if (word.Length < 4) continue;
   if (!word.Contains (req)) continue;
   if (word.Any (c => !letters.Contains (c))) continue;
   bool pangram = letters.All (c => word.Contains (c));
   int score = word.Length == 4 ? 1 : word.Length;
   if (pangram) score += 7;
   results.Add ((word, score, pangram));
}
results.Sort ((a, b) => {
   int scoreCmp = b.score.CompareTo (a.score);
   return scoreCmp != 0 ? scoreCmp : a.word.CompareTo (b.word);
});
int total = 0;
foreach (var (word, score, pangram) in results) {
   if (pangram) ForegroundColor = ConsoleColor.Green;
   else ResetColor ();
   WriteLine ($" {score, 2}. {word}");
   total += score;
}
ResetColor ();
WriteLine ($"{"----",4}");
WriteLine ($"{total, 3} total");