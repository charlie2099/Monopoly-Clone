using UnityEngine;

namespace Tiles
{
    public class Special : Tile
    {
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
        
        public override void OnLanded(Player player)
        {
            base.OnLanded(player);
        }
    }
}