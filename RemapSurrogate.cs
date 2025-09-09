using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace Guan
{
    public sealed class RemapSurrogate<T> : ISerializationSurrogate where T : new()
    {
        private readonly Dictionary<string, string> _memberMap;

        public RemapSurrogate(Dictionary<string, string> memberMap) => _memberMap = memberMap;

        public void GetObjectData(object obj, SerializationInfo info, StreamingContext ctx)
        {
            foreach (var m in obj.GetType().GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (m is FieldInfo f)
                    info.AddValue(f.Name, f.GetValue(obj));

                else if (m is PropertyInfo p && p.CanRead && p.GetIndexParameters().Length == 0)
                    info.AddValue(p.Name, p.GetValue(obj, null));
            }
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext ctx, ISurrogateSelector sel)
        {
            var target = obj is T t ? t : new T();
            foreach (SerializationEntry e in info)
            {
                var name = _memberMap.TryGetValue(e.Name, out var mapped) ? mapped : e.Name;

                var f = typeof(T).GetField(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (f != null)
                {
                    f.SetValue(target, ConvertIfEnum(e.Value, f.FieldType));
                    continue;
                }

                var p = typeof(T).GetProperty(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (p != null && p.CanWrite && p.GetIndexParameters().Length == 0)
                    p.SetValue(target, ConvertIfEnum(e.Value, p.PropertyType), null);
            }
            return target;
        }

        private static object ConvertIfEnum(object value, Type destType)
        {
            if (value == null) return null;
            if (destType.IsEnum)
            {
                var intVal = value is int i ? i : Convert.ToInt32(value);
                return Enum.ToObject(destType, intVal);
            }
            return Convert.ChangeType(value, Nullable.GetUnderlyingType(destType) ?? destType);
        }
    }
}
