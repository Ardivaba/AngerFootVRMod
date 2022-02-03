using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace AngerFootVR
{
    public static class Controllers
    {
        public static Vector3 DevicePosition()
        {
            InputDeviceCharacteristics rightControllersFilter = InputDeviceCharacteristics.HeadMounted;

            List<InputDevice> foundControllers = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(rightControllersFilter, foundControllers);

            var device = foundControllers[0];

            Vector3 position;
            device.TryGetFeatureValue(CommonUsages.centerEyePosition, out position);
            return position;
        }

        public static Quaternion DeviceRotation()
        {
            InputDeviceCharacteristics rightControllersFilter = InputDeviceCharacteristics.HeadMounted;

            List<InputDevice> foundControllers = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(rightControllersFilter, foundControllers);

            var device = foundControllers[0];

            Quaternion rotation;
            device.TryGetFeatureValue(CommonUsages.deviceRotation, out rotation);
            return rotation;
        }

        public static Vector3 LeftControllerPosition()
        {
            InputDeviceCharacteristics rightControllersFilter = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Left;

            List<InputDevice> foundControllers = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(rightControllersFilter, foundControllers);

            var device = foundControllers[0];

            Vector3 position;
            device.TryGetFeatureValue(CommonUsages.devicePosition, out position);
            return position;
        }

        public static Quaternion LeftControllerRotation()
        {
            InputDeviceCharacteristics rightControllersFilter = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Left;

            List<InputDevice> foundControllers = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(rightControllersFilter, foundControllers);

            var device = foundControllers[0];

            Quaternion rotation;
            device.TryGetFeatureValue(CommonUsages.deviceRotation, out rotation);
            return rotation;
        }

        public static Vector3 RightControllerPosition()
        {
            InputDeviceCharacteristics rightControllersFilter = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Right;

            List<InputDevice> foundControllers = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(rightControllersFilter, foundControllers);

            var device = foundControllers[0];

            Vector3 position;
            device.TryGetFeatureValue(CommonUsages.devicePosition, out position);
            return position;
        }

        public static Quaternion RightControllerRotation()
        {
            InputDeviceCharacteristics rightControllersFilter = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Right;

            List<InputDevice> foundControllers = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(rightControllersFilter, foundControllers);

            var device = foundControllers[0];

            Quaternion rotation;
            device.TryGetFeatureValue(CommonUsages.deviceRotation, out rotation);
            return rotation;
        }

        public static bool LeftControllerTriggerButton()
        {
            InputDeviceCharacteristics rightControllersFilter = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Left;

            List<InputDevice> foundControllers = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(rightControllersFilter, foundControllers);

            var device = foundControllers[0];

            bool value;
            device.TryGetFeatureValue(CommonUsages.triggerButton, out value);
            return value;
        }

        public static float LeftControllerTrigger()
        {
            InputDeviceCharacteristics rightControllersFilter = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Left;

            List<InputDevice> foundControllers = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(rightControllersFilter, foundControllers);

            var device = foundControllers[0];

            float value;
            device.TryGetFeatureValue(CommonUsages.trigger, out value);
            return value;
        }

        public static float RightControllerTrigger()
        {
            InputDeviceCharacteristics rightControllersFilter = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Right;

            List<InputDevice> foundControllers = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(rightControllersFilter, foundControllers);

            var device = foundControllers[0];

            float value;
            device.TryGetFeatureValue(CommonUsages.trigger, out value);
            return value;
        }

        public static float LeftControllerGrip()
        {
            InputDeviceCharacteristics rightControllersFilter = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Left;

            List<InputDevice> foundControllers = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(rightControllersFilter, foundControllers);

            var device = foundControllers[0];

            float value;
            device.TryGetFeatureValue(CommonUsages.grip, out value);
            return value;
        }

        public static float RightControllerGrip()
        {
            InputDeviceCharacteristics rightControllersFilter = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Right;

            List<InputDevice> foundControllers = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(rightControllersFilter, foundControllers);

            var device = foundControllers[0];

            float value;
            device.TryGetFeatureValue(CommonUsages.grip, out value);
            return value;
        }

        public static bool LeftControllerMenuButtonPressed()
        {
            InputDeviceCharacteristics rightControllersFilter = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Left;

            List<InputDevice> foundControllers = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(rightControllersFilter, foundControllers);

            var device = foundControllers[0];

            bool value;
            device.TryGetFeatureValue(CommonUsages.menuButton, out value);
            return value;
        }

        public static bool LeftControllerPrimaryButtonPressed()
        {
            InputDeviceCharacteristics rightControllersFilter = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Left;

            List<InputDevice> foundControllers = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(rightControllersFilter, foundControllers);

            var device = foundControllers[0];

            bool value;
            device.TryGetFeatureValue(CommonUsages.primaryButton, out value);
            return value;
        }

        public static bool RightControllerPrimaryButtonPressed()
        {
            InputDeviceCharacteristics rightControllersFilter = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Right;

            List<InputDevice> foundControllers = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(rightControllersFilter, foundControllers);

            var device = foundControllers[0];

            bool value;
            device.TryGetFeatureValue(CommonUsages.primaryButton, out value);
            return value;
        }

        public static bool RightControllerSecondaryButtonPressed()
        {
            InputDeviceCharacteristics rightControllersFilter = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Right;

            List<InputDevice> foundControllers = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(rightControllersFilter, foundControllers);

            var device = foundControllers[0];

            bool value;
            device.TryGetFeatureValue(CommonUsages.secondaryButton, out value);
            return value;
        }

        public static Vector2 LeftControllerPrimaryAxis()
        {
            InputDeviceCharacteristics rightControllersFilter = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Left;

            List<InputDevice> foundControllers = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(rightControllersFilter, foundControllers);

            var device = foundControllers[0];

            Vector2 value;
            device.TryGetFeatureValue(CommonUsages.primary2DAxis, out value);
            return value;
        }

        public static Vector2 RightControllerPrimaryAxis()
        {
            InputDeviceCharacteristics rightControllersFilter = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Right;

            List<InputDevice> foundControllers = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(rightControllersFilter, foundControllers);

            var device = foundControllers[0];

            Vector2 value;
            device.TryGetFeatureValue(CommonUsages.primary2DAxis, out value);
            return value;
        }
    }
}
