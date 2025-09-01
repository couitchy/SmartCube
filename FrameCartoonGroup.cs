using System;
using System.Collections.Generic;

namespace Guan
{
    [Serializable]
    public class FrameCartoonGroup
    {
        public string name = "";

        public uint frameCount;

        public uint delay = 100U;

        public uint loopCount = 1U;

        public bool cleanDisplay = true;

        public List<FrameCartoonElement> ele = new List<FrameCartoonElement>();
    }
}
