public static string PrinterName
{
  get { return @"\\{0}\POS58".FormatWith(Environment.MachineName); }
}

private void btnPrintReceipt_Click(object sender, EventArgs e)
{ 
  Print(PrinterName, GetDocument());
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
}

private byte[] GetDocument()
{
            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                // Reset the printer bws (NV images are not cleared)
                bw.Write(AsciiControlChars.Escape);
                bw.Write('@');

                // Render the logo
                //RenderLogo(bw);
                PrintReceipt(bw);

                // Feed 3 vertical motion units and cut the paper with a 1 point cut
                bw.Write(AsciiControlChars.GroupSeparator);
                bw.Write('V');
                bw.Write((byte)66);
                bw.Write((byte)3);

                bw.Flush();

                return ms.ToArray();
            }
}

        /// <summary>
        /// This is the method we print the receipt the way we want. Note the spaces. 
        /// Wasted a lot of paper on this to get it right.
        /// </summary>
        /// <param name="bw"></param>
        private void PrintReceipt(BinaryWriter bw)
        {

            bw.LargeText("     Sadisa");
            bw.LargeText("  Enterprises");
            bw.NormalFont("  M:071-2628126 T:045-2271300");
            bw.FeedLines(1);
            bw.NormalFont("Invoice #: " + _mappedInvoice.InvoiceNumber);
            bw.NormalFont("Date: " + _mappedInvoice.InvoiceDateFormatted);
            bw.NormalFont("Customer: " + ReadOnlyCustomer.GetById(_mappedInvoice.CustomerID).Name);
            bw.FeedLines(1);

            bw.NormalFont("Itm     Qty     Price    Tot");
            bw.NormalFont("-----------------------------");
            foreach (var item in _mappedInvoice.InvoiceItems)
            {
                // var idx = InvoiceItems.IndexOf(item) + 1;
                bw.NormalFont(ReadOnlyItem.GetById(item.ItemID).Name);
                bw.NormalFont("       {0}   {1}  {2}".FormatWith(item.Qty, item.UnitPrice, item.Qty * item.UnitPrice), false);

            }
            bw.FeedLines(2);
            bw.NormalFont(" Discount:  " + _mappedInvoice.Discount);
            bw.NormalFont( "Sub Total:  " + _mappedInvoice.SubTotal);
            bw.FeedLines(1);
            bw.High(       "     Total:  " + _mappedInvoice.Total);
            bw.FeedLines(1);
            bw.NormalFont(   "  Payment:  " + _mappedInvoice.Payment);
            bw.NormalFont(   "  Balance:  " + _mappedInvoice.Balance);
            bw.Finish();

        }