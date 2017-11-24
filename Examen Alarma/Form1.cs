using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace Examen_Alarma
{
    public partial class frmalarma : Form
    {
         WindowsMediaPlayer wplayer = new WindowsMediaPlayer();
        
        bool flag = true;
        string contra;
        System.IO.Ports.SerialPort ArduinoPort;
        public frmalarma()
        {
            InitializeComponent();
            // ArduinoPort = new System.IO.Ports.SerialPort();
            //  ArduinoPort.PortName = "COM3";  //sustituir por vuestro 
            //  ArduinoPort.BaudRate = 9600;
            WindowsMediaPlayer wplayer = new WindowsMediaPlayer();
            

        }

        private void frmalarma_Load(object sender, EventArgs e)
        {
            serialPort1.Open();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            string dist = serialPort1.ReadLine().ToString();
            textBox1.Text = dist + "CM";
            int dista = Int32.Parse(dist);
            if (dista <= 5)
            {
                wplayer.URL = @"C:\Users\adrian\Downloads\alarma.mp3";
                wplayer.controls.play();
                activa();
                timer1.Stop();
               
            }


        }

        public void activa()
        {
            btndesa.Visible = true;
            lbldetec.Visible = true;
            textBox2.Visible = true;
        }

        public void desactiva()
        {
            wplayer.controls.stop();
            textBox2.Text = " ";
            btndesa.Visible = false;
            lbldetec.Visible = false;
            textBox2.Visible = false;
        }


        private void lbldistan_Click(object sender, EventArgs e)
        {

        }

        private void timer6_Tick(object sender, EventArgs e)
        {

        }

        private void btnenter_Click(object sender, EventArgs e)
        {

        }

        private void btndesa_Click(object sender, EventArgs e)
        {
            
                contra = textBox2.Text;

                if (contra != "1416")
                {
                    serialPort1.Write("0");

                }
                else
                {
                    serialPort1.Write("1");
                    desactiva();
                    timer1.Start();

                }
                
        }
    }

}