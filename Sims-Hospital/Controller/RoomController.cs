// File:    RoomController.cs
// Author:  stani
// Created: Sunday, 3 April 2022 15:58:27
// Purpose: Definition of Class RoomController

using Dto;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class RoomController
    {
        public RoomService RoomService { get; set; }
        public RoomController(RoomService roomService)
        {
            this.RoomService = roomService;
        }
        public void Create(CreateRoomDTO newRoom)
        {
            RoomService.Create(newRoom);
        }
        public void Edit(EditRoomDTO editRoom)
        {
            RoomService.Edit(editRoom);
        }

        public void Delete(int roomId)
        {
            RoomService.Delete(roomId);
        }

        public List<Room> ReadAll()
        {
            return RoomService.ReadAll();
        }

        public Room ReadById(int roomId)
        {
            return RoomService.ReadById(roomId);
        }

        public Room ReadByName(string roomName)
        {
            return RoomService.ReadByName(roomName);
        }
        public bool RoomExists(string roomName)
        {
            return RoomService.RoomExists(roomName);
        }
    }
}