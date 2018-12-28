using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SecuritySystem;
using Microsoft.Win32;
using SecuritySstem.Object;
using System.Diagnostics;
using System.Threading;
using DevExpress.XtraCharts;
using DevExpress.XtraTreeList.Nodes;

namespace SecuritySstem
{
    public partial class FrmMain : Form
    {
        private int sp_Start = -1;

        private SerialPortHelper serialPortHelper = null;

        private DataHandler dataHandler = null;

        private int delay = 10;

        public static int phaseIndex = 1;

        private bool startPointSelected = false;

        private bool bShowMessage = false;

        public FrmMain()
        {
            InitializeComponent();

            serialPortHelper = new SerialPortHelper();
            dataHandler = new DataHandler(serialPortHelper);

            //this.Font = new System.Drawing.Font("宋体", 12, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));  
        }

        private void InitLocation()
        {
            int sumHeight = groupBox1.Height + groupBox2.Height + groupBox3.Height;
            int sumWidth = groupBox2.Width + btnSave.Width + 30;
            //MessageBox.Show(tabSystem.SelectedTabPage.Width.ToString() + " " + sumWidth.ToString());
            groupBox2.Left = (tabSystem.SelectedTabPage.Width - sumWidth) / 2;
            groupBox1.Left = groupBox2.Left;
            groupBox3.Left = groupBox1.Left;
            groupBox12.Left = groupBox2.Right - groupBox12.Width;



            groupBox1.Top = (tabSystem.SelectedTabPage.Height - sumHeight) / 4;
            groupBox12.Top = groupBox1.Top;
            groupBox2.Top = groupBox1.Bottom + (tabSystem.SelectedTabPage.Height - sumHeight) / 4;
            groupBox3.Top = groupBox2.Bottom + (tabSystem.SelectedTabPage.Height - sumHeight) / 4;


            //MessageBox.Show(groupBox2.Location.ToString());
            //btnSave.Left = (int)((xtraTabPage1.Width - btnSave.Width) / 2);
            //btnSave.Top = groupBox3.Bottom + 10;

            label77.Left = textBox30.Left - label77.Width - 2;
            label1.Left = dtpSystem.Left - label1.Width - 2;

            label2.Left = numericUpDown1.Left - label2.Width - 2;
            label4.Left = comboBox16.Left - label4.Width - 2;
            label5.Left = comboBox1.Left - label5.Width - 2;
            label6.Left = comboBox2.Left - label6.Width - 2;

            label7.Left = numericUpDown2.Left - label7.Width - 2;
            label8.Left = comboBox3.Left - label8.Width - 2;
            label9.Left = comboBox4.Left - label9.Width - 2;
            label10.Left = comboBox5.Left - label10.Width - 2;

            label60.Left = comboBox17.Left - label60.Width - 2;
            label3.Left = comboBox23.Left - label3.Width - 2;
            label50.Left = comboBox24.Left - label50.Width - 2;

            label59.Left = comboBox20.Left - label59.Width - 2;
            label62.Left = comboBox26.Left - label62.Width - 2;
            label61.Left = comboBox25.Left - label61.Width - 2;

            label58.Left = comboBox22.Left - label58.Width - 2;
            label70.Left = comboBox28.Left - label70.Width - 2;
            label63.Left = comboBox27.Left - label63.Width - 2;

            btnSave.Left = groupBox3.Right + 30;
            btnQueryAll1.Left = btnSave.Left;
            btnClearAll1.Left = btnSave.Left;
            btnSave.Top = groupBox3.Bottom - btnSave.Height;
            btnQueryAll1.Top = btnSave.Top - btnQueryAll1.Height - 10;
            btnClearAll1.Top = btnQueryAll1.Top - btnClearAll1.Height - 10;

            //groupBox5.Left = (int)((xtraTabPage2.Width - groupBox4.Width) / 2);
            //groupBox4.Left = groupBox5.Left;
            //groupBox6.Left = groupBox5.Left;
            //groupBox7.Left = groupBox6.Right + 7;

            //sumHeight = groupBox4.Height + groupBox5.Height + groupBox6.Height + 60;
            //groupBox6.Top = (int)((xtraTabPage2.Height - sumHeight) / 2)-10;
            //groupBox7.Top = groupBox6.Top;
            //groupBox5.Top = groupBox6.Bottom + 30;
            //groupBox4.Top = groupBox5.Bottom + 30;

            //btnQueryAll.Left = groupBox4.Right + 50;
            //btnClearAll.Left = btnQueryAll.Left;
            //btnSaveParam.Left = btnQueryAll.Left;

            //btnSaveParam.Top = groupBox4.Bottom - btnQueryAll.Height;
            //btnQueryAll.Top = btnSaveParam.Top - btnQueryAll.Height-10;
            //btnClearAll.Top = btnQueryAll.Top - btnClearAll.Height - 10;
            // MessageBox.Show(tabSystem.SelectedTabPage.Width.ToString() + " " + tabSystem.SelectedTabPage.Height.ToString());

            groupBox10.Left = 5;
            groupBox10.Top = 5;
            groupBox10.Width = tabSystem.SelectedTabPage.Width - 10;
            groupBox10.Height = (int)((tabSystem.SelectedTabPage.Height - 10) * 0.32);


            groupBox8.Left = 5;
            groupBox8.Top = groupBox10.Bottom + 5;
            groupBox8.Width = (tabSystem.SelectedTabPage.Width - 15) / 2;
            groupBox8.Height = (int)((tabSystem.SelectedTabPage.Height - 10) * 0.68);

            groupBox9.Left = groupBox8.Right + 5;
            groupBox9.Top = groupBox10.Bottom + 5;
            groupBox9.Width = groupBox8.Width;
            groupBox9.Height = (int)((groupBox8.Height - 5) * 0.53);

            groupBox11.Left = groupBox9.Left;
            groupBox11.Top = groupBox9.Bottom + 5;
            groupBox11.Width = groupBox9.Width;
            groupBox11.Height = (int)((groupBox8.Height - 5) * 0.47);

            chartChannel.Top = 15;
            chartChannel.Left = 5;
            chartChannel.Width = groupBox10.Width - comboBox14.Width - 25;
            chartChannel.Height = groupBox10.Height - 20;


            label55.Left = chartChannel.Right + 10;
            comboBox14.Left = label55.Left;
            btnSignData.Left = comboBox14.Left;
          
            label55.Top = chartChannel.Top;
            comboBox14.Top = label55.Bottom + 5;
            btnSignData.Top = comboBox14.Bottom + 5;
            

            chartSign.Top = 15;
            chartSign.Left = 5;
            chartSign.Width = groupBox8.Width - btnSignStrength.Width - 25;
            chartSign.Height = groupBox8.Height - 20;

            btnSignStrength.Left = chartSign.Right + 10;
            btnSignStrength.Top = chartSign.Top;
            btnCloseSignStrength.Left = btnSignStrength.Left;
            btnCloseSignStrength.Top = btnSignStrength.Bottom + 5;

            int height_Interval = 5;
            sumHeight = treeList1.Height + treeList3.Height + btnPhase.Height;
            if (sumHeight + 35 <= groupBox9.Height)
            {
                height_Interval = 10;
            }
            treeList1.Top = (groupBox9.Height - sumHeight - 10) / 2 >= 15 ? (groupBox9.Height - sumHeight - 10) / 2 : 15;
            treeList1.Left = 10;
            treeList1.Width = groupBox9.Width - 20;
            // treeList1.Height = groupBox9.Height - 20;


            treeList3.Top = treeList1.Bottom + height_Interval;
            treeList3.Left = treeList1.Left;
            treeList3.Width = treeList1.Width;
            //treeList2.Height = treeList1.Height;

            btnPhase.Left = (groupBox9.Width - btnPhase.Width) / 2;
            btnPhase.Top = treeList3.Bottom + height_Interval;
 
            sumHeight = label56.Height + trackBarControl1.Height + btnRigth.Height;

            label56.Top = (groupBox11.Height - sumHeight) / 4 >= 15 ? (groupBox11.Height - sumHeight) / 4 : 15;
            label56.Left = (groupBox11.Width - label56.Width) / 2;

            trackBarControl1.Top = label56.Bottom + 10;
            trackBarControl1.Left = 10;
            trackBarControl1.Width = groupBox11.Width - 20;

            btnLeft.Left = 10;
            btnLeft.Top = trackBarControl1.Bottom + 10;
             

            btnRigth.Left = trackBarControl1.Right - btnRigth.Width;
            btnRigth.Top = btnLeft.Top;

            btnSetPhase.Left = (groupBox11.Width - btnSetPhase.Width) / 2;
            btnSetPhase.Top = btnLeft.Top;



            btnClearAlarm.Top = tabSystem.SelectedTabPage.Height - btnClearAlarm.Height - 15;
            btnAlarm.Top = btnClearAlarm.Top;
            btnSaveAlarm.Top = btnClearAlarm.Top;

            btnClearAlarm.Left = 15;
            btnAlarm.Left = (tabSystem.SelectedTabPage.Width - (btnAlarm.Width * 2 + 10)) / 2;
            btnSaveAlarm.Left = btnAlarm.Right + 10;


            treeList2.Height = tabSystem.SelectedTabPage.Height - btnAlarm.Height - 30;

            sumWidth = groupBox13.Width + btnClearAll2.Width + 30;
            sumHeight = groupBox13.Height + groupBox14.Height + groupBox15.Height;

            groupBox13.Left = (tabSystem.SelectedTabPage.Width - sumWidth) / 2;
            groupBox13.Top = (tabSystem.SelectedTabPage.Height - sumHeight) / 4;

            groupBox14.Left = groupBox13.Left;
            groupBox14.Top = groupBox13.Bottom + (tabSystem.SelectedTabPage.Height - sumHeight) / 4;

            groupBox15.Left = groupBox13.Left;
            groupBox15.Top = groupBox14.Bottom + (tabSystem.SelectedTabPage.Height - sumHeight) / 4;


            btnClearAll2.Left = groupBox15.Right + 30;
            btnQueryAll2.Left = btnClearAll2.Left;
            btnClearAll2.Top = groupBox15.Bottom - btnSave.Height;
            btnQueryAll2.Top = btnClearAll2.Top - btnQueryAll2.Height - 10;

            label78.Left = textBox31.Left - label78.Width - 2;
            label79.Left = textBox36.Left - label79.Width - 2;
            label80.Left = numericUpDown3.Left - label80.Width - 2;
        }

        private void EnableButton(bool flag)
        {
            btnSetDT.Enabled = flag;
            btnSetParam.Enabled = flag;
            btnSetCH1.Enabled = flag;
            btnSetCH2.Enabled = flag;
            btnSetCH3.Enabled = flag;
            btnQuerySystemDT.Enabled = flag;
            btnQueryVersion.Enabled = flag;
            btnQuerySystemParam.Enabled = flag;
            btnQueryCH1.Enabled = flag;
            btnQueryCH2.Enabled = flag;
            btnQueryCH3.Enabled = flag;
            btnPhase.Enabled = flag;
            btnSignStrength.Enabled = flag;
            btnCloseSignStrength.Enabled = flag;
            btnSignData.Enabled = flag;
            btnCloseSignData.Enabled = flag;
            btnAlarm.Enabled = flag;
            btnSave.Enabled = flag;
            btnQueryAll.Enabled = flag;
            btnClearAll.Enabled = flag;
            btnLeft.Enabled = flag;
            btnRigth.Enabled = flag;
            btnSetPhase.Enabled = flag;
            //btnSaveAlarm.Enabled = flag;
            btnSaveParam.Enabled = flag;
            btnQueryAll1.Enabled = flag;
            btnClearAll1.Enabled = flag;

            trackBarControl1.Enabled = flag;


            btnQueryCheck.Enabled = flag;
            btnSetInterval.Enabled = flag;
            btnSetRandom.Enabled = flag;
            btnSetMidu.Enabled = flag;
            btnSetTongbu.Enabled = flag;
            btnSetNoise.Enabled = flag;
            btnSetXinhao.Enabled = flag;
            btnSetGongpin.Enabled = flag;
            btnQueryAll2.Enabled = flag;
            btnClearAll2.Enabled = flag;
        }

        private void InitComm()
        {
            cboPortName.Items.Clear();

            RegistryKey keyCom = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm");
            if (keyCom != null)
            {
                string[] sSubKeys = keyCom.GetValueNames();
                foreach (string sName in sSubKeys)
                {
                    string sValue = (string)keyCom.GetValue(sName);
                    cboPortName.Items.Add(sValue);
                }
               
            }
        }

