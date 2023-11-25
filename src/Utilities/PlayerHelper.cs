namespace BloodmoonServerStatus.Utilities
{
    internal class PlayerHelper
    {
        private static readonly ModLog<PlayerHelper> _log = new ModLog<PlayerHelper>();

        public static bool TryGetClientInfo(int entityId, out ClientInfo clientInfo)
        {
            clientInfo = ConnectionManager.Instance.Clients.ForEntityId(entityId);
            if (clientInfo == null)
            {
                _log.Error($"Could not retrieve remote player connection for {entityId}");
                return false;
            }
            return true;
        }

        public static bool TryGetClientInfoAndEntityPlayer(World world, int entityId, out ClientInfo clientInfo, out EntityPlayer player)
        {
            clientInfo = ConnectionManager.Instance.Clients.ForEntityId(entityId);
            if (clientInfo == null)
            {
                _log.Error($"Could not retrieve remote player connection for {entityId}");
                player = null;
                return false;
            }
            if (!world.Players.dict.TryGetValue(entityId, out player))
            {
                _log.Error($"Could not retrieve player for {entityId}");
                return false;
            }
            return true;
        }

        public static void TriggerGameEvent(ClientInfo clientInfo, EntityPlayer player, string eventName)
        {
            _ = GameEventManager.Current.HandleAction(eventName, null, player, false);
            clientInfo.SendPackage(NetPackageManager.GetPackage<NetPackageGameEventResponse>().Setup(eventName, clientInfo.entityId, "", "", NetPackageGameEventResponse.ResponseTypes.Approved));
        }
    }
}
