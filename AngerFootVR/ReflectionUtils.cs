using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AngerFootVR.Util
{
    public static class ReflectionUtils
    {
        public static void ChangeStaticValue(Type type, string fieldName, object value)
        {
            type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Static)
                .SetValue(null, value);
        }

        public static void SetValue(object instance, string fieldName, object value)
        {
            instance.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(instance, value);
        }

        public static object GetValue(object instance, string fieldName)
        {
            return instance.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(instance);
        }
    }
}
