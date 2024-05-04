using Chess.Scripts.Core;
using UnityEngine;

public class KingManager : MonoBehaviour
{
    private bool showing = false;

    // Getting referance to Placement handler script in object
    public ChessPlayerPlacementHandler placementHandler;

    Position currentPos;

    int maxTiles = 1;

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
            
            // Checking for 1 block movement in all direction
            MovementUp();
            MovementDown();

            MovementRight();
            MovementLeft();

            UpDiagonalClockwise();
            UpDiagonalAntiClockwise();

            DownDiagonalClockwise();
            DownDiagonalAntiClockwise() ;
        }
        else
        {
            showing = false;
            ChessBoardPlacementHandler.Instance.ClearHighlights();
        }

    }

    private void UpDiagonalClockwise()
    {
        RaycastHit hit;
        Vector3 direction = new Vector3(1, 1, 0);

        int row = currentPos.row + 1;
        int col = currentPos.column + 1;

        if (row > 7 || col > 7) return;

        // Checking clockwise
        if (Physics.Raycast(transform.position, direction, out hit, maxTiles + 0.2f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                    Position temp = new Position(row,col);
                    Highlight(temp);   
            }
        }
        else
        {
            Position temp = new Position(row, col);
            Highlight(temp);
        }

    }
    
    private void DownDiagonalClockwise()
    {
        RaycastHit hit;
        Vector3 direction = new Vector3(1, -1, 0);

        int row = currentPos.row - 1;
        int col = currentPos.column + 1;

        if (row < 0 || col > 7) return;

        // Checking clockwise
        if (Physics.Raycast(transform.position, direction, out hit, maxTiles + 0.2f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                    Position temp = new Position(row,col);
                    Highlight(temp);   
            }
        }
        else
        {
            Position temp = new Position(row, col);
            Highlight(temp);
        }

    }
    
    private void UpDiagonalAntiClockwise()
    {
        RaycastHit hit;
        Vector3 direction = new Vector3(-1, 1, 0);

        int row = currentPos.row + 1;
        int col = currentPos.column - 1;

        if (row > 7 || col < 0) return;

        // Checking clockwise
        if (Physics.Raycast(transform.position, direction, out hit, maxTiles + 0.2f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                    Position temp = new Position(row,col);
                    Highlight(temp);   
            }
        }
        else
        {
            Position temp = new Position(row, col);
            Highlight(temp);
        }

    }
    
    private void DownDiagonalAntiClockwise()
    {
        RaycastHit hit;
        Vector3 direction = new Vector3(-1, -1, 0);

        int row = currentPos.row - 1;
        int col = currentPos.column - 1;

        if (row < 0 || col < 0) return;

        // Checking clockwise
        if (Physics.Raycast(transform.position, direction, out hit, maxTiles + 0.2f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                    Position temp = new Position(row,col);
                    Highlight(temp);   
            }
        }
        else
        {
            Position temp = new Position(row, col);
            Highlight(temp);
        }

    }


    private void MovementUp()
    {
        RaycastHit hit;
        int nextBlock = 0;

        nextBlock = currentPos.row + 1;

        if (nextBlock > 7)
            return;

        // Check Up of the king if enemy then red circle
        // If any other piece then do nothing
        if (Physics.Raycast(transform.position, Vector3.up, out hit, maxTiles))
        {

            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                Position temp = new Position(nextBlock, currentPos.column);
                Highlight(temp);
            }
        }
        else
        {
            // If nothing space is empty then allow king to move 1 step up
            Position temp = new Position(nextBlock, currentPos.column);
            Highlight(temp);
        }

    }

    private void MovementDown()
    {
        RaycastHit hit;
        int nextBlock = 0;

        // Checking for Down
        nextBlock = currentPos.row - 1;

        if (nextBlock < 0)
            return;

        Position temp = new Position(nextBlock, currentPos.column);
        Highlight(temp);

        //if (Physics.Raycast(transform.position, Vector3.down, out hit, maxTiles))
        //{
        //    if (hit.collider.gameObject.CompareTag("Enemy"))
        //    {
        //        Position temp = new Position(nextBlock, currentPos.column);
        //        Highlight(temp);
        //    }
        //}
        //else
        //{
        //    Position temp = new Position(nextBlock, currentPos.column);
        //    Highlight(temp);
        //}
    }
    private void MovementRight()
    {
        RaycastHit hit;
        int nextBlock = 0;

        nextBlock = currentPos.column + 1;
        if (nextBlock > 7) return;

        if (Physics.Raycast(transform.position, Vector3.right, out hit, maxTiles))
        {

            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                Position temp = new Position(currentPos.row, nextBlock);
                Highlight(temp);
            }
        }
        else
        {
            Position temp = new Position(currentPos.row, nextBlock);
            Highlight(temp);
        }
    }

    public void MovementLeft()
    {
        RaycastHit hit;
        int nextBlock = 0;

        // Checking for Left Side
        nextBlock = currentPos.column - 1;

        if (nextBlock < 0) return;

        if (Physics.Raycast(transform.position, Vector3.left, out hit, maxTiles))
        {
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                Position temp = new Position(currentPos.row, nextBlock);
                Highlight(temp);
            }
        }
        else
        {
            Position temp = new Position(currentPos.row, nextBlock);
            Highlight(temp);
        }
    }



    private void Highlight(Position pos)
    {
        ChessBoardPlacementHandler.Instance.Highlight(pos.row, pos.column);
    }

}
