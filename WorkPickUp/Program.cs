﻿using SampSharp.Core;
using SampSharp.Entities;

namespace WorkPickUp
{
    public class Program
    {
        static void Main(string[] args)
        {
            new GameModeBuilder()
                .UseEcs<Startup>()
                .Run();
        }
    }
}
