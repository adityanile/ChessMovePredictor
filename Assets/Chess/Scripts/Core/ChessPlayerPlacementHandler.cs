using System;
using UnityEngine;

namespace Chess.Scripts.Core {
    public class ChessPlayerPlacementHandler : MonoBehaviour {
        [SerializeField] public int row, column;

        private void Start() {
            transform.position = ChessBoardPlacementHandler.Instance.GetTile(row, column).transform.position;
         }

        public Position CurrentPosition()
        {
            return new Position(row, column);
        }
    }
}

[System.Serializable]
public class Position
{
    public int row;
    public int column;

    public Position(int r, int c)
    {
        this.row = r;
        this.column = c;
    }
}