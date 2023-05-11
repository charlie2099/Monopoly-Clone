﻿using UnityEngine;

namespace Tiles
{
    public class Tax : Tile
    {
        public void ChargeTax(float tax, Player player)
        {
            player.Balance -= tax;
        }
        
        /*public override void OnLanded()
        {
            Debug.Log("Landed on: " + TileName);
        }*/
    }
}