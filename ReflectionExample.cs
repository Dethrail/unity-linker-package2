using System.Reflection;
using UnityEngine;

namespace Test
{
    public class ReflectionExample
    {
        public static void InvokeBoinkByReflection(string methodName)
        {
            typeof(ReflectionExample).GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, null);
        }

        // No other code directly references the Boink method, so when when stripping is enabled,
        // it will be removed unless the [Preserve] attribute is applied.
        static void Boink()
        {
            Debug.Log("############################ boink");
        }
    }
}
