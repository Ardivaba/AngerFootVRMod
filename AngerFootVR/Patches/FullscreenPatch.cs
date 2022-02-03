using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace AngerFootVR.Patches
{
    [HarmonyPatch(typeof(GameSettings), "OnGameStarted")]
    internal class FullscreenPatch
    {
        [HarmonyPrefix]
        internal static bool OnGameStarted()
        {
            bool _hasAppliedSettingsAtStart = (bool) typeof(GameSettings)
                .GetField("_hasAppliedSettingsAtStart", BindingFlags.NonPublic | BindingFlags.Static)
                .GetValue(null);

            if (!_hasAppliedSettingsAtStart)
            {
                GameState.LogEvent("Apply Quality Settings");
                QualitySettings.SetQualityLevel(GameSettings.QualityLevel, applyExpensiveChanges: true);
                GameSettings.Resolution.Apply(FullScreenMode.MaximizedWindow);
                typeof(GameSettings)
                    .GetField("_hasAppliedSettingsAtStart", BindingFlags.NonPublic | BindingFlags.Static)
                    .SetValue(null, true);
            }

            return false;
        }
    }
}
