using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NgLog
{
    public class NgLog
    {
        /// <summary>
        /// 存放日志的容器
        /// </summary>
        private RichTextBox LogBox { set; get; }
        /// <summary>
        /// 容器最大行数
        /// </summary>
        private int MaxLines { set; get; }
        /// <summary>
        /// 初始化日志用的容器
        /// </summary>
        /// <param name="richTextBox">存放日志的容器</param>
        public void InitLogBox(RichTextBox richTextBox)
        {
            this.LogBox = richTextBox;
            this.MaxLines = 2000;
        }
        /// <summary>
        /// 初始化日志用的容器
        /// </summary>
        /// <param name="richTextBox">存放日志的容器</param>
        /// <param name="maxLines">容器最大行数</param>
        public void InitLogBox(RichTextBox richTextBox, int maxLines)
        {
            this.LogBox = richTextBox;
            this.MaxLines = maxLines;
        }
        /// <summary>
        /// 委托存放数据
        /// </summary>
        /// <param name="msg">实际数据</param>
        public delegate void InvokeLog(string msg);
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        public void Log(string msg)
        {
            if (LogBox.InvokeRequired)
            {
                InvokeLog t = new InvokeLog(Log);
                this.LogBox.BeginInvoke(t, new object[] { msg });
            }
            else
            {
                if (LogBox.Lines.Length > MaxLines)
                    LogBox.Clear();
                this.LogBox.AppendText(DateTime.Now.ToLongTimeString() + "--" + msg + "\r\n");
            }
        }
    }
}
