using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleTable
{
    public static class MapHelper
    {
        public static T Map<T>(IList<object> parameters) where T : new() {
            var obj = new T();
            var type = typeof(T);
            var properies = type.GetProperties();
            if (properies.Length < parameters.Count) {
                throw new Exception();
            }
            for (int i = 0; i < parameters.Count; i++) {
                properies[i].SetValue(obj, parameters[i]);
            }

            return obj;
        }
    }
}
