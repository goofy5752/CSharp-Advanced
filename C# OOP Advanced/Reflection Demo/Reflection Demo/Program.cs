using System;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Reflection.Emit;

namespace Reflection_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFile(@"C:\Users\Admin\Desktop\Programming\nat.dll");

            //Type type = assembly.GetType("TestRunner");

            //var obj = Activator.CreateInstance(type);
        }
    }
}