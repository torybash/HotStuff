using System.Collections;
using System.Collections.Generic;
//using KnapNok;
using UnityEngine;

namespace Frantics.Hot
{
    /// <summary>
    /// 
    /// </summary>
    public class HotVehicleFrame : MonoBehaviour
    {

        private Rigidbody2D m_Rigidbody = null;
        public Rigidbody2D Rigidbody
        {
            get
            {
                if (m_Rigidbody == null)
                    m_Rigidbody = GetComponent<Rigidbody2D>();
                return m_Rigidbody;
            }
        }


        [SerializeField]
        private Transform m_EnginePos;
        [SerializeField]
        private Transform m_DriveWheelPos;
        [SerializeField]
        private Transform m_SupportWheelPos;
        [SerializeField]
        private Transform m_DriverSeatPos;


        public void AttachParts(HotVehicleEngine engine, HotVehicleWheel driveWheel, HotVehicleWheel supportWheel)
        {
			var engineStats = engine.Stats;
			engine.gameObject.SetActive(false);
            //engine.transform.position = m_EnginePos.position;
            //engine.FixedJoint.connectedBody = Rigidbody;
            

            driveWheel.transform.position = m_DriveWheelPos.position;
            driveWheel.HingeJoint.connectedBody = Rigidbody;
            driveWheel.InitializeMotor(engineStats.MotorSpeed, engineStats.MaxMotorTorque);

            supportWheel.transform.position = m_SupportWheelPos.position;
            supportWheel.HingeJoint.connectedBody = Rigidbody;
        }

    }
}