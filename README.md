# dns-me.com client
www.dns-me.com is a free DNS service for IOT devices. 
with dns-me you can access to the public or local ip address of a device. Just by using a dns-me name like dev_mydevice.dns-me.com

<b>Update client</b>
You can use this .net C# update client to update the IP address of a device. 

### Update single device
1. Go to www.dns-me.com and create a free account
2. Create a device with a name and a password
3. You can update your device like this:
```
DnsMe.UpdateDevice("dev_test.dns-me.com", "123456");
```

### Update multiple devices (device group)
1. Go to www.dns-me.com and create a free account
2. Create a new device group (like: mygroup_xxxxxxx.dns-me.com) and a masterkey
3. You can create and update new devices by using this code:
```
DnsMe.UpdateDeviceInDeviceGroup("mygroup_devicename.dns-me.com", MASTERKEY);
```
