using Tiles;
using UnityEngine;

namespace Commands
{
    public class MoveCommand : ICommand
    {
        private readonly Token _token;
        private readonly Tile _previousTile;
        private readonly Tile _newTile;

        public MoveCommand(Token token, Tile previousTile, Tile newTile)
        {
            _token = token;
            _previousTile = previousTile;
            _newTile = newTile;
        }
    
        public void Execute()
        { 
            var newTilePos = _newTile.transform.position;
            var destination = new Vector3(newTilePos.x, _token.transform.position.y, newTilePos.z);
            _token.transform.position = destination;
            _token.SetCurrentTile(_newTile);
        }

        public void Undo()
        {
            var oldTilePos = _previousTile.transform.position;
            var destination = new Vector3(oldTilePos.x, _token.transform.position.y, oldTilePos.z);
            _token.transform.position = destination;
            _token.SetCurrentTile(_previousTile);
        }
    }
}
