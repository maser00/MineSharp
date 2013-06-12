using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSharp.Logic.Chunks
{
    class ChunkPacket
    {

        public int X { get; private set; }
        public int Z { get; private set; }
        public bool GroundUp { get; private set; }
        public ushort PrimaryBitMap { get; private set; }
        public ushort AddBitMap { get; private set; }
        public byte[] CompressedData { get; private set; }

        public ChunkPacket(int X, int Z, bool GroundUp, ushort PrimaryBitMap, ushort AddBitMap, byte[] CompressedData)
        {
            this.X = X;
            this.Z = Z;
            this.GroundUp = GroundUp;
            this.PrimaryBitMap = PrimaryBitMap;
            this.AddBitMap = AddBitMap;
            this.CompressedData = CompressedData;
        }
    }
}
