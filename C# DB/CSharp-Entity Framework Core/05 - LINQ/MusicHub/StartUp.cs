namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //int producerId = int.Parse(Console.ReadLine());
            //Console.WriteLine(ExportAlbumsInfo(context, producerId));

            int duration = int.Parse(Console.ReadLine());
            Console.WriteLine(ExportSongsAboveDuration(context, duration));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var producerAlbums = context.Albums
                .Where(a => a.ProducerId.HasValue &&
                            a.ProducerId.Value == producerId)
                .AsEnumerable()
                .OrderByDescending(a => a.Price)
                .Select(album => new
                {
                    AlbumName = album.Name,
                    ReleaseDate = album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = album.Producer.Name,
                    AlbumSongs = album.Songs
                        .Select(song => new
                        {
                            SongName = song.Name,
                            Price = song.Price.ToString("f2"),
                            WriterName = song.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.WriterName)
                        .ToList(),
                    TotalAlbumPrice = album.Price.ToString("f2")
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var album in producerAlbums)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}")
                  .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                  .AppendLine($"-ProducerName: {album.ProducerName}")
                  .AppendLine("-Songs:");

                int songNumber = 1;

                foreach (var song in album.AlbumSongs)
                {
                    sb.AppendLine($"---#{songNumber++}")
                      .AppendLine($"---SongName: {song.SongName}")
                      .AppendLine($"---Price: {song.Price}")
                      .AppendLine($"---Writer: {song.WriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.TotalAlbumPrice}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .AsEnumerable()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(song => new
                {
                    SongName = song.Name,
                    Performers = song.SongPerformers
                        .Select(sp => new
                        {
                            PerformerFullName = $"{sp.Performer.FirstName} {sp.Performer.LastName}"
                        })
                        .OrderBy(sp => sp.PerformerFullName)
                        .ToList(),
                    WriterName = song.Writer.Name,
                    AlbumProducerName = song.Album.Producer.Name,
                    Duration = song.Duration
                        .ToString("c")
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            int songNumber = 1;

            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{songNumber++}")
                  .AppendLine($"---SongName: {song.SongName}")
                  .AppendLine($"---Writer: {song.WriterName}");

                foreach (var performer in song.Performers)
                {
                    sb.AppendLine($"---Performer: {performer.PerformerFullName}");
                }

                sb.AppendLine($"---AlbumProducer: {song.AlbumProducerName}")
                  .AppendLine($"---Duration: {song.Duration}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
