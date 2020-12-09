using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMO_WorkSpace
{
    public class EntityStats : MonoBehaviour
    {
        public int m_maxHealthPoint = 100;
        public int m_maxMagicPoint = 100;
        public int m_healthPoint = 100;
        public int m_magicPoint = 100;

        private bool m_isDead = false;

        public void AddHealthPoint(int deltaHP)
        {
            m_healthPoint += deltaHP;
            if(m_healthPoint >= m_maxHealthPoint)
            {
                m_healthPoint = m_maxHealthPoint;
            }
            if(m_healthPoint < 0)
            {
                m_healthPoint = 0;
            }
        }

        public void AddMagicPoint(int deltaMP)
        {
            m_magicPoint += deltaMP;
            if (m_magicPoint >= m_maxMagicPoint)
            {
                m_magicPoint = m_maxMagicPoint;
            }
            if (m_magicPoint < 0)
            {
                m_magicPoint = 0;
            }
        }
    }
}