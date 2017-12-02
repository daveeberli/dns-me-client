using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DnsMeApi.Containers;
using Newtonsoft.Json;

namespace DnsMeApi
{
    public class DnsMe
    {
        /// <summary>
        /// Updates the IP of a device on dns-me.com. The ip of the caller is used (IPV4 or IPV6)
        /// </summary>
        /// <param name="deviceUrl">The url of the device. e.g. dev_123456.dns-me.com</param>
        /// <param name="devicePassword">The password as deviced on the dns-me.com cloud</param>
        /// <returns>true if the IP was updated, false if not</returns>
        public static async Task<bool> UpdateDevice(string deviceUrl, string devicePassword)
        {
            using (var restApi = new RestApiClient())
            {
                var response = await restApi.Client.GetAsync("api/Update?url=" + deviceUrl + "&password=" + devicePassword);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        ///  Updates the IP of a device on dns-me.com
        /// </summary>
        /// <param name="deviceUrl">The url of the device. e.g. dev_123456.dns-me.com</param>
        /// <param name="devicePassword">The password as deviced on the dns-me.com cloud</param>
        /// <param name="ipV4">The IP V4 address of the device. Or null if not exists</param>
        /// <param name="ipV6">The IP V6 address of the device. Or null if not exists</param>
        /// <returns>true if the IP was updated, false if not</returns>
        public static async Task<bool> UpdateDevice(string deviceUrl, string devicePassword, IPAddress ipV4, IPAddress ipV6)
        {
            var updateData = new UpdateContainer(deviceUrl, devicePassword, ipV4, ipV6);

            using (var restApi = new RestApiClient())
            {
                var json = JsonConvert.SerializeObject(updateData);
                var content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await restApi.Client.PostAsync("api/Update", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        ///  Updates the IP of a device on dns-me.com
        /// </summary>
        /// <param name="deviceUrl">The url of the device. e.g. mygroup_123456.dns-me.com</param>
        /// <param name="masterPassword">The master password of the device group</param>
        /// <param name="ipV4">The IP V4 address of the device. Or null if not exists</param>
        /// <param name="ipV6">The IP V6 address of the device. Or null if not exists</param>
        /// <returns>true if the IP was updated, false if not</returns>
        public static async Task<bool> UpdateDeviceInDeviceGroup(string deviceUrl, string masterPassword, IPAddress ipV4, IPAddress ipV6)
        {
            // Calculate device password
            var devicePassword = PasswordHelper.CaclucatePasswordForDeviceInDeviceGroup(deviceUrl, masterPassword);

            return await UpdateDevice(deviceUrl, devicePassword, ipV4, ipV6);
        }

        /// <summary>
        /// Updates the IP of a device on dns-me.com. The ip of the caller is used (IPV4 or IPV6)
        /// </summary>
        /// <param name="deviceUrl">The url of the device. e.g. dev_123456.dns-me.com</param>
        /// <param name="masterPassword">The master password of the device group</param>
        /// <returns>true if the IP was updated, false if not</returns>
        public static async Task<bool> UpdateDeviceInDeviceGroup(string deviceUrl, string masterPassword)
        {
            // Calculate device password
            var devicePassword = PasswordHelper.CaclucatePasswordForDeviceInDeviceGroup(deviceUrl, masterPassword);

            return await UpdateDevice(deviceUrl, devicePassword);
        }
    }
}
