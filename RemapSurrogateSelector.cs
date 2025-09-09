using System;
using System.Collections;
using System.Runtime.Serialization;

namespace Guan
{
    public class RemapSurrogateSelector : SurrogateSelector, IEnumerable
    {
        public void Add(Type type, ISerializationSurrogate surrogate)
        {
            AddSurrogate(type, new StreamingContext(StreamingContextStates.All), surrogate);
        }

        public void Add<T>(RemapSurrogate<T> surrogate) where T : new()
        {
            AddSurrogate(typeof(T), new StreamingContext(StreamingContextStates.All), surrogate);
        }

        public IEnumerator GetEnumerator()
        {
            return new object[0].GetEnumerator();
        }
    }
}
