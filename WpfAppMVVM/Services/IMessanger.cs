using System;
using System.Collections.Generic;
using System.Text;
using WpfAppMVVM.Message;

namespace WpfAppMVVM.Services
{
    public interface IMessanger
    {
        void Subcribe<T>(Action<object> action) where T : IMessage;
        void Send<T>(T message) where T : IMessage;
    }
}
