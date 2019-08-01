using IdentityDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityDemo.ViewModels
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }

    public class CreateMessageViewModel
    {
        public CreateMessageViewModel()
        {

        }
        public CreateMessageViewModel(Message message)
        {
            Text = message.Text;
        }
        public string Text { get; set; }
    }
}