        private void InitData()
        {
            btnOpen.Enabled = true;
            btnClose.Enabled = false;

            EnableButton(false);

            InitComm();

            if (cboPortName.Items.Count > 0)
            {
                cboPortName.Text = ClsIniOperation.ReadIni("SerialPort", "PortName");
                if (string.IsNullOrEmpty(cboPortName.Text))
                {
                    cboPortName.SelectedIndex = 0;
                }
            }
            else
            {
                cboPortName.Text = string.Empty;
            }

            dtpSystem.Value = DateTime.Now;//DateTime.Parse(ClsIniOperation.ReadIni("SystemDT", "SystemDT"));

            //numericUpDown1.Value = -1;//ClsIniOperation.ReadIni("SystemParam", "Phase");
            ((UpDownBase)numericUpDown1).Text = "";
            //numericUpDown1.Value = 58000;//int.Parse(ClsIniOperation.ReadIni("SystemParam", "Frequency"));
            comboBox16.Items.Add("57.8K");
            comboBox16.Items.Add("58K");
            comboBox16.Items.Add("58.2K");
            comboBox16.Items.Add("58.4K");
            comboBox16.Items.Add("58.6K");
            //comboBox16.SelectedIndex = 1;

            comboBox1.Items.Add("模式1");
            comboBox1.Items.Add("模式2");
            comboBox1.Items.Add("模式3");
            comboBox1.Items.Add("模式4");
            comboBox1.Items.Add("模式5");
            //comboBox1.SelectedIndex = 0;//int.Parse(ClsIniOperation.ReadIni("SystemParam", "SendInterval"));

            comboBox2.Items.Add("L");
            comboBox2.Items.Add("M");
            comboBox2.Items.Add("H");
            //comboBox2.SelectedIndex = 2;//int.Parse(ClsIniOperation.ReadIni("SystemParam", "SendStrength"));

            //numericUpDown2.Value = 0;// int.Parse(ClsIniOperation.ReadIni("SystemParam", "RevDelay"));
            ((UpDownBase)numericUpDown2).Text = "";

            comboBox3.Items.Add("上升沿");
            comboBox3.Items.Add("下降沿");
            //comboBox3.SelectedIndex = 0;// int.Parse(ClsIniOperation.ReadIni("SystemParam", "ChannelMode"));

            comboBox4.Items.Add("OFF");
            comboBox4.Items.Add("ON");
            //comboBox4.SelectedIndex = 1;//int.Parse(ClsIniOperation.ReadIni("SystemParam", "InterferenceDetection"));

            comboBox5.Items.Add("OFF");
            comboBox5.Items.Add("小榔头");
            comboBox5.Items.Add("中榔头");
            comboBox5.Items.Add("大榔头");
            //comboBox5.SelectedIndex = 1;//int.Parse(ClsIniOperation.ReadIni("SystemParam", "SignDetection"));

            comboBox6.Items.Add("OFF");
            comboBox6.Items.Add("ON");
            //comboBox6.SelectedIndex = 0;// int.Parse(ClsIniOperation.ReadIni("SystemParam", "DecodingFilterA"));

            comboBox7.Items.Add("OFF");
            comboBox7.Items.Add("ON");
            //comboBox7.SelectedIndex = 0;// int.Parse(ClsIniOperation.ReadIni("SystemParam", "DecodingFilterB"));

            comboBox8.Items.Add("OFF");
            comboBox8.Items.Add("ON");
            //comboBox8.SelectedIndex = 0;// int.Parse(ClsIniOperation.ReadIni("SystemParam", "DecodingFilterC"));

            comboBox9.Items.Add("OFF");
            comboBox9.Items.Add("ON");
            //comboBox9.SelectedIndex = 0;// .Parse(ClsIniOperation.ReadIni("SystemParam", "DecodingFilterD"));

            for (int i = 0; i <= 5; i++)
            {
                comboBox17.Items.Add(i.ToString());
                comboBox20.Items.Add(i.ToString());
                comboBox22.Items.Add(i.ToString());
            }
            //comboBox17.SelectedIndex = 0;
            //comboBox20.SelectedIndex = 0;
            //comboBox22.SelectedIndex = 0;
            for (int i = 1; i <= 10; i++)
            {
                comboBox18.Items.Add(i.ToString());
                comboBox19.Items.Add(i.ToString());
                comboBox21.Items.Add(i.ToString());
            }
            //comboBox18.SelectedIndex = 0;
            //comboBox19.SelectedIndex = 0;
            //comboBox21.SelectedIndex = 0;

            comboBox23.Items.Add("ON");
            comboBox23.Items.Add("OFF");
            comboBox24.Items.Add("ON");
            comboBox24.Items.Add("OFF");
            comboBox25.Items.Add("ON");
            comboBox25.Items.Add("OFF");
            comboBox26.Items.Add("ON");
            comboBox26.Items.Add("OFF");
            comboBox27.Items.Add("ON");
            comboBox27.Items.Add("OFF");
            comboBox28.Items.Add("ON");
            comboBox28.Items.Add("OFF");
            //comboBox23.SelectedIndex = 0;
            //comboBox24.SelectedIndex = 0;
            //comboBox25.SelectedIndex = 0;
            //comboBox26.SelectedIndex = 0;
            //comboBox27.SelectedIndex = 0;
            //comboBox28.SelectedIndex = 0;

            checkBox1.Checked = true;//ClsIniOperation.ReadIni("CH1", "Sign1") == "1" ? true : false;
            checkBox2.Checked = false; //ClsIniOperation.ReadIni("CH1", "Sign2") == "1" ? true : false;
            checkBox3.Checked = false; //ClsIniOperation.ReadIni("CH1", "Sign3") == "1" ? true : false;
            comboBox10.Items.Add("ON");
            comboBox10.Items.Add("OFF");
            //comboBox10.SelectedIndex = 1;//int.Parse(ClsIniOperation.ReadIni("CH1", "Buzze"));

            
            checkBox6.Checked = false;// ClsIniOperation.ReadIni("CH2", "Sign1") == "1" ? true : false;
            checkBox5.Checked = true; //ClsIniOperation.ReadIni("CH2", "Sign2") == "1" ? true : false;
            checkBox4.Checked = false; //ClsIniOperation.ReadIni("CH2", "Sign3") == "1" ? true : false;
            comboBox11.Items.Add("ON");
            comboBox11.Items.Add("OFF");
            //comboBox11.SelectedIndex = 1;//int.Parse(ClsIniOperation.ReadIni("CH2", "Buzze"));

          
            checkBox9.Checked = false; //ClsIniOperation.ReadIni("CH3", "Sign1") == "1" ? true : false;
            checkBox8.Checked = false;//ClsIniOperation.ReadIni("CH3", "Sign2") == "1" ? true : false;
            checkBox7.Checked = true; //ClsIniOperation.ReadIni("CH3", "Sign3") == "1" ? true : false;
            comboBox12.Items.Add("ON");
            comboBox12.Items.Add("OFF");
            //comboBox12.SelectedIndex = 1;//int.Parse(ClsIniOperation.ReadIni("CH3", "Buzze"));

            comboBox13.Items.Add("CH1");
            comboBox13.Items.Add("CH2");
            comboBox13.Items.Add("CH3");
            //comboBox13.SelectedIndex = 0;//int.Parse(ClsIniOperation.ReadIni("Phase", "Channel"));

            comboBox14.Items.Add("CH1");
            comboBox14.Items.Add("CH2");
            comboBox14.Items.Add("CH3");
            comboBox14.SelectedIndex = 0;//int.Parse(ClsIniOperation.ReadIni("Sign", "Channel"));

            chartSign.Series.Clear();
            DevExpress.XtraCharts.Series barSeries1 = new DevExpress.XtraCharts.Series("噪声", DevExpress.XtraCharts.ViewType.Bar);
            DevExpress.XtraCharts.Series barSeries2 = new DevExpress.XtraCharts.Series("信号", DevExpress.XtraCharts.ViewType.Bar);
            barSeries1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            barSeries2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            chartSign.Series.Add(barSeries1);
            chartSign.Series.Add(barSeries2);
            chartSign.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.False;

            chartChannel.Series.Clear();
            DevExpress.XtraCharts.Series lineSeries1 = new DevExpress.XtraCharts.Series("本机相位", DevExpress.XtraCharts.ViewType.Line);
            DevExpress.XtraCharts.Series lineSeries2 = new DevExpress.XtraCharts.Series("周围环境数据", DevExpress.XtraCharts.ViewType.Line);
            DevExpress.XtraCharts.Series lineSeries3 = new DevExpress.XtraCharts.Series("", DevExpress.XtraCharts.ViewType.Line);
            DevExpress.XtraCharts.Series lineSeries4 = new DevExpress.XtraCharts.Series("", DevExpress.XtraCharts.ViewType.Line);
            DevExpress.XtraCharts.Series lineSeries5 = new DevExpress.XtraCharts.Series("", DevExpress.XtraCharts.ViewType.Line);

            lblX.Left = lblX.Left - 37;
            lblY.Left = lblX.Left;

            //((LineSeriesView)chartChannel.Series[2].View).LineMarkerOptions.Size = 1;
            // chartChannel.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.False;
            chartChannel.CrosshairOptions.ShowArgumentLine = false;
            lineSeries1.CrosshairLabelVisibility = DevExpress.Utils.DefaultBoolean.False;
            lineSeries2.CrosshairLabelVisibility = DevExpress.Utils.DefaultBoolean.False;
            lineSeries3.CrosshairLabelVisibility = DevExpress.Utils.DefaultBoolean.False;
            lineSeries4.CrosshairLabelVisibility = DevExpress.Utils.DefaultBoolean.False;
            lineSeries5.CrosshairLabelVisibility = DevExpress.Utils.DefaultBoolean.False;
       
            lineSeries1.View.Color = Color.Red;
            lineSeries2.View.Color = Color.Black;
            lineSeries3.View.Color = Color.Green;
            lineSeries4.View.Color = Color.Green;
            lineSeries5.View.Color = Color.Green;
       
            ((LineSeriesView)lineSeries3.View).LineStyle.Thickness =  2;
            ((LineSeriesView)lineSeries4.View).LineStyle.Thickness = 2;
            ((LineSeriesView)lineSeries5.View).LineStyle.Thickness = 2;

            ((LineSeriesView)lineSeries1.View).LineStyle.DashStyle = DashStyle.Dash;
            ((LineSeriesView)lineSeries4.View).LineStyle.DashStyle = DashStyle.Dash;
            ((LineSeriesView)lineSeries5.View).LineStyle.DashStyle = DashStyle.Dash;
            chartChannel.Series.Add(lineSeries1);
            chartChannel.Series.Add(lineSeries2);
            chartChannel.Series.Add(lineSeries3);
            chartChannel.Series.Add(lineSeries4);
            chartChannel.Series.Add(lineSeries5);

            ((LineSeriesView)chartChannel.Series[0].View).LineMarkerOptions.Size = 1;
            ((LineSeriesView)chartChannel.Series[1].View).LineMarkerOptions.Size = 1;
            ((LineSeriesView)chartChannel.Series[2].View).LineMarkerOptions.Size = 1;
            ((LineSeriesView)chartChannel.Series[3].View).LineMarkerOptions.Size = 1;
            ((LineSeriesView)chartChannel.Series[4].View).LineMarkerOptions.Size = 1;

            comboBox15.Items.Add("1");
            comboBox15.Items.Add("0.1");
            comboBox15.SelectedIndex = 0;

            //trackBarControl1.Properties.Minimum = 0;
            //trackBarControl1.Properties.Maximum = 3600;
            //for (int i = 0; i <= 18; i++)
            //{
            //    int lblValue = i * 200;
            //    int temp = i * 20;
            //    trackBarControl1.Properties.Labels.Add(new DevExpress.XtraEditors.Repository.TrackBarLabel(temp.ToString("0.0"), lblValue));
            //}

            checkBox19.Checked = true;

            comboBox29.Items.Add("正常模式");
            comboBox29.Items.Add("可调模式");
            comboBox29.Items.Add("YS0");
            comboBox29.Items.Add("YS1");
            comboBox29.Items.Add("YS2");
            comboBox29.Items.Add("YS3");
            comboBox29.Items.Add("YS4");
            comboBox29.Items.Add("YS5");
            comboBox29.Items.Add("YS6");
            comboBox29.Items.Add("YS7");
            comboBox29.Items.Add("YS8");

            comboBox30.Items.Add("H");
            comboBox30.Items.Add("M");
            comboBox30.Items.Add("L");
            //comboBox30.SelectedIndex = 0;

            comboBox31.Items.Add("ON");
            comboBox31.Items.Add("OFF");
            //comboBox31.SelectedIndex = 0;

            comboBox32.Items.Add("ON");
            comboBox32.Items.Add("OFF");
            //comboBox32.SelectedIndex = 0;

            comboBox33.Items.Add("ON");
            comboBox33.Items.Add("OFF");
            //comboBox33.SelectedIndex = 0;

            comboBox34.Items.Add("自动");
            comboBox34.Items.Add("50HZ");
            comboBox34.Items.Add("60HZ");
            //comboBox34.SelectedIndex = 0;
        }

        //private object obj1;
        //private byte orderType1;

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //string aa = "10 FF FE 0A 00 02 D0 07 01 01 00 09 1A 08 01 10 FF FE 0E 00 03 00 00 6F 00 E0 07 0A 1E 10 1E 00 BD 01";
            //string[] bb = aa.Split(' ');
            //List<byte> lstRev = new List<byte>() ;
            //for (int i = 0; i < bb.Length;i++ )
            //    lstRev.Add(Convert.ToByte("0x" + bb[i], 16));
            // List<byte> lstRev = new List<byte>();
            // lstRev.Add(0x10);
            // lstRev.Add(0xFF);
            // lstRev.Add(0xFE);

            // lstRev.Add(0x7);
            // lstRev.Add(0x0);

            //lstRev.Add(0x7);
            //lstRev.Add((byte)0xFF);
            //lstRev.Add((byte)0x02);
            //lstRev.Add((byte)0x01);
            //lstRev.Add((byte)0x64);

            //lstRev.Add(0xe0);
            //lstRev.Add((byte)7);

            //lstRev.Add((byte)10);
            //lstRev.Add((byte)30);
            //lstRev.Add((byte)20);
            //lstRev.Add((byte)04);
            //lstRev.Add((byte)30);

            //Random rn = new Random();
            //lstRev.Add((byte)rn.Next(0, 255));
            //lstRev.Add((byte)rn.Next(0, 255));
            //lstRev.Add((byte)rn.Next(0, 255));
            //lstRev.Add((byte)rn.Next(0, 255));
            //lstRev.Add((byte)rn.Next(0, 255));
            //lstRev.Add((byte)rn.Next(0, 255));
            //for (int i = 1; i <= 800; i++)
            //{
                //lstRev.Add((byte)(i));
                //lstRev.Add((byte)rn.Next(0, 255));
                //lstRev.Add((byte)16);
                //lstRev.Add((byte)10);
                //lstRev.Add((byte)30);
                //lstRev.Add((byte)18);
                //lstRev.Add((byte)15);
                //lstRev.Add((byte)14);

                //lstRev.Add((byte)1);
                //lstRev.Add((byte)2);
                //lstRev.Add((byte)3);
                //lstRev.Add((byte)4);
                //lstRev.Add((byte)5);
                //lstRev.Add((byte)6);
                //lstRev.Add((byte)7);
                //lstRev.Add((byte)8);
                //lstRev.Add((byte)i);
                //lstRev.Add((byte)rn.Next(0, 4));
                //lstRev.Add(0x16);
                //lstRev.Add(0x0A);
                //lstRev.Add(0x1E);
                //lstRev.Add(0x01);
                //lstRev.Add(0x03);
                //lstRev.Add(0x16);

            //for (int j = 9; j <= 16; j++)
            //{
            //    lstRev.Add((byte)(rn.Next(0, 255)));
            //}
            //    if ((i < 100) || (i >= 200 && i < 300) || (i >= 400 && i < 500) || (i >= 600 && i < 700) || (i >= 700 && i < 800)
            //        || (i >= 800 && i < 900) || (i >= 1000 && i < 1100) || (i >= 1100 && i < 1200) || (i >= 1200 && i < 1300)
            //        || (i >= 1400 && i < 1500) || (i >= 1500 && i < 1600))
            //    {

            //        lstRev.Add((byte)(rn.Next(0, 255)));
            //        lstRev.Add( 0x80);
            //    }
            //    else if ((i >= 100 && i < 200) || (i >= 300 && i < 400) || (i >= 500 && i <= 600) || (i >= 700 && i <= 800)
            //        || (i >= 900 && i <= 1000) || (i >= 1100 && i <= 1200) || (i >= 1300 && i <= 1400) || (i >= 1500 && i <= 1600))
            //    {


            //        lstRev.Add((byte)(rn.Next(0, 255)));
            //        lstRev.Add( 0x0);
            //    }

            //}

            //byte[] bytcheck = GetDataCheck(lstRev.GetRange(3, lstRev.Count - 3));
            //lstRev.Add(bytcheck[0]);
            //lstRev.Add(bytcheck[1]);
            //obj1 = dataHandler.GetDataValue(lstRev);
            //orderType1 = 0x10;
          

            //serialPortHelper.LstReciveByte = lstRev;
            int width = int.Parse(ClsIniOperation.ReadIni("Window", "Width"));
            int height = int.Parse(ClsIniOperation.ReadIni("Window", "Height"));

            //this.Width = width;
            //this.Height = height;
            this.Size = new System.Drawing.Size(width, height);

            InitLocation();

            InitData();
  
            Thread thd = new Thread(ShowData);
            //thd.Priority = ThreadPriority.Highest;
            thd.IsBackground = true;
            thd.Start();

            //Thread thd1 = new Thread(test);
            //thd1.IsBackground = true;
            //thd1.Start();
           
        }


        private byte[] GetDataCheck(List<byte> checkList)
        {
            byte[] bytResult = new byte[2];

            int sumCheck = 0;
            for (int i = 0; i < checkList.Count; i++)
            {
                sumCheck += checkList[i];
            }

            string temp = sumCheck.ToString("X4");

            bytResult[0] = Convert.ToByte("0x" + temp.Substring(temp.Length - 2, 2), 16);
            bytResult[1] = Convert.ToByte("0x" + temp.Substring(temp.Length - 4, 2), 16);

            return bytResult;
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                return;
            }

            InitLocation();

            //lblX.Left =  chartChannel.Left + chartChannel.Width - lblX.Width - 10;
            //lblY.Left = lblX.Left;
            //lblX.Top = chartChannel.Top + 60;
            //lblY.Top = lblX.Bottom + 5;
            //lblX.Text = "X轴：193";
            //lblY.Text = "X轴：170";
            //lblX.Visible = true;
            //lblY.Visible = true;

