using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace ImgStorgeASP.Misc
{
	public class GetIP
	{
        public static string GetLocalIPAddress()
        {
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface netInterface in networkInterfaces)
            {
                if (netInterface.OperationalStatus == OperationalStatus.Up &&
                    netInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                    netInterface.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
                {
                    IPInterfaceProperties ipProps = netInterface.GetIPProperties();

                    foreach (UnicastIPAddressInformation ip in ipProps.UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork &&
                            !IPAddress.IsLoopback(ip.Address))
                        {
                            Console.WriteLine($"Interface: {netInterface.Name}, IP Address: {ip.Address}");
                            Console.WriteLine($"Local IP Address: {ip.Address}");


                            return ip.Address.ToString();
                        }
                    }
                }
            }

            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}


