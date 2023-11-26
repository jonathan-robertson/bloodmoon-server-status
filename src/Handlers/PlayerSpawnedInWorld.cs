using BloodmoonServerStatus.Utilities;
using System;

namespace BloodmoonServerStatus.Handlers
{
    internal class PlayerSpawnedInWorld
    {
        private static readonly ModLog<PlayerSpawnedInWorld> _log = new ModLog<PlayerSpawnedInWorld>();

        /// <summary>
        /// Handle player spawning into world.
        /// </summary>
        /// <param name="clientInfo">The client currently spawning in.</param>
        /// <param name="respawnType">The type of respawn.</param>
        /// <param name="pos">The position this player is respawning to.</param>
        public static void Handle(ClientInfo clientInfo, RespawnType respawnType, Vector3i pos)
        {
            try
            {
                if (clientInfo == null)
                {
                    _log.Warn("local client");
                    HandleLocalPlayers(respawnType);
                }
                else
                {
                    _log.Warn("remote client");
                    HandleRemotePlayer(clientInfo, respawnType);
                }
            }
            catch (Exception e)
            {
                _log.Error("Failed to handle PlayerSpawnedInWorld event.", e);
            }
        }

        private static void HandleLocalPlayers(RespawnType respawnType)
        {
            _log.Warn($"respawn type: {respawnType}");
            switch (respawnType)
            {
                case RespawnType.NewGame: // local player creating a new game
                case RespawnType.LoadedGame: // local player loading existing game
                case RespawnType.Died: // existing player returned from death
                    var valueToSet = GameManager.Instance.World.aiDirector.BloodMoonComponent.BloodMoonActive ? 1 : 0;
                    _log.Warn($"expected value: {valueToSet}");
                    var localPlayers = GameManager.Instance.World.GetLocalPlayers();
                    _log.Warn($"total local players: {localPlayers.Count}");
                    for (var i = 0; i < localPlayers.Count; i++)
                    {
                        _log.Warn($"local player {i} is alive? {localPlayers[i].IsAlive()}");
                        if (localPlayers[i].IsAlive())
                        {
                            localPlayers[i].SetCVar(ModApi.BloodMoonCvarName, valueToSet);
                        }
                    }
                    break;
            }
        }

        private static void HandleRemotePlayer(ClientInfo clientInfo, RespawnType respawnType)
        {
            _log.Warn($"respawn type: {respawnType}");
            if (!GameManager.Instance.World.Players.dict.TryGetValue(clientInfo.entityId, out var player)
                || !player.IsAlive())
            {
                _log.Warn($"remote player is either not present or is dead");
                return; // player not found or player not ready
            }

            switch (respawnType)
            {
                case RespawnType.EnterMultiplayer: // first-time login for new player
                case RespawnType.JoinMultiplayer: // existing player rejoining
                case RespawnType.Died: // existing player returned from death
                    var valueToSet = GameManager.Instance.World.aiDirector.BloodMoonComponent.BloodMoonActive ? 1 : 0;
                    _log.Warn($"expected value: {valueToSet}");
                    player.SetCVar(ModApi.BloodMoonCvarName, valueToSet);
                    break;
            }
        }
    }
}
