using System;
using System.Text.Json;
using Newtonsoft.Json;

namespace Data
{
    public sealed class IDL
    {
        private static readonly Lazy<IDL> lazy =
            new Lazy<IDL>(() => new IDL());
        public static IDL Instance { get { return lazy.Value; } }

        private IDL()
        {

        }

        public void SavaData(string data)
        {


    }
    }
}
