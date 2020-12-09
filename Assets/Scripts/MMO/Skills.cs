using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMO_WorkSpace
{
    [CreateAssetMenu(menuName = "MMO/Create Skill")]
    public class Skills : ScriptableObject
    {
        // The description of skill
        [TextArea]
        public string Descriptions;

        // The icon of skill
        public Sprite Icon;

        // #Todo: Add skill attributes

        // The affected attributes of skill
        public List<EntityAttributes> AffectedAttributes = new List<EntityAttributes>();
    }
}