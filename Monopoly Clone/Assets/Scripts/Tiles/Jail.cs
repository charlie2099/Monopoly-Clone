using UnityEngine;

namespace Tiles
{
    public class Jail : Tile
    {
        public override void OnLanded()
        {
            Debug.Log("Landed on: " + TileName);
        }
    }
}