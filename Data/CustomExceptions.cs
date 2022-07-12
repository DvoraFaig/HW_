using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataExceptions
{
    [Serializable]
    public class UnableAccessDataException :Exception
    {
        public UnableAccessDataException() { }

        public UnableAccessDataException(string message)
            : base(message) { }

        public UnableAccessDataException(string message, Exception inner)
            : base(message, inner) { }
    }
}
