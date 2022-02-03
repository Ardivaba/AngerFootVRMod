using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AngerFootVR
{
    public static class HandsManager
    {
        private static Vector3 _leftIkPosition = Vector3.zero;
        private static Vector3 _rightIkPosition = Vector3.zero;

        public static void ApplyIK()
        {
            var player = GameObject.FindObjectOfType<Player>();
            var fpsHands = GameObject.Find("fpsHands_V02");
            var parent = player.Camera.transform.parent;

            // Left bones
            var leftUpperArm = GameObject.Find("FPS_Hands_02_RigSkin:FPS_Hands_l_FPS_hands_ShoulderSHJnt");
            var leftForearm = GameObject.Find("FPS_Hands_02_RigSkin:FPS_Hands_l_FPS_hands_Elbow_CurveSHJnt");
            var leftHand = GameObject.Find("FPS_Hands_02_RigSkin:FPS_Hands_l_FPS_hands_WristSHJnt");
            var leftIk = fpsHands.gameObject.AddComponent<InverseKinematics>();

            // Left bones setup
            leftIk.upperArm = leftUpperArm.transform;
            leftIk.forearm = leftForearm.transform;
            leftIk.hand = leftHand.transform;
            leftIk.uppperArm_OffsetRotation = new Vector3(0, 90, 0);
            leftIk.forearm_OffsetRotation = new Vector3(0, 90, 0);
            leftIk.hand_OffsetRotation = new Vector3(0, 90, 0);

            // Left elbow target
            var leftElbowTarget = new GameObject("Left IK Elbow");
            leftElbowTarget.transform.parent = fpsHands.transform;
            leftElbowTarget.transform.localPosition = new Vector3(-1f, -0.5f, 0.5f);
            leftIk.elbow = leftElbowTarget.transform;

            // Left IK target
            var leftTarget = new GameObject("Left IK Target");
            leftTarget.transform.parent = parent.transform;
            leftIk.target = leftTarget.transform;

            // Right bones
            var rightUpperArm = GameObject.Find("FPS_Hands_02_RigSkin:FPS_Hands_r_FPS_hands_ShoulderSHJnt");
            var rightForearm = GameObject.Find("FPS_Hands_02_RigSkin:FPS_Hands_r_FPS_hands_Elbow_CurveSHJnt");
            var rightHand = GameObject.Find("FPS_Hands_02_RigSkin:FPS_Hands_r_FPS_hands_WristSHJnt");
            var rightIk = fpsHands.gameObject.AddComponent<InverseKinematics>();

            rightIk.upperArm = rightUpperArm.transform;
            rightIk.forearm = rightForearm.transform;
            rightIk.hand = rightHand.transform;
            rightIk.uppperArm_OffsetRotation = new Vector3(0, -90, 0);
            rightIk.forearm_OffsetRotation = new Vector3(0, -90, 0);
            rightIk.hand_OffsetRotation = new Vector3(40f, -180f, -90f);

            // Right elbow target
            var rightElbowTarget = new GameObject("Right IK Elbow");
            rightElbowTarget.transform.parent = fpsHands.transform;
            rightElbowTarget.transform.localPosition = new Vector3(1f, -0.5f, 0.5f);
            rightIk.elbow = rightElbowTarget.transform;

            // Right IK target
            var rightTarget = new GameObject("Right IK Target");
            rightTarget.transform.parent = parent.transform;
            rightIk.target = rightTarget.transform;

            // Reattach glock
            foreach (var rig in GameObject.FindObjectsOfType<FirstPersonGunRig>())
            {
                Transform child = rig.transform;
                if (child.GetComponent<FirstPersonGunRig>())
                {
                    if (IsWeaponTwoHanded(rig))
                    {
                        child.transform.position = rightHand.transform.position;
                        child.transform.rotation = rightHand.transform.rotation;
                        child.transform.parent = rightHand.transform;
                        child.transform.localPosition = new Vector3(-0.29f, 0.31f, 1.47f);
                        child.transform.localEulerAngles = new Vector3(0, -270, -90);
                        child.transform.GetComponent<Animator>().enabled = false;
                    }
                    else
                    {
                        child.transform.position = rightHand.transform.position;
                        child.transform.rotation = rightHand.transform.rotation;
                        child.transform.parent = rightHand.transform;
                        child.transform.localPosition = new Vector3(-0.69f, 0.29f, 1.51f);
                        child.transform.localEulerAngles = new Vector3(0, -270, -90);
                        child.transform.GetComponent<Animator>().enabled = false;
                    }
                }
            }
        }

        public static void UpdateIK()
        {
            // Left
            var leftIkTarget = GameObject.Find("Left IK Target");

            _leftIkPosition = Vector3.Lerp(leftIkTarget.transform.localPosition, Controllers.LeftControllerPosition(), 15f * Time.deltaTime);
            leftIkTarget.transform.localPosition = _leftIkPosition;
            leftIkTarget.transform.localRotation = Controllers.LeftControllerRotation();

            // Right
            var rightIkTarget = GameObject.Find("Right IK Target");

            _rightIkPosition = Vector3.Lerp(rightIkTarget.transform.localPosition, Controllers.RightControllerPosition(), 15f * Time.deltaTime);

            rightIkTarget.transform.localPosition = _rightIkPosition;
            rightIkTarget.transform.localEulerAngles = Controllers.RightControllerRotation().eulerAngles;

            // Pump attach
            var pump = GameObject.Find("ShotGun:Pump");
            if (Vector3.Distance(leftIkTarget.transform.position, pump.transform.position) < 0.25f)
            {
                leftIkTarget.transform.parent = pump.transform;
                leftIkTarget.transform.localPosition = Vector3.zero;
                MelonLogger.Msg("Attaching to pump");
            }
            else
            {
                leftIkTarget.transform.parent = GameObject.Find("fpsHands_V02").transform;
                MelonLogger.Msg("Not attaching to pump");
            }
        }

        private static bool IsWeaponTwoHanded(FirstPersonGunRig rig)
        {
            return rig.transform.name == "Shotgun";
        }
    }
}
