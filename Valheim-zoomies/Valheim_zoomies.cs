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
                    
                    log.LogInfo($"Deer speed was: {__instance.m_speed}"); 
                    __instance.m_speed = 40;
                    log.LogInfo($"Deer speed is now: {__instance.m_speed}");

                }
                //log.LogInfo($"The speed of the character is: {___m_speed}");
              //  log.LogInfo($"The instance of the character is: {__instance}");
              //  log.LogInfo($"The character name is: {__instance.m_name}");
            }
        }
    }
}
