using System.Net;

namespace DnsMeApi.Containers
{
    /// <summary>
    /// Container class to update an IP
    /// </summary>
    public class UpdateContainer
    {
        public UpdateContainer(string deviceUrl, string password, IPAddress ipV4, IPAddress ipV6)
        {
            this.DeviceUrl = deviceUrl;
            this.Password = password;

            if (ipV4 == null)
            {
                this.IpV4 = null;
            }
            else
            {
                this.IpV4 = ipV4.ToString();
            }

            if (ipV6 == null)
            {
                this.IpV6 = null;
            }
            else
            {
                this.IpV6 = ipV6.ToString();
            }
        }

        /// <summary>
        /// The Url of the device. (e.g. dev_123456.dns-me.com)
        /// </summary>
        public string DeviceUrl { get; set; }

        /// <summary>
        /// The Password of the device. 
        /// If it's a single device the password was set when you have created the device. 
        /// If it's a device from a device group, the password is calculated like this:
        /// Device Password = sha256(DeviceName + Masterkey)
        /// The device Password is encoded as Base64.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The IP V4
        /// </summary>
        public string IpV4 { get; set; }

        /// <summary>
        /// The IP V6
        /// </summary>
        public string IpV6 { get; set; }
    }
}
