using System;
using Tiles;

namespace Interfaces
{
    public interface ILandable
    {
        public event Action<Tile> OnLandedEvent;
        public void OnLanded();
    }
}
