using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRDemo1.Models
{
    /// <summary>
    /// 画板坐标
    /// </summary>
    [Serializable]
    public class CanvasPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Start { get; set; }
        public int PenWeight { get; set; }
        public string PenColor { get; set; }
    }
}
