using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace Test
{
    public class NewBehaviourScript : MonoBehaviour
    {
        public string methodName;

        private void Start()

        {
            ReflectionExample.InvokeBoinkByReflection(methodName);
        }
    }
}
