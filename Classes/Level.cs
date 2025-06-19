namespace UnlockTheCatPuzzleSolver.Classes;

public abstract class Level
{
    public abstract List<Block> Blocks { get; }
    public int ExitRow = 2;
    public int ExitCol = 5;
}