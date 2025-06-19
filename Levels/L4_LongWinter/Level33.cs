using UnlockTheCatPuzzleSolver.Classes;

namespace UnlockTheCatPuzzleSolver.Levels.L4_LongWinter;

public class Level33 : Level
{
    public override List<Block> Blocks { get; } = new List<Block>
    {
        // Cat
        new Block(0, 2, 0, 2, true), 
        // Blocks
        new Block(1, 0, 1, 2, false), 
        new Block(2, 0, 2, 3, false),    
        new Block(3, 0, 4, 2, true),   
        new Block(4, 3, 0, 2, false),    
        new Block(5, 3, 1, 2, true),   
        new Block(6, 3, 3, 2, true),   
        new Block(7, 3, 5, 3, false),    
        new Block(8, 4, 1, 2, true),    
        new Block(9, 4, 3, 2, false),   
        new Block(10,4, 4, 2, false),    
        new Block(11,5, 0, 3, true),    
    };
}