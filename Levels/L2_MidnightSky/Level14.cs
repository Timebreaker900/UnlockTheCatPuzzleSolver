using UnlockTheCatPuzzleSolver.Classes;

namespace UnlockTheCatPuzzleSolver.Levels.L2_MidnightSky;

public class Level14 : Level
{
    public override List<Block> Blocks { get; } = new List<Block>
    {
        // Cat
        new Block(0, 2, 1, 2, true), 
        // Blocks
        new Block(1, 0, 0, 3, false),
        new Block(2, 0, 1, 2, true),
        new Block(3, 0, 3, 3, false),
        new Block(4, 3, 1, 2, false),
        new Block(5, 3, 2, 3, true),
        new Block(6, 4, 5, 2, false),
        new Block(7, 5, 2, 3, true),
    };
}