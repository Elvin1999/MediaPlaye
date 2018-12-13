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
        protected BaseMedia(string duration, string format, string filePath)
        {
            Duration = duration;
            Format = format;
            FilePath = filePath;
        }
        public string Duration { get; set; }
        public string Format { get; set; }
        public string FilePath { get; set; }
        public string GetDuration()
        {
            return Duration;
        }

        public string GetFile()
        {
            return FilePath;
        }

        public string GetFormat()
        {
            return Format;
        }
    }
    class Music : BaseMedia
    {
        public bool Mono { get; set; }
        public bool Stereo { get; set; }
        public bool IsMono()
        {
            return !Stereo;
        }
        public bool IStereo()
        {
            return Stereo;
        }
        public Music(string duration, string format, string filePath,bool stereo)
            : base(duration, format, filePath)
        {
            Stereo = stereo;
        }
    }
    class Video : Music
    {
        List<Frame> frames = new List<Frame>();
        public Video(string duration, string format, string filePath,bool stereo) :
            base(duration, format, filePath,stereo)
        {
        }
        public void AddFrame(Frame frame)
        {
            frames.Add(frame);
        }
        public string GetFrame(int second)
        {
            return frames[second - 1].MyFrame;
        }
        public int FramesCount()
        {
            return frames.Count;
        }
        public void ShowVideo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===================================================================");
            Console.WriteLine($"Duration {Duration} Format {Format} FilePath {FilePath} Stereo {IStereo()}  Mono {IsMono()}");
            Console.WriteLine("===================================================================");
            foreach (var item in frames)
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("=========");
                Console.WriteLine("=========");
                Console.WriteLine($"|{item.MyFrame}|");
                Console.WriteLine("=========");
                Console.WriteLine("=========");
            }
        }
    }
    class Frame
    {
        public int Second { get; set; }
        public string MyFrame { get; set; }
        public Frame(string myFrame,int second)
        {
            MyFrame = myFrame;
        }  
        int GetSecond()
        {
            return Second;
        }
    }
    class Controller
    {
        public void Run()
        {
            Frame frame1 = new Frame("1.Frame",1);
            Frame frame2 = new Frame("2.Frame",2);
            Frame frame3 = new Frame("3.Frame",3);
            Frame frame4 = new Frame("4.Frame",4);
            Music music = new Music("2.55", "mp3", @"C:\Users", true);    
            Video video = new Video("2.55", "mp4", @"C:\Users", true);          
            video.AddFrame(frame1); video.AddFrame(frame2);
            video.AddFrame(frame3); video.AddFrame(frame4);
            //Console.WriteLine(video.GetFrame(3));
            video.ShowVideo();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.Run();
        }
    }
}
