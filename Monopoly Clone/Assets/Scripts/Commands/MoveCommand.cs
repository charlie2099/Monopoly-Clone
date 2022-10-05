using Tiles;
using UnityEngine;

namespace Commands
{
    public class MoveCommand : ICommand
    {
        private readonly Piece _piece;
        private readonly Tile oldPropertyTile;
        private readonly Tile newPropertyTile;

        public MoveCommand(Piece piece, Tile oldPropertyTile, Tile newPropertyTile)
        {
            _piece = piece;
            this.oldPropertyTile = oldPropertyTile;
            this.newPropertyTile = newPropertyTile;
        }
    
        public void Execute()
        {
            var newTilePos = newPropertyTile.transform.position;
            //var speed = 1.0f * Time.deltaTime;
            _piece.transform.position = new Vector3(newTilePos.x, _piece.transform.position.y, newTilePos.z);

            /*_piece.transform.position = Vector3.Lerp(_piece.transform.position,
                new Vector3(newTilePos.x, _piece.transform.position.y, newTilePos.z), speed);*/
        }

        public void Undo()
        {
            var oldTilePos = oldPropertyTile.transform.position;
            _piece.transform.position = new Vector3(oldTilePos.x, _piece.transform.position.y, oldTilePos.z);
        }
    }
}
