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
using Ionic.Zlib;
using MineSharp.Handlers;
using MineSharp.Logic.Chunks;
using MineSharp.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSharp.Logic
{
    class ChunkTest
    {
        public static void SendTestChunk(Client client, int x, int  y, byte type, byte metaData)
        {
            bool groundUp = true;
            ushort bitmap = 15;
            ushort addbitmap = 0;
            List<byte> data = new List<byte>();

            // add 4096 dirt blocks
            for (int i = 0; i < 4096; i++)
            {
                data.Add(type);
            }

            // add metadata
            for (int i = 0; i < 2048; i++)
            {
                data.Add(metaData);
            }

            // add light
            for (int i = 0; i < 2048; i++)
            {
                data.Add(0xFF);
            }

            // addArray
            for (int i = 0; i < 2048; i++)
            {
                data.Add(0x00);
            }

            byte[] compressedData = ZlibStream.CompressBuffer(data.ToArray());

            using (var packet = new PacketWriter(SendOpcode.ChunkData))
            {
                packet.Write(x/16);
                packet.Write(y/16);
                packet.Write(groundUp);
                packet.Write(bitmap);
                packet.Write(addbitmap);
                packet.Write(compressedData.Length);
                packet.Write(compressedData);
                client.Send(packet);
            }
        }
    }
}