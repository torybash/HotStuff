using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Frantics.Hot
{
    /// <summary>
    /// 
    /// </summary>
    public class HotVehicleEngine : MonoBehaviour
    {
        [Serializable]
        public class EngineStats
        {
            public float MaxMotorTorque;
            public float MotorSpeed;
        }

        [SerializeField]
        private EngineStats m_Stats;
        public EngineStats Stats
        {
            get { return m_Stats;  }
        }

        private FixedJoint2D m_FixedJoint = null;
        public FixedJoint2D FixedJoint
        {
            get
            {
                if (m_FixedJoint == null)
                    m_FixedJoint = GetComponent<FixedJoint2D>();
                return m_FixedJoint;
            }
        }

    }
}