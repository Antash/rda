using System;
using System.Collections.Generic;
using System.IO;
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
		private string dfilename = "tmp.wav";

		private double[] signal;
		private List<float> rawSignal;

		public UcVoice()
		{
			InitializeComponent();

			rawSignal = new List<float>(10000);

			wl = new WavLib();
			wf = new WaveFormat(8000, 16, 1);

			ucFilter1.InitParams(1.0/8000, 64, 700, 1500);

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
			writer = new WaveFileWriter(dfilename, wf);
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
			byte[] buffer = e.Buffer;

			for (int index = 0; index < e.BytesRecorded; index += 2)
			{
				short sample = (short) ((buffer[index + 1] << 8) |
					                    buffer[index]);
				float sample32 = sample/32768f;
				rawSignal.Add(sample32);
			}

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
			WaveStream outputStream = CreateInputStream(dfilename);
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
			makeArray();

			var filter = ucFilter1.FilterFunc;
			var filtered = Algorithms.Convolution(signal, filter);

			ConvertFromSignal(filtered, dfilename);
		}

		public static List<float> GetSamples(string fileName)
		{
			var res = new List<float>();
			using (var ms = new WaveFileReader(fileName))
			{
				if (ms.WaveFormat.SampleRate != 8000 || ms.WaveFormat.Channels != 1 || ms.WaveFormat.BitsPerSample != 16)
					throw new FormatException();
				for (int i = 0; i < ms.Length / 4; i++)
				{
					float sample;
					if (ms.TryReadFloat(out sample))
						res.Add(sample);
				}
			}
			return res;
		}

		private void ConvertFromSignal(double[] filtered, string fileName)
		{
			writer = new WaveFileWriter(fileName, wf);
			foreach (float v in filtered)
			{
				var buffer = new byte[2];

				buffer[0] = (byte)((short)(v*32768f) & 0x00FF);
				buffer[1] = (byte)((short)(v*32768f) >> 8);

				writer.WriteData(buffer, 0, 2);
			}
			writer.Close();
		}

		private void ConvertToSignal(string fileName)
		{
			GetSamples(fileName);
			makeArray();
		}

		void makeArray()
		{
			signal = new double[rawSignal.Count];
			int i = 0;
			foreach (float v in rawSignal)
				signal[i++] = v;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.DefaultExt = "wav";
			ofd.Filter = "(wav)|*.wav";
			ofd.FileName = "test";
			ofd.ShowDialog(); 
			if (File.Exists(ofd.FileName))
				ConvertToSignal(ofd.FileName);
		}

		private void button6_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.DefaultExt = "wav";
			sfd.Filter = "(wav)|*.wav";
			sfd.FileName = "test";
			sfd.ShowDialog();
			ConvertFromSignal(signal, sfd.FileName);
		}
	}
}
