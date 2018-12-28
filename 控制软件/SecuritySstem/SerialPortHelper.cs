using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace SecuritySstem
{
    public class SerialPortHelper
    {
        private SerialPort serialPort = null;   //串口对象
        private string portName = "COM1";


        //private bool isNormalFrame = false;

        //private byte returnType = 0;

        private List<byte> lstReciveByte = null;   //所有接受字节集合
        //private List<byte> lstDataDomain = null;   //有效数据字节集合
 
        //private List<byte> lstRead = null;

        //private int frameLen = 0;      //当前帧长度

        public List<byte> LstReciveByte
        {
            get { return lstReciveByte; }
            set { lstReciveByte = value; }
        }

        //public bool IsNormalFrame
        //{
        //    get { return isNormalFrame; }
        //    set { isNormalFrame = value; }
        //}

        //public byte ReturnType
        //{
        //    get { return returnType; }
        //}

        public string PortName
        {
            get { return portName; }
            set { portName = value; }
        }

        //public List<byte> LstDataDomain
        //{
        //    get { return lstDataDomain; }
        //}

        //public List<byte> LstRead
        //{
        //    get { return lstRead; }
        //}

        public SerialPortHelper( )
        {
         
            this.lstReciveByte = new List<byte>();
            //this.lstDataDomain = new List<byte>();
           
            //this.lstRead = new List<byte>();

            //serialPort = new SerialPort();

            //注册接收事件
            //serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
        }

        public bool Open()
        {
            try
            {
                //if (serialPort.IsOpen)
                //{
                //    serialPort.Close();
                //    serialPort.Dispose();
                //}
                if (serialPort != null)
                {
                    serialPort.Close();
                    serialPort.Dispose();
                }

                serialPort = new SerialPort();
                serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);

                serialPort.PortName = portName;
                serialPort.BaudRate = 115200;

                serialPort.Parity = Parity.None;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;

                serialPort.RtsEnable = true;
                serialPort.DtrEnable = true;
                serialPort.ReceivedBytesThreshold = 1;

                serialPort.Open();
            }
            catch(Exception ex)
            {
                string aa = ex.Message;
                //serialPort.Dispose();
                //serialPort = new SerialPort();
                return false;
            }

            serialPort.DiscardInBuffer();
            serialPort.DiscardOutBuffer();
 
            return true;
        }

        public bool Close()
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    try
                    {
                        serialPort.Close();
                        serialPort.Dispose();
                    }
                    catch
                    {
                        serialPort.Dispose();
                        return false;
                    }
                }

                return true;
            }
            catch
            {
                //serialPort.Dispose();
                return false;
            }
        }

        //public void ClearResult()
        //{
        //    isNormalFrame = false;
        //    returnType = 0;
        //    //lstReciveByte.Clear();
        //    lstDataDomain.Clear();
          
        //    lstRead.Clear();
        //}

        public void Write(byte[] buffer, int offset, int count)
        {
            //先清除上次结果
            //ClearResult();
            //lstReciveByte.Clear();

            int sendCount = 0;
            if (count % 8 == 0)
            {
                sendCount = count / 8;
            }
            else
            {
                sendCount = count / 8 + 1;
            }

            for (int i = 0; i < sendCount - 1; i++)
            {
                byte[] temp = new byte[8];
                for (int j = 0; j < 8; j++)
                {
                    temp[j] = buffer[i * 8 + j];
                }
                //serialPort.Write(buffer, 0, buffer.Length);
                serialPort.Write(temp, 0, 8);
                System.Threading.Thread.Sleep(150);
            }

            int lastCount = count - (sendCount - 1) * 8;
            byte[] last = new byte[lastCount];
            for (int i = 0; i < lastCount; i++)
            {
                last[i] = buffer[(sendCount - 1) * 8 + i];
            }
            serialPort.Write(last, 0, lastCount);
        }


        //private byte[] GetDataCheck(int frameLen)
        //{
        //    byte[] bytResult = new byte[2];

        //    int sumCheck = 0;
        //    for (int i = 3; i < lstReciveByte.Count-2; i++)
        //    {
        //        sumCheck += lstReciveByte[i];
        //    }

        //    string temp = sumCheck.ToString("X4");

        //    bytResult[0] = Convert.ToByte("0x" + temp.Substring(temp.Length - 2, 2), 16);
        //    bytResult[1] = Convert.ToByte("0x" + temp.Substring(temp.Length - 4, 2), 16);

        //    return bytResult;
        //}

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //获取从缓冲区中得到的字节数
            int byteSum = serialPort.BytesToRead;
            byte[] buffer = new byte[byteSum];

            //从缓冲区中读取数据到数组
            serialPort.Read(buffer, 0, byteSum);

            //添加本次接收的字节到接收集合

            lstReciveByte.AddRange(buffer);

            //int revLength = lstReciveByte.Count;

            //if (lstReciveByte.Count >= 8)
            //{
            //    if (lstReciveByte[0] == 0x10 && lstReciveByte[1] == 0xFF && lstReciveByte[2] == 0xFE)  //识别帧
            //    {
            //        int dataLength = lstReciveByte[4] * 256 + lstReciveByte[3];
            //        //if (dataLength == revLength - 5)      //长度
            //        {
            //            int frameLen = dataLength + 5;
            //            if (revLength >= frameLen)
            //            {
            //                byte[] bytCheck = GetDataCheck(frameLen);
            //                if (bytCheck[1] == lstReciveByte[frameLen - 1] && bytCheck[0] == lstReciveByte[frameLen - 2])  //校验和
            //                {
            //                    lstRead.AddRange(lstReciveByte);

            //                    lstDataDomain.AddRange(lstReciveByte.GetRange(5, dataLength - 2));

            //                    returnType = lstDataDomain[0];

            //                    isNormalFrame = true;

            //                    //lstReciveByte.Clear();
            //                }

            //                lstReciveByte.RemoveRange(0, frameLen);
            //            }
            //        }
            //    }
            //}

          

        }
    }
}
