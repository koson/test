using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

using BetteryMonitoringSystem.Common;

namespace BetteryMonitoringSystem.File
{
    [Serializable]
    public class IniFileHandle
    {
                /********************생성자*******************/
        public IniFileHandle(string INIPath)
        {
            path = INIPath;
            System.IO.FileInfo cFileInfo = new System.IO.FileInfo(INIPath);
            if (!cFileInfo.Exists) FileCreate(cFileInfo);
        }
        public IniFileHandle()
        {

        }

        /********************소멸자*******************/
        ~IniFileHandle()
        {  }

        /********************정  의*******************/
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,            string key, string val, string filePath);        
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,                 string key, string def, StringBuilder retVal,            int size, string filePath);
        
        /********************변  수*******************/
        public string path;
        
        /********************메소드*******************/
        public void FileWrite(string Value)
        {
            FileWrite(Value, path.ToString());
        }

        public void FileWrite(string Value, string FullName)
        {

            try
            {
                using (System.IO.StreamWriter w = System.IO.File.AppendText(FullName))
                {
                    w.WriteLine(Value);

                    w.Flush();
                    w.Close();
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }

        }


        /// <summary>
        /// Write Data to the INI File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// Section name
        /// <PARAM name="Key"></PARAM>
        /// Key Name
        /// <PARAM name="Value"></PARAM>
        /// Value Name
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }

        /// <summary>
        /// Read Data Value From the Ini File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// <PARAM name="Key"></PARAM>
        /// <PARAM name="Path"></PARAM>
        /// <returns></returns>
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp,
                                            255, this.path);
            return temp.ToString();

        }
        public string IniReadValue(string Section, string Key, string Default)
        {
            try
            {
                StringBuilder temp = new StringBuilder(255);
                int i = GetPrivateProfileString(Section, Key, "", temp,
                                                255, this.path);

                return (temp.Length == 0 ? Default.ToString() : temp.ToString());
            }
            catch
            {
                return Default;
            }


        }
        private bool FileCreate(System.IO.FileInfo cFileInfo)
        {
        reFileCreate:
            bool bCreateFile = false;
            if (!cFileInfo.Exists)
            {
                try
                {

                    System.IO.FileStream fstr = cFileInfo.Create();
                    fstr.Close();
                }
                catch (System.IO.DirectoryNotFoundException)
                {
                    if (CreatePath(cFileInfo.DirectoryName))
                    {
                        goto reFileCreate;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return bCreateFile;
        }

        public  bool CreatePath(string FullPathDirectory)
        {
            System.Collections.ArrayList strFullPath = GetPathDirectory(FullPathDirectory);
            //throw new System.NotImplementedException();
            bool bCreatePath = false;
            foreach (string path in strFullPath)
            {
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                    bCreatePath = true;
                }
            }
            return bCreatePath;
        }

        private System.Collections.ArrayList GetPathDirectory(string FullPathDirectory)
        {
            int start = 4;

            System.Collections.ArrayList path = new System.Collections.ArrayList();

            if (FullPathDirectory != null)
            {
                while (start < FullPathDirectory.Length)
                {
                    start = FullPathDirectory.IndexOf('\\', start) + 2;
                    try
                    {
                        path.Add(FullPathDirectory.Substring(0, start - 2));
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        path.Add(FullPathDirectory);
                        return path;
                    }
                }
            }
            return path;
            //throw new System.NotImplementedException();
        }




        public DataTable getLogFile(string OpenPath)
        {
            string contents;
            int tabSize = 13;
            string[] arInfo;
            string line;


            Utils util = new Utils();
            DataTable table = util.createTable(
                                                new string[] { "시간", "전압", "전류", "온도1", "온도2", "온도3", "온도4", "온도5", "온도6", "Contact1", "Contact2", "Contact3", "Contact4" },
                                                new string[] { "" }
                                                );
            DataRow row;

            try
            {

                string FILENAME = OpenPath;
                //Get a StreamReader class that can be used to read the file
                StreamReader objStreamReader;
                objStreamReader = System.IO.File.OpenText(FILENAME);
                while ((line = objStreamReader.ReadLine()) != null)
                {
                    contents = line.Replace(("").PadRight(tabSize, ' '), "\t");
                    // define which character is seperating fields
                    char[] textdelimiter = { '\t' };

                    arInfo = contents.Split(textdelimiter, StringSplitOptions.RemoveEmptyEntries);

                    row = table.NewRow();
                    for (int i = 0; i < arInfo.Length; i++)
                    {
                        row[i] = arInfo[i].ToString();
                    }
                    table.Rows.Add(row);
                }
                objStreamReader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return table;
        }


        public DataTable getErrorLogFile(string OpenPath)
        {
                       string contents;
            int tabSize = 6;
            string[] arInfo;
            
            string line;


            Utils util = new Utils();
            DataTable table = util.createTable(
                                                new string[] { "SaveTime", "Error Time", "COM", "BMS ID", "Error Code", "Error Value" },
                                                new string[] { "" }
                                                );
            DataRow row;

            try
            {

                string FILENAME = OpenPath;
                //Get a StreamReader class that can be used to read the file
                StreamReader objStreamReader;
                objStreamReader = System.IO.File.OpenText(FILENAME);
                while ((line = objStreamReader.ReadLine()) != null)
                {
                    //contents = line.Replace(("").PadRight(tabSize, ' '), "\t");
                    contents = line.Replace(("").PadRight(tabSize, ' '), "\t");
                    
                    // define which character is seperating fields
                    char[] textdelimiter = { '\t' };

                    arInfo = contents.Split(textdelimiter, StringSplitOptions.RemoveEmptyEntries);

                    row = table.NewRow();
                    int rowOffset = 0;
                    for (int i = 0; i < arInfo.Length; i++)
                    {
                        if (arInfo[i].ToString().Substring(0, 1) != " ")
                            row[rowOffset++] = arInfo[i].ToString();
                    }
                    table.Rows.Add(row);
                }
                objStreamReader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

            return table;
        }


        public DataRow[] getErrorDataRows(DateTime time, string[] expression)
        {

            try
            {
                // 백업파일 이름형태로 날짜변환
                string dateFileName = string.Format("{0:D4}{1:D2}{2:D2}", time.Year, time.Month, time.Day);


                // 읽을 백업파일 경로설정
                string filePath = Properties.Settings.Default.BackupDir + "\\ErrorLog" + "\\" + dateFileName + ".Log";


                // 에러 리스트 로그파일 읽어서 테이블에 넣기
                DataTable errorDataTable = getErrorLogFile(filePath);
                if (errorDataTable == null)
                    return null;


                // where 조건절
                string where = "'" + expression[0] + "' <= SaveTime and SaveTime <= '" + expression[1] + "'";

                // select
                DataRow[] foundRows = errorDataTable.Select(where);

                return foundRows;
            }
            catch( Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
    

            
        }
    }
}
