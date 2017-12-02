using System;
using System.Net;
using DnsMeApi;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Simple update
            var result = DnsMe.UpdateDevice("dev_test.dns-me.com", "123456");
            result.Wait();
            Console.WriteLine(result.Result);

            // Advanced update
            var result2 = DnsMe.UpdateDevice("dev_test.dns-me.com", "123456", IPAddress.Parse("192.168.1.1"), IPAddress.Parse("2A02:1205:506C:A20:8948:8104:772D:C57D"));
            result2.Wait();
            Console.WriteLine(result2.Result);

            // Caculate device password
            var masterKey = "6449DA1BB45C71C71C57EDC603B4A644";
            var result3 = DnsMe.UpdateDeviceInDeviceGroup("mydevicegroup_devicename.dns-me.com", masterKey, IPAddress.Parse("192.168.1.1"), IPAddress.Parse("2A01:1205:506C:A60:8948:7104:772D:C57D"));
            result3.Wait();
            Console.WriteLine(result3.Result);


            Console.Read();
        }
    }
}
