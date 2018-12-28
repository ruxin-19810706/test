using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SecuritySstem.Object;
using System.Windows.Forms;

namespace SecuritySstem
{
    public class DataHandler
    {
        private SerialPortHelper serialPortHelper = null;  //通讯帮助类

        private bool isNormalFrame = false;

        private byte returnType = 0;
 
         
        private List<byte> lstDataDomain = null;   //有效数据字节集合

        private List<byte> lstRead = null;

        public bool IsNormalFrame
        {
            get { return isNormalFrame; }
            set { isNormalFrame = value; }
        }

        public byte ReturnType
        {
            get { return returnType; }
        }
 
        public List<byte> LstDataDomain
        {
            get { return lstDataDomain; }
        }

        public List<byte> LstRead
        {
            get { return lstRead; }
        }
 
        public DataHandler(SerialPortHelper serialPortHelper)
        {
            this.serialPortHelper = serialPortHelper;

            lstDataDomain = new List<byte>();
            lstRead = new List<byte>();
        }

        /// <summary>
        /// 发送数据 
        /// </summary>
        /// <param name="obj"></param>
        public List<byte> Send(byte orderCode, object obj)
        {
            List<byte> checkList = new List<byte>();

            switch (orderCode)
            {
                case 0x01:              //设置单板时间
                    if (obj is SystemDT)
                    {
                        SystemDT systemDT = (SystemDT)obj;
                        //数据长度 
                        checkList.Add(0x0A);
                        checkList.Add(0x00);
                        //命令
                        checkList.Add(orderCode);
                        //数据
                        checkList.AddRange(GetBytesFromSystemDT(systemDT));
                    }
                    break;
                case 0x02:         //查询单板时间
                case 0x03:         //查询单板版本信息
                case 0x05:         //查询系统参数
                case 0x07:         //查询CH1参数
                case 0x09:         //查询CH2参数
                case 0x0B:         //查询CH3参数
                case 0x0C:         //保存参数
                case 0x10:         //显示通道信号强度
                case 0x11:         //关闭信号强度显示
                case 0x14:         //退出上传通道信号
                case 0x20:         //上传单板报警记录

                case 0x68:         //查询效验码
                case 0x6E:
                case 0x69:
                case 0x6A:
                case 0x6B:
                case 0x6C:
                case 0x6D:
                case 0x0E:  
                    //数据长度 
                    checkList.Add(0x03);
                    checkList.Add(0x00);
                    //命令
                    checkList.Add(orderCode);
                    break;
                case 0x04:         //系统参数设置
                    if (obj is SystemParam)
                    {
                        SystemParam systemParam = (SystemParam)obj;
                        //数据长度 
                        checkList.Add(0x10);
                        checkList.Add(0x00);
                        //命令
                        checkList.Add(orderCode);
                        //数据
                        checkList.AddRange(GetBytesFromSystemParam(systemParam));
                    }
                    break;
                case 0x06:         //设置CH1参数
                case 0x08:         //设置CH2参数
                case 0x0A:         //设置CH3参数
                    if (obj is ChannelParam)
                    {
                        ChannelParam channelParam = (ChannelParam)obj;
                        //数据长度 
                        checkList.Add(0x07);
                        checkList.Add(0x00);
                        //命令
                        checkList.Add(orderCode);
                        //数据
                        checkList.AddRange(GetBytesFromChannelParam(channelParam));
                    }
                    break;
                case 0x12:         //检测周围相位
                case 0x13:         //上传通道信号

                    //数据长度 
                    checkList.Add(0x04);
                    checkList.Add(0x00);
                    //命令
                    checkList.Add(orderCode);
                    //数据
                    checkList.Add(byte.Parse(obj.ToString()));

                    break;
                case 0x15:         //设置调试相位

                    //数据长度 
                    checkList.Add(0x08);
                    checkList.Add(0x00);
                    //命令
                    checkList.Add(orderCode);

                    //数据
                    float f = float.Parse(obj.ToString());
                    checkList.AddRange(BitConverter.GetBytes(f));
                    checkList.Add((byte)FrmMain.phaseIndex);

                    break;

                case 0x60:   //设置随机数

                    //数据长度 
                    checkList.Add(0x06);
                    checkList.Add(0x00);
                    //命令
                    checkList.Add(orderCode);

                    //数据
                    RandomModel randomModel = (RandomModel)obj;
                    checkList.AddRange(GetBytesFromRandomModel(randomModel));
 
                    break;

                case 0x61:   //设置发射密度
                case 0x62:   //设置同步
                case 0x63:   //设置噪声抑制
                case 0x64:   //设置信号抑制
                case 0x65:   //设置可调间隔
                case 0x0D:   //设置信号抑制
                    //数据长度 
                    checkList.Add(0x04);
                    checkList.Add(0x00);
                    //命令
                    checkList.Add(orderCode);

                    //数据
                    checkList.Add(byte.Parse(obj.ToString()));

                    break;
            }

            byte[] bytCheck = GetDataCheck(checkList);

            List<byte> sendList = new List<byte>();

            sendList.Add(0x10);
            sendList.Add(0xFF);
            sendList.Add(0xFE);
            sendList.AddRange(checkList);
            sendList.AddRange(bytCheck);

            isNormalFrame = false;
            serialPortHelper.Write(sendList.ToArray(), 0, sendList.Count);

            return sendList;
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

        private List<byte> GetBytesFromRandomModel(RandomModel randomModel)
        {
            List<byte> bytList = new List<byte>();


            bytList.Add((byte)randomModel.Data1);
            bytList.Add((byte)randomModel.Data2);
            bytList.Add((byte)randomModel.ModelType);
 

            return bytList;
        }

        private List<byte> GetBytesFromSystemDT(SystemDT systemDT)
        {
            List<byte> bytList = new List<byte>();

            string strHex = string.Empty;

            strHex = systemDT.Year.ToString("X4");
            bytList.Add(Convert.ToByte("0x" + strHex.Substring(2, 2), 16));
            bytList.Add(Convert.ToByte("0x" + strHex.Substring(0, 2), 16));
            bytList.Add((byte)systemDT.Month);
            bytList.Add((byte)systemDT.Day);
            bytList.Add((byte)systemDT.Hour);
            bytList.Add((byte)systemDT.Minute);
            bytList.Add((byte)systemDT.Second);

            return bytList;
        }

        private List<byte> GetBytesFromSystemParam(SystemParam systemParam)
        {
            List<byte> bytList = new List<byte>();

            string strHex = string.Empty;

            //byte[] bytPahse = BitConverter.GetBytes(systemParam.Phase);
            strHex = systemParam.Phase.ToString("X4");
            bytList.Add(Convert.ToByte("0x" + strHex.Substring(2, 2), 16));
            bytList.Add(Convert.ToByte("0x" + strHex.Substring(0, 2), 16));

            //strHex = systemParam.Frequency.ToString("X4");
            //bytList.Add(Convert.ToByte("0x" + strHex.Substring(2, 2), 16));
            //bytList.Add(Convert.ToByte("0x" + strHex.Substring(0, 2), 16));

            bytList.Add((byte)systemParam.Frequency);

            bytList.Add((byte)systemParam.SendInterval);
            bytList.Add((byte)systemParam.SendStrength);
            bytList.Add((byte)systemParam.RevDelay);
            bytList.Add((byte)systemParam.ChannelMode);
            bytList.Add((byte)systemParam.InterferenceDetection);
            bytList.Add((byte)systemParam.SignDetection);
            bytList.Add((byte)systemParam.DecodingFilterA);
            bytList.Add((byte)systemParam.DecodingFilterB);
            bytList.Add((byte)systemParam.DecodingFilterC);
            bytList.Add((byte)systemParam.DecodingFilterD);

            return bytList;
        }

        private List<byte> GetBytesFromChannelParam(ChannelParam channelParam)
        {
            List<byte> bytList = new List<byte>();

            sbyte sbyt = (sbyte)channelParam.AlarmThreshold;
            bytList.Add((byte)sbyt);

            byte byt = 0;
            byt = (byte)(byt | channelParam.TX);
            byt = (byte)(byt | (channelParam.RX<<1));
            //byt = (byte)(byt | (channelParam.Sign3<<2));

            bytList.Add(byt);

            bytList.Add((byte)channelParam.Buzzer);

            bytList.Add((byte)channelParam.ChannelGain);

            return bytList;
        }
 
        /// <summary>
        /// 得到的记录数据
        /// </summary>
        public object DataValue
        {
            get
            {
                //return GetDataValue(serialPortHelper.LstDataDomain);
                lock (newObj)
                {
                    return GetDataValue(serialPortHelper.LstReciveByte);
                }
   
            }
        }

        object newObj = new object();

        /// <summary>
        /// 返回记录数据
        /// </summary>
        /// <param name="lstDataDomain">数据域数组</param>
        /// <returns></returns>
        //public object GetDataValue(List<byte> lstDataDomain)
        public object GetDataValue(List<byte> lstReciveByte)
        {
            //如果返回不是正常应答帧  返回空
            //if (!serialPortHelper.IsNormalFrame)
            //{
            //    return null;
            //}
             
 
            //lstClone.AddRange(lstDataDomain);

            //isNormalFrame = false;
            returnType = 0;
            lstDataDomain.Clear();
            lstRead.Clear();

            int revLength = lstReciveByte.Count;
            if (revLength >= 8)
            {
                if (lstReciveByte[0] == 0x10 && lstReciveByte[1] == 0xFF && lstReciveByte[2] == 0xFE)  //识别帧
                {
                    int dataLength = lstReciveByte[4] * 256 + lstReciveByte[3];

                    int frameLen = dataLength + 5;
                    if (revLength >= frameLen)
                    {
                        List<byte> checkList = lstReciveByte.GetRange(3, dataLength);
                        byte[] bytCheck = GetDataCheck(checkList);
                        if (bytCheck[1] == lstReciveByte[frameLen - 1] && bytCheck[0] == lstReciveByte[frameLen - 2])  //校验和
                        {
                            lstRead.AddRange(lstReciveByte.GetRange(0, frameLen));

                            lstDataDomain.AddRange(lstReciveByte.GetRange(5, dataLength - 2));

                            returnType = lstDataDomain[0];

                            isNormalFrame = true;

                            Application.DoEvents();
                            //System.Threading.Thread.Sleep(50);
                            //lstReciveByte.Clear();
                        }
                        //else
                        //{
                        //    byte a = lstReciveByte[frameLen - 1];
                        //    byte b = lstReciveByte[frameLen - 2];
                        //    isNormalFrame = true;
                        //    returnType = 0x20;
                        //    lstDataDomain.AddRange(lstReciveByte.GetRange(5, dataLength - 2));
                        //    lstRead.AddRange(lstReciveByte.GetRange(0, frameLen));
                        //}

                        lstReciveByte.RemoveRange(0, frameLen);
                    }

                }
            }

            

            if (!isNormalFrame)
            {
                return null;
            }

            //创建一个新集合  克隆数据域数据
            List<byte> lstClone = new List<byte>();
            lstClone.AddRange(lstDataDomain);

            object obj = null;

            if (lstClone.Count > 1)
            {
                switch (lstClone[0])
                {
                    case 0x01:              //设置单板时间
                    case 0x04:              //系统参数设置
                    case 0x06:              //设置CH1参数
                    case 0x08:              //设置CH2参数
                    case 0x0A:              //设置CH3参数
                    case 0x0C:              //保存参数
                    case 0x11:              //关闭信号强度显示
                    case 0x14:              //退出上传通道信号
                    case 0x15:              //设置调试相位

                    case 0x60:
                    case 0x61:
                    case 0x62:
                    case 0x63:
                    case 0x64:
                    case 0x65:
                    case 0x0D:
                        if (lstClone[1] == 0)
                        {
                            obj = "操作成功";
                            // MessageBox.Show("操作成功");
                        }
                        else if (lstClone[1] == 1)
                        {
                            obj = "参数错误";
                            //MessageBox.Show("参数错误");
                        }
                        else
                        {
                            obj = "无效";
                            //MessageBox.Show("无效");
                        }
                        break;
                    case 0x68:
                        if (lstClone.Count == 5)
                        {
                            CheckCode checkCode = new CheckCode();
                            checkCode.Data1 = lstClone[1];
                            checkCode.Data2 = lstClone[2];
                            checkCode.Data3 = lstClone[3];
                            checkCode.Data4 = lstClone[4];
                            obj = checkCode;
                        }
                        break;
                    case 0x6E:
                        if (lstClone.Count == 2)
                        {
                            RandomModel randomModel = new RandomModel();
                            randomModel.ModelType = lstClone[1];
                            obj = randomModel;
                        }
                        break;
                    case 0x69:
                        if (lstClone.Count == 2)
                        {
                            MiduParam param = new MiduParam();
                            param.Data = lstClone[1];
                            obj = param;
                        }
                        break;
                    case 0x6A:
                        if (lstClone.Count == 2)
                        {
                            TongbuParam param = new TongbuParam();
                            param.Data = lstClone[1];
                            obj = param;
                        }
                        break;
                    case 0x6B:
                        if (lstClone.Count == 2)
                        {
                            NoiseParam param = new NoiseParam();
                            param.Data = lstClone[1];
                            obj = param;
                        }
                        break;
                    case 0x6C:
                        if (lstClone.Count == 2)
                        {
                            XinhaoParam param = new XinhaoParam();
                            param.Data = lstClone[1];
                            obj = param;
                        }
                        break;
                    case 0x6D:
                        if (lstClone.Count == 2)
                        {
                            InterverParam param = new InterverParam();
                            param.Data = lstClone[1];
                            obj = param;
                        }
                        break;
                    case 0x0E:
                        if (lstClone.Count == 2)
                        {
                            GongpinParam param = new GongpinParam();
                            param.Data = lstClone[1];
                            obj = param;
                        }
                        break;
                    case 0x02:              //查询单板时间
                        if (lstClone.Count == 8)
                        {
                            SystemDT systemDT = new SystemDT();
                            systemDT.Year = lstClone[2] * 256 + lstClone[1];
                            systemDT.Month = lstClone[3];
                            systemDT.Day = lstClone[4];
                            systemDT.Hour = lstClone[5];
                            systemDT.Minute = lstClone[6];
                            systemDT.Second = lstClone[7];
                            obj = systemDT;
                        }
                        break;
                    case 0x03:              //查询单板版本信息
                        if (lstClone.Count == 12)
                        {
                            VersionInfo versionInfo = new VersionInfo();
                            versionInfo.SoftVersion = lstClone[1] + "." + lstClone[2] + "." + lstClone[3] + "." + lstClone[4];
                            versionInfo.CompileDT = new SystemDT();
                            versionInfo.CompileDT.Year = lstClone[6] * 256 + lstClone[5];
                            versionInfo.CompileDT.Month = lstClone[7];
                            versionInfo.CompileDT.Day = lstClone[8];
                            versionInfo.CompileDT.Hour = lstClone[9];
                            versionInfo.CompileDT.Minute = lstClone[10];
                            versionInfo.CompileDT.Second = lstClone[11];
                            obj = versionInfo;
                        }
                        break;
                    case 0x05:              //查询系统参数
                        if (lstClone.Count == 14)
                        {
                            SystemParam systemParam = new SystemParam();
                             //byte[] phase = lstClone.GetRange(1, 4).ToArray();
                            //phase = phase.Reverse().ToArray();
                            systemParam.Phase = lstClone[2] * 256 + lstClone[1];
                            systemParam.Frequency = lstClone[3];
                            systemParam.SendInterval = lstClone[4];
                            systemParam.SendStrength = lstClone[5];
                            systemParam.RevDelay = lstClone[6];
                            systemParam.ChannelMode = lstClone[7];
                            systemParam.InterferenceDetection = lstClone[8];
                            systemParam.SignDetection = lstClone[9];
                            systemParam.DecodingFilterA = lstClone[10];
                            systemParam.DecodingFilterB = lstClone[11];
                            systemParam.DecodingFilterC = lstClone[12];
                            systemParam.DecodingFilterD = lstClone[13];
                            obj = systemParam;
                        }
                        break;
                    case 0x07:              //查询CH1参数
                    case 0x09:              //查询CH2参数
                    case 0x0B:              //查询CH3参数
                        if (lstClone.Count == 5)
                        {
                            ChannelParam channelParam = new ChannelParam();
                            channelParam.AlarmThreshold =lstClone[1];
                            //channelParam.Sign1 = lstClone[2] & 0x01;
                            //channelParam.Sign2 = (lstClone[2] >> 1) & 0x01;
                            //channelParam.Sign3 = (lstClone[2] >> 2) & 0x01;
                            channelParam.TX = lstClone[2] & 0x01;
                            channelParam.RX = (lstClone[2] >> 1) & 0x01;
                            channelParam.Buzzer = lstClone[3];
                            channelParam.ChannelGain = lstClone[4];
                            obj = channelParam;
                        }
                        break;
                    case 0x10:              //显示通道信号强度
                        if (lstClone.Count == 7)
                        {
                            ChannelSignStrength channelSignStrength = new ChannelSignStrength();
                            channelSignStrength.Ch1Noise = lstClone[1];
                            channelSignStrength.Ch1Sign = lstClone[2];
                            channelSignStrength.Ch2Noise = lstClone[3];
                            channelSignStrength.Ch2Sign = lstClone[4];
                            channelSignStrength.Ch3Noise = lstClone[5];
                            channelSignStrength.Ch3Sign = lstClone[6];
                            obj = channelSignStrength;
                        }
                        break;
                    case 0x12:              //检测周围相位
                        if (lstClone.Count == 33)
                        {
                            List<string> phaseList = new List<string>();
                            for (int i = 0; i < 16; i++)
                            {
                                int temp = lstClone[i * 2 + 2] * 256 + lstClone[i * 2 + 1];
                                if (temp == 65535)
                                {
                                    phaseList.Add("无");
                                }
                                else
                                {
                                    double fTemp = temp * 0.1;
                                    phaseList.Add(fTemp.ToString("0.0"));
                                }
                                
                            }
                            obj = phaseList;
                        }
                        break;
                    case 0x13:              //上传通道信号
                        //if (lstClone.Count == 601)
                        {
                            int number = (lstClone.Count - 1) / 2;
                            UploadChannelSign ucs = new UploadChannelSign();
                            ucs.Bit15List = new List<int>();
                            ucs.Bit0_14List = new List<int>();
                            for (int i = 0; i < number; i++)
                            {
                                if ((lstClone[i * 2 + 2] >> 7) == 1)
                                {
                                    ucs.Bit15List.Add(1600);
                                }
                                else
                                {
                                    ucs.Bit15List.Add(0);
                                }
                                // ucs.Bit15List.Add((lstClone[i * 2 + 2] >> 15) & 0x80);
                                ucs.Bit0_14List.Add((lstClone[i * 2 + 2] & 0x7F) * 256 + lstClone[i * 2 + 1]);
                            }
                            obj = ucs;
                        }
                        break;
                    case 0x20:              //上传单板报警记录

                        List<AlarmRecord> arList = new List<AlarmRecord>();
                        int count = (lstClone.Count - 1) / 16;

                        for (int i = 0; i < count; i++)
                        {
                            AlarmRecord ar = new AlarmRecord();

                            ar.index = i + 1;
                            ar.Number = lstClone[i * 16 + 1];
                            ar.Code = lstClone[i * 16 + 2];
                            ar.RecordDT = new SystemDT();
                            ar.RecordDT.Year = 2000 + lstClone[i * 16 + 3];
                            ar.RecordDT.Month = lstClone[i * 16 + 4];
                            ar.RecordDT.Day = lstClone[i * 16 + 5];
                            ar.RecordDT.Hour = lstClone[i * 16 + 6];
                            ar.RecordDT.Minute = lstClone[i * 16 + 7];
                            ar.RecordDT.Second = lstClone[i * 16 + 8];

                            StringBuilder sb = new StringBuilder();
                            for (int j = 9; j <= 16; j++)
                            {
                                if (sb.Length > 0)
                                {
                                    sb.Append(" ");
                                }
                                sb.Append(lstClone[i * 16 + j].ToString("X2"));
                            }
                            ar.Data = sb.ToString();
                            arList.Add(ar);
                           
                        }
                        obj = arList;
                        break;
                }
            }

            return obj;
        }

    }
}
