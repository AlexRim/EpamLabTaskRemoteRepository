using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace QuadraticEquationLibrary
{
   
    class NegativeDiscriminantException: Exception
    {
        public NegativeDiscriminantException() { }
        public NegativeDiscriminantException(string message) : base(message) { }
        public NegativeDiscriminantException(string message, Exception ex) : base(message) { }

    }
}
