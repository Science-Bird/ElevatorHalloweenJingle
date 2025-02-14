using HarmonyLib;
using UnityEngine;

namespace ElevatorHalloweenJingle.Patches
{
    [HarmonyPatch(typeof(MineshaftElevatorController))]
    public class ElevatorJinglePatch
    {
        internal static System.Random clipRandom;

        [HarmonyPatch("Update")]
        [HarmonyPrefix]
        private static void SetJingleClip(MineshaftElevatorController __instance)
        {
            if (__instance.playMusic && !__instance.elevatorJingleMusic.isPlaying)
            {
                int clipIndex = clipRandom.Next(0, __instance.elevatorHalloweenClips.Length);
                if (__instance.elevatorMovingDown)
                {
                    __instance.elevatorJingleMusic.clip = __instance.elevatorHalloweenClips[clipIndex];
                }
                else
                {
                    __instance.elevatorJingleMusic.clip = __instance.elevatorHalloweenClipsLoop[clipIndex];
                }
            }
        }

        [HarmonyPatch("OnEnable")]
        [HarmonyPrefix]
        private static void SetJingleRandom(MineshaftElevatorController __instance)
        {
            clipRandom = new System.Random(StartOfRound.Instance.randomMapSeed);
        }
    }
}
