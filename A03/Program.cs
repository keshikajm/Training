// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2026.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Program to find all valid Spelling Bee words from a dictionary, calculate their scores,
// identify pangrams, and display the results in descending order of score.
// ------------------------------------------------------------------------------------------------
using static System.Console;

char[] letters = { 'U', 'X', 'A', 'L', 'T', 'N', 'E' };
char requiredLetter = letters[0];
string[] wordList = File.ReadAllLines ("spellbee_wordlist.txt");
List<(string word, int score, bool pangram)> results = [];
foreach (string line in wordList) {
   string word = line.Trim ().ToUpper ();
   if (word.Length < 4) continue;
   if (!word.Contains (requiredLetter)) continue;
   if (word.Any (c => !letters.Contains (c))) continue;
   bool pangram = letters.All (c => word.Contains (c));
   int score = word.Length == 4 ? 1 : word.Length;
   if (pangram) score += 7;
   results.Add ((word, score, pangram));
}
results.Sort ((a, b) => {
   int scoreComparison = b.score.CompareTo (a.score);
   return scoreComparison != 0 ? scoreComparison : a.word.CompareTo (b.word);
});
int total = 0;
foreach (var (word, score, pangram) in results) {
   if (pangram) ForegroundColor = ConsoleColor.Green;
   else ResetColor ();
   WriteLine ($"{score,2}. {word}");
   total += score;
}
ResetColor ();
WriteLine ();
WriteLine ($"Total score: {total}");