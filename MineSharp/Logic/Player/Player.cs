using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSharp.Logic
{
    public class Player
    {
        public string Username { get; private set; }
        public Position Position { get; private set; }
        public View View {get; private set; }
        public double Stance { get; set; }
        public bool OnGround { get; set; }
 
        public Player(string name)
        {
            this.Username = name;
            Position = new Position();
            View = new View();
        }

        public void Move(double x, double y, double z)
        {
            //TODO: logic, such as send to others on map
            Position.X = x;
            Position.Y = y;
            Position.X = z;
        }

        public void SetView(float yaw, float pitch)
        {
            View.yaw = yaw;
            View.pitch = pitch;
        }
    }
}