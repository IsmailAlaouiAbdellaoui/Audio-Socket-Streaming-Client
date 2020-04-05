using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using NAudio.Lame;
using NAudio.Wave;
using Microsoft.AspNetCore.WebSockets;
using System.Net.WebSockets;

namespace WinFormClient
{
    public partial class ChatForm : Form
    {
        //NAudio.
        public WasapiLoopbackCapture cap;
        public HubConnection _connection;
        public bool b = true;
        public WaveFileWriter writer ;
        public StreamWriter file_base64;




        public ChatForm()
        {
            InitializeComponent();
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            address.Focus();
        }

        private void address_Enter(object sender, EventArgs e)
        {
            AcceptButton = connect;
        }

        private async void connect_Click(object sender, EventArgs e)
        {
            UpdateState(connected: false);

            _connection = new HubConnectionBuilder()
                .WithUrl(address.Text)
                //.AddMessagePackProtocol()
                .Build();

            _connection.On<string, string>("broadcastMessage", OnSend);

            _connection.On("ListenDesktop", () =>
             {
                 MessageBox.Show("A friend wants to listen to your music ! :p");
                 try
                 {
                     cap = new WasapiLoopbackCapture();
                     cap.DataAvailable += InputBufferToFileCallback;
                     
                     cap.RecordingStopped += stoppedrecordingCallback;
                     //var outputFilePath = "C:\\Users\\Smail\\Desktop\\output-sound-card.mp3";
                     //writer = new WaveFileWriter(outputFilePath, cap.WaveFormat);
                     //file_base64 = new StreamWriter(@"C:\\Users\\Smail\\Desktop\\output-sound-Base64.txt");
                     cap.StartRecording();

                 }
                 catch (Exception ex)
                 {

                     MessageBox.Show("error while listening :" + ex.Message);
                 }
             });
            _connection.On("StopListenDesktop", () =>
             {
                 cap.StopRecording();
                 //writer.Dispose();
                 //writer = null;
                 cap.Dispose();
                 //MessageBox.Show("stopped recording .");

             });

            Log(Color.Gray, "Starting connection...");
            try
            {
                await _connection.StartAsync();
            }
            catch (Exception ex)
            {
                Log(Color.Red, ex.ToString());
                return;
            }

            Log(Color.Gray, "Connection established.");

            UpdateState(connected: true);

            message.Focus();
        }



        private void Log(Color color, string message)
        {
            Action callback = () =>
            {
                //messagesList.Items.Add(new LogMessage(color, message));
                messagesList.Items.Add(message);
            };

            Invoke(callback);
        }

        private class LogMessage
        {
            public Color MessageColor { get; }

            public string Content { get; }

            public LogMessage(Color messageColor, string content)
            {
                MessageColor = messageColor;
                Content = content;
            }
        }

        private async void disconnect_Click(object sender, EventArgs e)
        {
            Log(Color.Gray, "Stopping connection...");
            try
            {
                await _connection.StopAsync();
            }
            catch (Exception ex)
            {
                Log(Color.Red, ex.ToString());
            }

            Log(Color.Gray, "Connection terminated.");

            UpdateState(connected: false);
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            //while(b)
            //{
                try
                {
                    await _connection.InvokeAsync("Send", "WinFormsApp", message.Text);
                }
                catch (Exception ex)
                {
                    Log(Color.Red, ex.ToString());
                }
            //}
            
        }

        private void message_Enter(object sender, EventArgs e)
        {
            AcceptButton = sendButton;
        }

        private void UpdateState(bool connected)
        {
            disconnect.Enabled = connected;
            connect.Enabled = !connected;
            address.Enabled = !connected;

            message.Enabled = connected;
            sendButton.Enabled = connected;
        }
        private void OnSend(string name, string message)
        {
            Log(Color.Black, name + ": " + message);
        }

