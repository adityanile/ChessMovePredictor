using Chess.Scripts.Core;
using System.Collections;
using UnityEngine;

public class BishopManager : MonoBehaviour
{
    private bool showing = false;

    // Getting referance to Placement handler script in object
    public ChessPlayerPlacementHandler placementHandler;

    Position currentPos;
    float maxTiles = 7.5f;

    // These are diagonal limits for the bishop to get the ending of the board
    public GameObject bishopLimits;

    void Start()
    {
        bishopLimits = GameObject.Find("Limits");

        placementHandler = GetComponent<ChessPlayerPlacementHandler>();
        StartCoroutine(Wait());

        // Get Current position from which to move
        currentPos = placementHandler.CurrentPosition();
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        bishopLimits.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!showing)
        {
            showing = true;
            bishopLimits.SetActive(true);

            // Checking in All Direction and if valid then mark the positions
            CheckDiagonallyUp();
            CheckDiagonallyDown();

            bishopLimits.SetActive(false);
        }
        else
        {
            showing = false;
            ChessBoardPlacementHandler.Instance.ClearHighlights();
        }

    }

    void CheckDiagonallyUp()
    {
        RaycastHit hit;
        Vector3 direction = new Vector3(1, 1, 0);

        // Checking clockwise
        if (Physics.Raycast(transform.position, direction, out hit, maxTiles))
        {
            if (hit.collider.CompareTag("Enemy") || hit.collider.CompareTag("Limit"))
            {
                int tiles = Mathf.RoundToInt((hit.collider.transform.position.y - transform.position.y));
                for (int i = 1; i <= tiles; i++)
                {
                    Position temp = new Position(currentPos.row + i, currentPos.column + i);
                    Highlight(temp);
                }
            }
            else
            {
                int tiles = Mathf.RoundToInt((hit.collider.transform.position.y - transform.position.y) - 1);

                for (int i = 1; i <= tiles; i++)
                {
                    Position temp = new Position(currentPos.row + i, currentPos.column + i);
                    Highlight(temp);
                }
            }
        }


        // Checking anticlockwise
        direction = new Vector3(-1, 1, 0);

        if (Physics.Raycast(transform.position, direction, out hit, maxTiles))
        {
            if (hit.collider.CompareTag("Enemy") || hit.collider.CompareTag("Limit"))
            {
                int tiles = Mathf.RoundToInt((hit.collider.transform.position.y - transform.position.y));

                for (int i = 1; i <= tiles; i++)
                {
                    Position temp = new Position(currentPos.row + i, currentPos.column - i);
                    Highlight(temp);
                }
            }
            else
            {
                int tiles = Mathf.RoundToInt((hit.collider.transform.position.y - transform.position.y) - 1);

                for (int i = 1; i <= tiles; i++)
                {
                    Position temp = new Position(currentPos.row + i, currentPos.column - i);
                    Highlight(temp);
                }
            }
        }

    }
    void CheckDiagonallyDown()
    {
        RaycastHit hit;
        Vector3 direction = new Vector3(1, -1, 0);

        // Checking clockwise
        if (Physics.Raycast(transform.position, direction, out hit, maxTiles))
        {
            if (hit.collider.CompareTag("Enemy") || hit.collider.CompareTag("Limit"))
            {
                int tiles = Mathf.RoundToInt((transform.position.y - hit.collider.transform.position.y));

                for (int i = 1; i <= tiles; i++)
                {
                    Position temp = new Position(currentPos.row - i, currentPos.column + i);
                    Highlight(temp);
                }
            }
            else
            {
                int tiles = Mathf.RoundToInt((transform.position.y - hit.collider.transform.position.y) - 1);

                for (int i = 1; i <= tiles; i++)
                {
                    Position temp = new Position(currentPos.row - i, currentPos.column + i);
                    Highlight(temp);
                }
            }
        }


        // Checking anticlockwise
        direction = new Vector3(-1, -1, 0);

        if (Physics.Raycast(transform.position, direction, out hit, maxTiles))
        {
            if (hit.collider.CompareTag("Enemy") || hit.collider.CompareTag("Limit"))
            {
                int tiles = Mathf.RoundToInt((transform.position.y - hit.collider.transform.position.y));

                for (int i = 1; i <= tiles; i++)
                {
                    Position temp = new Position(currentPos.row - i, currentPos.column - i);
                    Highlight(temp);
                }
            }
            else
            {
                int tiles = Mathf.RoundToInt((transform.position.y - hit.collider.transform.position.y) - 1);

                for (int i = 1; i <= tiles; i++)
                {
                    Position temp = new Position(currentPos.row - i, currentPos.column - i);
                    Highlight(temp);
                }
            }
        }

    }


    private void Highlight(Position pos)
    {
        ChessBoardPlacementHandler.Instance.Highlight(pos.row, pos.column);
    }


}
