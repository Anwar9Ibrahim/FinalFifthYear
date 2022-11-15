using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alturos.Yolo;
using Alturos.Yolo.Model;
using Alturos.VideoInfo;
using OpenCvSharp;
using System.Drawing;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Animation;
using System.Configuration;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using OpenCvSharp.Extensions;
using System.IO;
using System.Windows;
using System.Diagnostics;

namespace FinalFifthYear
{
    class Yolo
    {
        string conda;
        string strCmdText = @"C:\ProgramData\Anaconda3\Scripts\activate.bat";

        //how many vehicles have i found over all time
        public static int VehicleCount = 0;
        //Original YOLO
        //string[] AcceptedTypes = { "bicycle", "car", "motorbike", "bus", "truck" };
        //Mr omar
         string[] AcceptedTypes = { " bicycle", "car", "van", "truck", "tricycle", "awning-tricycle", "bus", "motor" };
        List<Mat> frames;
        //detected frames
        Color[] colors;
        public List<Mat> detecteFrames;
        //A list of all the Found Vehicles
        public List<Vehicle> vehicles;
        //the detectedVideo Path
        string inputFilePath;
        //VideoCapture Video;
        string videoTitle;
        ///Trying to release memory
        double qurt;
        double threqurt;
        double fps;
        public Yolo(string detectVid)
        {
            frames = new List<Mat>();
            detecteFrames = new List<Mat>();
            colors = new Color[AcceptedTypes.Length];
            vehicles = new List<Vehicle>();
            inputFilePath = detectVid;
            // inputFilePath.Substring(inputFilePath.Length - inputFilePath.LastIndexOf("//"));
            //Video = new VideoCapture(detectVid);
            videoTitle = inputFilePath.Substring(inputFilePath.LastIndexOf("\\") + 1);

            //videoTackle(inputFilePath);
            //detectFile();
        }
        //public VideoAnalyzer
        public async void VideoTackle()
        {
            var i = 0;
            var img = new Mat();
            using (var video = new VideoCapture(inputFilePath))
            {
                qurt = video.FrameHeight * 0.30;
                threqurt = video.FrameHeight * 0.40;
                fps = video.Fps;
                while (video.Grab())
                {
                    img = video.RetrieveMat();
                    frames.Add(img);
                    i++;
                }
            }
            //using (var writer = new VideoWriter())
            //{
            //    writer.Open("D:\\anwar\\out.avi", video.FourCC, video.Fps, new Size(video.FrameHeight, video.FrameWidth));
            //    //detectFile();
            //    int carCount = 0;
            //    using (var yoloWrapper = new YoloWrapper("yolov4-o.cfg", "yolov4-o_final.weights", "o.names"))
            //    {
            //        var frame = frames[0];
            //        var yoloTracking = new YoloTracking(frame.Width, frame.Height);
            //        var count = frames.Count();
            //        for (var j = 0; j < count; j++)
            //        {
            //            byte[] imageData = frames[j].ToBytes();
            //            var items = yoloWrapper.Detect(imageData).Where(v => AcceptedTypes.Any(s => (v.Type).Equals(s))).ToArray();

            //            var trackingItems = yoloTracking.Analyse(items);
            //           // carCount = yoloTracking.Analyse(items).Count();
            //            detecteFrames.Add(frames[j]);
            //            drawRectangles(detecteFrames[j], trackingItems);
            //            // writer.Write(frames[j]);
            //        }
            //    }
            //    for (var k = 0; k  < detecteFrames.Count(); k++)
            //    {
            //        Cv2.ImShow("image", frames[k]);
            //        Cv2.WaitKey(1);
            //    }
            // }
            // detectFile();
            //  }
        }
        //public List<Mat> detectFile()
        public void detectFile()
        {
            int carCount = 0;
            //Mr Omar dataset
            using (var yoloWrapper = new YoloWrapper("yolov4-o.cfg", "yolov4-o_final.weights", "o.names"))
            //YOLO originl
            //using (var yoloWrapper = new YoloWrapper("yolov4.cfg", "yolov4.weights", "coco.names"))
            {
                var i = 0;

                // var img = new Mat();
                using (var video = new VideoCapture(inputFilePath))
                {
                    qurt = video.FrameHeight * 0.30;
                    threqurt = video.FrameHeight * 0.40;
                    var yoloTracking = new YoloTracking(video.FrameWidth, video.FrameHeight);
                    fps = video.Fps;
                    while (video.Grab())
                    {
                        using (var img = video.RetrieveMat())
                        {
                            //  img = video.RetrieveMat();
                            //        frames.Add(img);
                            //        i++;
                            //    }
                            //}
                            //  var frame = frames[0];
                            // var yoloTracking = new YoloTracking(frame.Width, frame.Height);
                            //var yoloTracking = new YoloTracking(img.Width, img.Height);
                            // var count = frames.Count();

                            //for (var i = 0; i < count-2; i ++)
                            //{
                            //if (frames[i] != null)
                            if (img != null)
                            {
                                try
                                {
                                    //byte[] imageData = frames[i].ToBytes();
                                    byte[] imageData = img.ToBytes();
                                    //detecting will give us yoloitems
                                    var items = yoloWrapper.Detect(imageData).Where(v => AcceptedTypes.Any(s => (v.Type).Equals(s))).ToArray();
                                    var editedImage = drawRectangles(img, items);
                                    //tracking will give us yoloTrackingitem this means that we also have an objectId  assosiated with each object 
                                    var trackingItems = yoloTracking.Analyse(items);
                                   // var editedImage = drawRectangles(img, items);
                                    //detecteFrames.Add(frames[i]);
                                    //CountVehicles(frames[i], trackingItems, i);
                                    CountVehicles(img, trackingItems, i);
                                    // i++;
                                    // drawRectangles(frames[i], trackingItems);
                                    // var editedImage= drawRectangles(img, trackingItems);
                                    //OpenCvSharp.VideoWriter videoWriter= new VideoWriter("temp")
                                    //this way it will start showing the results faster
                                    // Cv2.ImShow("image", detecteFrames[i]);
                                    //Cv2.ImShow("image2", frames[i]);
                                    Cv2.ImShow("image2", editedImage);
                                    Cv2.WaitKey(1);
                                    //carCount = trackingItems.Count();
                                    //frames[i].Dispose();
                                    //frames[i].Dispose();
                                    editedImage.Dispose();
                                }
                                catch
                                {
                                    var st = "frame error";
                                }

                            }
                            i++;
                        }
                    }
                }
            }
            var longhd = vehicles.Count();
            // return detecteFrames;
        }
        private Mat drawRectangles(Mat frame, IEnumerable<YoloItem> items)
        {
            //draw the lines
            //double qurt = frame.Height * 0.50;
            double threqurt = frame.Height * 0.60;
            //Cv2.Line(frame, new OpenCvSharp.Point(0.0, qurt), new OpenCvSharp.Point(frame.Width, qurt), Scalar.Green);
            Cv2.Line(frame, new OpenCvSharp.Point(0.0, threqurt), new OpenCvSharp.Point(frame.Width, threqurt), Scalar.Red, 2);
            Cv2.PutText(frame, "Objects being tracked: "+vehicles.Count.ToString()+ " ", new OpenCvSharp.Point(5, 35), HersheyFonts.HersheySimplex,1,Scalar.Green, 2);


            //draw the rectangles to surround each object
            foreach (YoloItem item in items)
            {
                // frame.Circle(new OpenCvSharp.Point(item.X, item.Y), 1, Scalar.Red, 5);
                //var rectHeight = (item.Height *20) / 100;
                // var rectWidth = (item.Width * 10)/100 ;
                //find a way to color each object type with some color
                OpenCvSharp.Rect rect = new OpenCvSharp.Rect(item.X, item.Y, item.Width, item.Height);
                //frame.Rectangle(new Rect(new OpenCvSharp.Point(item.X, item.Y), new OpenCvSharp.Size(rectHeight, rectWidth)), Scalar.Green, -1);
                //frame.PutText(item.Type + "  " + item.Confidence.ToString("0.00"), new OpenCvSharp.Point(item.X+ rectWidth/10, item.Y+ rectHeight/2), HersheyFonts.HersheySimplex, 0.5, Scalar.White);
                frame.PutText(item.Type + "  " + item.Confidence.ToString("0.00"), new OpenCvSharp.Point(item.X, item.Y), HersheyFonts.HersheySimplex, 0.5, Scalar.White);
                //frame.PutText(item.ObjectId, new OpenCvSharp.Point(item.X, item.Y), HersheyFonts.HersheySimplex, 1, Scalar.Red, 5);
                frame.Rectangle(rect, Scalar.Green, 2);
            }
            return frame;
        }
        private void CountVehicles(Mat frame, IEnumerable<YoloTrackingItem> items, int i)
        {
            //var qurt = frame.Height * 0.30;
            var threqurt = frame.Height * 0.60;
            int tempCount = 0;
            foreach (YoloTrackingItem item in items)
            {
                Vehicle vehicle = new Vehicle(item, i);
                var exist = vehicles.Any(v => v.TrackingItem.ObjectId == item.ObjectId);
                if (!exist)
                {
                    if(item.Y< threqurt && (item.Y + item.Height)> threqurt) {
                        Bitmap croppedImage = CropImage(frame.ToBitmap(), new Rectangle(item.X, item.Y, item.Width, item.Height));
                        vehicle.ImagePath = string.Format(@"C:\Users\anwar\source\repos\FinalFifthYear\FinalFifthYear\images\{0}_item_{1}.jpg", videoTitle, i + tempCount);
                        try
                        {
                            croppedImage.Save(vehicle.ImagePath);
                        }
                        catch
                        {
                            var excepion = "saveFile Error";
                        }
                        tempCount++;
                        vehicles.Add(vehicle);
                    }
                    
                }
                else
                {
                    var foundV = vehicles.Find(v => v.TrackingItem.ObjectId == item.ObjectId);
                    foundV.TrackingItem = item;
                    if (foundV.TrackingItem.Y > qurt && foundV.visiting == false && foundV.Seen == false)
                    {
                        foundV.visiting = true;
                        foundV.InFrame = i;
                    }
                    else if (foundV.TrackingItem.Y > threqurt && foundV.visiting == true && foundV.Seen == false)
                    {
                        foundV.visiting = false;
                        foundV.Seen = true;
                        foundV.OutFrame = i;
                        foundV.Speed = calculateSpeed(foundV);
                    }
                }

            }
        }
        private double calculateSpeed(Vehicle vehicle)
        {

            var speed = 0.0;
            if (vehicle.OutFrame != 0)
            {
                var time = (vehicle.OutFrame - vehicle.InFrame) / fps;//calculate time num_of_frames/frame rate
                var distance = (threqurt - qurt) * 10;//i invented this :E3
                speed = distance / time;
            }
            return speed;
        }
        public void AddVehiclesToDB()
        {

            foreach (Vehicle vehicle in vehicles)
            {
                try
                {
                    string connetionString = null;
                    SqlConnection cnn;
                    connetionString = "Server=.;Database=VehicleCounter;User id=sa; Password=123;";
                    cnn = new SqlConnection(connetionString);
                    cnn.Open();

                    SqlCommand command;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    String sql = "";
                    VehicleEntity vehicleEntity = new VehicleEntity(vehicle);

                    sql = "Insert into Vehicle (Id,CreationDate,VehicleType,Speed,Status,ImageURL,VideoTitle,Color) values(@Id,@CreationDate, @VehicleType, @Speed, @Status,@ImagePath,@VideoTitle,@Color )";

                    command = new SqlCommand(sql, cnn);
                    //add with Value
                    command.Parameters.AddWithValue("@Id", vehicleEntity.Id);
                    command.Parameters.AddWithValue("@CreationDate", vehicleEntity.CreationDate);
                    command.Parameters.AddWithValue("@VehicleType", vehicleEntity.VehicleType);
                    command.Parameters.AddWithValue("@Speed", vehicleEntity.Speed);
                    command.Parameters.AddWithValue("@Status", vehicleEntity.Status);
                    command.Parameters.AddWithValue("@ImagePath", vehicleEntity.ImageURL);
                    command.Parameters.AddWithValue("@VideoTitle", videoTitle);
                    command.Parameters.AddWithValue("@Color", "InitialValue");

                    command.ExecuteNonQuery();
                    //adapter.InsertCommand = new SqlCommand(sql, cnn);
                    //adapter.InsertCommand.ExecuteNonQuery();

                    command.Dispose();
                    cnn.Close();
                }
                catch
                {
                    String d = "db Erroe";
                }

            }
        }
        public Bitmap CropImage(Bitmap source, Rectangle section)
        {
            var bitmap = new Bitmap(section.Width, section.Height);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
                return bitmap;
            }
        }
        //private void run_cmd(string cmd, string args)
        //{
        // pythonWorkingDir=@"C:\Users\anwar\yolov4-deepsort"
        //}
        public void CallProcess()
        //string pythonWorkDir, string workingDirectory, string command)
        { 
            var workingDirectory = Path.GetFullPath(@"C:\Users\anwar\yolov4-deepsort");
            //string workingDirectory = @"";
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    WorkingDirectory = workingDirectory,
                    CreateNoWindow = true
                }
            };
            process.Start();
            // Pass multiple commands to cmd.exe
            using (var sw = process.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    // Vital to activate Anaconda
                    sw.WriteLine(strCmdText);
                    sw.WriteLine("activate yolov4-gpu");
                    // run your script. You can also pass in arguments
                    // string command= string.Format("python object_tracker.py --video ./data/video/new.mp4 --output ./outputs/demo.avi --model yolov4 --info")
                    string outputvideo = @"./ outputs / demo.avi";
                    inputFilePath = @"./data/video/cars.mp4";
                    string commad = string.Format("python object_tracker.py --video {0} --output {1} --model {2} --info", inputFilePath, outputvideo, "yolov4");
                    //string command = String.Format("python matching.py --template \"{0}\" --image \"{1}\" --output \"{2}\" --count {3}",
                    // wordPath, imagePath, outputImagePath, numOfResults);
                    //command = String.Format("play.py");
                    sw.WriteLine(commad);
                    sw.WriteLine("exit");
                    //process.WaitForExit(600000);
                    while (!process.StandardOutput.EndOfStream)
                    {
                        var line = process.StandardOutput.ReadLine();
                        conda += line + "\r\n";
                    }
                    conda += "end";
                    // 
                    // process.WaitForExit();
                }
                else
                {
                    Debug.WriteLine("Error occured");
                }
            }
        }
            ////int VehicleCount = 0;
            //var qurt = frame.Height * 0.30;
            //var threqurt = frame.Height * 0.40;
            //foreach (YoloTrackingItem item in items)
            //{
            //    if (item.Y > qurt && item.Y < threqurt+item.Height)
            //    {
            //        var exists = vehicles.FindAll(v => v.TrackingItem.ObjectId == item.ObjectId);
            //        if(!exists.Any())//if vehicle doesnt exist 
            //        {
            //            //frame.PutText(i+"WWWWWWWWWWWWW", new OpenCvSharp.Point(frame.Width /2 , frame.Height / 2), HersheyFonts.HersheySimplex, 0.5, Scalar.Red, 2);

            //            //we need to add the vehicle
            //            Vehicle ve = new Vehicle(item, i);
            //            ve.visiting = true;
            //            vehicles.Add(ve);
            //        }
            //        else  //this Id is used already
            //        {
            //           // frame.PutText("GGGGGGGGGGGGELSE_1GGGGGGGGg", new OpenCvSharp.Point(frame.Width / 2, frame.Height / 2), HersheyFonts.HersheySimplex, 0.5, Scalar.Red, 2);

            //            //two cases
            //            var potintiolVisiting = exists.Any(v => v.visiting == true /*&& v.Seen==false*/);//first case we are now vesiting this vehicle
            //                //we dont need to re add it just don't do anything
            //                if(potintiolVisiting)
            //            {
            //               // frame.PutText("GGGGGGGGGGGIM IN FFFFF GGGGGGGGGGg", new OpenCvSharp.Point(frame.Width / 2, frame.Height / 2), HersheyFonts.HersheySimplex, 0.5, Scalar.Red, 2);

            //                var updateVe = exists.Find(v => v.visiting == true);
            //                exists.Remove(updateVe);
            //                updateVe.TrackingItem = item;
            //                exists.Add(updateVe);                           

            //            }
            //                else
            //            //if(!potintiolVisiting)//if there is no vehicle with the corrusponding Id being vesited right now
            //                //then we are re using this Id
            //            {
            //               // frame.PutText("GGGGGGGGGGGELSE 2 GGGGGGGGg", new OpenCvSharp.Point(frame.Width / 2, frame.Height / 2), HersheyFonts.HersheySimplex, 0.5, Scalar.Red, 2);

            //                Vehicle vehicle = new Vehicle(item, i);
            //                vehicle.visiting = true;
            //                vehicles.Add(vehicle);
            //            }
            //        }
            //    }
            //}
            //foreach (Vehicle vehicle1 in vehicles)  
            //{
            //    if (vehicle1.TrackingItem.Y > threqurt && vehicle1.visiting == true /*&& vehicle1.Seen==false*/)
            //    {
            //        //this means that we can count this vehicle 
            //        VehicleCount++;
            //        frame.PutText(VehicleCount+" ", new OpenCvSharp.Point(vehicle1.TrackingItem.X, vehicle1.TrackingItem.Y), HersheyFonts.HersheySimplex, 0.5, Scalar.Red, 2);
            //        vehicle1.visiting = false;
            //        vehicle1.OutFrame = i;
            //        vehicle1.Seen = true;
            //    }
            //    else
            //    {
            //        //frame.PutText("GGGGGGGGGGFuckedUPGGGGGg \n", new OpenCvSharp.Point(frame.Width / 2, frame.Height/2), HersheyFonts.HersheySimplex, 0.5, Scalar.Red, 2); 

            //    }
            //}

            //private Scalar getColor()
            //{
            //    for (int i = 0; i < AcceptedTypes.Length; i++)
            //    {
            //        var rand = new Random();
            //        colors[i] = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            //    }
            //}
        }
}
