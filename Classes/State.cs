namespace UnlockTheCatPuzzleSolver.Classes;

public class State
{
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