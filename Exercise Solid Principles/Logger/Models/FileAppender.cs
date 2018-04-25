using Logger.Enums;
using Logger.Models.Contracts;

namespace Logger.Models.Factories
{
	internal class FileAppender : IAppender
	{
		private ILayout layout;
		private ErrorLevel errorLevel;
		private ILogFile logFile; 
		public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile logFile)
		{
			this.Layout = layout;
			this.ErrorLevel = errorLevel;
			this.MessagesAppended = 0;
			this.logFile = logFile;
		}

		public ILayout Layout { get; }
		public int MessagesAppended { get; private set; }

		public ErrorLevel ErrorLevel { get; }

		public void Append(IError error)
		{
			string formattedError = this.Layout.FormatError(error);
			this.logFile.WriteToFile(formattedError);
			this.MessagesAppended++;
		}

		public override string ToString()
		{
			string result = $"Appender type: {this.GetType().Name}," +
				$" Layout type: {this.Layout.GetType().Name}, " +
				$"Report level: {this.ErrorLevel.ToString()}," +
				$" Messages appended: {this.MessagesAppended}, File size: {this.logFile.Size}";
			return result;
		}
	}
}