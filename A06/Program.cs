// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2026.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Program to solve the 8-Queens puzzle using backtracking and identify unique solutions by
// removing rotational and reflectional duplicates.
// ------------------------------------------------------------------------------------------------
using System.Text;
using static System.Console;

class Program {
   const int n = 8;

   static void Main () {
      OutputEncoding = Encoding.UTF8;
      int[] board = new int[n];
      var solutions = new List<int[]> ();
      queensSolver.sSolve (board, solutions);
      var uniqueSolutions = BoardSymmetry.sGetUniqueSolutions (solutions);
      WriteLine ($"Total solutions: {solutions.Count}");
      WriteLine ($"Unique solutions: {uniqueSolutions.Count}\n");
      bool iShowUnique = sAskShowUnique ();
      var toShow = iShowUnique ? uniqueSolutions : solutions;
      WriteLine (iShowUnique ? "\nUNIQUE SOLUTIONS\n" : "\nALL SOLUTIONS\n");
      sDisplaySolutions (toShow);
   }

   // Prompts until the user presses A or U, then reports the choice
   static bool sAskShowUnique () {
      while (true) {
         WriteLine ("Display (A)ll 92 solutions or (U)nique 12 solutions? [A/U]");
         switch (ReadKey (true).Key) {
            case ConsoleKey.A: return false;
            case ConsoleKey.U: return true;
            default: WriteLine ("Please press A or U."); break;
         }
      }
   }

   // Walks the chosen list, printing each board with a pause in between
   static void sDisplaySolutions (List<int[]> toShow) {
      int count = 1;
      foreach (int[] solution in toShow) {
         WriteLine ($"Solution {count} of {toShow.Count}:");
         BoardPrinter.sPrintBoard (solution);
         if (count < toShow.Count) {
            Write ("Press any key for next solution, or Q to quit");
            bool iQuit = ReadKey (true).Key == ConsoleKey.Q;
            WriteLine ("\n");
            if (iQuit) break;
         }
         count++;
      }
   }
}

// Finds every valid arrangement of non-attacking queens via backtracking
static class queensSolver {
   public static void sSolve (int[] board, List<int[]> solutions) {
      int size = board.Length;
      var usedColumn = new bool[size];
      var usedDiagUp = new bool[2 * size - 1];
      var usedDiagDown = new bool[2 * size - 1];
      sSolveRow (board, 0, solutions, usedColumn, usedDiagUp, usedDiagDown);
   }

   // Uses backtracking to find and store all valid solutions
   static void sSolveRow (int[] board, int row, List<int[]> solutions,
       bool[] usedColumn, bool[] usedDiagUp, bool[] usedDiagDown) {
      if (row == board.Length) {
         solutions.Add ((int[])board.Clone ());
         return;
      }
      for (int col = 0; col < board.Length; col++) {
         if (sIsSafe (row, col, usedColumn, usedDiagUp, usedDiagDown)) {
            board[row] = col;
            sMark (row, col, usedColumn, usedDiagUp, usedDiagDown, true);
            sSolveRow (board, row + 1, solutions, usedColumn, usedDiagUp, usedDiagDown);
            sMark (row, col, usedColumn, usedDiagUp, usedDiagDown, false); // backtrack
         }
      }
   }

   // O(1) column/diagonal lookup instead of rescanning every prior row
   static bool sIsSafe (int row, int col, bool[] usedColumn, bool[] usedDiagUp,
                       bool[] usedDiagDown) {
      bool iColumnUsed = usedColumn[col];
      bool iDiagUpUsed = usedDiagUp[row + col];
      bool iDiagDownUsed = usedDiagDown[row - col + usedColumn.Length - 1];
      return !iColumnUsed && !iDiagUpUsed && !iDiagDownUsed;
   }

   // Marks or clears a placement's column/diagonal occupancy
   static void sMark (int row, int col, bool[] usedColumn, bool[] usedDiagUp, bool[] usedDiagDown,
                     bool iValue) {
      usedColumn[col] = iValue;
      usedDiagUp[row + col] = iValue;
      usedDiagDown[row - col + usedColumn.Length - 1] = iValue;
   }
}

//Removes solutions that are the same after rotation or reflection
static class BoardSymmetry {
   public static List<int[]> sGetUniqueSolutions (List<int[]> solutions) {
      var seen = new HashSet<string> ();
      var unique = new List<int[]> ();
      foreach (int[] solution in solutions) {
         if (seen.Add (sCanonicalKey (solution)))
            unique.Add (solution);
      }
      return unique;
   }

   // Finds the smallest string from all 8 rotated and mirrored forms
   static string sCanonicalKey (int[] board) {
      var forms = new List<string> ();
      int[] current = (int[])board.Clone ();
      for (int i = 0; i < 4; i++) {
         forms.Add (string.Join (",", current));
         current = sRotate (current);
      }
      current = sMirror (board);
      for (int i = 0; i < 4; i++) {
         forms.Add (string.Join (",", current));
         current = sRotate (current);
      }
      forms.Sort ();
      return forms[0];
   }

   // Rotates the board 90° clockwise
   static int[] sRotate (int[] board) {
      int size = board.Length;
      var rotated = new int[size];
      for (int row = 0; row < size; row++)
         rotated[board[row]] = size - 1 - row;
      return rotated;
   }

   // Mirrors the board horizontally
   static int[] sMirror (int[] board) {
      int size = board.Length;
      var mirrored = new int[size];
      for (int row = 0; row < size; row++)
         mirrored[row] = size - 1 - board[row];
      return mirrored;
   }
}

// Draws a single board using Unicode box-drawing characters
static class BoardPrinter {
   public static void sPrintBoard (int[] board) {
      WriteLine ("┌───┬───┬───┬───┬───┬───┬───┬───┐");
      for (int row = 0; row < board.Length; row++) {
         Write ("│");
         for (int col = 0; col < board.Length; col++)
            Write (board[row] == col ? " \u265B │" : "   │");
         WriteLine ();
         if (row < board.Length - 1)
            WriteLine ("├───┼───┼───┼───┼───┼───┼───┼───┤");
      }
      WriteLine ("└───┴───┴───┴───┴───┴───┴───┴───┘\n");
   }
}

