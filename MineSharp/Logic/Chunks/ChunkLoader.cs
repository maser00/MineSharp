using Ionic.Zlib;
using MineSharp.Logic.Chunks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSharp.Logic
{
    class ChuckLoader
    {

        public static ChunkPacket ChunkToPacket()
        {

            int chunkX = 0;
            int chunkY = 0;

            byte[] blockType = new byte[16];
            byte[] blockMetadata = new byte[8];
            byte[] blockLight = new byte[8];
            byte[] addArray = new byte[8];

            for (int i = 0; i < 16; i++)
            {
                blockType[i] = 78;
            }

            for (int i = 0; i < 8; i++)
            {
                blockMetadata[i] = 0x00;
                blockLight[i] = 0x11;
                addArray[i] = 0x00;
            }

            int index = 0;
            byte[] data = new byte[blockType.Length + blockMetadata.Length +
                blockLight.Length + addArray.Length];
            Array.Copy(blockType, 0, data, index, blockType.Length);
            index += blockType.Length;
            Array.Copy(blockMetadata, 0, data, index, blockMetadata.Length);
            index += blockMetadata.Length;
            Array.Copy(blockLight, 0, data, index, blockLight.Length);
            index += blockLight.Length;
            Array.Copy(addArray, 0, data, index, addArray.Length);

            byte[] compressedData = ZlibStream.CompressBuffer(data);
            return new ChunkPacket(chunkX, chunkY, false, (ushort)1, (ushort)1, compressedData);
        }
    }
}
