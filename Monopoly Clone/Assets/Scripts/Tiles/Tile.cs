using System;
using Interfaces;
using TMPro;
using UnityEngine;

namespace Tiles
{
    public abstract class Tile : MonoBehaviour, ILandable 
    {
        public event Action<Tile> OnTileLanded;
        public string TileName => tileName;
        public int TileNum => tileNum;

        [SerializeField] private int tileNum;
        [SerializeField] private string tileName;
        [SerializeField] private TextMeshPro tileNameText;

        protected virtual void Start()
        {
            tileNameText.text = tileName;
        }

        public virtual void OnLanded()
        {
            Debug.Log("Landed on: " + tileName);
            OnTileLanded?.Invoke(this);
        }
    }
}
