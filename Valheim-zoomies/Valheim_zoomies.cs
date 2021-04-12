using BepInEx;
using HarmonyLib;
using UnityEngine;


namespace Zoomies_mod
{
    [BepInPlugin("Reesy.Zoomies_mod", "Zoomies_mod", "0.1.0")]
    [BepInProcess("valheim.exe")]
    public class ValheimMod : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("Reesy.Zoomies_mod");
        public static BepInEx.Logging.ManualLogSource log;
        void Awake()
        {
            log = Logger;
            log.LogInfo("Zoomies mod initiated");
            harmony.PatchAll();
        }
        [HarmonyPatch(typeof(Character), "UpdateWalking")]
        class UpdateWalkingPatch
        {
            static void Prefix(ref Character __instance)
            {
                if (__instance.m_name == "$enemy_deer")
                {
                    //This should really be patched inside the awake method.
                    log.LogInfo($"Deer run speed was:  {__instance.m_runSpeed}");
                    __instance.m_runSpeed = 0.1f;
                    log.LogInfo($"Deer run speed is now:  {__instance.m_runSpeed}");
                }

            }
        }
    }
}
