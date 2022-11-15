using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Alturos.Yolo;
using Alturos.Yolo.Model;
using Emgu.CV.UI;
using Microsoft.Win32;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;


namespace FinalFifthYear
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        string detectedVid;
        private DataTable dTVehicles;
        private Yolo detector;
        public MainWindow()
        {
            InitializeComponent();
            detectedVid = @"D:\anwar\count.mp4";
            dTVehicles = new DataTable();
            //detector = new Yolo(detectedVid);
            //detector.CallProcess();
        //////opening the connection//////

            //////continoue
            //command.Dispose();
            //cnn.Close();
            /////insert elements////

        }

        private void BInputFile_Click(object sender, RoutedEventArgs e)
        {
            //choosing the input video
            Lpath.Visibility = Visibility.Hidden;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Video files (*.mpg; *.mpeg; *.avi; *.mp4)| *.mpg; *.mpeg; *.avi; *.mp4";
            if (openFileDialog.ShowDialog() == true)
            {
                //BDetect.IsEnabled = true;
                detectedVid = openFileDialog.FileName;
                avPlayer.Source = new Uri(detectedVid);
               // Lpath.Text = openFileDialog.FileName;
            }
            detector = new Yolo(detectedVid);
        }

        
        private void BDetect_Click(object sender, RoutedEventArgs e)
        {
            //starting the detection 
            //Lpath.Text = "Please waite your detection will start shortley";
            MessageBox.Show("your detection has started please wait...");
            if (avPlayer.HasVideo)
            {
                //avPlayer.Pause();
                var s = detectedVid;
                //define the weights, all the data set cinfigurations
                //crop our video into frames
               // detector.VideoTackle();
                //start detection and tracking this will give us frames with the rectangles drawn on them
                //var detectedFrames =
                detector.detectFile();
                //aDD to data base
                detector.AddVehiclesToDB();
            }


        }

        private void BStopDetect_Click(object sender, RoutedEventArgs e)
        {
            //System.Data.SqlClient
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=VehicleCounter";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            MessageBox.Show("Connection Open  !");
            cnn.Close();
            //Cv2.DestroyAllWindows();
        }

        private void BPower_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BMinus_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BDatabaseVehicles_Click(object sender, RoutedEventArgs e)
        {
            Lpath.Visibility = Visibility.Hidden;
            DGVehiclesFromDB.Visibility = Visibility.Visible;
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Server=.;Database=VehicleCounter;User id=sa; Password=123;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            MessageBox.Show("Connection Open  !");
            cnn.Close();
            /////select ///////
            try
            {
                SqlCommand command;
                SqlDataReader dataReader;
                String sql, Output = " ";
                sql = "Select * from Vehicle";

                command = new SqlCommand(sql, cnn);
                SqlDataAdapter sda = new SqlDataAdapter(command);
                //DataTable dt = new DataTable("emp");
                dTVehicles = new DataTable("emp");
                sda.Fill(dTVehicles);
                // MessageBox.Show("connected");
                //Binding binding = new Binding();
                //binding.Source = dTVehicles;
                DGVehiclesFromDB.ItemsSource = dTVehicles.DefaultView;
            }

            catch
            {
                MessageBox.Show("db error");
            }
        }


        private void CurrVehicles_Click(object sender, RoutedEventArgs e)
        {
            Lpath.Visibility = Visibility.Hidden;
            DGVehiclesFromDB.Visibility = Visibility.Visible;
            DataTable dataTable = new DataTable();
            foreach(Vehicle vehicle in detector.vehicles)
            {
              //  dataTable.C
                dataTable.NewRow();

            }
            
                // DGVehiclesFromDB.ItemsSource = detector.vehicles.de
        }
    }
}