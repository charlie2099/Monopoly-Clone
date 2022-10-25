using UnityEngine;

namespace Tiles
{
    public class Go : Tile
    {
        public override void OnLanded()
        {
            Debug.Log("Landed on: " + TileName);
        }
    }
}