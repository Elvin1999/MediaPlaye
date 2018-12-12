using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp9
{
    interface IMedia
    {
        string GetDuration();
        string GetFormat();
        string GetFile();
    }
    class BaseMedia : IMedia
    {
        public string GetDuration()
        {
            return "";
        }

        public string GetFile()
        {
            return "";
        }

        public string GetFormat()
        {
            return "";
        }
    }
    class Music : BaseMedia
    {
        bool IsMono()
        {
            return false;
        }
        bool IStereo()
        {
            return false;
        }
    }
    class Video : Music
    {
        void AddFrame(Frame frame)
        {

        }
        string GetFrame(int second)
        {
            return " ";
        }
        int FramesCount()
        {
            return 1;
        }
    }
    class Frame
    {
        int GetSecond()
        {
            return 1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
