using System;

namespace Tiles
{
    public class TaxTile : Tile
    {
        private void Start()
        {
            IsEmpty = true;
        }

        public void ChargeTax(float tax, Player player)
        {
            player.Money -= tax;
        }
    }
}