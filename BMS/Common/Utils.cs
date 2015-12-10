using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace BetteryMonitoringSystem.Common
{
    public class Utils
    {

        /// <summary> Convert a string of hex digits (ex: E4 CA B2) to a byte array. </summary>
        /// <param name="s"> The string containing the hex digits (with or without spaces). </param>
        /// <returns> Returns an array of bytes. </returns>
        public byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        /// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
        /// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
        /// <returns> Returns a well formatted string of hex digits with spacing. </returns>
        public string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
        }

        /// <summary>
        /// 테이블 만들기
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="primaryKey"></param>
        /// <returns>DataTable</returns>
        public DataTable createTable(string[] columns, string[] primaryKey)
        {
            DataTable table = new DataTable();

            // Column 추가
            foreach (string col in columns)
            {
                table.Columns.Add(col);
            }

            // 기본키 설정
            int index = 0;
            if( primaryKey != null )
            { 
                DataColumn[] PrimaryKeyColumns = new DataColumn[primaryKey.Length];
                foreach (string key in primaryKey)
                {
                    PrimaryKeyColumns[index++] = table.Columns[key];
                }
                table.PrimaryKey = PrimaryKeyColumns;
            }
            return table;
        }

    }
}
