using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "ColourGroupData", menuName = "ScriptableObjects/ColourGroupData")]
public class ColourGroup : ScriptableObject
{
    public Color groupColour;
    public List<PropertyData> propertyTiles;
}
