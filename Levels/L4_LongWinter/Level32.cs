using UnlockTheCatPuzzleSolver.Classes;

namespace UnlockTheCatPuzzleSolver.Levels.L4_LongWinter;

public class Level32 : Level
{
    public override List<Block> Blocks { get; } = new List<Block>
    {
        // Cat
        new Block(0, 2, 1, 2, true), 
        // Blocks
        new Block(1, 0, 0, 2, true), 
        new Block(2, 0, 3, 3, true),    
        new Block(3, 1, 3, 2, false),   
        new Block(4, 1, 4, 2, true),    
        new Block(5, 2, 0, 2, false),   
        new Block(6, 2, 5, 3, false),   
        new Block(7, 3, 3, 2, true),    
        new Block(8, 4, 0, 2, true),    
        new Block(9, 3, 2, 3, false),   
        new Block(10,5, 3, 3, true),    
    };
}