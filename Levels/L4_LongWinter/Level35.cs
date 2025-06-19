using UnlockTheCatPuzzleSolver.Classes;

namespace UnlockTheCatPuzzleSolver.Levels.L4_LongWinter;

public class Level35 : Level
{
    public override List<Block> Blocks { get; } = new List<Block>
    {
        // Cat
        new Block(0, 2, 0, 2, true), 
        // Blocks
        new Block(1, 0, 2, 3, false), 
        new Block(2, 0, 3, 2, true),    
        new Block(3, 0, 5, 3, false),   
        new Block(4, 1, 3, 2, false),    
        new Block(5, 3, 0, 2, false),   
        new Block(6, 3, 1, 3, true),   
        new Block(7, 4, 1, 2, true),    
        new Block(8, 4, 3, 2, false),    
        new Block(9, 4, 4, 2, false),   
        new Block(10,5, 0, 2, true),      
    };
}