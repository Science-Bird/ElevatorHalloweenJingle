using HarmonyLib;
using UnityEngine;

namespace ElevatorHalloweenJingle.Patches
{
    [HarmonyPatch(typeof(MineshaftElevatorController))]
    public class ElevatorJinglePatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPrefix]
        private static void SetJingleClip(MineshaftElevatorController __instance)
        {
            if (!__instance.elevatorJingleMusic.isPlaying)
            {
                if (__instance.elevatorMovingDown)
                {
                    __instance.elevatorJingleMusic.clip = __instance.elevatorHalloweenClips[Random.Range(0, __instance.elevatorHalloweenClips.Length)];
                }
                else
                {
                    __instance.elevatorJingleMusic.clip = __instance.elevatorHalloweenClipsLoop[Random.Range(0, __instance.elevatorHalloweenClipsLoop.Length)];
                }
            }
        }
    }
}
