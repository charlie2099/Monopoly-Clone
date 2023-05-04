using Tiles;
using UnityEngine;

namespace Commands
{
    public class MoveCommand : ICommand
    {
        private readonly Token token;
        private readonly Tile _previousTile;
        private readonly Tile _newTile;

        public MoveCommand(Token token, Tile previousTile, Tile newTile)
        {
            this.token = token;
            _previousTile = previousTile;
            _newTile = newTile;
        }
    
        public void Execute()
        { 
            var newTilePos = _newTile.transform.position;
            var destination = new Vector3(newTilePos.x, token.transform.position.y, newTilePos.z);
            token.transform.position = destination;
            //AnimationController.Instance.MoveTo(_piece, destination);
            token.SetCurrentTile(_newTile);
            //_piece.MoveTo(destination);
        }

        public void Undo()
        {
            var oldTilePos = _previousTile.transform.position;
            var destination = new Vector3(oldTilePos.x, token.transform.position.y, oldTilePos.z);
            token.transform.position = destination;
            token.SetCurrentTile(_previousTile);
        }
    }
}
