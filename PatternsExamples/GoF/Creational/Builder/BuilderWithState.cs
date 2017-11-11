using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PatternsExamples.GoF.Creational.Builder._232323 {
    public class Start
    {
        public Start()
        {
            new MailMessageBuilder(new MailMessage()).To("me@nn.com").Build();
        }
    }


    public class MailMessageBuilder {
        private readonly MailMessage _mailMessage;
        internal MailMessageBuilder(MailMessage mailMessage) {
            _mailMessage = mailMessage;
        }
        public FinalMailMessageBuilder To(string address) {
            _mailMessage.To.Add(address);
            // Для большей эффективности может быть добавлено кэширование
            return new FinalMailMessageBuilder(_mailMessage);
        }
        // Остальные методы остались без изменения
    }
    public class FinalMailMessageBuilder {
        private readonly MailMessage _mailMessage;
        internal FinalMailMessageBuilder(MailMessage mailMessage) {
            _mailMessage = mailMessage;
        }
        public MailMessage Build() {
            return _mailMessage;
        }
    }
}
