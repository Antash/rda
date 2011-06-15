using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NAudio.Wave;

namespace RDA
{
	class WavLib
	{
		public string[] GetIDev()
		{
			string []res = new string[WaveIn.DeviceCount];
			int waveInDevices = WaveIn.DeviceCount;
			for (int waveInDevice = 0; waveInDevice < waveInDevices; waveInDevice++)
			{
				WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(waveInDevice);
				res[waveInDevice] =  string.Format("Device {0}: {1}, {2} channels",
				                  waveInDevice, deviceInfo.ProductName, deviceInfo.Channels);
			}
			return res;
		}

		public string[] GetODev()
		{
			string[] res = new string[WaveOut.DeviceCount];
			int waveInDevices = WaveOut.DeviceCount;
			for (int waveInDevice = 0; waveInDevice < waveInDevices; waveInDevice++)
			{
				WaveOutCapabilities deviceInfo = WaveOut.GetCapabilities(waveInDevice);
				res[waveInDevice] = string.Format("Device {0}: {1}, {2} channels",
								  waveInDevice, deviceInfo.ProductName, deviceInfo.Channels);
			}
			return res;
		}

		public static double[] OpenWAV(string fileName)
		{
			BinaryReader br = new BinaryReader(File.OpenRead(fileName), Encoding.ASCII);

			br.BaseStream.Seek(0L, SeekOrigin.Begin);
			if (new string(br.ReadChars(4)).ToUpper() != "RIFF")
				throw new InvalidOperationException();

			br.ReadInt32();
			if (new string(br.ReadChars(4)).ToUpper() != "WAVE")
				throw new InvalidOperationException();

			if (new string(br.ReadChars(4)).ToUpper() != "FMT ")
				throw new InvalidOperationException();

			br.ReadInt32();

			short FormatTag = br.ReadInt16();
			short Channels = br.ReadInt16();
			int SamplesPerSec = br.ReadInt32();
			int AvgBytesPerSec = br.ReadInt32();
			short BlockAlign = br.ReadInt16();
			short BitsPerSample = br.ReadInt16();

			if (new string(br.ReadChars(4)).ToUpper() != "DATA")
				throw new InvalidOperationException();

			int num = br.ReadInt32();
			double[] Data = new double[num / 3];
			long SumCO = Data.LongLength;
			byte[] buffer = new byte[4];
			for (long i = 0; i < SumCO; i++)
			{
				buffer[0] = br.ReadByte();
				buffer[1] = br.ReadByte();
				buffer[2] = br.ReadByte();
				if (((sbyte)buffer[2]) < 0)
				{
					buffer[3] = 0xff;
				}
				else
				{
					buffer[3] = 0;
				}
				Data[i] = BitConverter.ToInt32(buffer, 0);
			}
			return Data;
		}
	}
}
