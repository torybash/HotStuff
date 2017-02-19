using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Frantics;
//using Frantics.Avatars;
//using Frantics.PlayerComponents;
//using KnapNok;
using System;

namespace Frantics.Hot
{
    /// <summary>
    /// Server player class for minigame (FSM)
    /// </summary>
    public class HotPlayer : MonoBehaviour //ServerPlayer
    {
        //private FSMState m_IdleState = new FSMState("Idle");
        //private FSMState m_FreeMovingState = new FSMState("FreeMoving");

        //private PlayerMovementController m_PlayerMovementController;
        //private CameraTrackedObject m_CameraTrackedObject;


        [Header("DEBUG VEHICLE CONSTRUCTION")]
        [SerializeField]
        private HotVehicleFrame m_DBGFramePrefab;
        [SerializeField]
        private HotVehicleEngine m_DBGEnginePrefab;
        [SerializeField]
        private HotVehicleWheel m_DBGDriveWheelPrefab;
        [SerializeField]
        private HotVehicleWheel m_DBGSupportWheelPrefab;

        private HotVehicleFrame m_Frame;
        private HotVehicleEngine m_Engine;
        private HotVehicleWheel m_DriveWheel;
        private HotVehicleWheel m_SupportWheel;

        private bool m_IsSpeederDown = false;


        //protected override void Awake()
        //{
        //    base.Awake();

        //    m_PlayerMovementController = GetComponent<PlayerMovementController>();

        //    // Register player for generic camera tracking
        //    m_CameraTrackedObject = this.gameObject.AddComponent<CameraTrackedObject>();

        //    m_IdleState.onEnterState += OnIdleEnter;
        //    m_IdleState.onUpdateState += OnIdleUpdate;
        //    AddState(m_IdleState);

        //    m_FreeMovingState.onEnterState += OnFreeMovingEnter;
        //    AddState(m_FreeMovingState);

        //    InitializeVehicle();
        //}

		void Start()
		{
			InitializeVehicle();
		}


        void Update()
        {
            //DEBUG!!
            m_IsSpeederDown = Input.GetKey(KeyCode.RightArrow);
        }

        void FixedUpdate()
        {
            if (m_DriveWheel != null)
                m_DriveWheel.SetSpeederDown(m_IsSpeederDown);
        }

        private void InitializeVehicle()
        {
            m_Frame = Instantiate(m_DBGFramePrefab, transform);
            m_Frame.transform.position = transform.position;

            m_Engine = Instantiate(m_DBGEnginePrefab, transform);
            m_DriveWheel = Instantiate(m_DBGDriveWheelPrefab, transform);
            m_SupportWheel = Instantiate(m_DBGSupportWheelPrefab, transform);

            m_Frame.AttachParts(m_Engine, m_DriveWheel, m_SupportWheel);
        }

        //protected override void OnPlayerInitialized()
        //{
        //    base.OnPlayerInitialized();

        //    // WARINING : Every registering lister to input from ServerPlayerManager have to be here (after initialization player)

        //    // EXAMPLE : Listning on button down event
        //    ServerPlayerManager.Instance.AddListenerForButton(PlayerID, OnPlayerButtonEvent);
        //}

        //private void OnPlayerButtonEvent(float duration, byte ButtonID)
        //{
            
        //}

        //private void OnIdleEnter(FSMState fromState)
        //{
        //    // Place for script
        //}

        //private void OnIdleUpdate()
        //{
        //    // Place for script
        //}

        //private void OnFreeMovingEnter(FSMState fromState)
        //{
        //    m_PlayerMovementController.SetActive(true);
        //}
    }
}
