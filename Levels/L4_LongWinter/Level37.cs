using UnlockTheCatPuzzleSolver.Classes;

namespace UnlockTheCatPuzzleSolver.Levels.L4_LongWinter;

public class Level37 : Level
{
    public override List<Block> Blocks { get; } = new List<Block>
    {
        // Cat
        new Block(0, 2, 1, 2, true), 
        // Blocks
        new Block(1, 0, 0, 2, true), 
        new Block(2, 0, 2, 2, false),    
        new Block(3, 0, 4, 2, true),   
        new Block(4, 1, 0, 2, true),    
        new Block(5, 1, 4, 3, false),   
        new Block(6, 1, 5, 3, false),   
        new Block(7, 2, 0, 3, false),    
        new Block(8, 3, 1, 3, true),    
        new Block(9, 4, 3, 2, false),   
        new Block(10,4, 4, 2, true),      
        new Block(11,5, 0, 2, true),      
        new Block(12,5, 4, 2, true),      
    };
}