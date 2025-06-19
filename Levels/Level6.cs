using UnlockTheCatPuzzleSolver.Classes;

namespace UnlockTheCatPuzzleSolver.Levels;

public class Level6 : Level
{
    public override List<Block> Blocks { get; } = new List<Block>
    {
        // Cat
        new Block(0, 2, 1, 2, true), 
        // Blocks
        new Block(1, 2, 3, 3, false),
        new Block(2, 3, 1, 2, true),
        new Block(3, 3, 5, 3, false),
        new Block(4, 4, 1, 2, false),
        new Block(5, 5, 2, 2, true),
    };
}