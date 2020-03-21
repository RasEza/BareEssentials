using System;

namespace BareEssentials
{
    public static class ActionHelper
    {
        public static void Repeat(int iterations, Action a)
        {
            for (int i = 0; i < iterations; i++)
            {
                a.Invoke();
            }
        }
    }
}
