using System;
using Tiles;

namespace Interfaces
{
    public interface IPurchasable
    {
        public event Action<Tile> OnPropertyTileLanded;
        public int PropertyCost { get; set; }
        public void Purchase();
        public void Mortgage();
        public void SetOwner(Player player);
        public Player HasOwner();
        //public void Upgrade();
        //public void Downgrade();
    }
}
