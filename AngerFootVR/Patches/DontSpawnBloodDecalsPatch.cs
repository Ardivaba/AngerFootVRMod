using HarmonyLib;
using System;
using UnityEngine;

namespace AngerFootVR.Patches
{
    [HarmonyPatch(typeof(BloodCamera), "SpawnBlood", new Type[] { typeof(Vector3), typeof(Vector3), typeof(bool) })]
    internal class DontSpawnBloodDecalsPatch
    {
        [HarmonyPrefix]
        internal static bool SpawnBlood(Vector3 position, Vector3 direction, ref bool spawnDecalToo)
        {
            spawnDecalToo = false;
            return true;
        }
    }

    [HarmonyPatch(typeof(BloodCamera), "SpawnBlood", new Type[] { typeof(Vector3), typeof(Vector3), typeof(Color), typeof(bool) })]
    internal class DontSpawnBloodDecalsPatch2
    {
        [HarmonyPrefix]
        internal static bool SpawnBlood(Vector3 position, Vector3 direction, ref bool spawnDecalToo)
        {
            spawnDecalToo = false;
            return true;
        }
    }
}
