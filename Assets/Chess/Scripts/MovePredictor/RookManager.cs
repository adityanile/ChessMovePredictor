using Chess.Scripts.Core;
using UnityEngine;

public class RookManager : MonoBehaviour
{
    private bool showing = false;

    // Getting referance to Placement handler script in object
    public ChessPlayerPlacementHandler placementHandler;

    Position currentPos;
    int maxTiles = 7;

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

            // Checking in All Direction and if valid then mark the positions
            MarkValidPositionsUp();
            MarkValidPositionsDown();
            MarkValidPositionsRight();
            MarkValidPositionsLeft();

        }
        else
        {
            showing = false;
            ChessBoardPlacementHandler.Instance.ClearHighlights();
        }

    }

    private void MarkValidPositionsUp()
    {
        // Now To decide till which block to move staight till we will Raycast to determine
        // Distance at which we get enemy or our own peice

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.up, out hit, maxTiles))
        {
            int tiles = Mathf.RoundToInt((hit.collider.transform.position.y - transform.position.y));

            for (int i = 1; i <= tiles; i++)
            {
                Position temp = new Position(currentPos.row + i, currentPos.column);
                Highlight(temp);
            }
        }
        else
        {
            int tiles = maxTiles - currentPos.row;

            for (int i = 1; i <= tiles; i++)
            {
                Position temp = new Position(currentPos.row + i, currentPos.column);
                Highlight(temp);
            }
        }
    }
    private void MarkValidPositionsDown()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, maxTiles))
        {
            int tiles = Mathf.RoundToInt((transform.position.y - hit.collider.transform.position.y));

            for (int i = 1; i <= tiles; i++)
            {
                Position temp = new Position(currentPos.row - i, currentPos.column);
                Highlight(temp);
            }
        }
        else
        {
            int tiles = currentPos.row;

            for (int i = 1; i <= tiles; i++)
            {
                Position temp = new Position(currentPos.row - i, currentPos.column);
                Highlight(temp);
            }
        }
    }

    private void MarkValidPositionsRight()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.right, out hit, maxTiles))
        {
            int tiles = Mathf.RoundToInt((hit.collider.transform.position.x - transform.position.x));

            for (int i = 1; i <= tiles; i++)
            {
                Position temp = new Position(currentPos.row, currentPos.column + i);
                Highlight(temp);
            }
        }
        else
        {
            int tiles = maxTiles - currentPos.column;

            for (int i = 1; i <= tiles; i++)
            {
                Position temp = new Position(currentPos.row, currentPos.column + i);
                Highlight(temp);
            }
        }


    }
    private void MarkValidPositionsLeft()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.left, out hit, maxTiles))
        {
            int tiles = Mathf.RoundToInt((transform.position.x - hit.collider.transform.position.x));

            for (int i = 1; i <= tiles; i++)
            {
                Position temp = new Position(currentPos.row, currentPos.column - i);
                Highlight(temp);
            }
        }
        else
        {
            int tiles = currentPos.column;

            for (int i = 1; i <= tiles; i++)
            {
                Position temp = new Position(currentPos.row, currentPos.column - i);
                Highlight(temp);
            }
        }
    }

    private void Highlight(Position pos)
    {
        ChessBoardPlacementHandler.Instance.Highlight(pos.row, pos.column);
    }
}
