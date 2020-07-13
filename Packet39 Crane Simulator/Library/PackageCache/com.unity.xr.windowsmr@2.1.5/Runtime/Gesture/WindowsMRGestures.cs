using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine.Scripting;
using UnityEngine.XR.InteractionSubsystems;

namespace UnityEngine.XR.WindowsMR
{
    /// <summary>
    /// <para>
    /// Provide WindowsMR specific event callbacks that will inform code of when gesture events occur.
    /// </para>
    /// </summary>
    [DisallowMultipleComponent]
    [Preserve]
    public sealed class WindowsMRGestures : MonoBehaviour
    {
        /// <summary>
        /// Get the <c>WindowsMRGestureSubsystem</c> whose lifetime this component manages.
        /// </summary>
        public WindowsMRGestureSubsystem gestureSubsystem { get; private set; }

        /// <summary>
        /// This event is invoked whenever a <see cref="WindowsMRHoldGestureEvent"/> is received by the gestures subsystem.
        /// </summary>
        public event Action<WindowsMRHoldGestureEvent> onHoldChanged;

        /// <summary>
        /// This event is invoked whenever a <see cref="WindowsMRManipulationGestureEvent"/> is received by the gestures subsystem.
        /// </summary>
        public event Action<WindowsMRManipulationGestureEvent> onManipulationChanged;

        /// <summary>
        /// This event is invoked whenever a <see cref="WindowsMRNavigationGestureEvent"/> is received by the gestures subsystem.
        /// </summary>
        public event Action<WindowsMRNavigationGestureEvent> onNavigationChanged;

        /// <summary>
        /// This event is invoked whenever a <see cref="WindowsMRTappedGestureEvent"/> is received by the gestures subsystem.
        /// </summary>
        public event Action<WindowsMRTappedGestureEvent> onTappedChanged;

        /// <summary>
        /// This event is invoked whenever a <see cref="ActivateGestureEvent"/> is received by the gestures subsystem.
        /// </summary>
        public event Action<ActivateGestureEvent> onActivate;

        public bool enableNavigationGesture = false;
        public bool enableManipulationGesture = false;

        void Start()
        {
            List<XRGestureSubsystem> gestureSubsystems = new List<XRGestureSubsystem>();
            SubsystemManager.GetInstances<XRGestureSubsystem>(gestureSubsystems);
            foreach (var subsystem in gestureSubsystems)
            {
                if (subsystem != null && subsystem is WindowsMRGestureSubsystem)
                    gestureSubsystem = subsystem as WindowsMRGestureSubsystem;
            }

            OnValidate();
        }

        void OnValidate()
        {
            Debug.Assert(!(enableNavigationGesture && enableManipulationGesture),
                "Navigation and Manipulation gestures can not be enabled simulataneously");

            if (gestureSubsystem != null)
            {
                gestureSubsystem.SetEnableNavigationGesture(enableNavigationGesture);
                gestureSubsystem.SetEnableManipulationGesture(enableManipulationGesture);
            }
        }

        void Update()
        {
            if (gestureSubsystem == null || !gestureSubsystem.running)
                return;

            gestureSubsystem.Update();

            if (onHoldChanged != null)
            {
                foreach (var holdGestureEvent in gestureSubsystem.holdGestureEvents)
                    onHoldChanged(holdGestureEvent);
            }

            if (onManipulationChanged != null)
            {
                foreach (var manipulationGestureEvent in gestureSubsystem.manipulationGestureEvents)
                    onManipulationChanged(manipulationGestureEvent);
            }

            if (onNavigationChanged != null)
            {
                foreach (var navigationGestureEvent in gestureSubsystem.navigationGestureEvents)
                    onNavigationChanged(navigationGestureEvent);
            }

            if (onTappedChanged != null)
            {
                foreach (var tappedGestureEvent in gestureSubsystem.tappedGestureEvents)
                    onTappedChanged(tappedGestureEvent);
            }

            if (onActivate != null)
            {
                foreach (var activateGestureEvent in gestureSubsystem.activateGestureEvents)
                    onActivate(activateGestureEvent);
            }
        }
    }
}
