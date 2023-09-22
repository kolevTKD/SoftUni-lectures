namespace P01.Stream_Progress
{
    public class File : IStreamable
    {
        public File(string name, int length, int bytesSent)
        {
            Name = name;
            Length = length;
            BytesSent = bytesSent;
        }
        public string Name { get; private set; }
        public int Length { get; set; }
        public int BytesSent { get; set; }
    }
}
