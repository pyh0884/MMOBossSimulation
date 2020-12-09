using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMO_WorkSpace
{
    [System.Serializable]
    public class EntityAttributes
    {
        private Attributes m_attribute;
        private int m_attributeAmount;

        public EntityAttributes(Attributes attribute, int attributeAmount)
        {
            m_attribute = attribute;
            m_attributeAmount = attributeAmount;
        }
    }
}