using UnityEngine;

namespace Tiles
{
    public class FreeParking : Tile
    {
        public override void OnLanded()
        {
            Debug.Log("Landed on: " + TileName);
        }
    }
}