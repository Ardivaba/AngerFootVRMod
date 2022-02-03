using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace AngerFootVR.Patches
{
    [HarmonyPatch(typeof(HitscanProjectile), "Cast")]
    internal class HitscanProjectileCastPatch
    {
        [HarmonyPrefix]
        internal static bool Cast(HitscanProjectile __instance, ref Vector3 origin, ref Vector3 direction, int layerMask, out Vector3 position, out Vector3 normal, out Collider collider)
        {
            if (__instance.Owner is Player)
            {
                var muzzle = GetMuzzleTransform();
                origin = muzzle.transform.position;
                direction = muzzle.transform.forward;
            }

            position = Vector3.zero;
            normal = Vector3.zero;
            collider = null;
            return true;
        }

        private static Transform GetMuzzleTransform()
        {
            var hands = GameObject.Find("FPS_Hands_02_RigSkin:FPS_Hands_r_FPS_hands_WristSHJnt");
            var gunRig = hands.transform.GetComponentInChildren<FirstPersonGunRig>();
            return typeof(FirstPersonGunRig).GetField("_muzzlePosition", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(gunRig) as Transform;
        }
    }
}
