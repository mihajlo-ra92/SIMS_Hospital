// File:    EditRoomDTO.cs
// Author:  stani
// Created: Sunday, 3 April 2022 16:31:11
// Purpose: Definition of Class EditRoomDTO

using System;

namespace Dto
{
    public class EditRoomDTO
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public RoomType RoomType { get; set; }

    }
}