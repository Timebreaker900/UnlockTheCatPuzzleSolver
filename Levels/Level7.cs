using UnlockTheCatPuzzleSolver.Classes;

namespace UnlockTheCatPuzzleSolver.Levels;

public class Level7 : Level
{
    public override List<Block> Blocks { get; } = new List<Block>
    {
        // Cat
        new Block(0, 2, 1, 2, true), 
        // Blocks
        new Block(1, 0, 0, 3, false),
        new Block(2, 0, 3, 3, false),
        new Block(3, 3, 2, 2, false),
        new Block(4, 3, 3, 3, true),
        new Block(5, 4, 5, 2, false),
        new Block(6, 5, 2, 3, true),
    };
}