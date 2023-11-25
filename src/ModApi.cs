using BloodmoonServerStatus.Handlers;
using BloodmoonServerStatus.Utilities;
using HarmonyLib;
using System;
using System.Reflection;

namespace BloodmoonServerStatus
{
    internal class ModApi : IModApi
    {
        private static readonly ModLog<ModApi> _log = new ModLog<ModApi>();

        private static readonly string ModMaintainer = "@kanaverum";
        private static readonly string SupportLink = "https://discord.gg/hYa2sNHXya";

        public static string BloodMoonCvarName { get; private set; } = "is_bloodmoon";

        public void InitMod(Mod _modInstance)
        {
            var harmony = new Harmony(GetType().ToString());
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            ModEvents.GameAwake.RegisterHandler(OnGameAwake);
            ModEvents.PlayerSpawnedInWorld.RegisterHandler(PlayerSpawnedInWorld.Handle);
        }

        private void OnGameAwake()
        {
            try
            {
                _log.Info($"If this mod generates any errors, you can check with {ModMaintainer} at {SupportLink} for updates and receive support.");
            }
            catch (Exception e)
            {
                _log.Error("OnGameAwake", e);
            }
        }
    }
}
