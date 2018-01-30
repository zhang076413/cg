
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace ObjTool
{
    class FileUtil
    {
        public static String read(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            String datalines = "";
            while ((line = sr.ReadLine()) != null)
            {

                datalines = datalines + Environment.NewLine + line;
                Console.WriteLine(line.ToString());
            }
            return datalines;
        }

        public static void Write(string fullPathName, string txt)
        {
           
            if (File.Exists(@fullPathName))
            {
                File.Delete(@fullPathName);
            }
            try
            {
                FileStream fs = new FileStream(fullPathName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                //开始写入
                sw.Write(txt);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
            }
            catch (Exception e)
            {
            }

        }


    }
}