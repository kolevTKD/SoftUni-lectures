using P01.Stream_Progress.Models.Contracts;

namespace P01.Stream_Progress.Models
{
    public class HTML : IStreamable
    {
        private string path;
        public HTML(string path, int length, int bytesSent)
        {
            this.path = path;
            this.Length = length;
            this.BytesSent = bytesSent;
        }
        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}
