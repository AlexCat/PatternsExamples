using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternsExamples.GoF.Creational.Builder._sfdfdf;

namespace PatternsExamples.GoF.Creational.Builder._sfdfdf {

    public class Start {
        public Start() {
            var mailMessage =
                MailMessage.With()
                    .From("st@unknown.com")
                    .To("support@microsof.com")
                    .Subject("Msdn is down!")
                    .Body("Please fix!")
                    .Build();
            Console.WriteLine(mailMessage.To);
        }
    }

    public class MailMessage {
        private string _to;
        private string _from;
        private string _subject;
        private string _body;

        private MailMessage() { }

        public static MailMessageBuilder With() {
            return new MailMessageBuilder(new MailMessage());
        }

        public string To { get { return _to; } }
        public string From { get { return _from; } }
        public string Subject { get { return _subject; } }
        public string Body { get { return _body; } }

        // Объявлен внутри класса MailMessage
        public class MailMessageBuilder {
            private readonly MailMessage _mailMessage;
            internal MailMessageBuilder(MailMessage mailMessage) {
                _mailMessage = mailMessage;
            }
            public MailMessageBuilder To(string to) {
                _mailMessage._to = to;
                return this;
            }
            public MailMessageBuilder From(string from) {
                _mailMessage._from = from;
                return this;
            }
            public MailMessageBuilder Subject(string subject) {
                _mailMessage._subject = subject;
                return this;
            }
            public MailMessageBuilder Body(string body) {
                _mailMessage._body = body;
                return this;
            }
            public MailMessage Build() {
                return _mailMessage;
            }
        }
    }


}
