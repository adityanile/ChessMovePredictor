using Chess.Scripts.Core;
using UnityEngine;

public class KingManager : MonoBehaviour
{
    private bool showing = false;

    // Getting referance to Placement handler script in object
    public ChessPlayerPlacementHandler placementHandler;

    Position currentPos;

    // Start is called before the first frame update
    void Start()
    {
        placementHandler = GetComponent<ChessPlayerPlacementHandler>();

        // Get Current position from which to move
        currentPos = placementHandler.CurrentPosition();
    }

    private void OnMouseDown()
    {
        if (!showing)
        {
            showing = true;

            // Checking for 1 block movement in all direction
            MovementUp();
            MovementDown();

            MovementRight();
            MovementLeft();

            UpDiagonalClockwise();
            UpDiagonalAntiClockwise();

            DownDiagonalClockwise();
            DownDiagonalAntiClockwise();
        }
        else
        {
            showing = false;
            ChessBoardPlacementHandler.Instance.ClearHighlights();
        }

    }

    private void UpDiagonalClockwise()
    {
        int row = currentPos.row + 1;
        int col = currentPos.column + 1;

        if (row > 7 || col > 7) return;

        Position temp = new Position(row, col);
        Highlight(temp);
    }

    private void DownDiagonalClockwise()
    {
        int row = currentPos.row - 1;
        int col = currentPos.column + 1;

        if (row < 0 || col > 7) return;

        Position temp = new Position(row, col);
        Highlight(temp);
    }

    private void UpDiagonalAntiClockwise()
    {
        int row = currentPos.row + 1;
        int col = currentPos.column - 1;

        if (row > 7 || col < 0) return;

        Position temp = new Position(row, col);
        Highlight(temp);

    }

    private void DownDiagonalAntiClockwise()
    {
        int row = currentPos.row - 1;
        int col = currentPos.column - 1;

        if (row < 0 || col < 0) return;

        Position temp = new Position(row, col);
        Highlight(temp);

    }


    private void MovementUp()
    {
        int nextBlock = currentPos.row + 1;

        if (nextBlock > 7)
            return;

        Position temp = new Position(nextBlock, currentPos.column);
        Highlight(temp);
    }

    private void MovementDown()
    {
        int nextBlock = currentPos.row - 1;

        if (nextBlock < 0)
            return;

        Position temp = new Position(nextBlock, currentPos.column);
        Highlight(temp);
    }
    private void MovementRight()
    {
        int nextBlock = currentPos.column + 1;
        if (nextBlock > 7) return;

        Position temp = new Position(currentPos.row, nextBlock);
        Highlight(temp);
    }

    public void MovementLeft()
    {
        int nextBlock = currentPos.column - 1;

        if (nextBlock < 0) return;

        Position temp = new Position(currentPos.row, nextBlock);
        Highlight(temp);
    }



    private void Highlight(Position pos)
    {
        ChessBoardPlacementHandler.Instance.Highlight(pos.row, pos.column);
    }

}
