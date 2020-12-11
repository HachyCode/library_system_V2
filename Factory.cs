using System;
using System.Collections.Generic;
using System.Text;

namespace library_system
{
    class Factory
    {
        public static ILibraryHelper CreatLibraryHelper()
        {
            return new LibraryHelper();
        }
    }
}
