namespace P01.Stream_Progress.Models.Contracts
{
    public interface IStreamable
    {
        int Length { get; }
        int BytesSent { get; }
    }
}
