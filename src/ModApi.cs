using BloodmoonServerStatus.Handlers;
using BloodmoonServerStatus.Utilities;
using HarmonyLib;
using System.Reflection;

namespace BloodmoonServerStatus
{
    internal class ModApi : IModApi
    {
        private static readonly ModLog<ModApi> _log = new ModLog<ModApi>();

        public static string BloodMoonCvarName { get; private set; } = "is_bloodmoon";

        public void InitMod(Mod _modInstance)
        {
            var harmony = new Harmony(GetType().ToString());
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            ModEvents.PlayerSpawnedInWorld.RegisterHandler(PlayerSpawnedInWorld.Handle);
        }
    }
}
