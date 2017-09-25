using System;
using System.Collections.Generic;
using System.Text;

namespace QuadraticEquationLibrary
{
    class NotTheEquationException : Exception
    {
            public NotTheEquationException() { }
            public NotTheEquationException(string message) : base(message) { }
            public NotTheEquationException(string message, Exception ex) : base(message) { }
    }
}
