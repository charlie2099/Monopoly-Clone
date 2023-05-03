using System;
using Interfaces;
using TMPro;
using UnityEngine;

namespace Tiles
{
    public abstract class Tile : MonoBehaviour, ILandable
    {
        public event Action<Tile> OnLandedEvent;
        public string TileName => tileName;
        public int TileID => tileID;

        [SerializeField] private int tileID;
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
