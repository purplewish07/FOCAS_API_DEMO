using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FANUC
{
    public class Fanuc : Focas1
    {
        public static ushort h;

        //下載程序  5-27
        //開始
        private static short dwnstart(ushort handle, short type)
        {
            return Fanuc.cnc_dwnstart3(handle, type);
        }
        //結束
        private static short dwnend(ushort handle)
        {
            return Fanuc.cnc_dwnend3(handle);
        }
        //下載
        private static short dwnload(ushort handle, ref int datalength, string data)
        {
            //開始下載程序  datalength將會被返回，實際的輸出的字符數量
            return Fanuc.cnc_download3(handle, ref datalength, data);
        }
        //獲取詳細的錯誤信息
        private static short getdtailerr(ushort handle, Fanuc.ODBERR odberr)
        {
            return Fanuc.cnc_getdtailerr(handle, odberr);
        }
        //下載程序的入口點
        /// <summary>
        /// 向CNC下載指定類型的程序
        /// </summary>
        /// <param name="handle">句柄</param>
        /// <param name="type">程序類型</param>
        /// <param name="data">程序的內容</param>
        /// <param name="odberr">保存返回錯誤信息的詳細內容,為null不返回</param>
        /// <returns>錯誤碼</returns>
        public static short download(ushort handle, short type, string data, Fanuc.ODBERR odberr)
        {
            int datalength = data.Length;
            short ret = dwnstart(handle, type);
            if (ret == 0)
            {
                int olddata = datalength;
                while (true)
                {
                    ret = dwnload(handle, ref datalength, data);
                    //說明緩存已滿或為空，繼續嘗試
                    if (ret == (short)Fanuc.focas_ret.EW_BUFFER)
                    {
                        continue;
                    }
                    if (ret == Fanuc.EW_OK)
                    {
                        //說明當前下載完成,temp記錄剩餘下載量
                        int temp = olddata - datalength;
                        if (temp <= 0)
                        {
                            break;
                        }
                        else
                        {
                            data = data.Substring(datalength, temp);
                            datalength = temp; olddata = temp;
                        }
                    }
                    else
                    {
                        //下載出現錯誤，解析出具體的錯誤信息
                        if (odberr != null)
                        {
                            getdtailerr(handle, odberr);
                        }
                        //下載出錯
                        break;
                    }
                }
                //判斷是哪裡出的問題
                if (ret == 0)
                {
                    ret = dwnend(handle);
                    //結束下載出錯
                    return ret;
                }
                else
                {
                    dwnend(handle);
                    //下載出錯
                    return ret;
                }
            }
            else
            {
                dwnend(handle);
                //開始下載出錯
                return ret;
            }
        }
        //下載程序  5-27

        //上傳程序 5-28
        //開始
        private static short upstart(ushort handle, short type, int startno, int endno)
        {
            return cnc_upstart3(handle, type, startno, endno);
        }
        //上傳
        private static short uplod(ushort handle, int length, char[] databuf)
        {
            return cnc_upload3(handle, ref length, databuf);
        }
        //結束
        private static short upend(ushort handle)
        {
            return cnc_upend3(handle);
        }
        //上傳程序的入口
        /// <summary>
        /// 根據程序號讀取指定程序
        /// </summary>
        /// <param name="handle">句柄</param>
        /// <param name="type">類型</param>
        /// <param name="no">程序號</param>
        /// <param name="odberr">詳細錯誤內容，null不返回</param>
        /// <param name="data">返回的程序內容</param>
        /// <returns>錯誤碼</returns>
        public static short upload(ushort handle, short type, int no, ref string data, Fanuc.ODBERR odberr)
        {
            int startno = no; int endno = no;
            int length = 256; char[] databuf = new char[256];
            short ret = upstart(handle, type, startno, endno);
            if (ret == Fanuc.EW_OK)
            {
                string temp = "";
                while (true)
                {
                    //上傳
                    ret = uplod(handle, length, databuf);
                    temp = new string(databuf);
                    int one = temp.Length;
                    if (ret == (short)Fanuc.focas_ret.EW_BUFFER)
                    {
                        continue;
                    }
                    if (ret == Fanuc.EW_OK)
                    {
                        temp = temp.Replace("\0", "");
                        data += temp;
                        string lastchar = temp.Substring(temp.Length - 1, 1);
                        if (lastchar == "%")
                        {
                            break;
                        }
                    }
                    else
                    {
                        //下載出現錯誤，解析出具體的錯誤信息
                        if (odberr != null)
                        {
                            getdtailerr(handle, odberr);
                        }
                        //下載出錯
                        break;
                    }
                }
                //判斷是哪裡出的問題
                if (ret == 0)
                {
                    ret = upend(handle);
                    //結束上傳出錯
                    return ret;
                }
                else
                {
                    upend(handle);
                    //上傳出錯
                    return ret;
                }
            }
            else
            {
                //開始出錯
                upend(handle);
                return ret;
            }
        }
        //上傳程序 5-28

        //根據alm_grp 編號 返回 提示內容 簡
        public static string getalmgrp(short no)
        {
            string ret = "";
            switch (no)
            {
                case 0:
                    ret = "SW";
                    break;
                case 1:
                    ret = "PW";
                    break;
                case 2:
                    ret = "IO";
                    break;
                case 3:
                    ret = "PS";
                    break;
                case 4:
                    ret = "OT";
                    break;
                case 5:
                    ret = "OH";
                    break;
                case 6:
                    ret = "SV";
                    break;
                case 7:
                    ret = "SR";
                    break;
                case 8:
                    ret = "MC";
                    break;
                case 9:
                    ret = "SP";
                    break;
                case 10:
                    ret = "DS";
                    break;
                case 11:
                    ret = "IE";
                    break;
                case 12:
                    ret = "BG";
                    break;
                case 13:
                    ret = "SN";
                    break;
                case 14:
                    ret = "reserved";
                    break;
                case 15:
                    ret = "EX";
                    break;
                case 19:
                    ret = "PC";
                    break;
                default:
                    ret = "Not used";
                    break;
            }
            return ret;
        }
        //根據alm_grp 編號 返回 提示內容 簡

        //2016-6-2 根據地址碼和地址號，返回完整的顯示信息
        public static string getpmcadd(short a, ushort b)
        {
            string tempa = "";
            switch (a)
            {
                case 0:
                    tempa = "G";
                    break;
                case 1:
                    tempa = "F";
                    break;
                case 2:
                    tempa = "Y";
                    break;
                case 3:
                    tempa = "X";
                    break;
                case 4:
                    tempa = "A";
                    break;
                case 5:
                    tempa = "R";
                    break;
                case 6:
                    tempa = "T";
                    break;
                case 7:
                    tempa = "K";
                    break;
                case 8:
                    tempa = "C";
                    break;
                case 9:
                    tempa = "D";
                    break;
                default:
                    tempa = "n";
                    break;
            }
            string tempb = b.ToString().PadLeft(4, '0');
            return tempa + tempb;
        }
        //2016-6-2 根據地址碼和地址號，返回完整的顯示信息



    }
}
