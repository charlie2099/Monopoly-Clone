using System;
using Tiles;

namespace Interfaces
{
    public interface ILandable
    {
        public event Action<Tile> OnTileLanded;
        public void OnLanded();
    }
}
