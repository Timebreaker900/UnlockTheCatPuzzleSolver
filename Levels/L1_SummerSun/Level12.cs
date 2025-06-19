using UnlockTheCatPuzzleSolver.Classes;

namespace UnlockTheCatPuzzleSolver.Levels.L1_SummerSun;

public class Level12 : Level
{
    public override List<Block> Blocks { get; } = new List<Block>
    {
        // Cat
        new Block(0, 2, 0, 2, true), 
        // Blocks
        new Block(1, 0, 1, 2, false),
        new Block(2, 0, 2, 2, true),
        new Block(3, 0, 4, 2, true),
        new Block(4, 1, 3, 2, false),
        new Block(5, 1, 4, 2, true),
        new Block(6, 2, 4, 3, false),
        new Block(7, 2, 5, 2, false),
        new Block(8, 3, 0, 3, false),
        new Block(9, 3, 1, 3, true),
        new Block(10, 4, 2, 2, false),
        new Block(11, 4, 5, 2, false),
    };
}