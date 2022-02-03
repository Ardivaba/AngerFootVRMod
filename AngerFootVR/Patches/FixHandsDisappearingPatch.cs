using AngerFootVR.Util;
using HarmonyLib;
using UnityEngine;

namespace AngerFootVR.Patches
{
    [HarmonyPatch(typeof(FirstPersonRig), "Awake")]
    internal class FixHandsDisappearingPatch
    {
        [HarmonyPostfix]
        internal static void Awake(FirstPersonRig __instance)
        {
            var animator = (Animator)ReflectionUtils.GetValue(__instance, "_animator");
            animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;

            foreach (var renderer in __instance.GetComponentsInChildren<SkinnedMeshRenderer>())
            {
                renderer.updateWhenOffscreen = true;
            }
        }
    }
}
