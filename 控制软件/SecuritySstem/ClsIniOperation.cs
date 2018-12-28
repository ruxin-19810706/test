using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace SecuritySystem
{
    /// <summary>
    /// 读写INI文件
    /// </summary>
    public class ClsIniOperation
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key,
                                                             string val, string filePath);
        /*参数说明：section：INI文件中的段落；key：INI文件中的关键字；
          val：INI文件中关键字的数值；filePath：INI文件的完整的路径和名称。*/
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key,
                                                          string def, StringBuilder retVal,
                                                          int size, string filePath);
        /*参数说明：section：INI文件中的段落名称；key：INI文件中的关键字；
          def：无法读取时候时候的缺省数值；retVal：读取数值；size：数值的大小；
          filePath：INI文件的完整路径和名称。*/

        //ini文件路径
        static string IniFilePath = System.AppDomain.CurrentDomain.BaseDirectory + "Setup.ini";

        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="section">节</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string ReadIni(string section, string key)
        {
            StringBuilder strVal = new StringBuilder(255);
            int intVal = 0;

            intVal = GetPrivateProfileString(section, key, "", strVal, 255, IniFilePath);
            return strVal.ToString();
        }

        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="section">节</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static void WriteIni(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, IniFilePath);
        }
    }
}
