using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)this.Handle);

            //Load all User saved Components
            textBox1_0.Text = Properties.Settings.Default.textBox1_0;
            textBox1_1.Text = Properties.Settings.Default.textBox1_1;
            textBox1_2.Text = Properties.Settings.Default.textBox1_2;
            comboBox1.Text = Properties.Settings.Default.comboBox1;

            textBox2_0.Text = Properties.Settings.Default.textBox2_0;
            textBox2_1.Text = Properties.Settings.Default.textBox2_1;
            textBox2_2.Text = Properties.Settings.Default.textBox2_2;
            comboBox2.Text = Properties.Settings.Default.comboBox2;

            textBox3_0.Text = Properties.Settings.Default.textBox3_0;
            textBox3_1.Text = Properties.Settings.Default.textBox3_1;
            textBox3_2.Text = Properties.Settings.Default.textBox3_2;
            comboBox3.Text = Properties.Settings.Default.comboBox3;

            textBox4_0.Text = Properties.Settings.Default.textBox4_0;
            textBox4_1.Text = Properties.Settings.Default.textBox4_1;
            textBox4_2.Text = Properties.Settings.Default.textBox4_2;
            comboBox4.Text = Properties.Settings.Default.comboBox4;

            textBox5_0.Text = Properties.Settings.Default.textBox5_0;
            textBox5_1.Text = Properties.Settings.Default.textBox5_1;
            textBox5_2.Text = Properties.Settings.Default.textBox5_2;
            comboBox5.Text = Properties.Settings.Default.comboBox5;

            textBox6_0.Text = Properties.Settings.Default.textBox6_0;
            textBox6_1.Text = Properties.Settings.Default.textBox6_1;
            textBox6_2.Text = Properties.Settings.Default.textBox6_2;
            comboBox6.Text = Properties.Settings.Default.comboBox6;

            textBox7_0.Text = Properties.Settings.Default.textBox7_0;
            textBox7_1.Text = Properties.Settings.Default.textBox7_1;
            textBox7_2.Text = Properties.Settings.Default.textBox7_2;
            comboBox7.Text = Properties.Settings.Default.comboBox7;

            textBox8_0.Text = Properties.Settings.Default.textBox8_0;
            textBox8_1.Text = Properties.Settings.Default.textBox8_1;
            textBox8_2.Text = Properties.Settings.Default.textBox8_2;
            comboBox8.Text = Properties.Settings.Default.comboBox8;

            textBox9_0.Text = Properties.Settings.Default.textBox9_0;
            textBox9_1.Text = Properties.Settings.Default.textBox9_1;
            textBox9_2.Text = Properties.Settings.Default.textBox9_2;
            comboBox9.Text = Properties.Settings.Default.comboBox9;

            textBox10_0.Text = Properties.Settings.Default.textBox10_0;
            textBox10_1.Text = Properties.Settings.Default.textBox10_1;
            textBox10_2.Text = Properties.Settings.Default.textBox10_2;
            comboBox10.Text = Properties.Settings.Default.comboBox10;

            textBox11_0.Text = Properties.Settings.Default.textBox11_0;
            textBox11_1.Text = Properties.Settings.Default.textBox11_1;
            textBox11_2.Text = Properties.Settings.Default.textBox11_2;
            comboBox11.Text = Properties.Settings.Default.comboBox11;

            textBox12_0.Text = Properties.Settings.Default.textBox12_0;
            textBox12_1.Text = Properties.Settings.Default.textBox12_1;
            textBox12_2.Text = Properties.Settings.Default.textBox12_2;
            comboBox12.Text = Properties.Settings.Default.comboBox12;


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

        //Set Application to start hidden on "OnLoad" and on "OnShown"
        protected override void OnLoad(EventArgs e)
        {
            //Setting the Windows to SizableToolWindow will make it disappear from ALT+TAB
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Visible = false;
            Opacity = 0.00;
    
            base.OnLoad(e);
        }
        protected override void OnShown(EventArgs e)
        {
            //Setting the Windows to SizableToolWindow will make it disappear from ALT+TAB
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Visible = false;
            Opacity = 0.00;

            base.OnShown(e);
        }
        private void NotifyIcon_Open(object Sender, EventArgs e)
        {
            // Set the WindowState to normal if the form is minimized.
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            //Setting the Windows to Sizable will make it appear in ALT+TAB again
            this.FormBorderStyle = FormBorderStyle.Sizable;
            Visible = true;
            Opacity = 1.00;
            this.Activate();
        }
        private void NotifyIcon_Exit(object Sender, EventArgs e)
        {
            // Close the form, which closes the application and clears the NotifyIcon.
            // Also remove the application from the Clipboard Listener again.
            notifyIcon.Visible = false;
            this.Close();
        }
        private void NotifyIcon_Hide(object Sender, EventArgs e)
        {
            // Hides the form
            Visible = false;
        }


        [DllImport("User32.dll")]
        protected static extern int SetClipboardViewer(int hWndNewViewer);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        IntPtr nextClipboardViewer;


        //-----Algorhithms START-----
        //Trim To End Of Line including the content to trim
        protected string ContentTrimToEnd(string OriginalContent, string ContentToExchange)
        {
            int parameterIndex = OriginalContent.IndexOf(ContentToExchange, StringComparison.Ordinal);
            int indexLeft = parameterIndex;
            int indexRight = OriginalContent.Length - indexLeft;
            OriginalContent = OriginalContent.Remove(indexLeft, indexRight);
            return OriginalContent;
        }

        protected string ContentTrimToBeginning(string OriginalContent, string ContentToExchange)
        {
            int parameterIndex = OriginalContent.IndexOf(ContentToExchange, StringComparison.Ordinal);
            int indexLeft = parameterIndex;
            OriginalContent = OriginalContent.Remove(0, indexLeft);
            return OriginalContent;
        }

        //Content Exchange from string List
        protected string ContentReplace(string OriginalContent, string ContentToExchange, string ContentToBeExchangedWith)
        {
            OriginalContent = OriginalContent.Replace(ContentToExchange, ContentToBeExchangedWith);
            return OriginalContent;
        }

        protected string ContentAddToEnd(string OriginalContent, string ContentToAdd)
        {
            OriginalContent += ContentToAdd;
            return OriginalContent;
        }
        //-----Trimming Algorhithms END-----

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_DRAWCLIPBOARD = 0x308;
            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    string[] TextBoxes0Content = new string[] { textBox1_0.Text, textBox2_0.Text, textBox3_0.Text, textBox4_0.Text, textBox5_0.Text, textBox6_0.Text, textBox7_0.Text, textBox8_0.Text, textBox9_0.Text, textBox10_0.Text, textBox11_0.Text, textBox12_0.Text };
                    string[] TextBoxes1Content = new string[] { textBox1_1.Text, textBox2_1.Text, textBox3_1.Text, textBox4_1.Text, textBox5_1.Text, textBox6_1.Text, textBox7_1.Text, textBox8_1.Text, textBox9_1.Text, textBox10_1.Text, textBox11_1.Text, textBox12_1.Text };
                    string[] TextBoxes2Content = new string[] { textBox1_2.Text, textBox2_2.Text, textBox3_2.Text, textBox4_2.Text, textBox5_2.Text, textBox6_2.Text, textBox7_2.Text, textBox8_2.Text, textBox9_2.Text, textBox10_2.Text, textBox11_2.Text, textBox12_2.Text };
                    string[] ComboBoxesContent = new string[] { comboBox1.Text, comboBox2.Text, comboBox3.Text, comboBox4.Text, comboBox5.Text, comboBox6.Text, comboBox7.Text, comboBox8.Text, comboBox9.Text, comboBox10.Text, comboBox11.Text, comboBox12.Text };
                    string OriginalContent = string.Empty;
                    try
                    {
                        //Make sure to check if the content is in text format before doing anything
                        if (System.Windows.Forms.Clipboard.ContainsText() && !System.Windows.Forms.Clipboard.ContainsImage() && !System.Windows.Forms.Clipboard.ContainsAudio() && !System.Windows.Forms.Clipboard.ContainsFileDropList())
                        {
                            OriginalContent = System.Windows.Forms.Clipboard.GetText();

                            for (int i = 0; i < ComboBoxesContent.Length; i++)
                            {
                                //Column Data
                                List<string> RequiredKeyList = TextBoxes0Content.GetValue(i).ToString().Split(',').ToList();
                                List<string> ContentToExchangeList = TextBoxes1Content.GetValue(i).ToString().Split(',').ToList();
                                string Modifier = TextBoxes2Content.GetValue(i).ToString();
                                string Algorithm = ComboBoxesContent.GetValue(i).ToString();

                                //Converted Column Data for internal use
                                string ContentToExchangeInstance = ContentToExchangeList.Find(x => OriginalContent.Contains(x));
                                string RequiredKeyInstance = RequiredKeyList.Find(x => OriginalContent.Contains(x));

                                //Start of Clipbaord Content handling
                                if (RequiredKeyInstance != null)
                                {
                                    if (OriginalContent != string.Empty && OriginalContent != null)
                                    {
                                        //ContentTrimToEnd
                                        if (Algorithm == Algorhithms.GetValue(1).ToString())
                                        {
                                            if (ContentToExchangeInstance != string.Empty && ContentToExchangeInstance != null)
                                                OriginalContent = ContentTrimToEnd(OriginalContent, ContentToExchangeInstance);
                                        }

                                        //ContentTrimToBeginning
                                        if (Algorithm == Algorhithms.GetValue(2).ToString())
                                        {
                                            if (ContentToExchangeInstance != string.Empty && ContentToExchangeInstance != null)
                                                OriginalContent = ContentTrimToBeginning(OriginalContent, ContentToExchangeInstance);
                                        }

                                        //ContentReplace
                                        else if (Algorithm == Algorhithms.GetValue(3).ToString())
                                        {
                                            if (ContentToExchangeInstance != string.Empty && ContentToExchangeInstance != null)
                                                OriginalContent = ContentReplace(OriginalContent, ContentToExchangeInstance, Modifier);
                                        }

                                        //ContentAddToEnd
                                        else if (Algorithm == Algorhithms.GetValue(4).ToString())
                                        {
                                            //For some reason copying text from certain applications will make this Algorithm run several times
                                            //therefore we check if it has run already, this issue may be present in the upper algorithms too, unsure how to test.
                                            if (!OriginalContent.Contains(Modifier))
                                                OriginalContent = ContentAddToEnd(OriginalContent, Modifier);
                                        }
                                    }
                                }
                            }
                            if (OriginalContent != string.Empty && OriginalContent != null)
                                //System.Windows.Forms.Clipboard.SetText(OriginalContent);
                                System.Windows.Forms.Clipboard.SetDataObject(OriginalContent, true, 10, 100);
                            else
                                System.Windows.Forms.Clipboard.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        var directory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                        directory += "\\Morioh\\ClipboardManager\\Logging\\";
                        Directory.CreateDirectory(Path.GetDirectoryName(directory));

                        string Logfile = directory + "ErrorLog.log";
                        File.AppendAllText(Logfile, DateTime.Now.ToString("yyyy-MM-dd@HH:mm:ss") + ": " + ex.Message + "\n" + ex.ToString() + "\n");
                    }
                    SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;
                default:
                    //Called for any unhandled messages
                    base.WndProc(ref m);
                    break;
            }
        }


        //FORM VARIABLES
        public static string[] Algorhithms = new string[] { "", "ContentTrimToEnd", "ContentTrimToBeginning", "ContentReplace", "ContentAddToEnd" };

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(Algorhithms);
            comboBox2.Items.AddRange(Algorhithms);
            comboBox3.Items.AddRange(Algorhithms);
            comboBox4.Items.AddRange(Algorhithms);
            comboBox5.Items.AddRange(Algorhithms);
            comboBox6.Items.AddRange(Algorhithms);
            comboBox7.Items.AddRange(Algorhithms);
            comboBox8.Items.AddRange(Algorhithms);
            comboBox9.Items.AddRange(Algorhithms);
            comboBox10.Items.AddRange(Algorhithms);
            comboBox11.Items.AddRange(Algorhithms);
            comboBox12.Items.AddRange(Algorhithms);
        }


        //New Line
        private void textBox1_0_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox1_0 = textBox1_0.Text;
            Properties.Settings.Default.Save();
        }
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
        private void textBox2_0_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox2_0 = textBox2_0.Text;
            Properties.Settings.Default.Save();
        }
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


        //New Line
        private void textBox3_0_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox3_0 = textBox3_0.Text;
            Properties.Settings.Default.Save();
        }
        private void textBox3_1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox3_1 = textBox3_1.Text;
            Properties.Settings.Default.Save();
        }
        private void textBox3_2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox3_2 = textBox3_2.Text;
            Properties.Settings.Default.Save();
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.comboBox3 = comboBox3.Text;
            Properties.Settings.Default.Save();
        }


        //New Line
        private void textBox4_0_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox4_0 = textBox4_0.Text;
            Properties.Settings.Default.Save();
        }
        private void textBox4_1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox4_1 = textBox4_1.Text;
            Properties.Settings.Default.Save();
        }
        private void textBox4_2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox4_2 = textBox4_2.Text;
            Properties.Settings.Default.Save();
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.comboBox4 = comboBox4.Text;
            Properties.Settings.Default.Save();
        }


        //New Line
        private void textBox5_0_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox5_0 = textBox5_0.Text;
            Properties.Settings.Default.Save();
        }
        private void textBox5_1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox5_1 = textBox5_1.Text;
            Properties.Settings.Default.Save();
        }
        private void textBox5_2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox5_2 = textBox5_2.Text;
            Properties.Settings.Default.Save();
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.comboBox5 = comboBox5.Text;
            Properties.Settings.Default.Save();
        }


        //New Line
        private void textBox6_0_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox6_0 = textBox6_0.Text;
            Properties.Settings.Default.Save();
        }
        private void textBox6_1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox6_1 = textBox6_1.Text;
            Properties.Settings.Default.Save();
        }
        private void textBox6_2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox6_2 = textBox6_2.Text;
            Properties.Settings.Default.Save();
        }
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.comboBox6 = comboBox6.Text;
            Properties.Settings.Default.Save();
        }


        //New Line
        private void textBox7_0_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox7_0 = textBox7_0.Text;
            Properties.Settings.Default.Save();
        }
        private void textBox7_1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox7_1 = textBox7_1.Text;
            Properties.Settings.Default.Save();
        }
        private void textBox7_2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox7_2 = textBox7_2.Text;
            Properties.Settings.Default.Save();
        }
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.comboBox7 = comboBox7.Text;
            Properties.Settings.Default.Save();
        }


        //New Line
        private void textBox8_0_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox8_0 = textBox8_0.Text;
            Properties.Settings.Default.Save();
        }
        private void textBox8_1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox8_1 = textBox8_1.Text;
            Properties.Settings.Default.Save();
        }
        private void textBox8_2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox8_2 = textBox8_2.Text;
            Properties.Settings.Default.Save();
        }
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.comboBox8 = comboBox8.Text;
            Properties.Settings.Default.Save();
        }


        //New Line
        private void textBox9_0_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox9_0 = textBox9_0.Text;
            Properties.Settings.Default.Save();
        }
        private void textBox9_1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox9_1 = textBox9_1.Text;
            Properties.Settings.Default.Save();
        }
        private void textBox9_2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox9_2 = textBox9_2.Text;
            Properties.Settings.Default.Save();
        }
        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.comboBox9 = comboBox9.Text;
            Properties.Settings.Default.Save();
        }


        //New Line
        private void textBox10_0_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox10_0 = textBox10_0.Text;
            Properties.Settings.Default.Save();
        }
        private void textBox10_1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox10_1 = textBox10_1.Text;
            Properties.Settings.Default.Save();
        }
        private void textBox10_2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox10_2 = textBox10_2.Text;
            Properties.Settings.Default.Save();
        }
        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.comboBox10 = comboBox10.Text;
            Properties.Settings.Default.Save();
        }


        //New Line
        private void textBox11_0_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox11_0 = textBox11_0.Text;
            Properties.Settings.Default.Save();
        }
        private void textBox11_1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox11_1 = textBox11_1.Text;
            Properties.Settings.Default.Save();
        }
        private void textBox11_2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox11_2 = textBox11_2.Text;
            Properties.Settings.Default.Save();
        }
        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.comboBox11 = comboBox11.Text;
            Properties.Settings.Default.Save();
        }


        //New Line
        private void textBox12_0_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox12_0 = textBox12_0.Text;
            Properties.Settings.Default.Save();
        }
        private void textBox12_1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox12_1 = textBox12_1.Text;
            Properties.Settings.Default.Save();
        }
        private void textBox12_2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textBox12_2 = textBox12_2.Text;
            Properties.Settings.Default.Save();
        }
        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.comboBox12 = comboBox12.Text;
            Properties.Settings.Default.Save();
        }
    }
}
