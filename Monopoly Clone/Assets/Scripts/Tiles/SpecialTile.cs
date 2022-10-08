using System;

namespace Tiles
{
    public class SpecialTile : Tile
    {
        private void Start()
        {
            IsEmpty = true;
        }

        public void GiveCard(Player player)
        {
            // card.SetActive(true)
            // card.text = ...
            // card.Execute();
        }

        public void GenerateCard()
        {
            //
        }
    }
}