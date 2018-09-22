using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp.Interfaces
{
    public interface IConfigurationHelper
    {
        string GetValueByKey(string key);
    }
}
