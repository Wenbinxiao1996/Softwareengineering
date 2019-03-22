using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AriThMetic
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();//初始化
            Random number = new Random(); //实例化一个随机数           
            string[] operatos = new string[] { "＋", "－", "×", "÷" };
            string[] operatos1 = new string[] { "+", "-", "*", "/" };//转换成加减乘除号

            Console.WriteLine("您好！欢迎使用快乐四则运算！！");
            Thread.Sleep(8000);//logo首页加载...;
            Console.WriteLine("正在加载中,请稍后...");
            Thread.Sleep(5000);//logo首页加载...;

            Console.WriteLine("您好！您要生成多少题呢？");
            int draw = Convert.ToInt32(Console.ReadLine()); //按照客户需求，需要生成多少题，最大10000题

            Console.WriteLine("您要生多少以内的计算题呢？(0-100之内)");
            int difficulty = Convert.ToInt32(Console.ReadLine()); //根据用户需求，开始随机抽题               

            Console.WriteLine("正在加载题目,请您稍等...");
            //Thread.Sleep(8000);//加载速度8s;
            Console.WriteLine("题目已准备好，请您开始作答吧！");

            //题目的TXT
            
            //FileStream fs = new FileStream("D:\\Exercise.txt", FileMode.Create);
            string path = "D:\\Exercise.txt";
            
            StreamWriter sw = new StreamWriter(path, false, Encoding.Default);

            //答案的TXT
            //FileStream da = new FileStream("D:\\Answer.txt", FileMode.Create);
            //string fw = "D:\\Answer.txt";
            //StreamWriter fs = new StreamWriter(fw, false, Encoding.Default);

            //无法输入答案 暂存

            sw.Flush();
            for (int s = 0; s < draw; s++)
            {
                int nubere_shu = number.Next(1, 4);
                var result = Calculation.Formulas(dt, number, difficulty, operatos, operatos1, nubere_shu);
                Console.WriteLine(result);

                #region 写入TXT

                //int plus = 1;
                //获得字节数组

                //fs.Flush();

                //开始写入
                sw.WriteLine("四则运算题 " + nubere_shu +result);

                //清空缓冲区、关闭流
                //sw.Close();
                #endregion
            }
            sw.Close();
            // fs.Close();
            Console.ReadKey();
        }
    }
}