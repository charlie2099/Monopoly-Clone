using TMPro;
using UnityEngine;

namespace Tiles
{
    public abstract class Tile : MonoBehaviour, ILandable
    {
        public int TileID { get; set; }
        public abstract void OnLanded();
        
        [Header("Tile Data")]
        [SerializeField] protected string tileName;
        [SerializeField] protected TextMeshPro tileNameText;
    }
}
