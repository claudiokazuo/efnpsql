using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace Domain.Commands
{
    public interface ICommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
