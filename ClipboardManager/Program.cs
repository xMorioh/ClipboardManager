using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static ClipboardManager.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClipboardManager
{
    internal static class Program
    {
        //OLD, this is good if you want the application to run in the background only without GUI
        /*
        //https://stackoverflow.com/questions/621577/clipboard-event-c-sharp
        //https://stackoverflow.com/questions/17762037/error-while-trying-to-copy-string-to-clipboard
        //https://gist.github.com/glombard/7986317

        internal static class NativeMethods
        {
            //Reference https://learn.microsoft.com/en-us/windows/desktop/dataxchg/wm-clipboardupdate
            public const int WM_CLIPBOARDUPDATE = 0x031D;
            //Reference https://www.pinvoke.net/default.aspx/Constants.HWND
            public static IntPtr HWND_MESSAGE = new IntPtr(-3);

            //Reference https://www.pinvoke.net/default.aspx/user32/AddClipboardFormatListener.html
            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool AddClipboardFormatListener(IntPtr hwnd);

            //Reference https://www.pinvoke.net/default.aspx/user32.setparent
            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

            //Reference https://www.pinvoke.net/default.aspx/user32/getwindowtext.html
            [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

            //Reference https://www.pinvoke.net/default.aspx/user32.getwindowtextlength
            [DllImport("user32.dll")]
            public static extern int GetWindowTextLength(IntPtr hWnd);

            //Reference https://www.pinvoke.net/default.aspx/user32.getforegroundwindow
            [DllImport("user32.dll")]
            public static extern IntPtr GetForegroundWindow();
        }

        public static class Clipboard
        {
            public static string GetText()
            {
                string ReturnValue = string.Empty;
                Thread STAThread = new Thread(
                    delegate ()
                    {
                        // Use a fully qualified name for Clipboard otherwise it will end up calling itself.
                        ReturnValue = System.Windows.Forms.Clipboard.GetText();
                    });
                STAThread.SetApartmentState(ApartmentState.STA);
                STAThread.Start();
                STAThread.Join();

                return ReturnValue;
            }
        }

        public class ClipboardNotification
        {
            private class NotificationForm : Form
            {
                public NotificationForm()
                {
                    //Turn the child window into a message-only window (refer to Microsoft docs)
                    NativeMethods.SetParent(Handle, NativeMethods.HWND_MESSAGE);
                    //Place window in the system-maintained clipboard format listener list
                    NativeMethods.AddClipboardFormatListener(Handle);
                }

                //Trimming Algorhythms START
                //Trim To End Of Line including the content to trim
                protected string ContentTrimToEnd(string OriginalContent, string ContentToExchange)
                {
                    int parameterIndex = OriginalContent.IndexOf(ContentToExchange, StringComparison.Ordinal);
                    int indexLeft = parameterIndex;
                    int indexRight = OriginalContent.Length - indexLeft;
                    OriginalContent = OriginalContent.Remove(indexLeft, indexRight);
                    return OriginalContent;
                }

                //Content Exchange from string List
                protected string ContentReplace(string OriginalContent, string ContentToExchange, string ContentToBeExchangedWith)
                {
                    OriginalContent = OriginalContent.Replace(ContentToExchange, ContentToBeExchangedWith);
                    return OriginalContent;
                }
                //Trimming Algorhythms END

                protected override void WndProc(ref Message m)
                {
                    //Listen for operating system messages
                    if (m.Msg == NativeMethods.WM_CLIPBOARDUPDATE)
                    {
                        //Note that Clipboard.SetText should only be used once here, otherwise the program might get into a loop
                        string OriginalContent = Clipboard.GetText();
                        bool IsLink = OriginalContent.StartsWith("https://") || OriginalContent.StartsWith("http://");
                        string ContentToExchange = string.Empty;
                        string ContentToBeExchangedWith = string.Empty;

                        //Remove Youtube Identifyer
                        ContentToExchange = "?si="; // InputData.textBox1_1;
                        if (IsLink && OriginalContent.Contains(ContentToExchange))
                        {
                            OriginalContent = ContentTrimToEnd(OriginalContent, ContentToExchange);
                            System.Windows.Forms.Clipboard.SetText(OriginalContent);
                        }

                        //Exchange X formerly Twitter Domain Names in Links
                        //Make sure to add as much detail about your link as possible, otherwise it might conflict with other inputs
                        List<string> ContentToExchangeArray = new List<string>() { "//girlcockx.com", "//x.com", "//twitter.com" };
                        string ContentToExchangeInstance = ContentToExchangeArray.Find(x => OriginalContent.Contains(x));
                        if (IsLink && ContentToExchangeInstance != null)
                        {
                            ContentToBeExchangedWith = "//fixupx.com";
                            OriginalContent = ContentReplace(OriginalContent, ContentToExchangeInstance, ContentToBeExchangedWith);
                            System.Windows.Forms.Clipboard.SetText(OriginalContent);
                        }
                    }
                    //Called for any unhandled messages
                    base.WndProc(ref m);
                }
            }
        */

            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                //Application.Run(new NotificationForm());
            }
        }
    }