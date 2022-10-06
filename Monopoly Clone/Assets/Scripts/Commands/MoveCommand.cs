using Tiles;
using UnityEngine;

namespace Commands
{
    public class MoveCommand : ICommand
    {
        private readonly Piece _piece;
        private readonly Tile _previousTile;
        private readonly Tile _newTile;

        public MoveCommand(Piece piece, Tile previousTile, Tile newTile)
        {
            _piece = piece;
            _previousTile = previousTile;
            _newTile = newTile;
        }
    
        public void Execute()
        {
            var newTilePos = _newTile.transform.position;
            var destination = new Vector3(newTilePos.x, _piece.transform.position.y, newTilePos.z);
            _piece.transform.position = destination;
            //_piece.MoveTo(destination);

            //var speed = 1.0f * Time.deltaTime;
            /*_piece.transform.position = Vector3.Lerp(_piece.transform.position,
                new Vector3(newTilePos.x, _piece.transform.position.y, newTilePos.z), speed);*/
        }

        public void Undo()
        {
            var oldTilePos = _previousTile.transform.position;
            _piece.transform.position = new Vector3(oldTilePos.x, _piece.transform.position.y, oldTilePos.z);
        }
    }
}
