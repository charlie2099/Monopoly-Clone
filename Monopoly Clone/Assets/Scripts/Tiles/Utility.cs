using Interfaces;
using UnityEngine;

namespace Tiles
{
    public class Utility : Tile, IPurchasable
    {
        public void Purchase() {}

        public void Mortgage() {}

        public void SetOwner(Player player) {}

        public Player HasOwner() { return null; }
    }
}