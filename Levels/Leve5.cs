using UnlockTheCatPuzzleSolver.Classes;

namespace UnlockTheCatPuzzleSolver.Levels;

public class Level5 : Level
{
    public override List<Block> Blocks { get; } = new List<Block>
    {
        // Cat
        new Block(0, 2, 1, 2, true), 
        // Blocks
        new Block(1, 0, 0, 2, true),
        new Block(2, 0, 5, 3, false),
        new Block(3, 1, 0, 3, false),
        new Block(4, 1, 3, 3, false),
        new Block(5, 4, 0, 2, false),
        new Block(6, 4, 4, 2, true),
        new Block(7, 5, 2, 3, true),
    };
}