// File:    CreateRoomDTO.cs
// Author:  stani
// Created: Sunday, 3 April 2022 16:30:06
// Purpose: Definition of Class CreateRoomDTO

using System;

namespace Dto
{
    public class CreateRoomDTO
    {
        public string RoomName { get; set; }
        public RoomType RoomType { get; set; }

    }
}