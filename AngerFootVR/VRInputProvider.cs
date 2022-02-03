using AngerFootVR;
using Framework;
using MelonLoader;
using UnityEngine;

namespace AngerFootVR
{
    public class VRInputProvider : IInputProvider
    {
        public bool IsShootPressed()
        {
            return Controllers.RightControllerTrigger() > 0.2f;
        }

        public bool WasShootReleased()
        {
            return Controllers.RightControllerTrigger() < 0.2f;
        }

        public bool IsKickPressed()
        {
            return Controllers.LeftControllerTriggerButton();
        }

        public bool WasKickReleased()
        {
            return Controllers.LeftControllerTriggerButton();
        }

        public bool IsThrowPressed()
        {
            return Controllers.RightControllerGrip() > 0.2f;
        }

        public bool IsPausePressed()
        {
            return false;
        }

        public bool WasRespawnPressed()
        {
            return Controllers.LeftControllerMenuButtonPressed();
        }

        public bool WasJumpPressed()
        {
            return Controllers.LeftControllerGrip() > 0.2f;
        }

        public bool WasPausePressed()
        {
            return false;
        }

        public bool WasInteractPressed()
        {
            return Controllers.RightControllerPrimaryButtonPressed();
        }

        public bool WasPauseReleased()
        {
            return true;
        }

        public Vector2 GetMovementAxis()
        {
            var player = SingletonBehaviour<Player>.Instance;
            if (player)
            {
                Vector2 axis = Controllers.LeftControllerPrimaryAxis();
                float deviceAngle = -Controllers.DeviceRotation().eulerAngles.y;
                return (Quaternion.Euler(0, 0, deviceAngle) * axis).normalized;
            }

            return Vector2.zero;
        }

        float lookAxis = 0f;
        public Vector2 GetLookDelta()
        {
            lookAxis = Mathf.Lerp(lookAxis, Controllers.RightControllerPrimaryAxis().x, 35f * Time.deltaTime);

            return new Vector2(lookAxis * 3.5f, 0f);
        }
    }
}
