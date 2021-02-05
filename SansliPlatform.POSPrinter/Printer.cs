using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SansliPlatform.POSPrinter
{
    public class Printer
    {
        public static void GiftItems(string printerName, string ticketNo)
        {
            if (printerName == "ITherm280")
                Print("ITherm280", GetDocument(ticketNo));
        }

        private static void Print(string printerName, byte[] document)
        {

            NativeMethods.DOC_INFO_1 documentInfo;
            IntPtr printerHandle;

            documentInfo = new NativeMethods.DOC_INFO_1();
            documentInfo.pDataType = "RAW";
            documentInfo.pDocName = "Receipt";

            printerHandle = new IntPtr(0);

            if (NativeMethods.OpenPrinter(printerName.Normalize(), out printerHandle, IntPtr.Zero))
            {
                if (NativeMethods.StartDocPrinter(printerHandle, 1, documentInfo))
                {
                    int bytesWritten;
                    byte[] managedData;
                    IntPtr unmanagedData;

                    managedData = document;
                    unmanagedData = Marshal.AllocCoTaskMem(managedData.Length);
                    Marshal.Copy(managedData, 0, unmanagedData, managedData.Length);

                    if (NativeMethods.StartPagePrinter(printerHandle))
                    {
                        NativeMethods.WritePrinter(
                            printerHandle,
                            unmanagedData,
                            managedData.Length,
                            out bytesWritten);
                        NativeMethods.EndPagePrinter(printerHandle);
                    }
                    else
                    {
                        throw new Win32Exception();
                    }

                    Marshal.FreeCoTaskMem(unmanagedData);

                    NativeMethods.EndDocPrinter(printerHandle);
                }
                else
                {
                    throw new Win32Exception();
                }

                NativeMethods.ClosePrinter(printerHandle);
            }
            else
            {
                throw new Win32Exception();
            }

        }

        private static byte[] GetDocument(string ticketNo)
        {
            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                // Reset the printer bws (NV images are not cleared)
                bw.Write(AsciiControlChars.Escape);
                bw.Write('@');
                PrintReceipt(bw);
                bw.Write("&%PC");
                bw.Flush();
                return ms.ToArray();
            }
        }

        private static void PrintReceipt(BinaryWriter bw)
        {
            bw.LargeText("     Sadisa");
            bw.LargeText("  Enterprises");
            bw.NormalFont("  M:071-2628126 T:045-2271300 ");
            bw.NormalFont("-----------------------------");
            //bw.NormalFont("Invoice #: ");
            bw.NormalFont("Hour: ");
            bw.NormalFont("Minute: ");
            bw.NormalFont("Date: ");
            bw.NormalFont("Customer: ");
            bw.NormalFont("Itm     Qty     Price    Tot");
            bw.NormalFont("-----------------------------");
            bw.Finish();
        }
    }

}

