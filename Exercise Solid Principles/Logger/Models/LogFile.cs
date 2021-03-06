﻿using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Logger.Models
{
	public class LogFile : ILogFile
	{
		const string DefaultPath = "./data/";

		public LogFile(string fileName)
		{
			this.Path = DefaultPath + fileName;
			InitiallizeFile();
			this.Size = 0;
		}

		private void InitiallizeFile()
		{
			Directory.CreateDirectory(DefaultPath);
			File.AppendAllText(this.Path, string.Empty);
		}

		public string Path { get; }

		public int Size { get; private set; }

		public void WriteToFile(string errorLog)
		{
			File.AppendAllText(this.Path, errorLog + Environment.NewLine);
			int addedSize = 0;
			for (int i = 0; i < errorLog.Length; i++)
			{
				addedSize += errorLog[i];
			}

			this.Size += addedSize;
		}
	}
}
