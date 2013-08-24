//-----------------------------------------------------------------------
// <copyright file="PopedBallonException.cs" company="Telerik">
// Group: Zirconium
// Project: Game Balloons Pop
// Copyright (c) 2013 Telerik. All rights reserved.
//
// </copyright>
//-----------------------------------------------------------------------

namespace BaloonsPop.Exceptions
{
    using System;

    /// <summary>
    /// Class for handling exception when there isn't balloon on shouted coordinates
    /// </summary>
    public class PopedBallonException: Exception
    {
        public PopedBallonException(string message)
            : base(message)
        {
        }
    }
}
