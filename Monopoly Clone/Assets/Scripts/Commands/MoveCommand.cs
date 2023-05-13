using Tiles;
using UnityEngine;

namespace Commands
{
    public class MoveCommand : ICommand
    {
        private readonly Player _player;
        private readonly Tile _targetTile;
        private readonly Tile[] _tiles;

        public MoveCommand(Player player, Tile targetTile, Tile[] tiles)
        {
            _player = player;
            _targetTile = targetTile;
            _tiles = tiles;
        }

        public void Execute()
        {
            var playerToken = _player.Token;
            int nextTileNum = playerToken.CurrentTile.TileNum + 1;
            if (nextTileNum >= _tiles.Length)
                nextTileNum = 0; // loop back to the beginning of the list

            Waypoint nextTileWaypoint = GameManager.Instance.playerPathDict[_player].GetWaypoint(nextTileNum);
            playerToken.transform.position = Vector3.MoveTowards(playerToken.transform.position, nextTileWaypoint.transform.position, 5.0f * Time.deltaTime);
            playerToken.transform.LookAt(nextTileWaypoint.transform.position);

            if (playerToken.transform.position == nextTileWaypoint.transform.position)
            {
                playerToken.SetCurrentTile(_tiles[nextTileNum]);

                if (playerToken.CurrentTile == _targetTile)
                {
                    playerToken.CurrentTile.OnLanded(_player);
                }
            }
        }

        public void Undo() {}
    }

    
    /*public class MoveCommand : ICommand
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
    }*/
}
