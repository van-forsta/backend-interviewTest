using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confirmit.DotNetInterview.Api.Util
{
    public class KeyGenerator
    {
        private int _currentKey = 0;

        public int Generate()
        {
            _currentKey++;

            return _currentKey;
        }
    }
}
