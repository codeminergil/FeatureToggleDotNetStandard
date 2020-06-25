using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheConfigStandard
{
    using Models;

    public interface IToggleDataProvider
    {
        Toggle GetFlag(string name);

        Toggle GetFlag(string name, ToggleData userData);
    }
}
