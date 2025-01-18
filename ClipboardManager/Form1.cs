using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ClipboardManager
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenu contextMenu;
        private System.Windows.Forms.MenuItem menuItem1, menuItem2, menuItem3;

        public Form1()
        {
            InitializeComponent();

            //Load all User saved Components
            textBox1_1.Text = Properties.Settings.Default.textBox1_1;
            textBox1_2.Text = Properties.Settings.Default.textBox1_2;
            comboBox1.Text = Properties.Settings.Default.comboBox1;
            textBox2_1.Text = Properties.Settings.Default.textBox2_1;
            textBox2_2.Text = Properties.Settings.Default.textBox2_2;
            comboBox2.Text = Properties.Settings.Default.comboBox2;


            //Initiate TrayIcon
            this.components = new System.ComponentModel.Container();
            this.contextMenu = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();

            // Initialize contextMenu1
            this.contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.menuItem1, this.menuItem2, this.menuItem3 });

            // Initialize menuItems
            this.menuItem1.Index = 2;
            this.menuItem1.Text = "E&xit";
            this.menuItem1.Click += new System.EventHandler(this.NotifyIcon_Exit);
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "Open";
            this.menuItem2.Click += new System.EventHandler(this.NotifyIcon_Open);
            this.menuItem3.Index = 0;
            this.menuItem3.Text = "Hide";
            this.menuItem3.Click += new System.EventHandler(this.NotifyIcon_Hide);

            // Set up how the form should be displayed.
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Text = "Clipboard Manager";

            // Create the NotifyIcon.
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            
            // The Icon property sets the icon that will appear
            // in the systray for this application.
            notifyIcon.Icon = this.Icon;

            // The ContextMenu property sets the menu that will
            // appear when the systray icon is right clicked.
            notifyIcon.ContextMenu = this.contextMenu;

            // The Text property sets the text that will be displayed,
            // in a tooltip, when the mouse hovers over the systray icon.
            notifyIcon.Text = this.Text;
            notifyIcon.Visible = true;

            // Handle the DoubleClick event to activate the form.
            notifyIcon.DoubleClick += new System.EventHandler(this.NotifyIcon_Open);
        }

        //Set Application to start hidden
        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            Opacity = 0;

            base.OnLoad(e);
        }
        private void NotifyIcon_Open(object Sender, EventArgs e)
        {
            // Show the form when the user double clicks on the notify icon.

            // Set the WindowState to normal if the form is minimized.
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            // Activate the form and show it if it was previously hidden.
            Visible = true;
            Opacity = 1.00;
            this.Show();
            this.Activate();
        }
        private void NotifyIcon_Exit(object Sender, EventArgs e)
        {
            // Close the form, which closes the application and clears the NotifyIcon.
            notifyIcon.Visible = false;
            this.Close();
        }
        private void NotifyIcon_Hide(object Sender, EventArgs e)
        {
            // Hides the form
            Visible = false;
        }




        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
        private IntPtr _ClipboardViewerNext;

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

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_DRAWCLIPBOARD = 0x308;

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    string[] TextBoxes1Content = new string[] { textBox1_1.Text, textBox2_1.Text };
                    string[] TextBoxes2Content = new string[] { textBox1_2.Text, textBox2_2.Text };
                    string[] ComboBoxesContent = new string[] { comboBox1.Text, comboBox2.Text };

                    for (var i = 0; i < TextBoxes1Content.Length; i++)
                    {
                        string Algorythm                    = ComboBoxesContent.GetValue(i).ToString();
                        string ContentToExchange            = TextBoxes1Content.GetValue(i).ToString();
                        List<string> ContentToExchangeArray = TextBoxes1Content.GetValue(i).ToString().Split(',').ToList();
                        string ContentToBeExchangedWith     = TextBoxes2Content.GetValue(i).ToString();

                        string OriginalContent = Clipboard.GetText();

                        if (Algorythm == "ContentTrimToEnd")
                            if (ContentToExchange != string.Empty && OriginalContent.Contains(ContentToExchange))
                            {
                                OriginalContent = ContentTrimToEnd(OriginalContent, ContentToExchange);
                                System.Windows.Forms.Clipboard.SetText(OriginalContent);
                            }

                        //Make sure to add as much detail about your link as possible, otherwise it might conflict with other inputs
                        //List<string> ContentToExchangeArray = new List<string>() { "//girlcockx.com", "//x.com", "//twitter.com" };
                        string ContentToExchangeInstance = ContentToExchangeArray.Find(x => OriginalContent.Contains(x));
                        if (Algorythm == "ContentReplace")
                            if (ContentToExchangeInstance != string.Empty && ContentToExchangeInstance != null)
                            {
                                OriginalContent = ContentReplace(OriginalContent, ContentToExchangeInstance, ContentToBeExchangedWith);
                                System.Windows.Forms.Clipboard.SetText(OriginalContent);
                            }
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }


        //FORM VARIABLES
        public static string[] Algorhythms = new string[] { "ContentTrimToEnd", "ContentReplace" };

        private void Form1_Load(object sender, EventArgs e)
        {
            _ClipboardViewerNext = SetClipboardViewer(this.Handle);
            comboBox1.Items.AddRange(Algorhythms);
            comboBox2.Items.AddRange(Algorhythms);
        }


        //New Line
        private void textBox1_1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox1_1 = textBox1_1.Text;
            Properties.Settings.Default.Save();
        }

        private void textBox1_2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox1_2 = textBox1_2.Text;
            Properties.Settings.Default.Save();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.comboBox1 = comboBox1.Text;
            Properties.Settings.Default.Save();
        }


        //New Line
        private void textBox2_1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox2_1 = textBox2_1.Text;
            Properties.Settings.Default.Save();
        }

        private void textBox2_2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox2_2 = textBox2_2.Text;
            Properties.Settings.Default.Save();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.comboBox2 = comboBox2.Text;
            Properties.Settings.Default.Save();
        }
    }
}
