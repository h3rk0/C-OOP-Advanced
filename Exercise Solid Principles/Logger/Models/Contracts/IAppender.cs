using Logger.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Contracts
{
    public interface IAppender
    {
		ILayout Layout { get; }

		ErrorLevel ErrorLevel { get; }

		void Append(IError error);
    }
}
