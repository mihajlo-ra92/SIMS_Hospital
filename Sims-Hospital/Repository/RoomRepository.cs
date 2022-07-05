// File:    RoomRepository.cs
// Author:  stani
// Created: Sunday, 3 April 2022 15:43:37
// Purpose: Definition of Class RoomRepository

using Dto;
using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class RoomRepository
    {
        public RoomFileHandler RoomFileHandler = new RoomFileHandler();
        public List<Room> rooms;
        public RoomRepository()
        {
            rooms = RoomFileHandler.Read();
        }
        public List<Room> ReadAll()
        {
            return rooms;
        }

        public Room ReadById(int roomId)
        {

            return  rooms.Where(x => x.Id == roomId).FirstOrDefault();

        }

        public Room ReadByName(string roomName)
        {
            return rooms.Where(x => x.RoomName == roomName).FirstOrDefault();
        }
        public bool RoomExists(string roomName)
        {
            return rooms.Any(x => x.RoomName == roomName);
        }

        public void Create(CreateRoomDTO newRoom)
        {
            int id = 0;
            if (rooms.Count > 0)
            {
                id = rooms.Max(x => x.Id) + 1;
                if (ReadByName(newRoom.RoomName) != null)
                {
                    //throw new UsernameExistsException();
                }
            }
            Room room = new Room()
            {
                Id = id,
                RoomName = newRoom.RoomName,
                //RoomType = 
            };
            rooms.Add(room);
            RoomFileHandler.Write(rooms);
        }

        public void Edit(EditRoomDTO editRoom)
        {
            Room room = rooms.Where(x => x.Id == editRoom.RoomId).First();

            room.RoomName = editRoom.RoomName;
            //room.RoomType
            RoomFileHandler.Write(rooms);


        }

        public void Delete(int roomId)
        {
            Room room = rooms.Where(x => x.Id == roomId).First();
            rooms.Remove(room);
            RoomFileHandler.Write(rooms);
        }
    }
}