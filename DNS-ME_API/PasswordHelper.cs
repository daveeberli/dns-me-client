using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace DnsMeApi
{
    /// <summary>
    /// Helper class to calculate the password of a dns-me.com device password in a device group
    /// </summary>
    public static class PasswordHelper
    {
        /// <summary>
        /// Calculates a password for a device in a device group. 
        /// </summary>
        /// <param name="deviceUrl">The URL of the device e.g. mygroup_device123.dns-me.com</param>
        /// <param name="masterPassword">The master password of the device group</param>
        /// <returns>The password</returns>
        public static string CaclucatePasswordForDeviceInDeviceGroup(string deviceUrl, string masterPassword)
        {
            deviceUrl = deviceUrl.ToLower();

            if (deviceUrl.Contains(".dns-me.com"))
            {
                // remove dns-me.com ending
                deviceUrl = deviceUrl.Replace(".dns-me.com", string.Empty);
            }

            // Convert device name and master password to byte array
            var deviceNameBytes = Encoding.UTF8.GetBytes(deviceUrl);
            var masterPasswordBytes = ConvertHexStringToByteArray(masterPassword);
          
            var pwdBytes = new byte[deviceNameBytes.Length + masterPasswordBytes.Length];

            Buffer.BlockCopy(deviceNameBytes,0, pwdBytes, 0, deviceNameBytes.Length);
            Buffer.BlockCopy(masterPasswordBytes, 0, pwdBytes, deviceNameBytes.Length, masterPasswordBytes.Length);

            // Calculate Hash
            var algo = SHA256.Create();
            var password = algo.ComputeHash(pwdBytes);

            return Convert.ToBase64String(password);
        }

        /// <summary>
        /// Converts a Hex String to a byte array
        /// </summary>
        private static byte[] ConvertHexStringToByteArray(string hexString)
        {

            byte[] hexAsBytes = new byte[hexString.Length / 2];
            for (int index = 0; index < hexAsBytes.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                hexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return hexAsBytes;
        }
    }
}
