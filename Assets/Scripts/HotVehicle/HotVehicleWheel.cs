using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Frantics.Hot
{
    /// <summary>
    /// 
    /// </summary>
    public class HotVehicleWheel : MonoBehaviour
    {

        private HingeJoint2D m_HingeJoint = null;
        public HingeJoint2D HingeJoint
        {
            get
            {
                if (m_HingeJoint == null)
                    m_HingeJoint = GetComponent<HingeJoint2D>();
                return m_HingeJoint;
            }
        }


        public void SetSpeederDown(bool isSpeederDown)
        {
            HingeJoint.useMotor = isSpeederDown;
            //if (isSpeederDown)
            //{
            //    var motor = HingeJoint.motor;
            //    motor.motorSpeed = m_MotorSpeed;
            //    motor.maxMotorTorque = m_MaxMotorTorque;
            //    HingeJoint.motor = motor;
            //}
        }

        public void InitializeMotor(float motorSpeed, float maxMotorTorque)
        {
            var motor = HingeJoint.motor;
            motor.motorSpeed = motorSpeed;
            motor.maxMotorTorque = maxMotorTorque;
            HingeJoint.motor = motor;
        }
    }
}