using ScriptableObjects;
using UnityEngine;

namespace Tiles
{
    public abstract class Tile : MonoBehaviour
    {
        [SerializeField] protected string tileName;
        public bool IsEmpty { get; set; }
        public int TileID { get; set; }
    }
}
