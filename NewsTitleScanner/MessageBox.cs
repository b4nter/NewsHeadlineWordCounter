using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsTitleScanner
{
    class MessageBox
    {
        private List<string> _messages;
        public string _message { get;}

        public MessageBox(List<string> messages)
        {
            _messages = messages;
        }

    }
}
