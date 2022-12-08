namespace Models
{
    using P01.Stream_Progress.Models.Contracts;
    public class StreamProgressInfo
    {
        private IStreamable streamSource;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IStreamable streamSource)
        {
            this.streamSource = streamSource;
        }

        public int CalculateCurrentPercent()
        {
            return streamSource.BytesSent * 100 / streamSource.Length;
        }
    }
}
