﻿using System.Runtime.InteropServices;

namespace NexTerm
{
    internal class ConnectToNetwork
    {
        public class PinvokeWindowsNetworking
        {

            #region Consts
            private const int RESOURCE_CONNECTED = 0x1;
            private const int RESOURCE_GLOBALNET = 0x2;
            private const int RESOURCE_REMEMBERED = 0x3;
            private const int RESOURCETYPE_ANY = 0x0;
            private const int RESOURCETYPE_DISK = 0x1;
            private const int RESOURCETYPE_PRINT = 0x2;
            private const int RESOURCEDISPLAYTYPE_GENERIC = 0x0;
            private const int RESOURCEDISPLAYTYPE_DOMAIN = 0x1;
            private const int RESOURCEDISPLAYTYPE_SERVER = 0x2;
            private const int RESOURCEDISPLAYTYPE_SHARE = 0x3;
            private const int RESOURCEDISPLAYTYPE_FILE = 0x4;
            private const int RESOURCEDISPLAYTYPE_GROUP = 0x5;
            private const int RESOURCEUSAGE_CONNECTABLE = 0x1;
            private const int RESOURCEUSAGE_CONTAINER = 0x2;
            private const int CONNECT_INTERACTIVE = 0x8;
            private const int CONNECT_PROMPT = 0x10;
            private const int CONNECT_REDIRECT = 0x80;
            private const int CONNECT_UPDATE_PROFILE = 0x1;
            private const int CONNECT_COMMANDLINE = 0x800;
            private const int CONNECT_CMD_SAVECRED = 0x1000;
            private const int CONNECT_LOCALDRIVE = 0x100;
            #endregion

            #region Errors
            private const int NO_ERROR = 0;
            private const int ERROR_ACCESS_DENIED = 5;
            private const int ERROR_ALREADY_ASSIGNED = 85;
            private const int ERROR_BAD_DEVICE = 1200;
            private const int ERROR_BAD_NET_NAME = 67;
            private const int ERROR_BAD_PROVIDER = 1204;
            private const int ERROR_CANCELLED = 1223;
            private const int ERROR_EXTENDED_ERROR = 1208;
            private const int ERROR_INVALID_ADDRESS = 487;
            private const int ERROR_INVALID_PARAMETER = 87;
            private const int ERROR_INVALID_PASSWORD = 1216;
            private const int ERROR_MORE_DATA = 234;
            private const int ERROR_NO_MORE_ITEMS = 259;
            private const int ERROR_NO_NET_OR_BAD_PATH = 1203;
            private const int ERROR_NO_NETWORK = 1222;
            private const int ERROR_BAD_PROFILE = 1206;
            private const int ERROR_CANNOT_OPEN_PROFILE = 1205;
            private const int ERROR_DEVICE_IN_USE = 2404;
            private const int ERROR_NOT_CONNECTED = 2250;
            private const int ERROR_OPEN_FILES = 2401;

            private struct ErrorClass
            {
                public int num;
                public string message;

                public ErrorClass(int num, string message)
                {
                    this.num = num;
                    this.message = message;
                }
            }

            private static ErrorClass[] ERROR_LIST = new ErrorClass[] { new ErrorClass(ERROR_ACCESS_DENIED, "Error: Access Denied"), new ErrorClass(ERROR_ALREADY_ASSIGNED, "Error: Already Assigned"), new ErrorClass(ERROR_BAD_DEVICE, "Error: Bad Device"), new ErrorClass(ERROR_BAD_NET_NAME, "Error: Bad Net Name"), new ErrorClass(ERROR_BAD_PROVIDER, "Error: Bad Provider"), new ErrorClass(ERROR_CANCELLED, "Error: Cancelled"), new ErrorClass(ERROR_EXTENDED_ERROR, "Error: Extended Error"), new ErrorClass(ERROR_INVALID_ADDRESS, "Error: Invalid Address"), new ErrorClass(ERROR_INVALID_PARAMETER, "Error: Invalid Parameter"), new ErrorClass(ERROR_INVALID_PASSWORD, "Error: Invalid Password"), new ErrorClass(ERROR_MORE_DATA, "Error: More Data"), new ErrorClass(ERROR_NO_MORE_ITEMS, "Error: No More Items"), new ErrorClass(ERROR_NO_NET_OR_BAD_PATH, "Error: No Net Or Bad Path"), new ErrorClass(ERROR_NO_NETWORK, "Error: No Network"), new ErrorClass(ERROR_BAD_PROFILE, "Error: Bad Profile"), new ErrorClass(ERROR_CANNOT_OPEN_PROFILE, "Error: Cannot Open Profile"), new ErrorClass(ERROR_DEVICE_IN_USE, "Error: Device In Use"), new ErrorClass(ERROR_EXTENDED_ERROR, "Error: Extended Error"), new ErrorClass(ERROR_NOT_CONNECTED, "Error: Not Connected"), new ErrorClass(ERROR_OPEN_FILES, "Error: Open Files") };

            private static string getErrorForNumber(int errNum)
            {
                foreach (var er in ERROR_LIST)
                {
                    if (er.num == errNum)
                        return er.message;
                }

                return "Error: Unknown, " + errNum;
            }
            #endregion

            [DllImport("Mpr.dll")]
            private static extern int WNetUseConnection(nint hwndOwner, NETRESOURCE lpNetResource, string lpPassword, string lpUserID, int dwFlags, string lpAccessName, string lpBufferSize, string lpResult);

            [DllImport("Mpr.dll")]
            private static extern int WNetCancelConnection2(string lpName, int dwFlags, bool fForce);

            [StructLayout(LayoutKind.Sequential)]
            private class NETRESOURCE
            {
                public int dwScope = 0;
                public int dwType = 0;
                public int dwDisplayType = 0;
                public int dwUsage = 0;
                public string lpLocalName = "";
                public string lpRemoteName = "";
                public string lpComment = "";
                public string lpProvider = "";
            }

            public static string connectToRemote(string remoteUNC, string username, string password)
            {
                return connectToRemote(remoteUNC, username, password, false);
            }

            public static string connectToRemote(string remoteUNC, string username, string password, bool promptUser)
            {
                var nr = new NETRESOURCE();
                nr.dwType = RESOURCETYPE_DISK;
                nr.lpRemoteName = remoteUNC;

                // nr.lpLocalName = "F:";

                int ret;

                if (promptUser)
                {
                    ret = WNetUseConnection(nint.Zero, nr, "", "", CONNECT_INTERACTIVE | CONNECT_PROMPT, null, null, null);
                }
                else
                {
                    ret = WNetUseConnection(nint.Zero, nr, password, username, 0, null, null, null);
                }

                if (ret == NO_ERROR)
                    return null;
                return getErrorForNumber(ret);
            }

            public static string disconnectRemote(string remoteUNC)
            {
                int ret = WNetCancelConnection2(remoteUNC, CONNECT_UPDATE_PROFILE, false);
                if (ret == NO_ERROR)
                    return null;
                return getErrorForNumber(ret);
            }
        }
    }
}