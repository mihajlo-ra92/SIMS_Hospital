// File:    RoomService.cs
// Author:  stani
// Created: Sunday, 3 April 2022 15:53:03
// Purpose: Definition of Class RoomService

using Dto;
using Model;
using System;
using System.Collections.Generic;
using Repository;

namespace Service
{
    public class RoomService
    {
        public RoomRepository RoomRepository { get; set; }
        public RoomService(RoomRepository roomRepository)
        {
            RoomRepository = roomRepository;
        }
        public void Create(CreateRoomDTO newRoom)
        {
            RoomRepository.Create(newRoom);
        }
        public void Edit(EditRoomDTO editRoom)
        {
            RoomRepository.Edit(editRoom);
        }
        public void Delete(int roomId)
        {
            RoomRepository.Delete(roomId);
        }

        public List<Room> ReadAll()
        {
            return RoomRepository.ReadAll();
        }

        public Room ReadById(int roomId)
        {
            return RoomRepository.ReadById(roomId);
        }
        public Room ReadByName(string roomName)
        {
            return RoomRepository.ReadByName(roomName);
        }
        public bool RoomExists(string roomName)
        {
            return RoomRepository.RoomExists(roomName);
        }


    }
}