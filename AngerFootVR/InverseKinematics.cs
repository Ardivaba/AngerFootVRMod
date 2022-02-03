using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AngerFootVR
{
    public class InverseKinematics : MonoBehaviour
    {
        public Transform upperArm;
        public Transform forearm;
        public Transform hand;
        public Transform elbow;
        public Transform target;
        public Vector3 uppperArm_OffsetRotation;
        public Vector3 forearm_OffsetRotation;
        public Vector3 hand_OffsetRotation;
        public bool handMatchesTargetRotation = true;
        public bool debug;

        float angle;
        float upperArm_Length;
        float forearm_Length;
        float arm_Length;
        float targetDistance;
        float adyacent;

        void LateUpdate()
        {
            if (upperArm != null && forearm != null && hand != null && elbow != null && target != null)
            {
                upperArm.LookAt(target, elbow.position - upperArm.position);
                upperArm.Rotate(uppperArm_OffsetRotation);

                Vector3 cross = Vector3.Cross(elbow.position - upperArm.position, forearm.position - upperArm.position);

                upperArm_Length = Vector3.Distance(upperArm.position, forearm.position);
                forearm_Length = Vector3.Distance(forearm.position, hand.position);
                arm_Length = upperArm_Length + forearm_Length;
                targetDistance = Vector3.Distance(upperArm.position, target.position);
                targetDistance = Mathf.Min(targetDistance, arm_Length - arm_Length * 0.001f);

                adyacent = ((upperArm_Length * upperArm_Length) - (forearm_Length * forearm_Length) + (targetDistance * targetDistance)) / (2 * targetDistance);

                angle = Mathf.Acos(adyacent / upperArm_Length) * Mathf.Rad2Deg;

                upperArm.RotateAround(upperArm.position, cross, -angle);

                forearm.LookAt(target, cross);
                forearm.Rotate(forearm_OffsetRotation);

                if (handMatchesTargetRotation)
                {
                    hand.rotation = target.rotation;
                    hand.Rotate(hand_OffsetRotation);
                }

                if (debug)
                {
                    if (forearm != null && elbow != null)
                    {
                        Debug.DrawLine(forearm.position, elbow.position, Color.blue);
                    }

                    if (upperArm != null && target != null)
                    {
                        Debug.DrawLine(upperArm.position, target.position, Color.red);
                    }
                }
            }
            else
            {
                if (upperArm == null) MelonLogger.Error("IK: Upper Arm is not set");
                if (forearm == null) MelonLogger.Error("IK: Forearm is not set");
                if (hand == null) MelonLogger.Error("IK: Hand is not set");
                if (elbow == null) MelonLogger.Error("IK: Elbow is not set");
                if (target == null) MelonLogger.Error("IK: Target is not set");
            }
        }
    }
}