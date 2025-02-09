﻿using System;
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
            //Setting the Windows to SizableToolWindow will make it disappear from ALT+TAB
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Visible = false;
            Opacity = 0.00;

            base.OnLoad(e);
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

        //-----Trimming Algorhithms START-----
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
        //Trimming Algorhithms END-----

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_DRAWCLIPBOARD = 0x308;

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    string[] TextBoxes0Content = new string[] { textBox1_0.Text, textBox2_0.Text, textBox3_0.Text, textBox4_0.Text, textBox5_0.Text, textBox6_0.Text, textBox7_0.Text };
                    string[] TextBoxes1Content = new string[] { textBox1_1.Text, textBox2_1.Text, textBox3_1.Text, textBox4_1.Text, textBox5_1.Text, textBox6_1.Text, textBox7_1.Text };
                    string[] TextBoxes2Content = new string[] { textBox1_2.Text, textBox2_2.Text, textBox3_2.Text, textBox4_2.Text, textBox5_2.Text, textBox6_2.Text, textBox7_2.Text };
                    string[] ComboBoxesContent = new string[] { comboBox1.Text, comboBox2.Text, comboBox3.Text, comboBox4.Text, comboBox5.Text, comboBox6.Text, comboBox7.Text };

                    for (var i = 0; i < TextBoxes1Content.Length; i++)
                    {
                        List<string> RequiredKeyList = TextBoxes0Content.GetValue(i).ToString().Split(',').ToList();
                        List<string> ContentToExchangeList = TextBoxes1Content.GetValue(i).ToString().Split(',').ToList();
                        string ContentToBeExchangedWith = TextBoxes2Content.GetValue(i).ToString();
                        string Algorithm = ComboBoxesContent.GetValue(i).ToString();

                        string OriginalContent = Clipboard.GetText();
                        string ContentToExchangeInstance = ContentToExchangeList.Find(x => OriginalContent.Contains(x));
                        string RequiredKeyInstance = RequiredKeyList.Find(x => OriginalContent.Contains(x));

                        if (RequiredKeyInstance != null)
                        {
                            if (ContentToExchangeInstance != string.Empty && ContentToExchangeInstance != null && OriginalContent != string.Empty && OriginalContent != null)
                            {
                                //ContentTrimToEnd
                                if (Algorithm == Algorhithms.GetValue(1).ToString())
                                {
                                    OriginalContent = ContentTrimToEnd(OriginalContent, ContentToExchangeInstance);
                                    if (OriginalContent != string.Empty && OriginalContent != null)
                                        System.Windows.Forms.Clipboard.SetText(OriginalContent);
                                    else
                                        System.Windows.Forms.Clipboard.Clear();
                                }

                                //ContentReplace
                                else if (Algorithm == Algorhithms.GetValue(2).ToString())
                                {
                                    OriginalContent = ContentReplace(OriginalContent, ContentToExchangeInstance, ContentToBeExchangedWith);
                                    if (OriginalContent != string.Empty && OriginalContent != null)
                                        System.Windows.Forms.Clipboard.SetText(OriginalContent);
                                    else
                                        System.Windows.Forms.Clipboard.Clear();
                                }
                            }
                        }
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }


        //FORM VARIABLES
        public static string[] Algorhithms = new string[] { "", "ContentTrimToEnd", "ContentReplace" };

        private void Form1_Load(object sender, EventArgs e)
        {
            _ClipboardViewerNext = SetClipboardViewer(this.Handle);
            comboBox1.Items.AddRange(Algorhithms);
            comboBox2.Items.AddRange(Algorhithms);
            comboBox3.Items.AddRange(Algorhithms);
            comboBox4.Items.AddRange(Algorhithms);
            comboBox5.Items.AddRange(Algorhithms);
            comboBox6.Items.AddRange(Algorhithms);
            comboBox7.Items.AddRange(Algorhithms);
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

    }
}
