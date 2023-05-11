using System;
using Tiles;

namespace Interfaces
{
    public interface IPurchasable
    {
        public event Action<Tile> OnPropertyTileLanded;
        public Player Owner { get; set; }
        public int Cost { get; set; }
        public void Purchase();
        public void Mortgage();
        //public void Upgrade();
        //public void Downgrade();
    }
}
