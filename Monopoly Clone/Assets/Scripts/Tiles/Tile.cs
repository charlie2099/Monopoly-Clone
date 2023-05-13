using System;
using Interfaces;
using TMPro;
using UnityEngine;

namespace Tiles
{
    public abstract class Tile : MonoBehaviour, ILandable 
    {
        public event Action<Tile> OnTileLanded;
        public string TileName => tileData.TileName;
        public int TileNum => tileData.TileNum;

        [Header("Tile Data")]
        [SerializeField] private TextMeshPro tileNameText;
        [SerializeField] private TileData tileData;

        protected virtual void Start()
        { 
            tileNameText.text = tileData.TileName;
        }

        public virtual void OnLanded(Player player)
        {
            OnTileLanded?.Invoke(this);
        }
    }
}