            ClsIniOperation.WriteIni("Window", "Width", this.Width.ToString());
            ClsIniOperation.WriteIni("Window", "Height", this.Height.ToString());
        }

        public void WindowResize(int width, int height)
        {
            this.Size = new Size(width, height);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
 
            serialPortHelper.PortName = cboPortName.Text;

            if (serialPortHelper.Open())
            {
                btnOpen.Enabled = false;
                btnClose.Enabled = true;

                EnableButton(true);

                ClsIniOperation.WriteIni("SerialPort", "PortName", cboPortName.Text);
            }
            else
            {
                MessageBox.Show("串口打开失败");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!serialPortHelper.Close())
            {
                MessageBox.Show("串口关闭失败！");
            }
 
            btnOpen.Enabled = true;
            btnClose.Enabled = false;

            EnableButton(false);
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSerialData.Clear();
        }

        //private object obj1;
        //private byte orderType1;
        private bool bStop = false;

        private string returnValue = string.Empty;

        private void ShowData()
        {
            //string strShow = string.Empty;
            //int startIndex = 0;
            //int endIndex = 0;

            while (true)
            {
                //object obj = obj1;
                //byte orderType = orderType1;
   
                //显示通讯数据
                //if (bStop)
                //{
                //    Application.DoEvents();
                //    continue;
                //}

                //if (dataHandler.IsNormalFrame)
                {
                    object obj = dataHandler.DataValue;

                    byte orderType = dataHandler.ReturnType;  

                    if (obj != null)
                    {
                        this.Invoke((Action)delegate
                        {
                            //strShow = string.Empty;
                            //strShow = DateTime.Now.ToString("HH:mm:ss") + " <-- ";

                            //for (int i = 0; i < dataHandler.LstRead.Count; i++)
                            //{
                            //    strShow += dataHandler.LstRead[i].ToString("X2") + " ";
                            //}
                            //strShow += "\r\n";

                            //startIndex = txtSerialData.TextLength;
                            //txtSerialData.AppendText(strShow);
                            //endIndex = txtSerialData.TextLength;
                            //txtSerialData.Select(startIndex, endIndex - startIndex);
                            //txtSerialData.SelectionColor = Color.Red;

                            if (obj is string)
                            {
                                if (bShowMessage)
                                {
                                    MessageBox.Show(obj.ToString());
                                }
                                //txtSerialData.AppendText(obj.ToString() + "\r\n");
                                //serialPortHelper.ClearResult();
                                //returnValue = obj.ToString();
                            }
                            else if (obj is CheckCode)
                            {
                                CheckCode checkCode=obj as CheckCode;
                                textBox31.Text = checkCode.Data1.ToString("X2");
                                textBox32.Text = checkCode.Data2.ToString("X2");
                                textBox33.Text = checkCode.Data3.ToString("X2");
                                textBox34.Text = checkCode.Data4.ToString("X2");  
                            }
                            else if (obj is RandomModel)
                            {
                                RandomModel randomModel=obj as RandomModel;
                                comboBox29.SelectedIndex = randomModel.ModelType;
                            }
                            else if (obj is MiduParam)
                            {
                                MiduParam param = obj as MiduParam;
                                if (param.Data == 5)
                                {
                                    comboBox30.SelectedIndex = 0;
                                }
                                else if (param.Data == 4)
                                {
                                    comboBox30.SelectedIndex = 1;
                                }
                                else if (param.Data == 3)
                                {
                                    comboBox30.SelectedIndex = 2;
                                }
                            }
                            else if (obj is TongbuParam)
                            {
                                TongbuParam param = obj as TongbuParam;
                                comboBox31.SelectedIndex = param.Data == 1 ? 0 : 1;
                            }
                            else if (obj is NoiseParam)
                            {
                                NoiseParam param = obj as NoiseParam;
                                comboBox32.SelectedIndex = param.Data == 1 ? 0 : 1;
                            }
                            else if (obj is XinhaoParam)
                            {
                                XinhaoParam param = obj as XinhaoParam;
                                comboBox33.SelectedIndex = param.Data == 1 ? 0 : 1;
                            }
                            else if (obj is InterverParam)
                            {
                                InterverParam param = obj as InterverParam;
                                ///numericUpDown3.Value = param.Data;
                                ((UpDownBase)numericUpDown3).Text = param.Data.ToString();
                            }
                            else if (obj is GongpinParam)
                            {
                                GongpinParam param = obj as GongpinParam;
                                comboBox34.SelectedIndex = param.Data;
                            }
                            else if (obj is SystemDT)
                            {
                                SystemDT systemDT = (SystemDT)obj;
                                textBox3.Text = systemDT.Year + "-" + systemDT.Month.ToString("00") + "-" + systemDT.Day.ToString("00") + " " + systemDT.Hour.ToString("00") + ":" + systemDT.Minute.ToString("00") + ":" + systemDT.Second.ToString("00");
                                dtpSystem.CustomFormat = "yyyy-MM-dd HH:mm:ss";
                                dtpSystem.Text = systemDT.Year + "-" + systemDT.Month.ToString("00") + "-" + systemDT.Day.ToString("00") + " " + systemDT.Hour.ToString("00") + ":" + systemDT.Minute.ToString("00") + ":" + systemDT.Second.ToString("00");
                                //serialPortHelper.ClearResult();
                            }
                            else if (obj is VersionInfo)
                            {
                                VersionInfo versionInfo = (VersionInfo)obj;
                                SystemDT systemDT = versionInfo.CompileDT;
                                string compileDT = systemDT.Year + "-" + systemDT.Month.ToString("00") + "-" + systemDT.Day.ToString("00") + " " + systemDT.Hour.ToString("00") + ":" + systemDT.Minute.ToString("00") + ":" + systemDT.Second.ToString("00");
                                textBox21.Text = versionInfo.SoftVersion + " 编译时间:" + compileDT;
                                //serialPortHelper.ClearResult();
                                textBox30.Text = versionInfo.SoftVersion + " 编译时间:" + compileDT;
                            }
                            else if (obj is SystemParam)
                            {
                                SystemParam systemParam = (SystemParam)obj;
                                textBox2.Text = systemParam.Phase.ToString();
                                ((UpDownBase)numericUpDown1).Text = systemParam.Phase.ToString();

                                if (systemParam.Frequency == 0)
                                {
                                    textBox8.Text = "57.8K";
                                    comboBox16.Text = "57.8K";
                                }
                                else if (systemParam.Frequency == 1)
                                {
                                    textBox8.Text = "58K";
                                    comboBox16.Text = "58K";
                                }
                                else if (systemParam.Frequency == 2)
                                {
                                    textBox8.Text = "58.2K";
                                    comboBox16.Text = "58.2K";
                                }
                                else if (systemParam.Frequency == 3)
                                {
                                    textBox8.Text = "58.4K";
                                    comboBox16.Text = "58.4K";
                                }
                                else
                                {
                                    textBox8.Text = "58.6K";
                                    comboBox16.Text = "58.6K";
                                }

                                //textBox11.Text = systemParam.SendInterval == 0 ? "80ms" : "120ms";
                                if (systemParam.SendInterval == 0)
                                {
                                    textBox11.Text = "模式1";
                                    comboBox1.Text = "模式1";
                                }
                                else if (systemParam.SendInterval == 1)
                                {
                                    textBox11.Text = "模式2";
                                    comboBox1.Text = "模式2";
                                }
                                else if (systemParam.SendInterval == 2)
                                {
                                    textBox11.Text = "模式3";
                                    comboBox1.Text = "模式3";
                                }
                                else if (systemParam.SendInterval == 3)
                                {
                                    textBox11.Text = "模式4";
                                    comboBox1.Text = "模式4";
                                }
                                else
                                {
                                    textBox11.Text = "模式5";
                                    comboBox1.Text = "模式5";
                                }

                                if (systemParam.SendStrength == 0)
                                {
                                    textBox14.Text = "L";
                                    comboBox2.Text = "L";
                                }
                                else if (systemParam.SendStrength == 1)
                                {
                                    textBox14.Text = "M";
                                    comboBox2.Text = "M";
                                }
                                else
                                {
                                    textBox14.Text = "H";
                                    comboBox2.Text = "H";
                                }

                                textBox4.Text = systemParam.RevDelay.ToString();
                                ((UpDownBase)numericUpDown2).Text = systemParam.RevDelay.ToString();

                                if (systemParam.ChannelMode == 0)
                                {
                                    textBox7.Text = "上升沿";
                                    comboBox3.Text = "上升沿";
                                }
                                else
                                {
                                    textBox7.Text = "下降沿";
                                    comboBox3.Text = "下降沿";
                                }

                                textBox10.Text = systemParam.InterferenceDetection == 0 ? "OFF" : "ON";
                                comboBox4.Text = systemParam.InterferenceDetection == 0 ? "OFF" : "ON";

                                if (systemParam.SignDetection == 0)
                                {
                                    textBox13.Text = "OFF";
                                    comboBox5.Text = "OFF";
                                }
                                else if (systemParam.SignDetection == 1)
                                {
                                    textBox13.Text = "小榔头";
                                    comboBox5.Text = "小榔头";
                                }
                                else if (systemParam.SignDetection == 2)
                                {
                                    textBox13.Text = "中榔头";
                                    comboBox5.Text = "中榔头";
                                }
                                else
                                {
                                    textBox13.Text = "大榔头";
                                    comboBox5.Text = "大榔头";
                                }

                                textBox5.Text = systemParam.DecodingFilterA == 0 ? "OFF" : "ON";
                                textBox6.Text = systemParam.DecodingFilterB == 0 ? "OFF" : "ON";
                                textBox9.Text = systemParam.DecodingFilterC == 0 ? "OFF" : "ON";
                                textBox12.Text = systemParam.DecodingFilterD == 0 ? "OFF" : "ON";

                                comboBox6.Text = systemParam.DecodingFilterA == 0 ? "OFF" : "ON";
                                comboBox7.Text = systemParam.DecodingFilterB == 0 ? "OFF" : "ON";
                                comboBox8.Text = systemParam.DecodingFilterC == 0 ? "OFF" : "ON";
                                comboBox9.Text = systemParam.DecodingFilterD == 0 ? "OFF" : "ON";
                                //serialPortHelper.ClearResult();
                            }
                            else if (obj is ChannelParam)
                            {
                                ChannelParam channelParam = (ChannelParam)obj;
                                if (orderType == 0x07)
                                {
                                    textBox24.Text = channelParam.AlarmThreshold.ToString();
                                    textBox15.Text = channelParam.ChannelGain.ToString();
                                    ////checkBox18.Checked = channelParam.Sign1 == 0 ? false : true;
                                    ////checkBox17.Checked = channelParam.Sign2 == 0 ? false : true;
                                    ////checkBox16.Checked = channelParam.Sign3 == 0 ? false : true;
                                    textBox1.Text = channelParam.TX == 0 ? "OFF" : "ON";
                                    textBox25.Text = channelParam.RX == 0 ? "OFF" : "ON";
                                    textBox18.Text = channelParam.Buzzer == 0 ? "ON" : "OFF";

                                    comboBox17.Text = channelParam.AlarmThreshold.ToString();
                                    comboBox23.Text = channelParam.TX == 0 ? "OFF" : "ON";
                                    comboBox24.Text = channelParam.RX == 0 ? "OFF" : "ON";
                                    comboBox10.Text = channelParam.Buzzer == 0 ? "ON" : "OFF";
                                }
                                else if (orderType == 0x09)
                                {
                                    textBox23.Text = channelParam.AlarmThreshold.ToString();
                                    textBox16.Text = channelParam.ChannelGain.ToString();
                                    //checkBox15.Checked = channelParam.Sign1 == 0 ? false : true;
                                    //checkBox14.Checked = channelParam.Sign2 == 0 ? false : true;
                                    //checkBox13.Checked = channelParam.Sign3 == 0 ? false : true;
                                    textBox27.Text = channelParam.TX == 0 ? "OFF" : "ON";
                                    textBox26.Text = channelParam.RX == 0 ? "OFF" : "ON";
                                    textBox19.Text = channelParam.Buzzer == 0 ? "ON" : "OFF";

                                    comboBox20.Text = channelParam.AlarmThreshold.ToString();
                                    comboBox26.Text = channelParam.TX == 0 ? "OFF" : "ON";
                                    comboBox25.Text = channelParam.RX == 0 ? "OFF" : "ON";
                                    comboBox11.Text = channelParam.Buzzer == 0 ? "ON" : "OFF";
                                }
                                else if (orderType == 0x0B)
                                {
                                    textBox22.Text = channelParam.AlarmThreshold.ToString();
                                    textBox17.Text = channelParam.ChannelGain.ToString();
                                    //checkBox12.Checked = channelParam.Sign1 == 0 ? false : true;
                                    //checkBox11.Checked = channelParam.Sign2 == 0 ? false : true;
                                    //checkBox10.Checked = channelParam.Sign3 == 0 ? false : true;
                                    textBox29.Text = channelParam.TX == 0 ? "OFF" : "ON";
                                    textBox28.Text = channelParam.RX == 0 ? "OFF" : "ON";
                                    textBox20.Text = channelParam.Buzzer == 0 ? "ON" : "OFF";

                                    comboBox22.Text = channelParam.AlarmThreshold.ToString();
                                    comboBox28.Text = channelParam.TX == 0 ? "OFF" : "ON";
                                    comboBox27.Text = channelParam.RX == 0 ? "OFF" : "ON";
                                    comboBox12.Text = channelParam.Buzzer == 0 ? "ON" : "OFF";
                                }
                                //serialPortHelper.ClearResult();
                            }
                            else if (obj is ChannelSignStrength)
                            {
                                chartSign.BeginInit();

                                chartSign.Series[0].Points.Clear();
                                chartSign.Series[1].Points.Clear();

                                DevExpress.XtraCharts.XYDiagram xyDiagram1 = (XYDiagram)this.chartSign.Diagram;
                                xyDiagram1.AxisX.Visible = true;

                                ChannelSignStrength css = (ChannelSignStrength)obj;

                                SeriesPoint point1 = new SeriesPoint("CH1", new double[] { css.Ch1Noise });
                                SeriesPoint point2 = new SeriesPoint("CH1", new double[] { css.Ch1Sign });

                                SeriesPoint point3 = new SeriesPoint("CH2", new double[] { css.Ch2Noise });
                                SeriesPoint point4 = new SeriesPoint("CH2", new double[] { css.Ch2Sign });

                                SeriesPoint point5 = new SeriesPoint("CH3", new double[] { css.Ch3Noise });
                                SeriesPoint point6 = new SeriesPoint("CH3", new double[] { css.Ch3Sign });

                                chartSign.Series[0].Points.Add(point1);
                                chartSign.Series[0].Points.Add(point3);
                                chartSign.Series[0].Points.Add(point5);

                                chartSign.Series[1].Points.Add(point2);
                                chartSign.Series[1].Points.Add(point4);
                                chartSign.Series[1].Points.Add(point6);
                                //serialPortHelper.ClearResult();
                                chartSign.EndInit();
                            }
                            else if (obj is List<string>)
                            {
                                treeList1.BeginUpdate();
                                treeList3.BeginUpdate();
                                treeList1.Nodes.Clear();
                                treeList3.Nodes.Clear();

                                List<string> lstPahase = (List<string>)obj;

                                if (lstPahase.Count == 16)
                                {
                                    TreeListNode node = treeList1.Nodes.Add(obj);

                                    node.SetValue(Col_Phase1.AbsoluteIndex, lstPahase[0]);
                                    node.SetValue(Col_Phase2.AbsoluteIndex, lstPahase[1]);
                                    node.SetValue(Col_Phase3.AbsoluteIndex, lstPahase[2]);
                                    node.SetValue(Col_Phase4.AbsoluteIndex, lstPahase[3]);
                                    node.SetValue(Col_Phase5.AbsoluteIndex, lstPahase[4]);
                                    node.SetValue(Col_Phase6.AbsoluteIndex, lstPahase[5]);
                                    node.SetValue(Col_Phase7.AbsoluteIndex, lstPahase[6]);
                                    node.SetValue(Col_Phase8.AbsoluteIndex, lstPahase[7]);

                                    TreeListNode node1 = treeList3.Nodes.Add(obj);
                                    node1.SetValue(Col_Phase9.AbsoluteIndex, lstPahase[8]);
                                    node1.SetValue(Col_Phase10.AbsoluteIndex, lstPahase[9]);
                                    node1.SetValue(Col_Phase11.AbsoluteIndex, lstPahase[10]);
                                    node1.SetValue(Col_Phase12.AbsoluteIndex, lstPahase[11]);
                                    node1.SetValue(Col_Phase13.AbsoluteIndex, lstPahase[12]);
                                    node1.SetValue(Col_Phase14.AbsoluteIndex, lstPahase[13]);
                                    node1.SetValue(Col_Phase15.AbsoluteIndex, lstPahase[14]);
                                    node1.SetValue(Col_Phase16.AbsoluteIndex, lstPahase[15]);

                                }
                                treeList1.EndUpdate();
                                treeList3.EndUpdate();
                                //serialPortHelper.ClearResult();
                            }
                            else if (obj is UploadChannelSign)
                            {
                                chartChannel.BeginInit();


                                //chartChannel.Series[0].Points.Clear();
                                //chartChannel.Series[1].Points.Clear();
                                //chartChannel.Series[2].Points.Clear();

                                UploadChannelSign ucs = (UploadChannelSign)obj;

                                for (int i = 1; i <= ucs.Bit15List.Count; i++)
                                {
                                    SeriesPoint point = new SeriesPoint(i, ucs.Bit15List[i - 1]);
                                    chartChannel.Series[0].Points.Add(point);
                                }

                                for (int i = 1; i <= ucs.Bit0_14List.Count; i++)
                                {
                                    SeriesPoint point = new SeriesPoint(i, ucs.Bit0_14List[i - 1]);
                                    chartChannel.Series[1].Points.Add(point);
                                }
                                //serialPortHelper.ClearResult();

                                ((XYDiagram)chartChannel.Diagram).AxisX.VisualRange.Auto = false;
                                ((XYDiagram)chartChannel.Diagram).AxisX.VisualRange.AutoSideMargins = false;
                                ((XYDiagram)chartChannel.Diagram).AxisX.VisualRange.MaxValue = ucs.Bit15List.Count;
                                ((XYDiagram)chartChannel.Diagram).AxisX.VisualRange.MinValue = 0;
                                ((XYDiagram)chartChannel.Diagram).AxisX.WholeRange.Auto = false;
                                ((XYDiagram)chartChannel.Diagram).AxisX.WholeRange.AutoSideMargins = false;
                                ((XYDiagram)chartChannel.Diagram).AxisX.WholeRange.MaxValue = ucs.Bit15List.Count;
                                ((XYDiagram)chartChannel.Diagram).AxisX.WholeRange.MinValue = 0;
                                //sp_Start = -1;
                                //txtCalc.Text = "起点：无\r\n终点：无\r\n差值：无";

                                //chartChannel.Series[3].Points.Clear();
                                //chartChannel.Series[4].Points.Clear();

                                //lblTip.Visible = false;
                                //xValue = 0;
                                //x_Start = 0;

                                chartChannel.EndInit();
                            }
                            else if (obj is List<AlarmRecord>)
                            {
                                treeList2.BeginUpdate();

                                treeList2.Nodes.Clear();

                                List<AlarmRecord> alarmList = (List<AlarmRecord>)obj;

                                //alarmList.Sort(new AlarmComparer());

                                //alarmList.Reverse();

                                //StringBuilder sb = new StringBuilder();

                                foreach (AlarmRecord alarm in alarmList)
                                {
                                    TreeListNode node = treeList2.Nodes.Add(alarm);
                                    node.SetValue(Col_Index.AbsoluteIndex, alarm.index);
                                    node.SetValue(Col_RecordNum.AbsoluteIndex, alarm.Number.ToString("X2"));

                                    switch (alarm.Code)
                                    {
                                        case 0:
                                            node.SetValue(Col_RecordType.AbsoluteIndex, "无效记录");
                                            break;
                                        case 1:
                                            node.SetValue(Col_RecordType.AbsoluteIndex, "CH1报警");
                                            break;
                                        case 2:
                                            node.SetValue(Col_RecordType.AbsoluteIndex, "CH2报警");
                                            break;
                                        case 3:
                                            node.SetValue(Col_RecordType.AbsoluteIndex, "CH3报警");
                                            break;
                                        case 4:
                                            node.SetValue(Col_RecordType.AbsoluteIndex, "系统上电");
                                            break;
                                        case 7:
                                            node.SetValue(Col_RecordType.AbsoluteIndex, "系统设置新参数");
                                            break;
                                        case 8:
                                            node.SetValue(Col_RecordType.AbsoluteIndex, "计时标识");
                                            break;
                                        case 9:
                                            node.SetValue(Col_RecordType.AbsoluteIndex, "密钥溢出");
                                            break;
                                        case 10:
                                            node.SetValue(Col_RecordType.AbsoluteIndex, "初始化失败复位");
                                            break;
                                        case 11:
                                            node.SetValue(Col_RecordType.AbsoluteIndex, "工频相位丢失复位");
                                            break;
                                        case 128:
                                            node.SetValue(Col_RecordType.AbsoluteIndex, "系统故障");
                                            break;
                                        case 129:
                                            node.SetValue(Col_RecordType.AbsoluteIndex, "工频相位故障");
                                            break;
                                        case 130:
                                            node.SetValue(Col_RecordType.AbsoluteIndex, "FLASH故障");
                                            break;
                                        case 131:
                                            node.SetValue(Col_RecordType.AbsoluteIndex, "芯片1故障");
                                            break;
                                        case 132:
                                            node.SetValue(Col_RecordType.AbsoluteIndex, "芯片2故障");
                                            break;
                                    }

                                    SystemDT systemDT = (SystemDT)alarm.RecordDT;
                                    string strDT = systemDT.Year + "-" + systemDT.Month.ToString("00") + "-" + systemDT.Day.ToString("00") + " " + systemDT.Hour.ToString("00") + ":" + systemDT.Minute.ToString("00") + ":" + systemDT.Second.ToString("00");
                                    node.SetValue(Col_RecordDT.AbsoluteIndex, strDT);
                                    node.SetValue(Col_RecordData.AbsoluteIndex, alarm.Data);

                                    //sb.Append("记录序号:" + node.GetDisplayText(Col_RecordNum.AbsoluteIndex) +"  记录类型:" + node.GetDisplayText(Col_RecordType.AbsoluteIndex) + "  记录时间:" + strDT  + "  记录数据:" + alarm.Data);
                                    //sb.Append("\r\n");

                                }

                                treeList2.EndUpdate();

                                //string filePath = AppDomain.CurrentDomain.BaseDirectory + "报警记录.txt";
                                //using (System.IO.FileStream file = new System.IO.FileStream(filePath, System.IO.FileMode.Append, System.IO.FileAccess.Write))
                                //{
                                //    byte[] bytFile = Encoding.UTF8.GetBytes(sb.ToString());
                                //    file.Write(bytFile, 0, bytFile.Length);
                                //}
                                // serialPortHelper.ClearResult();
                            }
                        });
                    }
             
                }

                //System.Threading.Thread.Sleep(10);
                Application.DoEvents();
            }
        }

        private void btnSetDT_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpSystem.Text == " ")
                {
                    MessageBox.Show("参数设置有误");
                    return;
                }

                bShowMessage = true;

                EnableButton(false);
             
                this.Cursor = Cursors.WaitCursor;

                SystemDT systemDT = new SystemDT();
                systemDT.Year = dtpSystem.Value.Year;
                systemDT.Month = dtpSystem.Value.Month;
                systemDT.Day = dtpSystem.Value.Day;
                systemDT.Hour = dtpSystem.Value.Hour;
                systemDT.Minute = dtpSystem.Value.Minute;
                systemDT.Second = dtpSystem.Value.Second;

                List<byte> lstSend = dataHandler.Send(0x01, systemDT);

                ShowSendData(lstSend);

                if (RevData(0x01))
                {
                    //MessageBox.Show("操作成功");
                }
                //MessageBox.Show("操作成功");
            }
            catch
            {
                //MessageBox.Show("请检测串口");
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }



        }

        private void txtSerialData_TextChanged(object sender, EventArgs e)
        {
            txtSerialData.SelectionStart = txtSerialData.TextLength;
            txtSerialData.ScrollToCaret();
        }

        private void ShowSendData(List<byte> lstSend)
        {
            //string strShow = string.Empty;

            //strShow = DateTime.Now.ToString("HH:mm:ss") + " --> ";

            //for (int i = 0; i < lstSend.Count; i++)
            //{
            //    strShow += lstSend[i].ToString("X2") + " ";
            //}
            //strShow += "\r\n";

            //int startIndex = txtSerialData.TextLength;
            //txtSerialData.AppendText(strShow);
            //int endIndex = txtSerialData.TextLength;
            //txtSerialData.Select(startIndex, endIndex - startIndex);
            //txtSerialData.SelectionColor = Color.Green;
        }

        private bool RevData(byte returnType)
        {
            if (returnType == 0x12)
            {
                delay = int.Parse(ClsIniOperation.ReadIni("Delay", "Delay_12H")) + 1000;
            }
            else if (returnType == 0x13)
            {
                delay = int.Parse(ClsIniOperation.ReadIni("Delay", "Delay_13H")) + 1000;
            }
            else if (returnType == 0x20)
            {
                delay = int.Parse(ClsIniOperation.ReadIni("Delay", "Delay_20H")) + 1000;
            }
            else
            {
                delay = int.Parse(ClsIniOperation.ReadIni("Delay", "Delay_Else")) + 1000;
            }

            Stopwatch sp = new Stopwatch();
            sp.Reset();
            sp.Start();

            bool timeoutFlag = false;
            //while (!dataHandler.IsNormalFrame || dataHandler.ReturnType != returnType)
            while (!dataHandler.IsNormalFrame )
            {
                Application.DoEvents();
                //System.Threading.Thread.Sleep(1);
                if (sp.ElapsedMilliseconds > delay)
                {
                    timeoutFlag = true;
                    break;
                }
            }

            if (timeoutFlag)  //超时
            {
                //MessageBox.Show("数据接收超时，操作失败");
                //string strShow = string.Empty;

                //strShow = "数据接收超时，操作失败\r\n";
                //txtSerialData.AppendText(strShow);
                //return false;
                MessageBox.Show("数据接收超时，操作失败");
                return false;
            }

            

            return true;
        }

        private void btnSetParam_Click(object sender, EventArgs e)
        {
            try
            {
                if (((UpDownBase)numericUpDown1).Text == "" || ((UpDownBase)numericUpDown2).Text == ""  
                    || comboBox2.Text == "" || comboBox16.Text == "" || comboBox1.Text==""
                    || comboBox3.Text == "" || comboBox6.Text == "" || comboBox9.Text == ""
                    || comboBox4.Text == "" || comboBox7.Text == "" 
                    || comboBox5.Text == "" || comboBox8.Text == "" )
                {
                    MessageBox.Show("参数设置有误");
                    return;
                }

                bShowMessage = true;

                bShowMessage = true;

                EnableButton(false);
               
                this.Cursor = Cursors.WaitCursor;

                //float fPhse=0f;
                //if (!float.TryParse(textBox1.Text, out fPhse))
                //{
                //    MessageBox.Show("相位参数设置错误");
                //    return;
                //}
 
                SystemParam systemParam = new SystemParam();
                systemParam.Phase = (int)numericUpDown1.Value;
                systemParam.Frequency = comboBox16.SelectedIndex;
                systemParam.SendInterval = comboBox1.SelectedIndex;
                systemParam.SendStrength = comboBox2.SelectedIndex;
                systemParam.RevDelay = (int)numericUpDown2.Value;
                systemParam.ChannelMode = comboBox3.SelectedIndex;
                systemParam.InterferenceDetection = comboBox4.SelectedIndex;
                systemParam.SignDetection = comboBox5.SelectedIndex;
                systemParam.DecodingFilterA = 0;// comboBox6.SelectedIndex;
                systemParam.DecodingFilterB = 0;//comboBox7.SelectedIndex;
                systemParam.DecodingFilterC = 0;//comboBox8.SelectedIndex;
                systemParam.DecodingFilterD = 0;//comboBox9.SelectedIndex;

                List<byte> lstSend = dataHandler.Send(0x04, systemParam);

                ShowSendData(lstSend);

                if (RevData(0x04))
                {
                    //MessageBox.Show("操作成功");
                }
                

                //MessageBox.Show("操作成功");
            }
            catch
            {
                //MessageBox.Show("请检测串口");
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSetCH1_Click(object sender, EventArgs e)
        {
            try
            {
                if ( comboBox17.Text == "" || comboBox23.Text == "" || comboBox24.Text == "" || comboBox10.Text == "")
                {
                    MessageBox.Show("参数设置有误");
                    return;
                }

                bShowMessage = true;

                EnableButton(false);
               
                this.Cursor = Cursors.WaitCursor;
         

                ChannelParam channelParam = new ChannelParam();
                channelParam.AlarmThreshold = comboBox17.SelectedIndex;
                channelParam.ChannelGain = 10;
                //channelParam.Sign1 = checkBox1.Checked ? 1 : 0;
                //channelParam.Sign2 = checkBox2.Checked ? 1 : 0;
                //channelParam.Sign3 = checkBox3.Checked ? 1 : 0;
                channelParam.TX = comboBox23.SelectedIndex == 0 ? 1 : 0;
                channelParam.RX = comboBox24.SelectedIndex == 0 ? 1 : 0;
                channelParam.Buzzer = comboBox10.SelectedIndex;

                List<byte> lstSend = dataHandler.Send(0x06, channelParam);

                ShowSendData(lstSend);

                if (RevData(0x06))
                {
                    //MessageBox.Show("操作成功");
                }

                //MessageBox.Show("操作成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败：" + ex.Message);
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSetCH2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox20.Text == "" || comboBox26.Text == "" || comboBox25.Text == "" || comboBox11.Text == "")
                {
                    MessageBox.Show("参数设置有误");
                    return;
                }

                bShowMessage = true;

                EnableButton(false);
              
                this.Cursor = Cursors.WaitCursor;

                ChannelParam channelParam = new ChannelParam();
                channelParam.AlarmThreshold = comboBox20.SelectedIndex;
                channelParam.ChannelGain = 10;
                //channelParam.Sign1 = checkBox6.Checked ? 1 : 0;
                //channelParam.Sign2 = checkBox5.Checked ? 1 : 0;
                //channelParam.Sign3 = checkBox4.Checked ? 1 : 0;
                channelParam.TX = comboBox26.SelectedIndex == 0 ? 1 : 0;
                channelParam.RX = comboBox25.SelectedIndex == 0 ? 1 : 0;
                channelParam.Buzzer = comboBox11.SelectedIndex;

                List<byte> lstSend = dataHandler.Send(0x08, channelParam);

                ShowSendData(lstSend);

                if (RevData(0x08))
                {
                    //MessageBox.Show("操作成功");
                }

                //MessageBox.Show("操作成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败：" + ex.Message);
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSetCH3_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox22.Text == "" || comboBox28.Text == "" || comboBox27.Text == "" || comboBox12.Text == "")
                {
                    MessageBox.Show("参数设置有误");
                    return;
                }

                bShowMessage = true;

                EnableButton(false);
              
                this.Cursor = Cursors.WaitCursor;

                ChannelParam channelParam = new ChannelParam();
                channelParam.AlarmThreshold = comboBox22.SelectedIndex;
                channelParam.ChannelGain = 10;
                //channelParam.Sign1 = checkBox9.Checked ? 1 : 0;
                //channelParam.Sign2 = checkBox8.Checked ? 1 : 0;
                //channelParam.Sign3 = checkBox7.Checked ? 1 : 0;
                channelParam.TX = comboBox28.SelectedIndex == 0 ? 1 : 0;
                channelParam.RX = comboBox27.SelectedIndex == 0 ? 1 : 0;
                channelParam.Buzzer = comboBox12.SelectedIndex;

                List<byte> lstSend = dataHandler.Send(0x0A, channelParam);

                ShowSendData(lstSend);

                if (RevData(0x0A))
                {
                    //MessageBox.Show("操作成功");
                }

                //MessageBox.Show("操作成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败：" + ex.Message);
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                EnableButton(false);
              
                this.Cursor = Cursors.WaitCursor;
 
                List<byte> lstSend = dataHandler.Send(0x0C, null);

                ShowSendData(lstSend);

                if (RevData(0x0C))
                {
                    //MessageBox.Show("操作成功");
                }

                //MessageBox.Show("操作成功");
            }
            catch
            {
                MessageBox.Show("请检测串口");
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }


        private void btnQuerySystemDT_Click(object sender, EventArgs e)
        {
            try
            {

                EnableButton(false);
             
                this.Cursor = Cursors.WaitCursor;
 
                textBox3.Text = string.Empty;
                

                List<byte> lstSend = dataHandler.Send(0x02, null);

                ShowSendData(lstSend);

                RevData(0x02);

                //MessageBox.Show("操作成功");
            }
            catch
            {
                MessageBox.Show("请检测串口");
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnQueryVersion_Click(object sender, EventArgs e)
        {
            try
            {
                EnableButton(false);
               
                this.Cursor = Cursors.WaitCursor;

                textBox21.Text = string.Empty;
 

                List<byte> lstSend = dataHandler.Send(0x03, null);

                ShowSendData(lstSend);

                RevData(0x03);

                //MessageBox.Show("操作成功");
            }
            catch
            {
                MessageBox.Show("请检测串口");
            }
            finally
            {

                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnQuerySystemParam_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    EnableButton(false);

            //    this.Cursor = Cursors.WaitCursor; 

            //    textBox2.Text = string.Empty;
            //    textBox8.Text = string.Empty;
            //    textBox11.Text = string.Empty;
            //    textBox14.Text = string.Empty;
            //    textBox4.Text = string.Empty;
            //    textBox7.Text = string.Empty;
            //    textBox10.Text = string.Empty;
            //    textBox13.Text = string.Empty;
            //    textBox5.Text = string.Empty;
            //    textBox6.Text = string.Empty;
            //    textBox9.Text = string.Empty;
            //    textBox12.Text = string.Empty;


            //    List<byte> lstSend = dataHandler.Send(0x05, null);

            //    ShowSendData(lstSend);

            //    RevData(0x05);

            //    //MessageBox.Show("操作成功");
            //}
            //catch
            //{
            //    MessageBox.Show("请检测串口");
            //}
            //finally
            //{
            //    Application.DoEvents();
            //    EnableButton(true);
            //    this.Cursor = Cursors.Default;
            //}

          
            try
            {

                EnableButton(false);

                this.Cursor = Cursors.WaitCursor;

                //float fPhse=0f;
                //if (!float.TryParse(textBox1.Text, out fPhse))
                //{
                //    MessageBox.Show("相位参数设置错误");
                //    return;
                //}

                SystemParam systemParam = new SystemParam();

                int temp = 0;
                if (!int.TryParse(textBox2.Text.Trim(), out temp))
                {
                    MessageBox.Show("相位设置有误");
                    return;
                }
                if (temp < 0 || temp > 65535)
                {
                    MessageBox.Show("相位设置有误");
                    return;
                }

                systemParam.Phase = temp;
                switch (textBox8.Text.Trim().ToUpper())
                {
                    case "57.8K":
                        systemParam.Frequency = 0;
                        break;
                    case "58K":
                        systemParam.Frequency = 1;
                        break;
                    case "58.2K":
                        systemParam.Frequency = 2;
                        break;
                    case "58.4K":
                        systemParam.Frequency = 3;
                        break;
                    case "58.6K":
                        systemParam.Frequency = 4;
                        break;
                    default:
                        MessageBox.Show("频率设置有误");
                        return;
                }
                //systemParam.Frequency = comboBox16.SelectedIndex;
                switch (textBox11.Text.Trim())
                {
                    case "模式1":
                        systemParam.SendInterval = 0;
                        break;
                    case "模式2":
                        systemParam.SendInterval = 1;
                        break;
                    case "模式3":
                        systemParam.SendInterval = 2;
                        break;
                    case "模式4":
                        systemParam.SendInterval = 3;
                        break;
                    case "模式5":
                        systemParam.SendInterval = 4;
                        break;
                    default:
                        MessageBox.Show("发射模式设置有误");
                        return;
                }
                //systemParam.SendInterval = comboBox1.SelectedIndex;
                switch (textBox14.Text.Trim().ToUpper())
                {
                    case "L":
                        systemParam.SendStrength = 0;
                        break;
                    case "M":
                        systemParam.SendStrength = 1;
                        break;
                    case "H":
                        systemParam.SendStrength = 2;
                        break;
                    default:
                        MessageBox.Show("发射强度设置有误");
                        return;

                }
                //systemParam.SendStrength = comboBox2.SelectedIndex;
                if (!int.TryParse(textBox4.Text.Trim(), out temp))
                {
                    MessageBox.Show("接收延时设置有误");
                    return;
                }
                if (temp < 0 || temp > 255)
                {
                    MessageBox.Show("接收延时设置有误");
                    return;
                }
                systemParam.RevDelay = temp;
                //systemParam.ChannelMode = comboBox3.SelectedIndex;
                switch (textBox7.Text.Trim().ToUpper())
                {
                    case "上升沿":
                        systemParam.ChannelMode = 0;
                        break;
                    case "下降沿":
                        systemParam.ChannelMode = 1;
                        break;
                    default:
                        MessageBox.Show("同步边沿置有误");
                        return;
                }

                //systemParam.InterferenceDetection = comboBox4.SelectedIndex;
                switch (textBox10.Text.Trim().ToUpper())
                {
                    case "OFF":
                        systemParam.InterferenceDetection = 0;
                        break;
                    case "ON":
                        systemParam.InterferenceDetection = 1;
                        break;
                    default:
                        MessageBox.Show("恶意干扰检测设置有误");
                        return;
                }

                //systemParam.SignDetection = comboBox5.SelectedIndex;
                switch (textBox13.Text.Trim().ToUpper())
                {
                    case "OFF":
                        systemParam.InterferenceDetection = 0;
                        break;
                    case "小榔头":
                        systemParam.InterferenceDetection = 1;
                        break;
                    case "中榔头":
                        systemParam.InterferenceDetection = 2;
                        break;
                    case "大榔头":
                        systemParam.InterferenceDetection = 3;
                        break;
                    default:
                        MessageBox.Show("标牌靠近检测设置有误");
                        return;
                }

                //systemParam.DecodingFilterA = comboBox6.SelectedIndex;
                //systemParam.DecodingFilterB = comboBox7.SelectedIndex;
                //systemParam.DecodingFilterC = comboBox8.SelectedIndex;
                //systemParam.DecodingFilterD = comboBox9.SelectedIndex;
                switch (textBox5.Text.Trim().ToUpper())
                {
                    case "OFF":
                        systemParam.DecodingFilterA = 0;
                        break;
                    case "ON":
                        systemParam.DecodingFilterA = 1;
                        break;
                    default:
                        MessageBox.Show("解码滤波器A设置有误");
                        return;
                }

                switch (textBox6.Text.Trim().ToUpper())
                {
                    case "OFF":
                        systemParam.DecodingFilterB = 0;
                        break;
                    case "ON":
                        systemParam.DecodingFilterB = 1;
                        break;
                    default:
                        MessageBox.Show("解码滤波器B设置有误");
                        return;
                }

                switch (textBox9.Text.Trim().ToUpper())
                {
                    case "OFF":
                        systemParam.DecodingFilterC = 0;
                        break;
                    case "ON":
                        systemParam.DecodingFilterC = 1;
                        break;
                    default:
                        MessageBox.Show("解码滤波器C设置有误");
                        return;
                }

                switch (textBox12.Text.Trim().ToUpper())
                {
                    case "OFF":
                        systemParam.DecodingFilterD = 0;
                        break;
                    case "ON":
                        systemParam.DecodingFilterD = 1;
                        break;
                    default:
                        MessageBox.Show("解码滤波器D设置有误");
                        return;
                }

                List<byte> lstSend = dataHandler.Send(0x04, systemParam);

                ShowSendData(lstSend);

                if (RevData(0x04))
                {
                    MessageBox.Show("操作成功");
                }


                //MessageBox.Show("操作成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败：" + ex.Message);
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnQueryCH1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    EnableButton(false);
                
            //    this.Cursor = Cursors.WaitCursor;

            //    textBox15.Text = string.Empty;
            //    textBox18.Text = string.Empty;
            //    //checkBox16.Checked = false;
            //    //checkBox17.Checked = false;
            //    //checkBox18.Checked = false;
            //    textBox1.Text = string.Empty;
            //    textBox25.Text = string.Empty;
 
    

            //    List<byte> lstSend = dataHandler.Send(0x07, null);

            //    ShowSendData(lstSend);

            //    RevData(0x07);

            //    //MessageBox.Show("操作成功");
            //}
            //catch
            //{
            //    MessageBox.Show("请检测串口");
            //}
            //finally
            //{
            //    Application.DoEvents();
            //    EnableButton(true);
            //    this.Cursor = Cursors.Default;
            //}

            try
            {
                EnableButton(false);

                this.Cursor = Cursors.WaitCursor;


                ChannelParam channelParam = new ChannelParam();

                int temp = 0;
                if (!int.TryParse(textBox24.Text.Trim(), out temp))
                {
                    MessageBox.Show("报警门限设置有误");
                    return;
                }
                if (temp < 0 || temp > 10)
                {
                    MessageBox.Show("报警门限设置有误");
                    return;
                }
                channelParam.AlarmThreshold = temp;

                channelParam.ChannelGain = 10;

                switch (textBox1.Text.Trim().ToUpper())
                {
                    case "ON":
                        channelParam.TX = 1;
                        break;
                    case "OFF":
                        channelParam.TX = 0;
                        break;
                    default:
                        MessageBox.Show("TX设置有误");
                        return;
                }

                switch (textBox25.Text.Trim().ToUpper())
                {
                    case "ON":
                        channelParam.RX = 1;
                        break;
                    case "OFF":
                        channelParam.RX = 0;
                        break;
                    default:
                        MessageBox.Show("RX设置有误");
                        return;
                }

                switch (textBox18.Text.Trim().ToUpper())
                {
                    case "ON":
                        channelParam.RX = 0;
                        break;
                    case "OFF":
                        channelParam.RX = 1;
                        break;
                    default:
                        MessageBox.Show("独立报警设置有误");
                        return;
                }

                List<byte> lstSend = dataHandler.Send(0x06, channelParam);

                ShowSendData(lstSend);

                if (RevData(0x06))
                {
                    MessageBox.Show("操作成功");
                }

                //MessageBox.Show("操作成功");
            }
            catch
            {
                MessageBox.Show("请检测串口");
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnQueryCH2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    EnableButton(false);
             
            //    this.Cursor = Cursors.WaitCursor;

            //    textBox16.Text = string.Empty;
            //    textBox19.Text = string.Empty;
            //    //checkBox13.Checked = false;
            //    //checkBox14.Checked = false;
            //    //checkBox15.Checked = false;
             
            //    textBox26.Text = string.Empty;
            //    textBox27.Text = string.Empty;
            
 

            //    List<byte> lstSend = dataHandler.Send(0x09, null);

            //    ShowSendData(lstSend);

            //    RevData(0x09);

            //    //MessageBox.Show("操作成功");
            //}
            //catch
            //{
            //    MessageBox.Show("请检测串口");
            //}
            //finally
            //{
            //    Application.DoEvents();
            //    EnableButton(true);
            //    this.Cursor = Cursors.Default;
            //}

            try
            {
                EnableButton(false);

                this.Cursor = Cursors.WaitCursor;

                ChannelParam channelParam = new ChannelParam();
                int temp = 0;
                if (!int.TryParse(textBox23.Text.Trim(), out temp))
                {
                    MessageBox.Show("报警门限设置有误");
                    return;
                }
                if (temp < 0 || temp > 10)
                {
                    MessageBox.Show("报警门限设置有误");
                    return;
                }
                channelParam.AlarmThreshold = temp;

                channelParam.ChannelGain = 10;

                switch (textBox27.Text.Trim().ToUpper())
                {
                    case "ON":
                        channelParam.TX = 1;
                        break;
                    case "OFF":
                        channelParam.TX = 0;
                        break;
                    default:
                        MessageBox.Show("TX设置有误");
                        return;
                }

                switch (textBox26.Text.Trim().ToUpper())
                {
                    case "ON":
                        channelParam.RX = 1;
                        break;
                    case "OFF":
                        channelParam.RX = 0;
                        break;
                    default:
                        MessageBox.Show("RX设置有误");
                        return;
                }

                switch (textBox19.Text.Trim().ToUpper())
                {
                    case "ON":
                        channelParam.RX = 0;
                        break;
                    case "OFF":
                        channelParam.RX = 1;
                        break;
                    default:
                        MessageBox.Show("独立报警设置有误");
                        return;
                }

                List<byte> lstSend = dataHandler.Send(0x08, channelParam);

                ShowSendData(lstSend);

                if (RevData(0x08))
                {
                    MessageBox.Show("操作成功");
                }

                //MessageBox.Show("操作成功");
            }
            catch
            {
                MessageBox.Show("请检测串口");
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnQueryCH3_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    EnableButton(false);
                
            //    this.Cursor = Cursors.WaitCursor;

            //    textBox17.Text = string.Empty;
            //    textBox20.Text = string.Empty;
            //    //checkBox10.Checked = false;
            //    //checkBox11.Checked = false;
            //    //checkBox12.Checked = false;
 
            //    textBox28.Text = string.Empty;
            //    textBox29.Text = string.Empty;

            //    List<byte> lstSend = dataHandler.Send(0x0B, null);

            //    ShowSendData(lstSend);

            //    RevData(0x0B);

            //    //MessageBox.Show("操作成功");
            //}
            //catch
            //{
            //    MessageBox.Show("请检测串口");
            //}
            //finally
            //{
            //    Application.DoEvents();
            //    EnableButton(true);
            //    this.Cursor = Cursors.Default;
            //}

            try
            {
                EnableButton(false);

                this.Cursor = Cursors.WaitCursor;

                ChannelParam channelParam = new ChannelParam();
                int temp = 0;
                if (!int.TryParse(textBox22.Text.Trim(), out temp))
                {
                    MessageBox.Show("报警门限设置有误");
                    return;
                }
                if (temp < 0 || temp > 10)
                {
                    MessageBox.Show("报警门限设置有误");
                    return;
                }
                channelParam.AlarmThreshold = temp;

                channelParam.ChannelGain = 10;

                switch (textBox29.Text.Trim().ToUpper())
                {
                    case "ON":
                        channelParam.TX = 1;
                        break;
                    case "OFF":
                        channelParam.TX = 0;
                        break;
                    default:
                        MessageBox.Show("TX设置有误");
                        return;
                }

                switch (textBox28.Text.Trim().ToUpper())
                {
                    case "ON":
                        channelParam.RX = 1;
                        break;
                    case "OFF":
                        channelParam.RX = 0;
                        break;
                    default:
                        MessageBox.Show("RX设置有误");
                        return;
                }

                switch (textBox20.Text.Trim().ToUpper())
                {
                    case "ON":
                        channelParam.RX = 0;
                        break;
                    case "OFF":
                        channelParam.RX = 1;
                        break;
                    default:
                        MessageBox.Show("独立报警设置有误");
                        return;
                }

                List<byte> lstSend = dataHandler.Send(0x0A, channelParam);

                ShowSendData(lstSend);

                if (RevData(0x0A))
                {
                    MessageBox.Show("操作成功");
                }

                //MessageBox.Show("操作成功");
            }
            catch
            {
                MessageBox.Show("请检测串口");
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnPhase_Click(object sender, EventArgs e)
        {
            try
            {
                EnableButton(false);
            
                this.Cursor = Cursors.WaitCursor;

                treeList1.ClearNodes();
                treeList3.ClearNodes();

                List<byte> lstSend = dataHandler.Send(0x12, comboBox14.SelectedIndex);

                ShowSendData(lstSend);

                RevData(0x12);

                //MessageBox.Show("操作成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败：" + ex.Message);
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSignStrength_Click(object sender, EventArgs e)
        {
            try
            {
                EnableButton(false);
              
                this.Cursor = Cursors.WaitCursor;

                chartSign.Series[0].Points.Clear();
                chartSign.Series[1].Points.Clear();

                DevExpress.XtraCharts.XYDiagram xyDiagram1 = (XYDiagram)this.chartSign.Diagram;
                xyDiagram1.AxisX.Visible = false; 
 
                List<byte> lstSend = dataHandler.Send(0x10, null);

                ShowSendData(lstSend);

                RevData(0x10);

                //MessageBox.Show("操作成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败：" + ex.Message);
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnCloseSignStrength_Click(object sender, EventArgs e)
        {
            try
            {
                bShowMessage = false;

                exit = true;
                EnableButton(false);
              
                this.Cursor = Cursors.WaitCursor;

                List<byte> lstSend = dataHandler.Send(0x11, null);

                ShowSendData(lstSend);

                RevData(0x11);

                //MessageBox.Show("操作成功");
            }
            catch
            {
                MessageBox.Show("请检测串口");
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSignData_Click(object sender, EventArgs e)
        {
            try
            {
                
                EnableButton(false);
               
                this.Cursor = Cursors.WaitCursor;

                chartChannel.Series[0].Points.Clear();
                chartChannel.Series[1].Points.Clear();
                chartChannel.Series[2].Points.Clear();
                chartChannel.Series[3].Points.Clear();
                chartChannel.Series[4].Points.Clear();

                lblX.Visible = false;
                lblY.Visible = false;

                lblTip.Visible = false;
                xValue = 0;
                x_Start = 0;
                clickCount = 0;

                ((LineSeriesView)chartChannel.Series[3].View).LineStyle.DashStyle = DashStyle.Dash;
                ((LineSeriesView)chartChannel.Series[4].View).LineStyle.DashStyle = DashStyle.Dash;

                this.Cursor = Cursors.WaitCursor;
                EnableButton(false);

                List<byte> lstSend = dataHandler.Send(0x13, comboBox14.SelectedIndex);

                ShowSendData(lstSend);

                RevData(0x13);

                //MessageBox.Show("操作成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败：" + ex.Message);
            }
            finally
            {

                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnCloseSignData_Click(object sender, EventArgs e)
        {
            try
            {
                EnableButton(false);
              
                this.Cursor = Cursors.WaitCursor;

                List<byte> lstSend = dataHandler.Send(0x14, null);

                ShowSendData(lstSend);

                RevData(0x14);

                //MessageBox.Show("操作成功");
            }
            catch
            {
                MessageBox.Show("请检测串口");
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnAlarm_Click(object sender, EventArgs e)
        {
            try
            {
                EnableButton(false);
             
                this.Cursor = Cursors.WaitCursor;

                treeList2.ClearNodes();

                 

                List<byte> lstSend = dataHandler.Send(0x20, null);

                ShowSendData(lstSend);

                RevData(0x20);

                //MessageBox.Show("操作成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败：" + ex.Message);
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ClsIniOperation.WriteIni("SystemDT", "SystemDT", dtpSystem.Value.ToString("yyyy-MM-dd HH:mm:ss"));

            //ClsIniOperation.WriteIni("SystemParam", "Phase", textBox1.Text);
            //ClsIniOperation.WriteIni("SystemParam", "Frequency", numericUpDown1.Value.ToString());
            //ClsIniOperation.WriteIni("SystemParam", "SendStrength", comboBox2.SelectedIndex.ToString());
            //ClsIniOperation.WriteIni("SystemParam", "RevDelay", numericUpDown2.Value.ToString());
            //ClsIniOperation.WriteIni("SystemParam", "ChannelMode", comboBox3.SelectedIndex.ToString());
            //ClsIniOperation.WriteIni("SystemParam", "InterferenceDetection", comboBox4.SelectedIndex.ToString());
            //ClsIniOperation.WriteIni("SystemParam", "SignDetection", comboBox5.SelectedIndex.ToString());
            //ClsIniOperation.WriteIni("SystemParam", "DecodingFilterA", comboBox6.SelectedIndex.ToString());
            //ClsIniOperation.WriteIni("SystemParam", "DecodingFilterB", comboBox7.SelectedIndex.ToString());
            //ClsIniOperation.WriteIni("SystemParam", "DecodingFilterC", comboBox8.SelectedIndex.ToString());
            //ClsIniOperation.WriteIni("SystemParam", "DecodingFilterD", comboBox9.SelectedIndex.ToString());

            //ClsIniOperation.WriteIni("CH1", "ChannelGain", numericUpDown3.Value.ToString());
            //ClsIniOperation.WriteIni("CH1", "Sign1", checkBox1.Checked ? "1" : "0");
            //ClsIniOperation.WriteIni("CH1", "Sign2", checkBox2.Checked ? "1" : "0");
            //ClsIniOperation.WriteIni("CH1", "Sign3", checkBox3.Checked ? "1" : "0");
            //ClsIniOperation.WriteIni("CH1", "Buzze", comboBox10.SelectedIndex.ToString());

            //ClsIniOperation.WriteIni("CH2", "ChannelGain", numericUpDown4.Value.ToString());
            //ClsIniOperation.WriteIni("CH2", "Sign1", checkBox6.Checked ? "1" : "0");
            //ClsIniOperation.WriteIni("CH2", "Sign2", checkBox5.Checked ? "1" : "0");
            //ClsIniOperation.WriteIni("CH2", "Sign3", checkBox4.Checked ? "1" : "0");
            //ClsIniOperation.WriteIni("CH2", "Buzze", comboBox11.SelectedIndex.ToString());

            //ClsIniOperation.WriteIni("CH3", "ChannelGain", numericUpDown5.Value.ToString());
            //ClsIniOperation.WriteIni("CH3", "Sign1", checkBox9.Checked ? "1" : "0");
            //ClsIniOperation.WriteIni("CH3", "Sign2", checkBox8.Checked ? "1" : "0");
            //ClsIniOperation.WriteIni("CH3", "Sign3", checkBox7.Checked ? "1" : "0");
            //ClsIniOperation.WriteIni("CH3", "Buzze", comboBox12.SelectedIndex.ToString());

            //ClsIniOperation.WriteIni("CH3", "Buzze", comboBox12.SelectedIndex.ToString());

            //ClsIniOperation.WriteIni("Phase", "Channel", comboBox13.SelectedIndex.ToString());

            //ClsIniOperation.WriteIni("Sign", "Channel", comboBox14.SelectedIndex.ToString());
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            textBox22.Text = string.Empty;
            textBox23.Text = string.Empty;
            textBox24.Text = string.Empty;

            textBox3.Text = string.Empty;
            textBox21.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox11.Text = string.Empty;
            textBox14.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox10.Text = string.Empty;
            textBox13.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox9.Text = string.Empty;
            textBox12.Text = string.Empty;
            textBox15.Text = string.Empty;
            textBox18.Text = string.Empty;
            checkBox16.Checked = false;
            checkBox17.Checked = false;
            checkBox18.Checked = false;
            textBox16.Text = string.Empty;
            textBox19.Text = string.Empty;
            checkBox13.Checked = false;
            checkBox14.Checked = false;
            checkBox15.Checked = false;
            textBox17.Text = string.Empty;
            textBox20.Text = string.Empty;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            checkBox12.Checked = false;

            textBox1.Text = string.Empty;
            textBox25.Text = string.Empty;
            textBox26.Text = string.Empty;
            textBox27.Text = string.Empty;
            textBox28.Text = string.Empty;
            textBox29.Text = string.Empty;
        }

        private void btnQueryAll_Click(object sender, EventArgs e)
        {
            try
            {
                EnableButton(false);
          
                this.Cursor = Cursors.WaitCursor;

 
                List<byte> lstSend = new List<byte>();

                lstSend = dataHandler.Send(0x02, null);
                ShowSendData(lstSend);

               
                if (!RevData(0x02))
                {
                    return;
                }

                System.Threading.Thread.Sleep(100);

                lstSend = dataHandler.Send(0x03, null);
                ShowSendData(lstSend);

               
                if (!RevData(0x03))
                {
                    return;
                }

                System.Threading.Thread.Sleep(100);

                lstSend = dataHandler.Send(0x05, null);
                ShowSendData(lstSend);
                if (!RevData(0x05))
                {
                    return;
                }

                System.Threading.Thread.Sleep(100);

                lstSend = dataHandler.Send(0x07, null);
                ShowSendData(lstSend);
                if (!RevData(0x07))
                {
                    return;
                }

                System.Threading.Thread.Sleep(100);

                lstSend = dataHandler.Send(0x09, null);
                ShowSendData(lstSend);
                if (!RevData(0x09))
                {
                    return;
                }

                System.Threading.Thread.Sleep(100);

                lstSend = dataHandler.Send(0x0B, null);
                ShowSendData(lstSend);
                if (!RevData(0x0B))
                {
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("操作失败：" + ex.Message);
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            bShowMessage = false;

            EnableButton(false);

            chartChannel.Series[0].Points.Clear();
            chartChannel.Series[1].Points.Clear();
            chartChannel.Series[2].Points.Clear();
            chartChannel.Series[3].Points.Clear();
            chartChannel.Series[4].Points.Clear();

            lblX.Visible = false;
            lblY.Visible = false;

            lblTip.Visible = false;
            xValue = 0;
            x_Start = 0;
            clickCount = 0;

            ((LineSeriesView)chartChannel.Series[3].View).LineStyle.DashStyle = DashStyle.Dash;
            ((LineSeriesView)chartChannel.Series[4].View).LineStyle.DashStyle = DashStyle.Dash;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (trackBarControl1.Value <= trackBarControl1.Properties.Minimum)
                {
                    trackBarControl1.Value = trackBarControl1.Properties.Maximum;
                }
                else
                {
                    trackBarControl1.Value -= 1;
                }

                //trackBarControl1.Value -= 1;

                int value = trackBarControl1.Value; 
                //float value = 0f;
                //if (comboBox15.SelectedIndex == 0)
                //{
                //    value = trackBarControl1.Value;
                //}
                //else
                //{
                //    value = (float)(trackBarControl1.Value * 0.1);
                //}

                if (checkBox21.Checked)
                {
                    phaseIndex = 1;
                }
                else
                {
                    phaseIndex = 0;
                }

                List<byte> lstSend = dataHandler.Send(0x15, value);

                ShowSendData(lstSend);

                RevData(0x15);
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败：" + ex.Message);
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnRigth_Click(object sender, EventArgs e)
        {
            bShowMessage = false;

            EnableButton(false);

            chartChannel.Series[0].Points.Clear();
            chartChannel.Series[1].Points.Clear();
            chartChannel.Series[2].Points.Clear();
            chartChannel.Series[3].Points.Clear();
            chartChannel.Series[4].Points.Clear();

            lblX.Visible = false;
            lblY.Visible = false;

            lblTip.Visible = false;
            xValue = 0;
            x_Start = 0;
            clickCount = 0;

            ((LineSeriesView)chartChannel.Series[3].View).LineStyle.DashStyle = DashStyle.Dash;
            ((LineSeriesView)chartChannel.Series[4].View).LineStyle.DashStyle = DashStyle.Dash;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (trackBarControl1.Value >= trackBarControl1.Properties.Maximum)
                {
                    trackBarControl1.Value = trackBarControl1.Properties.Minimum;
                }
                else
                {
                    trackBarControl1.Value += 1;
                }

                //trackBarControl1.Value += 1;
                int value = trackBarControl1.Value; 

                //float value = 0f;
                //if (comboBox15.SelectedIndex == 0)
                //{
                //    value = trackBarControl1.Value;
                //}
                //else
                //{
                //    value = (float)(trackBarControl1.Value * 0.1);
                //}

                if (checkBox21.Checked)
                {
                    phaseIndex = 1;
                }
                else
                {
                    phaseIndex = 0;
                }

                List<byte> lstSend = dataHandler.Send(0x15, value);

                ShowSendData(lstSend);

                RevData(0x15);
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败：" + ex.Message);
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox15.SelectedIndex == 0)
            {

                int barValue = trackBarControl1.Value;
                trackBarControl1.Properties.Minimum = 0;
                trackBarControl1.Properties.Maximum = 119;
                trackBarControl1.Value = (int)(barValue * 0.1);
                trackBarControl1.Properties.Labels.Clear();
                for (int i = 0; i <= 5; i++)
                {
                    int lblValue = i * 20;
                    trackBarControl1.Properties.Labels.Add(new DevExpress.XtraEditors.Repository.TrackBarLabel(lblValue.ToString("0"), lblValue));
                }
                trackBarControl1.Properties.Labels.Add(new DevExpress.XtraEditors.Repository.TrackBarLabel(trackBarControl1.Properties.Maximum.ToString(), trackBarControl1.Properties.Maximum));
            }
            //else
            //{

            //    int barValue = trackBarControl1.Value;
            //    trackBarControl1.Properties.Minimum = 0;
            //    trackBarControl1.Properties.Maximum = 3600;
            //    trackBarControl1.Value = (int)(barValue * 10);
            //    trackBarControl1.Properties.Labels.Clear();
            //    for (int i = 0; i < 10; i++)
            //    {
            //        int lblValue = i * 400;
            //        int temp = i * 40;
            //        trackBarControl1.Properties.Labels.Add(new DevExpress.XtraEditors.Repository.TrackBarLabel(temp.ToString("0.0"), lblValue));
            //    }
            //}
        }

        private void trackBarControl1_ValueChanged(object sender, EventArgs e)
        {
            //float value = 0f;
            //if (comboBox15.SelectedIndex == 0)
            //{
            //    value = trackBarControl1.Value;
            //}
            //else
            //{
            //    value = (float)(trackBarControl1.Value * 0.1);
            //}

            int value = trackBarControl1.Value;
            label56.Text = "相位值:" + value;



        }

        private void btnSetPhase_Click(object sender, EventArgs e)
        {
            try
            {
                bShowMessage = true;

                EnableButton(false);

                chartChannel.Series[0].Points.Clear();
                chartChannel.Series[1].Points.Clear();
                chartChannel.Series[2].Points.Clear();
                chartChannel.Series[3].Points.Clear();
                chartChannel.Series[4].Points.Clear();

                lblX.Visible = false;
                lblY.Visible = false;

                lblTip.Visible = false;
                xValue = 0;
                x_Start = 0;
                clickCount = 0;

                ((LineSeriesView)chartChannel.Series[3].View).LineStyle.DashStyle = DashStyle.Dash;
                ((LineSeriesView)chartChannel.Series[4].View).LineStyle.DashStyle = DashStyle.Dash;

                this.Cursor = Cursors.WaitCursor;

                float value = 0f;
                if (comboBox15.SelectedIndex == 0)
                {
                    value = trackBarControl1.Value;
                }
                else
                {
                    value = (float)(trackBarControl1.Value * 0.1);
                }

                if (checkBox21.Checked)
                {
                    phaseIndex = 1;
                }
                else
                {
                    phaseIndex = 0;
                }

                List<byte> lstSend = dataHandler.Send(0x15, value);

                ShowSendData(lstSend);

                //Thread.Sleep(300);
                //List<byte> lstRev = new List<byte>();
                //lstRev.Add(0x10);
                //lstRev.Add(0xFF);
                //lstRev.Add(0xFE);

                //lstRev.Add(0x4);
                //lstRev.Add(0x0);
 
                //lstRev.Add((byte)0x15);

               
                //lstRev.Add((byte)0x00);
                

                //byte[] bytcheck = GetDataCheck(lstRev.GetRange(3, lstRev.Count - 3));
                //lstRev.Add(bytcheck[0]);
                //lstRev.Add(bytcheck[1]);
 

                //serialPortHelper.LstReciveByte.AddRange( lstRev);

                RevData(0x15);


                //MessageBox.Show("操作成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败：" + ex.Message);
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSaveAlarm_Click(object sender, EventArgs e)
        {
            if (treeList2.Nodes.Count == 0)
            {
                MessageBox.Show("无报警记录数据");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件(*.txt)|*.txt";
            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;

            //点了保存按钮进入 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string filePath = sfd.FileName; //获得文件路径 

                StringBuilder sb = new StringBuilder();
                foreach (TreeListNode node in treeList2.Nodes)
                {
                    sb.Append("序号: " + node.GetDisplayText(Col_Index.AbsoluteIndex) + "      记录序号: " + node.GetDisplayText(Col_RecordNum.AbsoluteIndex) + "      记录类型:" + node.GetDisplayText(Col_RecordType.AbsoluteIndex)
                        + "      记录时间:" + node.GetDisplayText(Col_RecordDT.AbsoluteIndex) + "      记录数据:" + node.GetDisplayText(Col_RecordData.AbsoluteIndex));
                    sb.Append("\r\n");
                }

                using (System.IO.FileStream file = new System.IO.FileStream(filePath, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    byte[] bytFile = Encoding.UTF8.GetBytes(sb.ToString());
                    file.Write(bytFile, 0, bytFile.Length);
                }

                MessageBox.Show("保存成功");
            }

        }

        private void cboPortName_DropDown(object sender, EventArgs e)
        {
            string portName = cboPortName.Text;
            InitComm();

            if (cboPortName.Items.Count > 0)
            {
                cboPortName.Text = cboPortName.Text;
                if (string.IsNullOrEmpty(cboPortName.Text))
                {
                    cboPortName.SelectedIndex = 0;
                }
            }
            else
            {
                cboPortName.Text = string.Empty;
            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked)
            {
                checkBox20.Checked = false;
                checkBox19.ForeColor = Color.Red;
                checkBox20.ForeColor = Color.Black;
            }
            else
            {
                checkBox19.ForeColor = Color.Black;
                checkBox20.ForeColor = Color.Red;
                checkBox20.Checked = true;
            }
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox20.Checked)
            {
                checkBox19.ForeColor = Color.Black;
                checkBox20.ForeColor = Color.Red;
                checkBox19.Checked = false;
            }
            else
            {
                checkBox19.ForeColor = Color.Black;
                checkBox20.ForeColor = Color.Red;
                checkBox19.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (alreadyClicked)
            //    return;
            //if (!alreadyClicked)
            //    alreadyClicked = true;
            button1.Enabled = false;

            try
            {
                chartChannel.Series[0].Points.Clear();
                chartChannel.Series[1].Points.Clear();

                this.Cursor = Cursors.WaitCursor;
                //EnableButton(false);

                //Application.DoEvents();
                //List<byte> lstSend = dataHandler.Send(0x13, comboBox14.SelectedIndex);

                //ShowSendData(lstSend);



                List<byte> lstRev = new List<byte>();
                lstRev.Add(0x10);
                lstRev.Add(0xFF);
                lstRev.Add(0xFE);

                lstRev.Add(0x43);
                lstRev.Add(0x6);

                lstRev.Add(0x13);

                Random rn = new Random();

                for (int i = 1; i <= 800; i++)
                {

                    if ((i < 100) || (i >= 200 && i < 300) || (i >= 400 && i < 500) || (i >= 600 && i < 700))
                    {

                        lstRev.Add((byte)(rn.Next(0, 255)));
                        lstRev.Add(0x80);
                    }
                    else if ((i >= 100 && i < 200) || (i >= 300 && i < 400) || (i >= 500 && i <= 600) || (i >= 700 && i <= 800))
                    {


                        lstRev.Add((byte)(rn.Next(0, 255)));
                        lstRev.Add(0x0);
                    }

                }

                byte[] bytcheck = GetDataCheck(lstRev.GetRange(3, lstRev.Count - 3));
                lstRev.Add(bytcheck[0]);
                lstRev.Add(bytcheck[1]);

                //string aa = "10 FF FE 0A 00 02 D0 07 01 01 00 09 1A 08 01 10 FF FE 0E 00 03 00 00 6F 00 E0 07 0A 1E 10 1E 00 BD 01";
                //string[] bb = aa.Split(' ');
                //List<byte> lstRev = new List<byte>();
                //for (int i = 0; i < bb.Length; i++)
                //    lstRev.Add(Convert.ToByte("0x" + bb[i], 16));

                serialPortHelper.LstReciveByte = lstRev;


                //RevData(0x02);

                System.Threading.Thread.Sleep(500);
            }
            finally
            {
                Application.DoEvents();
                button1.Enabled = true;
                this.Cursor = Cursors.Default;
            }
            //alreadyClicked = false;
        }
        private bool exit = false;
        private void test()
        {
            while (true)
            {
                if (exit)
                {
                    break;
                }
                List<byte> lstRev = new List<byte>();
                lstRev.Add(0x10);
                lstRev.Add(0xFF);
                lstRev.Add(0xFE);

                lstRev.Add(0x9);
                lstRev.Add(0x0);

                lstRev.Add((byte)0x10);

                Random rn = new Random();
                lstRev.Add((byte)rn.Next(0, 255));
                lstRev.Add((byte)rn.Next(0, 255));
                lstRev.Add((byte)rn.Next(0, 255));
                lstRev.Add((byte)rn.Next(0, 255));
                lstRev.Add((byte)rn.Next(0, 255));
                lstRev.Add((byte)rn.Next(0, 255));

                byte[] bytcheck = GetDataCheck(lstRev.GetRange(3, lstRev.Count - 3));
                lstRev.Add(bytcheck[0]);
                lstRev.Add(bytcheck[1]);


                serialPortHelper.LstReciveByte.AddRange(lstRev);

                Thread.Sleep(100);
            }
        }

        private void Item_Calc_Click(object sender, EventArgs e)
        {
            if (Item_Calc.Text == "进入计算差值状态")
            {
               

                //chartChannel.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.False;
                ((LineSeriesView)chartChannel.Series[0].View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                ((LineSeriesView)chartChannel.Series[1].View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                ((LineSeriesView)chartChannel.Series[0].View).LineMarkerOptions.Size = 1;
                ((LineSeriesView)chartChannel.Series[1].View).LineMarkerOptions.Size = 1;
                chartChannel.Cursor = Cursors.Hand;
                txtCalc.Text = "起点：无\r\n终点：无\r\n差值：无";
                txtCalc.Visible = true;
                Item_Calc.Text = "取消计算状态";
            }
            else
            {
   

                chartChannel.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.True;
                ((LineSeriesView)chartChannel.Series[0].View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.False;
                ((LineSeriesView)chartChannel.Series[1].View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.False;
                chartChannel.Cursor = Cursors.Default;
                txtCalc.Visible = false;
                Item_Calc.Text = "进入计算差值状态";
                sp_Start = -1;
                txtCalc.Text = "起点：无\r\n终点：无\r\n差值：无";
            }
        }

        private int x_Start = 0;
        private int clickCount = 0;
        private void chartChannel_MouseClick(object sender, MouseEventArgs e)
        {
            
            //// ChartHitInfo hitInfo = chartChannel.CalcHitInfo(e.X-100,e.Y);

            //// sp_Start = hitInfo.HitPoint.X ;
            //// //sp_Start = hitInfo.Axis.Name;
            ////txtCalc.Text = "起点：" + sp_Start.ToString() + "\r\n终点：无\r\n差值：无";
            //if (Item_Calc.Text == "取消计算状态")
            //{

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                clickCount++;
                if (clickCount >= 2)
                {
                    return;
                }
                //if (chartChannel.Series[4].Points.Count > 0)
                //{
                //    return;
                //}
                if (chartChannel.Series[0].Points.Count == 0)
                {
                    return;
                }
                if (chartChannel.Series[2].Points.Count == 0)
                {
                    SeriesPoint sp = new SeriesPoint(xValue, 800);
                    chartChannel.Series[2].Points.Add(sp);

                    SeriesPoint sp1 = new SeriesPoint(xValue, 0);
                    chartChannel.Series[3].Points.Add(sp1);
                    SeriesPoint sp2 = new SeriesPoint(xValue, 1600);
                    chartChannel.Series[3].Points.Add(sp2);

                    x_Start = e.X;
                }
                else
                {
                    if (chartChannel.Series[2].Points.Count > 1)
                    {
                        chartChannel.Series[2].Points.RemoveRange(1, chartChannel.Series[2].Points.Count-1);
                    }

                    chartChannel.Series[4].Points.Clear();
                   

                    SeriesPoint sp = new SeriesPoint(xValue, chartChannel.Series[2].Points[0].Values[0]);
                    chartChannel.Series[2].Points.Add(sp);

                    SeriesPoint sp1 = new SeriesPoint(xValue, 0);
                    chartChannel.Series[4].Points.Add(sp1);
                    SeriesPoint sp2 = new SeriesPoint(xValue, 1600);
                    chartChannel.Series[4].Points.Add(sp2);

                    //((LineSeriesView)chartChannel.Series[3].View).LineStyle.DashStyle = DashStyle.Solid;
                    //((LineSeriesView)chartChannel.Series[4].View).LineStyle.DashStyle = DashStyle.Solid;

                    //double calcValue=  Math.Abs(int.Parse(chartChannel.Series[2].Points[0].Argument)-int.Parse(chartChannel.Series[2].Points[1].Argument))*1.8;

                 
                    //lblTip.Text = "相位差：" + calcValue.ToString();
                    //lblTip.Location = new Point((int)(x_Start + (e.X - x_Start - lblTip.Width) / 2), (int)(chartChannel.Height / 2 - lblTip.Height));
                    //lblTip.Visible = true;

                    //toolTipController1.AutoPopDelay = int.MaxValue;

                    //toolTipController1.SetTitle(chartChannel, "相位差：" + calcValue.ToString());
                    //toolTipController1.ShowHint("相位差：" + calcValue.ToString());
                }
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                chartChannel.Series[2].Points.Clear();
                chartChannel.Series[3].Points.Clear();
                chartChannel.Series[4].Points.Clear();
                ((LineSeriesView)chartChannel.Series[3].View).LineStyle.DashStyle = DashStyle.Dash;
                ((LineSeriesView)chartChannel.Series[4].View).LineStyle.DashStyle = DashStyle.Dash;
                lblTip.Visible = false;
                clickCount = 0;
            }
          
        
        }

        private void chartChannel_MouseMove(object sender, MouseEventArgs e)
        {
            if (clickCount>=2)
            {
                return;
            }

            if (chartChannel.Series[0].Points.Count == 0)
            {
                return;
            }

            if (chartChannel.Series[2].Points.Count == 0)
            {
                return;
            }

            ChartHitInfo hitInfo = chartChannel.CalcHitInfo(e.Location);
            if (!hitInfo.InDiagram)
            {
                return;
            }
            //chartChannel.Series[4].Points.Clear();

            if (chartChannel.Series[2].Points.Count > 1)
            {
                if (chartChannel.Series[4].Points.Count > 0)
                {
                    chartChannel.Series[2].Points.RemoveRange(2, chartChannel.Series[2].Points.Count - 2);
                }
                else
                {
                    chartChannel.Series[2].Points.RemoveRange(1, chartChannel.Series[2].Points.Count - 1);
                }
            }

            //if (chartChannel.Series[4].Points.Count == 0)
            //{
            //if (((LineSeriesView)chartChannel.Series[3].View).LineStyle.DashStyle == DashStyle.Dash)
            //if (chartChannel.Series[4].Points.Count==0)
            {
                SeriesPoint sp = new SeriesPoint(xValue, chartChannel.Series[2].Points[0].Values[0]);
                chartChannel.Series[2].Points.Add(sp);
                //}
                chartChannel.Series[4].Points.Clear();
                SeriesPoint sp1 = new SeriesPoint(xValue, 0);
                chartChannel.Series[4].Points.Add(sp1);
                SeriesPoint sp2 = new SeriesPoint(xValue, 1600);
                chartChannel.Series[4].Points.Add(sp2);

                chartChannel.Refresh();


                int instance = Math.Abs(xValue - int.Parse(chartChannel.Series[2].Points[1].Argument));
                double calcValue = instance * 1.8;
                lblTip.Text = "相位差：" + calcValue.ToString();
                int piontCount = chartChannel.Series[0].Points.Count;
                if ((instance*1.0 / piontCount) * 844 <= lblTip.Width+20)
                {
                    lblTip.Location = new Point((int)(x_Start + (e.X - x_Start - lblTip.Width) / 2)+10, (int)(chartChannel.Height / 2));
                }
                else
                {
                    lblTip.Location = new Point((int)(x_Start + (e.X - x_Start - lblTip.Width) / 2)+10, (int)(chartChannel.Height / 2+12));
                }
                lblTip.Visible = true;
            }
            //if (sp_Start == -1)
            //{
            //    return;
            //}

            //ChartHitInfo hitInfo = chartChannel.CalcHitInfo(e.Location);

            //int sp_End = hitInfo.HitPoint.X;
            //double calcValue = (sp_End - sp_Start) * 1.8;
            //txtCalc.Text = "起点：" + sp_Start.ToString() + "\r\n终点：" + sp_End.ToString() + "\r\n差值：" + calcValue.ToString() + "度";

            //if (hitInfo.SeriesPoint != null)
            //{
            //    SeriesPoint sp_End = hitInfo.SeriesPoint ;
            //    double calcValue= (int.Parse(sp_End.Argument)-int.Parse(sp_Start.Argument))*1.8;
            //    txtCalc.Text = "起点：(" + sp_Start.Argument + "," + sp_Start.Values[0] + ")\r\n终点：(" + sp_End.Argument + "," + sp_End.Values[0] + ")\r\n差值：" + calcValue.ToString() +"度";
            //}
        }

        private void cmsChannel_Opening(object sender, CancelEventArgs e)
        {
            if (chartChannel.Series[0].Points.Count == 0)
            {
                e.Cancel = true;
            }
        }
        private double yValue = 0;
        private int xValue = 0;
        private void chartChannel_CustomDrawCrosshair(object sender, CustomDrawCrosshairEventArgs e)
        {
           foreach (CrosshairElement element in e.CrosshairElements)
           {
               SeriesPoint point = element.SeriesPoint;
               xValue = int.Parse(point.Argument);
               //txtCalc.Text = "起点：" + sp_Start.ToString() + "\r\n终点：无\r\n差值：无";
               yValue = point.Values[0];
               //SeriesPoint sp = new SeriesPoint(int.Parse(point.Argument), point.Values[0]);
               //chartChannel.Series[2].Points.Add(point);
               //startPointSelected = false;
               lblX.Text = "X轴：" + point.Argument;
               //int aaa = chartChannel.Series[1].Points.Count;
               //double nb= chartChannel.Series[1].Points[int.Parse(point.Argument)].Values[0];
               lblY.Text = "Y轴：" + chartChannel.Series[1].Points[int.Parse(point.Argument)-1].Values[0].ToString();

               //lblX.Left = groupBox10.Left + chartChannel.Left + chartChannel.Width - lblX.Width - 100;
               //lblY.Left = lblX.Left;

               lblX.Left = chartChannel.Left + chartChannel.Width - lblX.Width - 10;
               lblY.Left = lblX.Left;
               lblX.Top = chartChannel.Top + 60;
               lblY.Top = lblX.Bottom + 5;

               lblX.Visible = true;
               lblY.Visible = true;
               break;
           }

            //if (startPointSelected)
            //{
            //    foreach (CrosshairElement element in e.CrosshairElements)
            //    {
            //        SeriesPoint point = element.SeriesPoint;
            //        sp_Start = int.Parse(point.Argument);
            //        txtCalc.Text = "起点：" + sp_Start.ToString() + "\r\n终点：无\r\n差值：无";
            //        yValue = point.Values[0];
            //        SeriesPoint sp = new SeriesPoint(int.Parse(point.Argument), point.Values[0]);
            //        chartChannel.Series[2].Points.Add(point);
            //        startPointSelected = false;
            //        break;
            //    }
            //}
            //else
            //{
            //    foreach (CrosshairElement element in e.CrosshairElements)
            //    {
            //        SeriesPoint point = element.SeriesPoint;
            //        int sp_End = int.Parse(point.Argument);
            //        double calcValue = (sp_End - sp_Start) * 1.8;
            //        txtCalc.Text = "起点：" + sp_Start.ToString() + "\r\n终点：" + sp_End.ToString() + "\r\n差值：" + calcValue.ToString() + "度";

            //        SeriesPoint sp = new SeriesPoint(int.Parse(point.Argument), yValue);
            //        chartChannel.Series[2].Points.Add(point);
            //    }

            //}
          
        }

        private void btnClearAlarm_Click(object sender, EventArgs e)
        {
            treeList2.ClearNodes();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btnSaveParam_Click(object sender, EventArgs e)
        {
            try
            {
                EnableButton(false);

                this.Cursor = Cursors.WaitCursor;

                List<byte> lstSend = dataHandler.Send(0x0C, null);

                ShowSendData(lstSend);

                if (RevData(0x0C))
                {
                    MessageBox.Show("操作成功");
                }

                //MessageBox.Show("操作成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败：" + ex.Message);
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnQueryAll1_Click(object sender, EventArgs e)
        {
            try
            {
                EnableButton(false);

                this.Cursor = Cursors.WaitCursor;


                List<byte> lstSend = new List<byte>();

                lstSend = dataHandler.Send(0x02, null);
                ShowSendData(lstSend);


                if (!RevData(0x02))
                {
                    return;
                }

                System.Threading.Thread.Sleep(100);

                lstSend = dataHandler.Send(0x03, null);
                ShowSendData(lstSend);


                if (!RevData(0x03))
                {
                    return;
                }

                System.Threading.Thread.Sleep(100);

                lstSend = dataHandler.Send(0x05, null);
                ShowSendData(lstSend);
                if (!RevData(0x05))
                {
                    return;
                }

                System.Threading.Thread.Sleep(100);

                lstSend = dataHandler.Send(0x07, null);
                ShowSendData(lstSend);
                if (!RevData(0x07))
                {
                    return;
                }

                System.Threading.Thread.Sleep(100);

                lstSend = dataHandler.Send(0x09, null);
                ShowSendData(lstSend);
                if (!RevData(0x09))
                {
                    return;
                }

                System.Threading.Thread.Sleep(100);

                lstSend = dataHandler.Send(0x0B, null);
                ShowSendData(lstSend);
                if (!RevData(0x0B))
                {
                    return;
                }
            }
            catch
            {
                MessageBox.Show("请检测串口");
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnClearAll1_Click(object sender, EventArgs e)
        {
       
            dtpSystem.CustomFormat = " ";

            textBox30.Text = "";
          
            ((UpDownBase)numericUpDown1).Text = "";
        
            comboBox16.SelectedIndex = -1;

            
            comboBox1.SelectedIndex = -1;//int.Parse(ClsIniOperation.ReadIni("SystemParam", "SendInterval"));

        
             comboBox2.SelectedIndex = -1;//int.Parse(ClsIniOperation.ReadIni("SystemParam", "SendStrength"));

            ((UpDownBase)numericUpDown2).Text = "";

            comboBox3.SelectedIndex = -1;// int.Parse(ClsIniOperation.ReadIni("SystemParam", "ChannelMode"));

            comboBox4.SelectedIndex = -1;//int.Parse(ClsIniOperation.ReadIni("SystemParam", "InterferenceDetection"));


            comboBox5.SelectedIndex = -1;//int.Parse(ClsIniOperation.ReadIni("SystemParam", "SignDetection"));


            comboBox6.SelectedIndex = -1;// int.Parse(ClsIniOperation.ReadIni("SystemParam", "DecodingFilterA"));


            comboBox7.SelectedIndex = -1;// int.Parse(ClsIniOperation.ReadIni("SystemParam", "DecodingFilterB"));


            comboBox8.SelectedIndex = -1;// int.Parse(ClsIniOperation.ReadIni("SystemParam", "DecodingFilterC"));

            comboBox9.SelectedIndex = -1;// .Parse(ClsIniOperation.ReadIni("SystemParam", "DecodingFilterD"));

            comboBox17.SelectedIndex = -1;
            comboBox20.SelectedIndex = -1;
            comboBox22.SelectedIndex = -1;

            comboBox18.SelectedIndex = -1;
            comboBox19.SelectedIndex = -1;
            comboBox21.SelectedIndex = -1;

            comboBox23.SelectedIndex = -1;
            comboBox24.SelectedIndex = -1;
            comboBox25.SelectedIndex = -1;
            comboBox26.SelectedIndex = -1;
            comboBox27.SelectedIndex = -1;
            comboBox28.SelectedIndex = -1;


            comboBox10.SelectedIndex = -1;//int.Parse(ClsIniOperation.ReadIni("CH1", "Buzze"));


            comboBox11.SelectedIndex = -1;//int.Parse(ClsIniOperation.ReadIni("CH2", "Buzze"));



            comboBox12.SelectedIndex = -1;//int.Parse(ClsIniOperation.ReadIni("CH3", "Buzze"));


            comboBox13.SelectedIndex = -1;//int.Parse(ClsIniOperation.ReadIni("Phase", "Channel"));
        }

      

        private void btnClearAll2_Click(object sender, EventArgs e)
        {
            textBox31.Text = "";
            textBox32.Text = "";
            textBox33.Text = "";
            textBox34.Text = "";
            textBox35.Text = "";
            textBox36.Text = "";

            ((UpDownBase)numericUpDown3).Text = "";

            comboBox30.SelectedIndex = -1;
            comboBox31.SelectedIndex = -1;
            comboBox32.SelectedIndex = -1;
            comboBox33.SelectedIndex = -1;
            comboBox34.SelectedIndex = -1;
            comboBox29.SelectedIndex = -1;

        }

        private void btnSetRandom_Click(object sender, EventArgs e)
        {
            try
            {
                //byte byt1 = 0;
                byte byt1 = Convert.ToByte(textBox36.Text, 16);
                //bool result = byte.TryParse("0x" + textBox36.Text, out byt1);
                //if (!result)
                //{
                //    MessageBox.Show("参数设置有误");
                //    return;
                //}

                byte byt2 = Convert.ToByte(textBox35.Text, 16);
                //result = byte.TryParse(textBox35.Text, out byt2);
                //if (!result)
                //{
                //    MessageBox.Show("参数设置有误");
                //    return;
                //}

                if (comboBox29.Text == "")
                {
                    MessageBox.Show("参数设置有误");
                    return;
                }

                bShowMessage = true;

                EnableButton(false);

                //returnValue = string.Empty;
                //bStop = true;

                //System.Threading.Thread.Sleep(100);

                this.Cursor = Cursors.WaitCursor;

                RandomModel randomModel = new RandomModel();
                randomModel.Data1 = byt1;
                randomModel.Data2 = byt2;
                randomModel.ModelType = comboBox29.SelectedIndex;

                List<byte> lstSend = dataHandler.Send(0x60, randomModel);

                //ShowSendData(lstSend);

                if (RevData(0x60))
                {
                    //System.Threading.Thread.Sleep(100);
                   // MessageBox.Show(dataHandler.DataValue.ToString());

                    //MessageBox.Show("操作成功");
                }
                //MessageBox.Show("操作成功");
            }
            catch
            {
                MessageBox.Show("参数设置有误");
                //MessageBox.Show("请检测串口");
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;

                //bStop = false;
            }


        }

        private void btnSetMidu_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox30.Text == "")
                {
                    MessageBox.Show("参数设置有误");
                    return;
                }

                bShowMessage = true;

                EnableButton(false);

                this.Cursor = Cursors.WaitCursor;

                byte data = 5;
                if (comboBox30.SelectedIndex == 0)
                {
                    data = 5;
                }
                else if (comboBox30.SelectedIndex == 1)
                {
                    data = 4;
                }
                else if (comboBox30.SelectedIndex == 2)
                {
                    data = 3;
                }

                List<byte> lstSend = dataHandler.Send(0x61, data);

                ShowSendData(lstSend);

                if (RevData(0x61))
                {
                    //MessageBox.Show("操作成功");
                }
                //MessageBox.Show("操作成功");
            }
            catch
            {
                //MessageBox.Show("请检测串口");
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSetTongbu_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox31.Text == "")
                {
                    MessageBox.Show("参数设置有误");
                    return;
                }

                bShowMessage = true;

                EnableButton(false);

                this.Cursor = Cursors.WaitCursor;

                byte data = (byte)(comboBox31.SelectedIndex == 0 ? 1 : 0);
                

                List<byte> lstSend = dataHandler.Send(0x62, data);

                ShowSendData(lstSend);

                if (RevData(0x62))
                {
                    //MessageBox.Show("操作成功");
                }
                //MessageBox.Show("操作成功");
            }
            catch
            {
               // MessageBox.Show("请检测串口");
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSetNoise_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox32.Text == "")
                {
                    MessageBox.Show("参数设置有误");
                    return;
                }

                bShowMessage = true;

                EnableButton(false);

                this.Cursor = Cursors.WaitCursor;

                byte data = (byte)(comboBox32.SelectedIndex == 0 ? 1 : 0);


                List<byte> lstSend = dataHandler.Send(0x63, data);

                ShowSendData(lstSend);

                if (RevData(0x63))
                {
                    //MessageBox.Show("操作成功");
                }
                //MessageBox.Show("操作成功");
            }
            catch
            {
               // MessageBox.Show("请检测串口");
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSetXinhao_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox33.Text == "")
                {
                    MessageBox.Show("参数设置有误");
                    return;
                }

                bShowMessage = true;

                EnableButton(false);

                this.Cursor = Cursors.WaitCursor;

                byte data = (byte)(comboBox33.SelectedIndex == 0 ? 1 : 0);


                List<byte> lstSend = dataHandler.Send(0x64, data);

                ShowSendData(lstSend);

                if (RevData(0x64))
                {
                    //MessageBox.Show("操作成功");
                }
                //MessageBox.Show("操作成功");
            }
            catch
            {
                //MessageBox.Show("请检测串口");
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSetGongpin_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox34.Text == "")
                {
                    MessageBox.Show("参数设置有误");
                    return;
                }

                bShowMessage = true;

                EnableButton(false);

                this.Cursor = Cursors.WaitCursor;

                byte data = (byte)comboBox34.SelectedIndex;


                List<byte> lstSend = dataHandler.Send(0x0D, data);

                ShowSendData(lstSend);

                if (RevData(0x0D))
                {
                    //MessageBox.Show("操作成功");
                }
                //MessageBox.Show("操作成功");
            }
            catch
            {
                //MessageBox.Show("请检测串口");
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (((UpDownBase)numericUpDown3).Text == "")
                {
                    MessageBox.Show("参数设置有误");
                    return;
                }

                bShowMessage = true;

                EnableButton(false);

                this.Cursor = Cursors.WaitCursor;

                byte data = (byte)numericUpDown3.Value;


                List<byte> lstSend = dataHandler.Send(0x65, data);

                ShowSendData(lstSend);

                if (RevData(0x65))
                {
                    //MessageBox.Show("操作成功");
                }
                //MessageBox.Show("操作成功");
            }
            catch
            {
                //MessageBox.Show("请检测串口");
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnQueryCheck_Click(object sender, EventArgs e)
        {
            try
            {
                textBox31.Text = "";
                textBox32.Text = "";
                textBox33.Text = "";
                textBox34.Text = "";

                EnableButton(false);

                this.Cursor = Cursors.WaitCursor;
 
                List<byte> lstSend = dataHandler.Send(0x68, null);

                //ShowSendData(lstSend);

                if (RevData(0x68))
                {
                    MessageBox.Show("操作成功");
                }
                //MessageBox.Show("操作成功");
            }
            catch
            {
                MessageBox.Show("请检测串口");
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }


        }

        private void btnQueryAll2_Click(object sender, EventArgs e)
        {
            try
            {
                EnableButton(false);

                this.Cursor = Cursors.WaitCursor;


                List<byte> lstSend = new List<byte>();

                lstSend = dataHandler.Send(0x68, null);
                //ShowSendData(lstSend);


                if (!RevData(0x68))
                {
                    return;
                }

                System.Threading.Thread.Sleep(100);

                lstSend = dataHandler.Send(0x6E, null);
                //ShowSendData(lstSend);


                if (!RevData(0x6E))
                {
                    return;
                }

                System.Threading.Thread.Sleep(100);

                lstSend = dataHandler.Send(0x69, null);
                //ShowSendData(lstSend);
                if (!RevData(0x69))
                {
                    return;
                }

                System.Threading.Thread.Sleep(100);

                lstSend = dataHandler.Send(0x6A, null);
                //ShowSendData(lstSend);
                if (!RevData(0x6A))
                {
                    return;
                }

                System.Threading.Thread.Sleep(100);

                lstSend = dataHandler.Send(0x6B, null);
                //ShowSendData(lstSend);
                if (!RevData(0x6B))
                {
                    return;
                }

                System.Threading.Thread.Sleep(100);

                lstSend = dataHandler.Send(0x6C, null);
                //ShowSendData(lstSend);
                if (!RevData(0x6C))
                {
                    return;
                }

                System.Threading.Thread.Sleep(100);

                lstSend = dataHandler.Send(0x6D, null);
                //ShowSendData(lstSend);
                if (!RevData(0x6D))
                {
                    return;
                }

                System.Threading.Thread.Sleep(100);

                lstSend = dataHandler.Send(0x0E, null);
                //ShowSendData(lstSend);
                if (!RevData(0x0E))
                {
                    return;
                }
            }
            catch
            {
                MessageBox.Show("请检测串口");
            }
            finally
            {
                Application.DoEvents();
                EnableButton(true);
                this.Cursor = Cursors.Default;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataHandler.Send(0x6D, null);
            //ShowSendData(lstSend);
            if (!RevData(0x6D))
            {
                //return;
            }
        }

        private void btnWindow_Click(object sender, EventArgs e)
        {
            FrmWindow frmWindow = new FrmWindow(this, this.Width, this.Height);
            frmWindow.ShowDialog(this);
        }

 
    }
}
