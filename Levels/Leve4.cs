using UnlockTheCatPuzzleSolver.Classes;

namespace UnlockTheCatPuzzleSolver.Levels;

public class Level4 : Level
{
    public override List<Block> Blocks { get; } = new List<Block>
    {
        // Cat
        new Block(0, 2, 1, 2, true), 
        // Blocks
        new Block(1, 1, 4, 3, false),
        new Block(2, 3, 2, 2, false),
        new Block(3, 4, 4, 2, true),
        new Block(4, 5, 2, 3, true),
    };
}