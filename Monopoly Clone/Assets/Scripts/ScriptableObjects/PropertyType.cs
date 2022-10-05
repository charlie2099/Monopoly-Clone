using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PropertyTypeData", menuName = "ScriptableObjects/PropertyTypeData")]
    public class PropertyType : ScriptableObject
    {
        public bool isProperty;
    }
}