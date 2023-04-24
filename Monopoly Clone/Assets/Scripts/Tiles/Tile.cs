using System;
using Interfaces;
using TMPro;
using UnityEngine;

namespace Tiles
{
    public abstract class Tile : MonoBehaviour, ILandable
    {
        public event Action<Tile> OnLandedEvent;
        
        public string TileName { get => tileName; set => tileName = value; }
        public int TileID { get; set; }

        [Header("Tile Data")]
        [SerializeField] private string tileName;
        [SerializeField] private TextMeshPro tileNameText;

        protected virtual void Start()
        {
            tileNameText.text = tileName;
        }

        public virtual void OnLanded()
        {
            Debug.Log("Landed on: " + tileName);
            OnLandedEvent?.Invoke(this);
        }
    }
}
