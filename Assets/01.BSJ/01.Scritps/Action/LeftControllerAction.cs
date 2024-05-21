using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Action
{
    public class LeftControllerAction : MonoBehaviour, XRIDefaultInputActions.IXRILeftHandActions
    {
        private XRIDefaultInputActions controls;

        private void OnEnable()
        {
            if (controls == null)
            {
                controls = new XRIDefaultInputActions();
                controls.XRILeftHand.SetCallbacks(this);
            }
            controls.XRILeftHand.Enable();
        }

        public void OnAimFlags(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnAimPosition(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnAimRotation(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnGripPosition(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnGripRotation(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnHapticDevice(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnIsTracked(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnPinchPosition(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnPokePosition(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnPokeRotation(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnPosition(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnPrimaryButtonPress(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Left Controller: Primary Button Press");
            }
            //throw new System.NotImplementedException();
        }

        public void OnRotation(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnSecondaryButtonPress(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Left Controller: Secondary Button Press");
            }
            //throw new System.NotImplementedException();
        }

        public void OnTrackingState(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
