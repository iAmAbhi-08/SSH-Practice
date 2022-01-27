using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OptionsPractice.Models.Configuration;
using OptionsPractice.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptionsPractice.Services.Implementaions
{
    public class ConfigurationReader : IConfigurationReader
    {
        DashboardHeaderConfiguration dashboardHeaderConfig;

        public ConfigurationReader(IOptionsMonitor<DashboardHeaderConfiguration> optionsMonitor)
        {
            dashboardHeaderConfig = optionsMonitor.CurrentValue;
            optionsMonitor.OnChange(config => dashboardHeaderConfig = config);
        }

        string IConfigurationReader.ReadDashboardHeaderSettings()
        {
            return JsonConvert.SerializeObject(dashboardHeaderConfig);
        }
        
    }
}
