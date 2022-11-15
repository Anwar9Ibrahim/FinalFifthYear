using System;
using System.Collections.Generic;
using System.Text;
using Alturos.Yolo.Model;
using OpenCvSharp;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace FinalFifthYear
{
    public class Vehicle
    {
        //public string Id;
        public YoloTrackingItem TrackingItem;
        public bool Seen;
        public bool visiting;
        public int InFrame;
        public int OutFrame;
        public double Speed;
        public float SpeedF;
        public string ImagePath;
        public Vehicle(YoloTrackingItem item, int inFrame,int outFrame=0 )
        {
            SpeedF = (float)15.56;
            TrackingItem = item;
            visiting = false;
            InFrame = inFrame;
            Seen = false;
        }
    }
}
