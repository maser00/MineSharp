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