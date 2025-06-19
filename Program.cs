using UnlockTheCatPuzzleSolver.Classes;
using UnlockTheCatPuzzleSolver.Levels.L1_SummerSun;
using UnlockTheCatPuzzleSolver.Levels.L2_MidnightSky;
using UnlockTheCatPuzzleSolver.Levels.L4_LongWinter;

namespace UnlockTheCatPuzzleSolver;

internal static class Program {
    static readonly Dictionary<int, Func<Level?>> LevelFactories = new Dictionary<int, Func<Level?>>
    {
        // SummerSun
        [1] = () => new Level1(),
        [2] = () => new Level2(),
        [3] = () => new Level3(),
        [4] = () => new Level4(),
        [5] = () => new Level5(),
        [6] = () => new Level6(),
        [7] = () => new Level7(),
        [8] = () => new Level8(),
        [9] = () => new Level9(),
        [10] = () => new Level10(),
        [11] = () => new Level11(),
        [12] = () => new Level12(),
        [13] = () => new Level13(),
        // MidnightSky
        [14] = () => new Level14(),
        [15] = () => new Level15(),
        [16] = () => null, // Coming soon
        [17] = () => null, // Coming soon
        [18] = () => null, // Coming soon
        [19] = () => null, // Coming soon
        [20] = () => null, // Coming soon
        [21] = () => null, // Coming soon
        [22] = () => null, // Coming soon
        // Desert
        [23] = () => null, // Coming soon
        [24] = () => null, // Coming soon
        [25] = () => null, // Coming soon
        [26] = () => null, // Coming soon
        [27] = () => null, // Coming soon
        [28] = () => null, // Coming soon
        [29] = () => null, // Coming soon
        [30] = () => null, // Coming soon
        [31] = () => null, // Coming soon
        // LongWinter
        [32] = () => new Level32(),
        [33] = () => new Level33(),
        [34] = () => new Level34(),
        [35] = () => new Level35(),
        [36] = () => new Level36(),
        [37] = () => new Level37(),
        [38] = () => new Level38(),
    };
    
    static void PrintGrid(List<Block> blocks, int size)
    {
        // Erzeuge ein leeres Raster
        int?[,] grid = new int?[size, size];
        foreach (var b in blocks)
        {
            for (int i = 0; i < b.Length; i++)
            {
                int r = b.Row + (b.IsHorizontal ? 0 : i);
                int c = b.Col + (b.IsHorizontal ? i : 0);
                grid[r, c] = b.Id;
            }
        }

        // Drucke mit Kopf- und Zeilenbeschriftung
        Console.Write("    ");
        for (int c = 0; c < size; c++) Console.Write($"{c+1,3}");
        Console.WriteLine();
        Console.WriteLine("   +" + new string('-', size * 3 + (size-1)) + "+");

        for (int r = 0; r < size; r++)
        {
            Console.Write($"{r+1,2} |");
            for (int c = 0; c < size; c++)
            {
                string cell;
                if (!grid[r, c].HasValue)
                {
                    cell = "."; 
                }
                else if (grid[r, c].Value == 0)
                {
                    cell = "C";               
                }
                else
                {
                    cell = grid[r, c].Value.ToString(); 
                }

                Console.Write($"{cell,3}");
            }
            Console.WriteLine(" |");
        }

        Console.WriteLine("   +" + new string('-', size * 3 + (size-1)) + "+\n");
    }
    
    static void Main(string[] args) 
    {
        Console.WriteLine($"Welcome to the Unlock The Cat Puzzle Solver!");
        
        Console.WriteLine($"Please enter the Level you want to solve (1-{LevelFactories.Count}):");
        if (!int.TryParse(Console.ReadLine(), out int lvl) || !LevelFactories.ContainsKey(lvl))
        {
            Console.WriteLine("Level not Found!");
            return;
        }
        
        Level? level = LevelFactories[lvl]();
        
        if (level == null)
        {
            Console.WriteLine($"Level {lvl} is coming soon – bitte wähle ein anderes Level.");
            return;
        }
        
        int size = 6;
        var blocks = level.Blocks;
        var start = new State(blocks);
        int exitRow = 2, exitCol = 5; // Ausgang rechts von Zeile3 Spalte6

        
        Console.WriteLine("Startlocation:");
        PrintGrid(blocks, size);
        
        var solution = Solver.Solve(start, size, exitRow, exitCol);

        int step = 1;
        foreach (var (id, dr, dc) in solution)
        {
            // Block finden und Position ändern
            var b = blocks.First(bk => bk.Id == id);
            b.Row += dr;
            b.Col += dc;

            // human-readable Richtung
            string dir = dr == 1 ? "down" : dr == -1 ? "up" : dc == 1 ? "right" : "left";
            var label = id == 0 ? "Cat" : id.ToString();
            Console.WriteLine($"Step {step++}: Block {label} -> {dir}");
            PrintGrid(blocks, size);
        }
    }
}