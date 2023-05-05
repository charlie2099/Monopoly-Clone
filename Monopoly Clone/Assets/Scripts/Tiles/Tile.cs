using System;
using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Tiles
{
    public abstract class Tile : MonoBehaviour, ILandable
    {
        public event Action<Tile> OnLandedEvent;
        public string TileName => tileName;
        public int TileNum => tileNum;

        [FormerlySerializedAs("tileID")] [SerializeField] private int tileNum;
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
