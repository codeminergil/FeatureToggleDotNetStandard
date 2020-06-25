using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheConfigStandard
{
    public interface IToggleFactory
    {
        Toggle Get(string name);
        Toggle Get<T>() where T : ToggleId;
    }
}
