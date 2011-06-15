using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NAudio.Wave;

namespace RDA
{
	public partial class UcVoice : UserControl
	{
		private WavLib wl;
		private int selectedDevice;
		private int selectedPBDevice;
		private WaveIn waveIn;
		private WaveOut waveOut;
		private WaveFileWriter writer;
		private WaveFormat wf;
		private string filename = "tmp.wav";
		public UcVoice()
		{
			InitializeComponent();
			
			wl = new WavLib();
			wf = new WaveFormat(16000, 16, 2);

			var idev = wl.GetIDev();
			var odev = wl.GetODev();

			foreach (string d in idev)
				comboBox1.Items.Add(d);
			foreach (string d in odev)
				comboBox2.Items.Add(d);

			if (comboBox1.Items.Count > 0)
				comboBox1.SelectedIndex = 0;
			if (comboBox2.Items.Count > 0)
				comboBox2.SelectedIndex = 0;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			
			writer = new WaveFileWriter(filename, wf);
			waveIn = new WaveIn {DeviceNumber = selectedDevice, WaveFormat = wf};
			waveIn.DataAvailable += waveIn_DataAvailable;
			waveIn.StartRecording();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedDevice = comboBox1.SelectedIndex;
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedPBDevice = comboBox2.SelectedIndex;
		}

		void waveIn_DataAvailable(object sender, WaveInEventArgs e)
		{
			writer.WriteData(e.Buffer, 0, e.BytesRecorded);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			waveIn.DataAvailable -= waveIn_DataAvailable;
			waveIn.StopRecording();
			writer.Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			WaveStream outputStream = CreateInputStream(filename);
			waveOut = new WaveOut();
			waveOut.DeviceNumber = selectedPBDevice;
			waveOut.Init(outputStream);
			waveOut.Play();
		}

		public WaveStream CreateInputStream(string name)
		{
			WaveChannel32 inputStream;
			if (name.EndsWith(".wav"))
			{
				WaveStream readerStream = new WaveFileReader(name);
				readerStream = new WaveFormatConversionStream(wf, readerStream);
				inputStream = new WaveChannel32(readerStream);
			}
			else
			{
				throw new InvalidOperationException("Invalid extension");
			}
			return inputStream;
		}

		private void button4_Click(object sender, EventArgs e)
		{

		}
	}
}
