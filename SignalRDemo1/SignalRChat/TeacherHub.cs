using Microsoft.AspNetCore.SignalR;
using SignalRDemo1.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRDemo1.SignalRChat
{
    /// <summary>
    /// 
    /// </summary>
    public class TeacherHub : Hub
    {
        /// <summary>
        /// 教室房间
        /// </summary>
        private static ConcurrentDictionary<Guid, RoomInfo> _TeacherRooms=new ConcurrentDictionary<Guid, RoomInfo> ();
        /// <summary>
        /// 
        /// </summary>
        private static ConcurrentDictionary<Guid, List<CanvasPoint>> _CanvasPoint = new ConcurrentDictionary<Guid, List<CanvasPoint>>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns></returns>
        public Task<ResponseBase<Guid>> CreateRoom(string roomName)
        {
            // 判断房间是否存在
            if (_TeacherRooms.Values.Count(t=>t.RoomName== roomName)>0)
            {
                return Task.FromResult(new ResponseBase<Guid>() { Success=false,Message="房间名已被占用" });
            }
            // 将房间添加到集合中
            var model = new RoomInfo() {RoomId= Guid.NewGuid(), RoomName= roomName, OwnerConnectionId= base.Context.ConnectionId };
            _TeacherRooms.TryAdd(model.RoomId, model);
            _CanvasPoint.TryAdd(model.RoomId,new List<CanvasPoint>());
            // 将教师添加到创建的房间中
            Groups.AddToGroupAsync(base.Context.ConnectionId, model.RoomId.ToString());
            // 将创建的房间消息通知给所有的学生端
            Clients.All.SendAsync("NewZoomNotice", model.RoomId, model.RoomName);
            return Task.FromResult(new ResponseBase<Guid>() { Success = true, Data= model.RoomId });
        }
        /// <summary>
        /// 获取全部的房间信息
        /// </summary>
        /// <returns></returns>
        public Task<ResponseBase<List<RoomInfo>>> GetAllRomm()
        {
            var data = _TeacherRooms.Values.ToList();
            return Task.FromResult(new ResponseBase<List<RoomInfo>>() { Success = true, Data= data });
        }
        /// <summary>
        /// 加入房间
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns></returns>
        public Task<ResponseBase<string>> JoinRoom(Guid roomId)
        {
            if (!_TeacherRooms.ContainsKey(roomId))
            {
                return Task.FromResult(new ResponseBase<string>() { Success = false, Message = "房间不存在" });
            }
            Groups.AddToGroupAsync(base.Context.ConnectionId, roomId.ToString());
            return Task.FromResult(new ResponseBase<string>() { Success = true });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task AddPoint(Guid roomId,CanvasPoint canvasPoint)
        {
            var zoomCanvasPoint = _CanvasPoint[roomId];
            zoomCanvasPoint.Add(canvasPoint);
            return Clients.Group(roomId.ToString()).SendAsync("ReceivePoint", canvasPoint);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public Task<ResponseBase<List<CanvasPoint>>> GetAllPoint(Guid roomId)
        {
            var data = _CanvasPoint[roomId].ToList();
            return Task.FromResult(new ResponseBase<List<CanvasPoint>>() { Success = true, Data = data });
        }
    }
}
