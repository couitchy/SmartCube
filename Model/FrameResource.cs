using System;
using System.Collections.Generic;

namespace Guan
{
    [Serializable]
    public class FrameResource
    {
        public void Clear()
        {
            this.m_resSingle.Clear();
            this.m_resSolid.Clear();
        }

        public List<ResourceSingle> m_resSingle = new List<ResourceSingle>();

        public List<ResourceSolid> m_resSolid = new List<ResourceSolid>();
    }
}
