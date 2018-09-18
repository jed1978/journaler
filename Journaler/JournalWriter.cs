using System;
using System.IO;
using System.Text;

namespace Journaler
{
    public class JournalWriter : IDisposable
    {
        private BufferedStream _journalStream;
        private int _bufferSize;

        public JournalWriter(string journalFile)
        {
            _bufferSize = 65536;
            _journalStream =
                new BufferedStream(new FileStream(journalFile, FileMode.Append, FileAccess.Write, FileShare.Read), _bufferSize);
        }

        public void Append(string eventInfo)
        {
            var data = Encoding.UTF8.GetBytes(eventInfo);
            _journalStream.Write(data, 0, data.Length);
        }

        public void Dispose()
        {
            _journalStream.Flush();
            _journalStream?.Dispose();
        }
    }
}