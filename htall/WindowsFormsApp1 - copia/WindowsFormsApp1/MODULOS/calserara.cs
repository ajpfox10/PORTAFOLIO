using System;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowsFormsApp1
{
    public static class RawPrinterHelper
    {
        [DllImport("winspool.Drv", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool OpenPrinter(string printerName, out IntPtr printerHandle, IntPtr printerDefault);

        [DllImport("winspool.Drv", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool ClosePrinter(IntPtr printerHandle);

        [DllImport("winspool.Drv", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool StartDocPrinter(IntPtr printerHandle, int level, [In] DOCINFO docInfo);

        [DllImport("winspool.Drv", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool EndDocPrinter(IntPtr printerHandle);

        [DllImport("winspool.Drv", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool StartPagePrinter(IntPtr printerHandle);

        [DllImport("winspool.Drv", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool EndPagePrinter(IntPtr printerHandle);

        [DllImport("winspool.Drv", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool WritePrinter(IntPtr printerHandle, IntPtr data, int bytesToWrite, out int bytesWritten);

        public static bool SendStringToPrinter(string printerName, string text)
        {
            IntPtr printerHandle;
            if (!OpenPrinter(printerName.Normalize(), out printerHandle, IntPtr.Zero))
            {
                return false;
            }

            var docInfo = new DOCINFO();
            docInfo.pDocName = "Ticket";
            docInfo.pDataType = "RAW";

            if (!StartDocPrinter(printerHandle, 1, docInfo))
            {
                ClosePrinter(printerHandle);
                return false;
            }

            if (!StartPagePrinter(printerHandle))
            {
                EndDocPrinter(printerHandle);
                ClosePrinter(printerHandle);
                return false;
            }

            byte[] data = Encoding.ASCII.GetBytes(text);
            IntPtr unmanagedData = Marshal.AllocHGlobal(data.Length);
            Marshal.Copy(data, 0, unmanagedData, data.Length);

            int bytesWritten;
            bool success = WritePrinter(printerHandle, unmanagedData, data.Length, out bytesWritten);
            Marshal.FreeHGlobal(unmanagedData);

            if (!EndPagePrinter(printerHandle))
            {
                EndDocPrinter(printerHandle);
                ClosePrinter(printerHandle);
                return false;
            }

            if (!EndDocPrinter(printerHandle))
            {
                ClosePrinter(printerHandle);
                return false;
            }

            ClosePrinter(printerHandle);
            return success;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public class DOCINFO
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDataType;
        }
    }
}
