﻿/*
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

namespace MineSharp.Handlers
{
    public enum RecvOpcode : byte
    {
        Handshake = 0x02,
        ServerStats = 0xFE,
        ClientSettings = 0xCC,
        KeepAlive = 0x00,
        LoginRequest = 0x01,
        PlayerOnGround = 0x0A,
        PlayerPosition = 0x0B,
        PlayerLook = 0x0C,
        PlayerPositionAndLook = 0x0D,
        PlayerAbility = 0xCA
    }
}
