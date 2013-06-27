/*
 * This file is part of MineSharp. Copyright 2013 Cedric Van Goethem 
 * and Aaron Mousavi
 *  
 * MineSharp. is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Affero General Public License as
 * published by the Free Software Foundation, either version 3 of the
 * License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Affero General Public License for more details.
 * 
 * You should have received a copy of the GNU Affero General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>. 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MineSharp.Networking;
using MineSharp.Logic.Authentication;
using MineSharp.Logic;

namespace MineSharp.Handlers
{
    public class MovementHandlers
    {
        // TODO: does 3rd param still have a function?
        private static async Task SetPosition(Client client, PacketReader reader, bool has_stance = true)
        {
            double x = await reader.ReadDouble();
            double y = await reader.ReadDouble();
            if (has_stance)
            {
                double stance = await reader.ReadDouble();
                client.Player.Stance = stance;
            }
            double z = await reader.ReadDouble();
            client.Player.Move(x, y, z);
        }

        private static async Task SetOnGround(Client client, PacketReader reader)
        {
            bool ground = await reader.ReadBoolean();
            client.Player.OnGround = ground;
            //Console.WriteLine("Faling is {0}", ground);
        }

        private static async Task SetView(Client client, PacketReader reader)
        {
            float yaw = await reader.ReadFloat();
            float pitch = await reader.ReadFloat();
            client.Player.SetView(yaw, pitch);
        }

        [PacketHandler(RecvOpcode.PlayerOnGround)]
        public static async Task HandlePlayerGround(Client client, PacketReader reader)
        {
            await SetOnGround(client, reader);
            //Console.WriteLine("Client flying: {0}", !ground);
        }

        [PacketHandler(RecvOpcode.PlayerPosition)]
        public static async Task HandlePlayerPosition(Client client, PacketReader reader)
        {
            await SetPosition(client, reader);
            await SetOnGround(client, reader);
        }

        [PacketHandler(RecvOpcode.PlayerLook)]
        public static async Task HandlePlayerLook(Client client, PacketReader reader)
        {
            await SetView(client, reader);
            await SetOnGround(client, reader);
        }

        [PacketHandler(RecvOpcode.PlayerPositionAndLook)]
        public static async Task HandlePlayerPositionAndLook(Client client, PacketReader reader)
        {
            await SetPosition(client, reader);
            await SetView(client, reader);
            await SetOnGround(client, reader);
            using (var packet = new PacketWriter(SendOpcode.PlayerPosition))
            {
                Player player = client.Player;
                packet.Write(player.Position.X);
                packet.Write(player.Position.Y);
                packet.Write(player.Stance);
                packet.Write(player.Position.Z);
                packet.Write(player.View.yaw);
                packet.Write(player.View.pitch);
                packet.Write(player.OnGround);
                //Console.WriteLine("Pos: X={0}, Y={1}, Z={2}", player.Position.X, player.Position.Y, player.Position.Z);
                client.Send(packet);
            }
        }
    }
}