        private void messagesList_DrawItem(object sender, DrawItemEventArgs e)
        {
            var message = (LogMessage)messagesList.Items[e.Index];
            e.Graphics.DrawString(
                message.Content,
                messagesList.Font,
                new SolidBrush(message.MessageColor),
                e.Bounds);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //messagesList.Items.Add("test");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                #region Working part when Cap is stopped
                cap.StopRecording();
                cap.Dispose();

                if (writer != null)
                {
                    writer.Close();
                    writer.Dispose();
                    writer = null;
                }


                if(file_base64 != null)
                {
                    file_base64.Close();
                    file_base64.Dispose();
                    file_base64 = null;
                }

                #endregion




                //retMs.Close();
                //ms.Close();
                //rdr.Close();
                //wtr.Close();
                //wtr.Dispose();

                //using (var file = new FileStream("C:\\Users\\Smail\\Desktop\\output-test.mp3", FileMode.Create, FileAccess.Write))
                //    ms.WriteTo(file);


                //messagesList.Items.Add(ms.Length);
                if (ms2 != null)
                {
                    ms2.Close();
                    ms2.Dispose();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }
        //public MemoryStream retMs;
        //public RawSourceWaveStream rdr;
        public LameMP3FileWriter wtr;
        public MemoryStream ms; 
        /*async*/ void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cap = new WasapiLoopbackCapture();
                cap.DataAvailable += InputBufferToFileCallback;
                cap.RecordingStopped += stoppedrecordingCallback;
                var outputFilePath = "C:\\Users\\Smail\\Desktop\\output-sound-card.mp3";
                writer = new WaveFileWriter(outputFilePath, cap.WaveFormat);
                file_base64 = new StreamWriter(@"C:\\Users\\Smail\\Desktop\\output-sound-Base64.txt");


                var outputFilePath2 = "C:\\Users\\Smail\\Desktop\\output-sound-card2.mp3";
                ms = new MemoryStream();
                
                wtr = new LameMP3FileWriter(ms, cap.WaveFormat, (cap.WaveFormat.BitsPerSample * cap.WaveFormat.SampleRate * cap.WaveFormat.Channels)/1000);
                


                //retMs = new MemoryStream();
                //rdr = new RawSourceWaveStream(ms, cap.WaveFormat);
                //wtr = new LameMP3FileWriter(retMs, rdr.WaveFormat, 128);

                cap.StartRecording();

            }
            catch (Exception ex)
            {

                MessageBox.Show("error while listening :" + ex.Message);
            }

        }
        public MemoryStream ms2 = new MemoryStream();
        async void InputBufferToFileCallback(object sender, WaveInEventArgs e)
        {
            //Console.WriteLine("bytes recorded:"+e.BytesRecorded);
            //Console.WriteLine("size of buffer:"+e.Buffer.Length);
            //Console.WriteLine(" synchronized ?:"+e.Buffer.IsSynchronized);
            //File.WriteAllBytes("C:\\Users\\Smail\\Desktop\\pcm-byte-array.txt", e.Buffer);
            // The recorder bytes can be found in e.Buffer
            // The number of bytes recorded can be found in e.BytesRecorded
            // Process the audio data any way you wish...


            //await _connection.InvokeAsync("stream_server", e.Buffer);
            string temp_inBase64;

            //writer.Write(e.Buffer, 0, e.BytesRecorded);
            //if (writer.Position > cap.WaveFormat.AverageBytesPerSecond * 20)
            //{
            //    cap.StopRecording();
            //}
            //lock (e.Buffer)
            //{
            //ms = new MemoryStream(e.Buffer);
            try
            {
                #region Working part when sending raw audio to SignalR data and writing audio file
                await _connection.InvokeAsync("stream_server", e.Buffer);
                Console.WriteLine(e.Buffer.Length);
                //writer.Write(e.Buffer, 0, e.BytesRecorded);
                #endregion


                //using (var retMs = new MemoryStream())
                //using (var ms = new MemoryStream(e.Buffer))
                //using (var rdr = new RawSourceWaveStream(ms,cap.WaveFormat))
                //using (var wtr = new LameMP3FileWriter(retMs, rdr.WaveFormat, cap.WaveFormat.BitsPerSample*cap.WaveFormat.SampleRate*cap.WaveFormat.Channels))

                //var retMs = new MemoryStream();
                //var ms = new MemoryStream(e.Buffer);
                //var rdr = new RawSourceWaveStream(ms, cap.WaveFormat);
                //var outputFilePath = "C:\\Users\\Smail\\Desktop\\output-sound-card2.mp3";
                //var wtr = new LameMP3FileWriter(outputFilePath, cap.WaveFormat, (cap.WaveFormat.BitsPerSample * cap.WaveFormat.SampleRate * cap.WaveFormat.Channels)/1000);


                //rdr.CopyTo(wtr);
                //messagesList.Items.Add(wtr.);
                //byte[] buffer = new byte[2048]; // read in chunks of 2KB
                //int bytesRead;
                //wtr.Write(e.Buffer, 0, e.BytesRecorded); // Encodes audio wav raw data to memory stream using MP3 Lame
                //wtr.Read(e.Buffer, 0, e.BytesRecorded);

                //wtr.CopyToAsync(ms);
                //ms.Read(e.Buffer, 0, e.BytesRecorded);
                //wtr.Close();
                //messagesList.Items.Add(wtr.Length);
                //messagesList.Items.Add(ms.CanRead);
                //while ((bytesRead = ms.Read(buffer, 0, buffer.Length)) > 0)
                //{
                //    ms2.Write(buffer, 0, bytesRead);
                //}
                //byte[] result = ms2.ToArray();
                //messagesList.Items.Add(result.Length);

                //temp_inBase64 = Convert.ToBase64String(wtr);
                //var t = Task.Run(() => file_base64.WriteLine(temp_inBase64));
                //t.Wait();

                //messagesList.Items.Add(wtr.Length);
                //writer.Write(wtr.g, 0, retMs.ToArray().Length);

                //using (var wtr = new LameMP3FileWriter(retMs, rdr.WaveFormat, 128))
                //{
                //    rdr.CopyTo(wtr);
                //    //return retMs.ToArray();
                //    writer.Write(retMs.ToArray(), 0, retMs.ToArray().Length);
                //    temp_inBase64 = Convert.ToBase64String(retMs.ToArray());
                //    var t = Task.Run(() => file_base64.WriteLine(temp_inBase64));
                //    t.Wait();
                //}


                //writer.Write(e.Buffer, 0, e.BytesRecorded);


                //temp_inBase64 = Convert.ToBase64String(e.Buffer);
                //var t = Task.Run(() =>  file_base64.WriteLine(temp_inBase64) );
                //t.Wait();




            }
            catch (Exception ex)
                {
                    MessageBox.Show("error while writing : " + ex.Message);
                    //Console.WriteLine("error while writing : " + ex.Message);
                }
           // }
        }
        void stoppedrecordingCallback(object sender, StoppedEventArgs e)
        {
            //writer.Dispose();
            //writer = null;
            //cap.Dispose();
            //file_base64.Close();
            //file_base64.Dispose();
            //file_base64 = null;
            MessageBox.Show("stopped recording .");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var temp_cap = new WasapiLoopbackCapture();
            messagesList.Items.Add("sample rate :"+temp_cap.WaveFormat.SampleRate);
            messagesList.Items.Add("block align :"+temp_cap.WaveFormat.BlockAlign);
            messagesList.Items.Add("bits per sample :"+temp_cap.WaveFormat.BitsPerSample);
            messagesList.Items.Add("avg bytes/s :"+temp_cap.WaveFormat.AverageBytesPerSecond);
            messagesList.Items.Add("encoding :" + temp_cap.WaveFormat.Encoding);
            messagesList.Items.Add("extra size:" + temp_cap.WaveFormat.ExtraSize);
            messagesList.Items.Add("channels:" + temp_cap.WaveFormat.Channels);
        }
        public ClientWebSocket client;
        private async void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //TcpClient client = new TcpClient("wss://localhost/ws", 44317);
                //client.Connect();
                client = new ClientWebSocket();
                await client.ConnectAsync(new Uri("wss://localhost:44317/ws"), CancellationToken.None);
                //MessageBox.Show(client.State.ToString());
                label5.Text = client.State.ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error when trying to connect to websockets server : "+ex.Message);
            }
            

        }

        private async void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (client.State == WebSocketState.Open)
                {

                    byte[] test = Encoding.ASCII.GetBytes(textBox1.Text);
                    await client.SendAsync(new ArraySegment<byte>(test), WebSocketMessageType.Binary, false, CancellationToken.None);

                }
                else
                {
                    MessageBox.Show("Not connected to the server");
                }

            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (client.State == WebSocketState.Open)
                {
                    await client.CloseAsync(WebSocketCloseStatus.Empty, null, CancellationToken.None);
                    label5.Text = client.State.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("error while closing the connection : " + ex.Message);
            }
            
        }
    }

}
