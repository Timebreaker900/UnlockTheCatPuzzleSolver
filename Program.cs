

using UnlockTheCatPuzzleSolver.Classes;
using UnlockTheCatPuzzleSolver.Levels;

class Program {
    static readonly Dictionary<int, Func<Level>> LevelFactories = new Dictionary<int, Func<Level>>
    {
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
        
        Console.WriteLine($"Please enter the Level you want to solce (1-{LevelFactories.Count}):");
        if (!int.TryParse(Console.ReadLine(), out int lvl) || !LevelFactories.ContainsKey(lvl))
        {
            Console.WriteLine("Level not Found!");
            return;
        }
        
        Level level = LevelFactories[lvl]();
        
        int size = 6;
        var blocks = level.Blocks;
        var start = new State(blocks);
        int exitRow = 2, exitCol = 5; // Ausgang rechts von Zeile3 Spalte6

        
        var solution = Solver.Solve(start, size, exitRow, exitCol);
        
        Console.WriteLine("Startlocation:");
        PrintGrid(blocks, size);

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