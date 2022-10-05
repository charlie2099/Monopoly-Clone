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
         *
         *
         * Property Block Tile (name, image, cost, colour, houses)
         * Property Tile (name, image, cost)
         * Special Tile (name, image, pick up cards)
         * Tax Tile (name, image, cost)
         * Corner Tile (name, image)
         * GO (name, image, pick up money)
         *
         * Properties In Common
         * - Name
         * - Image
         */
    }
}