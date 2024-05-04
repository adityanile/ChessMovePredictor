using Chess.Scripts.Core;
using UnityEngine;

public class PawnManager : MonoBehaviour
{
    private bool showing = false;

    // Getting referance to Placement handler script in object
    public ChessPlayerPlacementHandler placementHandler;

    Position currentPos;
    public bool firstMove = true;

    int maxTiles = 2;

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

            // Before Move Check for a pawn is at end or not and if there is any peice is ahead or not
            if (CheckIfValidToMove() && !IsAtEnd())
            {
                MarkValidPositions();
            }
            else
            {
                Debug.Log("You are not Allowed to Move");
            }
        }
        else
        {
            showing = false;
            ChessBoardPlacementHandler.Instance.ClearHighlights();
        }

    }
    private void MarkValidPositions()
    {
        // initilly pawn will have chance to move two moves
        // Also if there is enemy or our piece ahead then no two tiles
        if (firstMove && currentPos.row == 1)
        {

            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.up, out hit, maxTiles))
            {
                int tiles = Mathf.RoundToInt((hit.collider.transform.position.y - transform.position.y) - 1);

                for (int i = 1; i <= tiles; i++)
                {
                    Position temp = new Position(currentPos.row + i, currentPos.column);
                    Highlight(temp);
                }
            }
            else
            {

                for (int i = 1; i <= maxTiles; i++)
                {
                    Position temp = new Position(currentPos.row + i, currentPos.column);
                    Highlight(temp);
                }
            }

        }
        else
        {
            Position temp = new Position(currentPos.row + 1, currentPos.column);
            Highlight(temp);
        }

        // Now Also Check Diagonally For a kill only if enemy is present Diagonally
        CheckIfEnemyDiagonally();
    }

    void CheckIfEnemyDiagonally()
    {
        RaycastHit hit;
        Vector3 direction = new Vector3(1, 1, 0);

        // Checking clockwise
        if (Physics.Raycast(transform.position, direction, out hit, 1))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                // Now if Enemy is Clockwise then Make Red Circle around it
                Position nextPos = new Position(currentPos.row + 1, currentPos.column + 1);
                Highlight(nextPos);
            }
        }

        // Checking anticlockwise
        direction = new Vector3(-1, 1, 0);

        if (Physics.Raycast(transform.position, direction, out hit, 1))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                // Now if Enemy is Clockwise then Make Red Circle around it
                Position nextPos = new Position(currentPos.row + 1, currentPos.column - 1);
                Highlight(nextPos);
            }
        }
    }

    bool CheckIfValidToMove()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.up, out hit, 1))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    bool IsAtEnd()
    {
        if (currentPos.row == 7)
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
