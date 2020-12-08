using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMO_WorkSpace
{
    [CreateAssetMenu(menuName = "MMO/Create Attribute")]
    public class Attributes : ScriptableObject
    {
        // The description of attribute
        public string Descriptions;

        // The icon of attribute
        public Sprite Thumbnail;
    }
}