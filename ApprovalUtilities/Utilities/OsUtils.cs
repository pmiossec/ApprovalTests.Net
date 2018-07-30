using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;

namespace ApprovalUtilities.Utilities
{
    public enum ApprovalsPlatform
    {
        Windows,
        Linux,
        Mac
    }

    public class OsUtils
    {
        public static ApprovalsPlatform GetPlatformId()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return ApprovalsPlatform.Mac;

            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return ApprovalsPlatform.Linux;

            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return ApprovalsPlatform.Windows;

            }

            throw new Exception("Unknow Operating System" + RuntimeInformation.OSDescription);
        }

        public static string GetFullOsNameFromWmi()
        {
            //return RuntimeInformation.OSDescription;
            var platformId = GetPlatformId();
            if (platformId == ApprovalsPlatform.Windows)
            {
                var caption =
                    (from x in
                         new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().OfType<ManagementObject>()
                     select x.GetPropertyValue("Caption")).FirstOrDefault();

                var name = caption == null ? Environment.OSVersion.ToString() : caption.ToString();
                return name;
            }
            else
            {
                return platformId.ToString();
            }
        }
        public static bool IsWindowsOs()
        {
            return Path.DirectorySeparatorChar == '\\';
        }

        public static bool IsUnixOs()
        {
            return !IsWindowsOs();
        }
    }
}