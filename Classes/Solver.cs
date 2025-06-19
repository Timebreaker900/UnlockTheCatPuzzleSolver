namespace UnlockTheCatPuzzleSolver.Classes;

public class Solver
{
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