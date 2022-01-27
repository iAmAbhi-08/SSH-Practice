using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptionsPractice.Services.Interfaces
{
    public interface IConfigurationReader
    {
        public string ReadDashboardHeaderSettings();
    }
}
