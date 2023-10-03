﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MathGameGit;

class Program
{
    static void Main(string[] args)
    {
        GameSession gameSession = new();
        gameSession.Start();
    }

    
}
public enum GameTypes
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Random
}

