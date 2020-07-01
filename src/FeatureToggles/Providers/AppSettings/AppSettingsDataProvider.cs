﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeatureToggles;
using FeatureToggles.Configuration.AppConfig;
using FeatureToggles.Models;
using FeatureToggles.Providers;

namespace TheConfigStandard.JsonProviders
{
    using Microsoft.Extensions.Configuration;
    using System.Net;

    public class AppSettingsDataProvider : IToggleDataProvider
    {
        private static ToggleConfigurationSection ToggleConfigurations;

        private Dictionary<string, ToggleElement> toggles = new Dictionary<string, ToggleElement>();

        public void Initialise()
        {
            for (int i = 0; i < ToggleConfigurations.Toggles.Count; i++)
            {
                ToggleElement element = ToggleConfigurations.Toggles[i];

                if (!toggles.ContainsKey(element.Name))
                {
                    toggles.Add(element.Name, ToggleConfigurations.Toggles[i]);
                }

            }
        }

        public AppSettingsDataProvider(IConfiguration configuration)
        {
            ToggleConfigurations = configuration.GetSection("ToggleConfiguration").Get<ToggleConfigurationSection>();
            Initialise();
        }

        public Toggle GetFlag(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Toggle.Empty;
            }

            if (!toggles.ContainsKey(name))
            {
                return Toggle.Empty;
            }

            ToggleElement element = toggles[name];

            Toggle toggle = new Toggle(element.Name, element.Enabled);

            return toggle;
        }

        public Toggle GetFlag(string name, ToggleData userData)
        {
            if (!toggles.ContainsKey(name))
            {
                return Toggle.Empty;
            }

            ToggleElement element = toggles[name];

            if (!string.IsNullOrWhiteSpace(userData.UserRoles))
            {
                List<string> roles = element.Roles.Select(x => x.Name).ToList();
                bool found = false;
                foreach (string role in userData.UserRoles.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (roles.Contains(role))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    return new Toggle(name, false);
                }
            }

            if (!string.IsNullOrWhiteSpace(userData.UserId))
            {
                List<string> users = element.Users.Select(x => x.Name).ToList();

                if (!users.Contains(userData.UserId))
                {
                    return new Toggle(name, false);
                }
            }

            if (!string.IsNullOrWhiteSpace(userData.IpAddress))
            {
                if (!IPAddress.TryParse(userData.IpAddress, out IPAddress candidate))
                {
                    return new Toggle(name, false);
                }

                List<string> addresses = element.IpAddresses.Select(x => x.Value).ToList();
                bool found = false;
                foreach (string address in addresses)
                {
                    if (string.IsNullOrWhiteSpace(address))
                    {
                        continue;
                    }

                    IPAddressRange range = IPAddressRange.FromCidrAddress(address);
                    if (range == IPAddressRange.Empty)
                    {
                        continue;
                    }

                    if (range.IPInRange(candidate))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    return new Toggle(name, false);
                }
            }

            return new Toggle(name, true);
        }


    }
}
