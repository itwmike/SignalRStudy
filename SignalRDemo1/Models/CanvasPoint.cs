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
        /// <summary>
        /// x轴坐标
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// y轴坐标
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// 是否开始绘制
        /// </summary>
        public bool Start { get; set; }
        /// <summary>
        /// 画笔粗细
        /// </summary>
        public int PenWeight { get; set; }
        /// <summary>
        /// 画笔颜色
        /// </summary>
        public string PenColor { get; set; }
    }
}
