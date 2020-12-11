using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_system
{
    class LibraryHelper : ILibraryHelper
    {
        public List<String> Categories { get { return new List<string> { "Programming", "Systems Analysis", "E - Commerce", "Interaction Design", "Web Design" }; } }
    }
}