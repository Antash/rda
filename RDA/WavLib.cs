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
	}
}
