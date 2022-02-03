using Framework;
using HarmonyLib;

namespace AngerFootVR.Patches
{
    [HarmonyPatch(typeof(PlayerMovement), "GetMoveSpeedMultiplier")]
    internal class MovementAccelerationPatch
    {
        [HarmonyPrefix]
        internal static bool GetMoveSpeedMultiplier(ref float __result, bool isGrounded)
        {
            var _player = SingletonBehaviour<Player>.Instance;
            float num = 1f + SingletonBehaviour<Player>.Instance.GetInfluenceLevel(Influence.Sugar);
            if (_player.FootRig.IsChargingKick && isGrounded)
            {
                num *= 0.25f;
            }
            if (!_player.HasWeapon || _player.Weapon is MeleeWeapon)
            {
                num += 0.2f;
            }

            __result = num * Controllers.LeftControllerPrimaryAxis().magnitude;

            return false;
        }
    }
}
