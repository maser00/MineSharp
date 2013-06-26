using MineSharp.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSharp.Handlers
{
    class ClientHandlers
    {
        [PacketHandler(RecvOpcode.ClientSettings)]
        public static async Task HandleClientSettings(Client client, PacketReader reader)
        {
            //TODO: save these settings in Player
            string locale = await reader.ReadString();
            byte viewDistance = await reader.ReadByte();
            byte chatFlags = await reader.ReadByte();
            byte difficulty = await reader.ReadByte();
            bool cape = await reader.ReadBoolean();
        }
    }
}
