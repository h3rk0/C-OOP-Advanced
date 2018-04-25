using Logger.Enums;
using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models
{
	public class ConsoleAppender : IAppender
	{
		public ConsoleAppender(ILayout layout,ErrorLevel level)
		{
			this.Layout = layout;
			this.ErrorLevel = level;
		}

		public ILayout Layout { get; }

		public ErrorLevel ErrorLevel { get; }

		public int MessagesAppended { get; private set; }

		public void Append(IError error)
		{
			string formatted = this.Layout.FormatError(error);
			this.MessagesAppended++;
			Console.WriteLine(formatted);
		}

		public override string ToString()
		{
			string result = $"Appender type: {this.GetType().Name}," +
				$" Layout type: {this.Layout.GetType().Name}, " +
				$"Report level: {this.ErrorLevel.ToString()}," +
				$" Messages appended: {this.MessagesAppended}";
			return result;
		}
	}
}
