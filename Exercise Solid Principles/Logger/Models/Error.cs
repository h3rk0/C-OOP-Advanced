﻿using Logger.Enums;
using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models
{
	public class Error : IError
	{
		public Error(DateTime dateTime, ErrorLevel level,string message)
		{
			this.DateTime = dateTime;
			this.ErrorLevel = level;
			this.Message = message;

		}

		public DateTime DateTime { get; }

		public string Message { get; }

		public ErrorLevel ErrorLevel { get; }
	}
}
