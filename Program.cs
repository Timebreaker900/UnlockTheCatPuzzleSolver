// Klasse repräsentiert einen Block
class Block
{
    public int Id;
    public int Row, Col;
    public int Length;
    public bool IsHorizontal;
    
    public Block(int id, int row, int col, int length, bool isHorizontal) {
        Id = id;
        Row = row;
        Col = col;
        Length = length;
        IsHorizontal = isHorizontal;
    }

    public Block Moved(int dRow, int dCol) {
        return new Block(Id, Row + dRow, Col + dCol, Length, IsHorizontal);
    }
}

class State {
    public List<Block> Blocks;

    public State(List<Block> blocks) {
        Blocks = blocks.Select(b => new Block(b.Id, b.Row, b.Col, b.Length, b.IsHorizontal)).ToList();
    }
    
    public override bool Equals(object obj) {
        var other = obj as State;
        if (other == null || Blocks.Count != other.Blocks.Count) return false;
        foreach (var b in Blocks) {
            var o = other.Blocks.First(x => x.Id == b.Id);
            if (o.Row != b.Row || o.Col != b.Col) return false;
        }
        return true;
    }
    public override int GetHashCode() {
        int h = 17;
        foreach(var b in Blocks.OrderBy(b=>b.Id)) {
            h = h * 31 + b.Row;
            h = h * 31 + b.Col;
        }
        return h;
    }
    
    public IEnumerable<(State state, int blockId, int dRow, int dCol)> GetNeighbors(int size) {
        bool[,] grid = new bool[size, size];
        foreach(var b in Blocks) {
            for(int i = 0; i < b.Length; i++) {
                int r = b.Row + (b.IsHorizontal ? 0 : i);
                int c = b.Col + (b.IsHorizontal ? i : 0);
                grid[r, c] = true;
            }
        }
        
        foreach(var b in Blocks) {
            int[][] dirs = b.IsHorizontal ? new int[][] { new int[]{0,1}, new int[]{0,-1} }
                                          : new int[][] { new int[]{1,0}, new int[]{-1,0} };
            foreach(var dir in dirs) {
                int dr = dir[0], dc = dir[1];
                int checkRow = b.Row + (dr > 0 ? b.Length : dr < 0 ? -1 : 0);
                int checkCol = b.Col + (dc > 0 ? b.Length : dc < 0 ? -1 : 0);
                if (checkRow >= 0 && checkRow < size && checkCol >= 0 && checkCol < size && !grid[checkRow, checkCol]) {
                    // legal: erzeuge neuen Zustand
                    var newBlocks = Blocks.Select(x => x.Id == b.Id ? x.Moved(dr, dc) : x).ToList();
                    var newState = new State(newBlocks);
                    yield return (newState, b.Id, dr, dc);
                }
            }
        }
    }
    
    public bool IsGoal(int exitRow, int exitCol) {
        var cat = Blocks.First(b => b.Id == 0);
        for(int i = 0; i < cat.Length; i++) {
            int r = cat.Row + (cat.IsHorizontal ? 0 : i);
            int c = cat.Col + (cat.IsHorizontal ? i : 0);
            if (r == exitRow && c == exitCol) return true;
        }
        return false;
    }
}

class Solver {
    public static List<(int blockId, int dRow, int dCol)> Solve(State start, int size, int exitRow, int exitCol) {
        var queue = new Queue<State>();
        var parent = new Dictionary<State,(State state,int id,int dr,int dc)>();

        queue.Enqueue(start);
        parent[start] = (null,0,0,0);

        while(queue.Count > 0) {
            var cur = queue.Dequeue();
            if (cur.IsGoal(exitRow, exitCol)) {
                // zurückverfolgen
                var moves = new List<(int,int,int)>();
                var s = cur;
                while(parent[s].state != null) {
                    var info = parent[s];
                    moves.Add((info.id, info.dr, info.dc));
                    s = info.state;
                }
                moves.Reverse();
                return moves;
            }
            foreach(var (nb, id, dr, dc) in cur.GetNeighbors(size)) {
                if (!parent.ContainsKey(nb)) {
                    parent[nb] = (cur, id, dr, dc);
                    queue.Enqueue(nb);
                }
            }
        }
        return null; // keine Lösung
    }
}

class Program {
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
                var id = grid[r, c].HasValue ? grid[r, c].Value.ToString() : ".";
                Console.Write($"{id,3}");
            }
            Console.WriteLine(" |");
        }

        Console.WriteLine("   +" + new string('-', size * 3 + (size-1)) + "+\n");
    }
    
    static void Main(string[] args) {
        int size = 6;
        // Blocks: Id=0 ist Katzenblock
        var blocks = new List<Block> {
            new Block(1, 0, 0, 2, true),    // B1: Zeile1 Spalte1-2
            new Block(2, 0, 3, 3, true),    // B2: Zeile1 Spalte4-6
            new Block(3, 1, 3, 2, false),   // B3: Spalte4 Zeile2-3
            new Block(4, 1, 4, 2, true),    // B4: Zeile2 Spalte5-6
            new Block(5, 2, 0, 2, false),   // B5: Spalte1 Zeile3-4
            new Block(0, 2, 1, 2, true),    // C=0: Katzenblock Zeile3 Spalte2-3
            new Block(6, 2, 5, 3, false),   // B6: Spalte6 Zeile3-5
            new Block(7, 3, 3, 2, true),    // B7: Zeile4 Spalte4-5
            new Block(8, 4, 0, 2, true),    // B8: Zeile5 Spalte1-2
            new Block(9, 3, 2, 3, false),   // B9: Spalte3 Zeile4-6
            new Block(10,5, 3, 3, true),    // B10: Zeile6 Spalte4-6
        };
        var start = new State(blocks);
        int exitRow = 2, exitCol = 5; // Ausgang rechts von Zeile3 Spalte6

        var solution = Solver.Solve(start, size, exitRow, exitCol);
        if (solution != null) {
            Console.WriteLine("Gefundene Züge:");
            foreach(var (id, dr, dc) in solution) {
                string dir = dr == 1 ? "down" : dr == -1 ? "up" : dc == 1 ? "right" : "left";
                Console.WriteLine($"Block {id} -> {dir}");
            }
        } else {
            Console.WriteLine("Keine Lösung gefunden.");
        }
        
        Console.WriteLine("Startzustand:");
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
            Console.WriteLine($"Step {step++}: Block {id} -> {dir}");
            PrintGrid(blocks, size);
        }
    }
}