using UnlockTheCatPuzzleSolver.Classes;

namespace UnlockTheCatPuzzleSolver.Levels;

public class Level3 : Level
{
    public override List<Block> Blocks { get; } = new List<Block>
    {
        // Cat
        new Block(0, 2, 1, 2, true), 
        // Blocks
        new Block(1, 0, 5, 3, false),
        new Block(2, 1, 3, 3, false),
        new Block(3, 3, 4, 2, true),
        new Block(4, 4, 4, 2, true),
        new Block(5, 5, 2, 3, true),
    };
}