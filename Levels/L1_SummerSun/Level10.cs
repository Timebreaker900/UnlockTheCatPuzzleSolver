using UnlockTheCatPuzzleSolver.Classes;

namespace UnlockTheCatPuzzleSolver.Levels.L1_SummerSun;

public class Level10 : Level
{
    public override List<Block> Blocks { get; } = new List<Block>
    {
        // Cat
        new Block(0, 2, 1, 2, true), 
        // Blocks
        new Block(1, 0, 1, 2, false),
        new Block(2, 0, 2, 2, true),
        new Block(3, 0, 4, 2, false),
        new Block(4, 0, 5, 2, false),
        new Block(5, 1, 3, 2, false),
        new Block(6, 2, 5, 2, false),
        new Block(7, 3, 2, 2, true),
        new Block(8, 4, 3, 2, false),
    };
}