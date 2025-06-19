using UnlockTheCatPuzzleSolver.Classes;

namespace UnlockTheCatPuzzleSolver.Levels;

public class Level9 : Level
{
    public override List<Block> Blocks { get; } = new List<Block>
    {
        // Cat
        new Block(0, 2, 1, 2, true), 
        // Blocks
        new Block(1, 0, 0, 2, true),
        new Block(2, 0, 3, 2, false),
        new Block(3, 1, 0, 2, true),
        new Block(4, 1, 4, 3, false),
        new Block(5, 1, 5, 3, false),
        new Block(6, 2, 3, 3, false),
        new Block(7, 3, 0, 2, true),
        new Block(8, 3, 2, 2, false),
        new Block(9, 4, 0, 2, false),
        new Block(10, 5, 3, 3, true),
    };
}