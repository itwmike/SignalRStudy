using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRDemo1.Models
{
    /// <summary>
    /// 房间信息
    /// </summary>
    public class RoomInfo
    {
        /// <summary>
        /// 房间名
        /// </summary>
        public string RoomName { get; set; }
        /// <summary>
        /// 房间编号
        /// </summary>
        public Guid RoomId { get; set; }
        /// <summary>
        /// 房间属主
        /// </summary>
        public string OwnerConnectionId { get; set; }
    }
}
