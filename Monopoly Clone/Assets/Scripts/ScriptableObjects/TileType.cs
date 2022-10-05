using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "TileTypeData", menuName = "ScriptableObjects/TileTypeData")]
    public class TileType : ScriptableObject
    {
        public string name;
        public Texture imageTexture;
        public GameObject reward;
        
        /*
         * Types of tiles
         * - Properties with houses (colour, stackable)
         * - Properties without houses (stations etc)
         * - Special (community chest, chance)
         * - GO, Jail, Freeparking, Go To Jail
         */
    }
}