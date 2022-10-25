using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tiles
{
    public class Go : Tile
    {
        public override void OnLanded()
        {
            Debug.Log("Landed on: " + tileName);
        }
    }
}