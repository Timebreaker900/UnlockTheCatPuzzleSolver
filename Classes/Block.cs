namespace UnlockTheCatPuzzleSolver.Classes;

public class Block
{
    public int Id;
    public int Row, Col;
    public int Length;
    public bool IsHorizontal;
    
    public Block(int id, int row, int col, int length, bool isHorizontal) {
        Id = id;
        Row = row;
        Col = col;
        Length = length;
        IsHorizontal = isHorizontal;
    }

    public Block Moved(int dRow, int dCol) {
        return new Block(Id, Row + dRow, Col + dCol, Length, IsHorizontal);
    }
}