using MineSharp.Logic;
using MineSharp.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSharp.Handlers
{
    class WorldHandler
    {
        public static async void SetCompas(Client client)
        {
            using (var packet = new PacketWriter(SendOpcode.SetCompas))
            {
                // TODO: set real compas data
                int x = 0;
                int y = 0;
                int z = 0;
                packet.Write(x);
                packet.Write(y);
                packet.Write(z);
                client.Send(packet);
            }
        }

        public static async void TestSpawn(Client client)
        {
            // Temp code to test chunks
            ChunkTest.SendTestChunk(client, 0, 0, 0x03, 0xAA);
            ChunkTest.SendTestChunk(client, -16, 0, 0x03, 0xAA);
            ChunkTest.SendTestChunk(client, 0, -16, 0x03, 0xAA);
            ChunkTest.SendTestChunk(client, -16, -16, 0x03, 0xAA);

            SetCompas(client);

            using (var packet = new PacketWriter(SendOpcode.PlayerPosition))
            {
                Player player = client.Player;
                packet.Write(8d);
                packet.Write(100d);
                packet.Write(0.0d);
                packet.Write(8d);
                packet.Write(0.0f);
                packet.Write(0.0f);
                packet.Write(false);
                client.Send(packet);
            }
        }
    }
}
