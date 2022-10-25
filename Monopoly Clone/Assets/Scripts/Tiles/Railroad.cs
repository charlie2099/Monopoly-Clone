using UnityEngine;

namespace Tiles
{
    public class Railroad : Tile
    {
        public override void OnLanded()
        {
            Debug.Log("Landed on: " + tileName);
        }
    }
}