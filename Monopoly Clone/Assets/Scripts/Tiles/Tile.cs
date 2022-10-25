using System;
using TMPro;
using UnityEngine;

namespace Tiles
{
    public abstract class Tile : MonoBehaviour, ILandable
    {
        public string TileName { get => tileName; set => tileName = value; }
        public int TileID { get; set; }
        public abstract void OnLanded();
        
        [Header("Tile Data")]
        [SerializeField] private string tileName;
        [SerializeField] private TextMeshPro tileNameText;

        protected virtual void Start()
        {
            tileNameText.text = tileName;
        }
    }
}
