﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespositoryLayer.CustomException
{
    public class TransactionException : Exception
    {
        public TransactionException(string message) : base(message) { }
    }
}
