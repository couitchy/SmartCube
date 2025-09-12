using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Guan
{
    public sealed class RemapSerializationBinder : SerializationBinder
    {
        private readonly Dictionary<string, Type> map;

        public RemapSerializationBinder(Dictionary<string, Type> map) { this.map = map; }

        public override Type BindToType(string assemblyName, string typeName)
        {
            string key = $"{typeName}, {assemblyName}";

            if (map.TryGetValue(key, out var t)) return t;

            if (map.TryGetValue(typeName, out t)) return t;

            return Type.GetType(key, throwOnError: true);
        }
    }
}
