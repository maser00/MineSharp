using MineSharp.Logic;
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

        [PacketHandler(RecvOpcode.PlayerAbility)]
        public static async Task HandlePlayerAbility(Client client, PacketReader reader)
        {
            byte flags = await reader.ReadByte();
            byte flySpeed = await reader.ReadByte();
            byte walkSpeed = await reader.ReadByte();

            Player player = client.Player;
            player.GodMode = (flags & 8) != 0;
            player.FlyingAllowed = (flags & 4) != 0;
            player.IsFlying = (flags & 2) != 0;
            player.CreativeMode = (flags & 1) != 0;
            Console.WriteLine("Godmode is {0}, flymode is {1}, flying is {2}, creative is {3}", player.GodMode, player.FlyingAllowed, player.IsFlying, player.CreativeMode);
            player.FlySpeed = flySpeed;
            player.WalkSpeed = walkSpeed;

            using (var packet = new PacketWriter(SendOpcode.PlayerAbility))
            {
                packet.Write(flags);
                packet.Write(flySpeed);
                packet.Write(walkSpeed);
                client.Send(packet);
            }
        }
    }
}
