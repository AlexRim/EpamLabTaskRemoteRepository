﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
  public  class NotTheEquationException : Exception
    {
            public NotTheEquationException() { }
            public NotTheEquationException(string message) : base(message) { }
            public NotTheEquationException(string message, Exception ex) : base(message) { }
    }
}
