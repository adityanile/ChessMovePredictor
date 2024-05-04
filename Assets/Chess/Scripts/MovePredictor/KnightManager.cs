using Chess.Scripts.Core;
using System.Collections.Generic;
using UnityEngine;

public class KnightManager : MonoBehaviour
{
    private bool showing = false;

    // Getting referance to Placement handler script in object
    public ChessPlayerPlacementHandler placementHandler;

    Position currentPos;

    // Start is called before the first frame update
    void Start()
    {
        placementHandler = GetComponent<ChessPlayerPlacementHandler>();
    }

    private void OnMouseDown()
    {
        if (!showing)
        {
            showing = true;

            // Get Current position from which to move
            currentPos = placementHandler.CurrentPosition();

            // Here we got all possible and valid position where knight can be Now Highlight these areas
            List<Position> pos = GetAllPossiblePositions(currentPos);

            foreach(Position p in pos)
            {
                Highlight(p);
            }

        }
        else
        {
            showing = false;
            ChessBoardPlacementHandler.Instance.ClearHighlights();
        }
    }

    List<Position> GetAllPossiblePositions(Position c)
    {
        List<Position> kpos = new List<Position>();
        Position temp;

        // All possible cases for the movement of the knight from current Position
        // Also Simulatneoulsy checking if calculated position is correct or not

        temp = new Position(c.row + 2, c.column + 1);
        if (ValidatePosition(temp))
            kpos.Add(temp);

        temp = new Position(c.row + 2, c.column - 1);
        if (ValidatePosition(temp))
            kpos.Add(temp);

        temp = new Position(c.row - 2, c.column + 1);
        if (ValidatePosition(temp))
            kpos.Add(temp);

        temp = new Position(c.row - 2, c.column - 1);
        if (ValidatePosition(temp))
            kpos.Add(temp);

        temp = new Position(c.row + 1, c.column + 2);
        if (ValidatePosition(temp))
            kpos.Add(temp);

        temp = new Position(c.row - 1, c.column + 2);
        if (ValidatePosition(temp))
            kpos.Add(temp);

        temp = new Position(c.row + 1, c.column - 2);
        if (ValidatePosition(temp))
            kpos.Add(temp);

        temp = new Position(c.row - 1, c.column - 2);
        if (ValidatePosition(temp))
            kpos.Add(temp);

        return kpos;
    }

    bool ValidatePosition(Position pos)
    {
        if ((pos.row >= 0 && pos.row <= 7) && (pos.column >= 0 && pos.column <= 7))
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    private void Highlight(Position pos)
    {
        ChessBoardPlacementHandler.Instance.Highlight(pos.row, pos.column);
    }

}
