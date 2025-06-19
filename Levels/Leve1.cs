using UnlockTheCatPuzzleSolver.Classes;

namespace UnlockTheCatPuzzleSolver.Levels;

public class Level1 : Level
{
    public override List<Block> Blocks { get; } = new List<Block>
    {
        new Block(0, 2, 1, 2, true), // Cat
        
        new Block(1, 1, 5, 3, false)
    };
}