﻿namespace JobBoard.Core.Exceptions
{
    using System;
    
    public class BusinessException : Exception
    {
        public BusinessException()
        {

        }

        public BusinessException(string message) : base(message)
        {

        }
    }
}