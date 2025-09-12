using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Guan
{
    [Serializable]
    [XmlInclude(typeof(PropertyElementBright))]
    [XmlInclude(typeof(PropertyElementDot))]
    [XmlInclude(typeof(PropertyElementLine))]
    [XmlInclude(typeof(PropertyElementPanel))]
    [XmlInclude(typeof(PropertyElementSolid))]
    public class FrameCartoonElement
    {
        public string name = "";

        public FrameCartoonType m_type;

        public List<FrameCartoonProperty> property = new List<FrameCartoonProperty>();
    }
}
