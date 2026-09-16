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

#region class Program------------------------------------------------------------------------------
class Program {
   static void Main () {
      OutputEncoding = Encoding.UTF8;
      int[] board = new int[n];
      var solutions = new List<int[]> ();
      QueensSolver.FindSolutions (board, solutions);
      var uniqueSolutions = FilterUniqueSolutions.GetUniqueSolutions (solutions);
      WriteLine ($"Total solutions: {solutions.Count}");
      WriteLine ($"Unique solutions: {uniqueSolutions.Count}\n");
      bool iShowUnique = SelectSolutions ();
      var toShow = iShowUnique ? uniqueSolutions : solutions;
      WriteLine (iShowUnique ? "\nUNIQUE SOLUTIONS\n" : "\nALL SOLUTIONS\n");
      DisplaySolutions (toShow);
   }

   #region Implementation--------------------------------------------
   // Prompts until the user presses A or U, then reports the choice
   static bool SelectSolutions () {
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
   static void DisplaySolutions (List<int[]> toShow) {
      int count = 1;
      foreach (int[] solution in toShow) {
         WriteLine ($"Solution {count} of {toShow.Count}:");
         BoardPrinter.PrintBoard (solution);
         if (count < toShow.Count) {
            Write ("Press any key for next solution, or Q to quit");
            bool iQuit = ReadKey (true).Key == ConsoleKey.Q;
            WriteLine ("\n");
            if (iQuit) break;
         }
         count++;
      }
   }
   #endregion

   #region Constants-------------------------------------------------
   const int n = 8;
   #endregion
}
#endregion

#region class QueensSolver-------------------------------------------------------------------------
static class QueensSolver {
   #region Implementation--------------------------------------------
   // Finds every valid arrangement of non-attacking queens via backtracking
   public static void FindSolutions (int[] board, List<int[]> solutions) {
      int size = board.Length;
      var usedColumn = new bool[size];
      var usedDiagUp = new bool[2 * size - 1];
      var usedDiagDown = new bool[2 * size - 1];
      PlaceQueens (board, 0, solutions, usedColumn, usedDiagUp, usedDiagDown);
   }

   // Uses backtracking to find and store all valid solutions
   static void PlaceQueens (int[] board, int row, List<int[]> solutions,
       bool[] usedColumn, bool[] usedDiagUp, bool[] usedDiagDown) {
      if (row == board.Length) {
         solutions.Add ((int[])board.Clone ());
         return;
      }
      for (int col = 0; col < board.Length; col++) {
         if (IsSafe (row, col, usedColumn, usedDiagUp, usedDiagDown)) {
            board[row] = col;
            UpdatePosition (row, col, usedColumn, usedDiagUp, usedDiagDown, true);
            PlaceQueens (board, row + 1, solutions, usedColumn, usedDiagUp, usedDiagDown);
            UpdatePosition (row, col, usedColumn, usedDiagUp, usedDiagDown, false); // backtrack
         }
      }
   }

   // O(1) column/diagonal lookup instead of rescanning every prior row
   static bool IsSafe (int row, int col, bool[] usedColumn, bool[] usedDiagUp,
                       bool[] usedDiagDown) {
      bool iColumnUsed = usedColumn[col];
      bool iDiagUpUsed = usedDiagUp[row + col];
      bool iDiagDownUsed = usedDiagDown[row - col + usedColumn.Length - 1];
      return !iColumnUsed && !iDiagUpUsed && !iDiagDownUsed;
   }

   // Marks or clears a placement's column/diagonal occupancy
   static void UpdatePosition (int row, int col, bool[] usedColumn, bool[] usedDiagUp,
                               bool[] usedDiagDown, bool iValue) {
      usedColumn[col] = iValue;
      usedDiagUp[row + col] = iValue;
      usedDiagDown[row - col + usedColumn.Length - 1] = iValue;
   }
   #endregion
}
#endregion

#region class FilterUniqueSolutions----------------------------------------------------------------
static class FilterUniqueSolutions {
   #region Implementation--------------------------------------------
   // Removes solutions that are the same after rotation or reflection
   public static List<int[]> GetUniqueSolutions (List<int[]> solutions) {
      var seen = new HashSet<string> ();
      var unique = new List<int[]> ();
      foreach (int[] solution in solutions) {
         if (seen.Add (CanonicalKey (solution)))
            unique.Add (solution);
      }
      return unique;
   }

   // Creates a common key for solutions with the same symmetry.
   static string CanonicalKey (int[] board) {
      var forms = new List<string> ();
      int[] current = (int[])board.Clone ();
      for (int i = 0; i < 4; i++) {
         forms.Add (string.Join (",", current));
         current = RotateBoard (current);
      }
      current = MirrorBoard (board);
      for (int i = 0; i < 4; i++) {
         forms.Add (string.Join (",", current));
         current = RotateBoard (current);
      }
      forms.Sort ();
      return forms[0];
   }

   // Rotates the board 90° clockwise
   static int[] RotateBoard (int[] board) {
      int size = board.Length;
      var rotated = new int[size];
      for (int row = 0; row < size; row++)
         rotated[board[row]] = size - 1 - row;
      return rotated;
   }

   // Mirrors the board horizontally
   static int[] MirrorBoard (int[] board) {
      int size = board.Length;
      var mirrored = new int[size];
      for (int row = 0; row < size; row++)
         mirrored[row] = size - 1 - board[row];
      return mirrored;
   }
   #endregion
}
#endregion

#region class BoardPrinter-------------------------------------------------------------------------
// Draws a single board using Unicode box-drawing characters
static class BoardPrinter {
   #region Implementation--------------------------------------------
   public static void PrintBoard (int[] board) {
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
   #endregion
}
#endregion
