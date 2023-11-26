using BloodmoonServerStatus.Utilities;
using HarmonyLib;
using System;

namespace BloodmoonServerStatus.Patches
{
    [HarmonyPatch(typeof(AIDirectorBloodMoonComponent), "StartBloodMoon")]
    internal class AIDirectorBloodMoonComponent_StartBloodMoon_Patches
    {
        private static readonly ModLog<AIDirectorBloodMoonComponent_StartBloodMoon_Patches> _log = new ModLog<AIDirectorBloodMoonComponent_StartBloodMoon_Patches>();

        public static void Postfix()
        {
            try
            {
                _log.Warn("Prefix: StartBloodMoon triggered"); // TODO: remove
                var players = GameManager.Instance.World.Players.list;
                for (var i = 0; i < players.Count; i++)
                {
                    players[i].SetCVar(ModApi.BloodMoonCvarName, 1);
                }
            }
            catch (Exception e)
            {
                _log.Error("Postfix", e);
            }
        }
    }

    [HarmonyPatch(typeof(AIDirectorBloodMoonComponent), "EndBloodMoon")]
    internal class AIDirectorBloodMoonComponent_EndBloodMoon_Patches
    {
        private static readonly ModLog<AIDirectorBloodMoonComponent_EndBloodMoon_Patches> _log = new ModLog<AIDirectorBloodMoonComponent_EndBloodMoon_Patches>();

        public static void Postfix()
        {
            try
            {
                _log.Warn("Prefix: EndBloodMoon triggered"); // TODO: remove
                var players = GameManager.Instance.World.Players.list;
                for (var i = 0; i < players.Count; i++)
                {
                    players[i].SetCVar(ModApi.BloodMoonCvarName, 0);
                }
            }
            catch (Exception e)
            {
                _log.Error("Postfix", e);
            }
        }
    }
}
