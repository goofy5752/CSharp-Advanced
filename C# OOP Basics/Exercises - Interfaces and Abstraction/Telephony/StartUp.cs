using System;

namespace TelephonyProj
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumber = Console.ReadLine().Split();
            string[] siteName = Console.ReadLine().Split();
            for (int i = 0; i < phoneNumber.Length; i++)
            {
                ICallable callable = new Phone(phoneNumber[i]);
                Console.WriteLine(callable.ToString());
            }
            for (int i = 0; i < siteName.Length; i++)
            {
                IBrowsable browsable = new Browse(siteName[i]);
                Console.WriteLine(browsable.ToString());
            }
        }
    }
}