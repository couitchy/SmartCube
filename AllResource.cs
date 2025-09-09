using System;

namespace Guan
{
    [Serializable]
    public class AllResource
    {
        public void Clear()
        {
            this.m_head.Clear();
            this.m_res.Clear();
            this.m_index.Clear();
            this.m_control.Clear();
        }

        public FrameHead m_head = new FrameHead();

        public FrameResource m_res = new FrameResource();

        public FrameIndex m_index = new FrameIndex();

        public FrameControl m_control = new FrameControl();

        public bool m_isMonochrome = true;
    }
}
