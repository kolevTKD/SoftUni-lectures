namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;
    using MusicHub.Data.Models;

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
                .Where(a => a.ProducerId.HasValue
                         && a.ProducerId.Value == producerId)
                .AsEnumerable()
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                        {
                            SongName = s.Name,
                            Price = s.Price.ToString("F2"),
                            Writer = s.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.Writer)
                        .ToList(),
                    TotalAlbumPrice = a.Price.ToString("F2")
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
                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{songNumber++}")
                      .AppendLine($"---SongName: {song.SongName}")
                      .AppendLine($"---Price: {song.Price}")
                      .AppendLine($"---Writer: {song.Writer}");
                }

                sb.AppendLine($"-AlbumPrice: {album.TotalAlbumPrice}");
            }

            return sb.ToString().TrimEnd(); ;
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songPerformers = context.Songs
                .AsEnumerable()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                    {
                        SongName = s.Name,
                        Performers = s.SongPerformers.Select(sp => new
                        {
                            PerformerFullName = $"{sp.Performer.FirstName} {sp.Performer.LastName}"
                        })
                        .OrderBy(sp => sp.PerformerFullName)
                        .ToList(),
                        WriterName = s.Writer.Name,
                        AlbumProducerName = s.Album.Producer.Name,
                        Duration = s.Duration.ToString("c")
                    })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ToList();

            StringBuilder sb = new StringBuilder();
            int songNumber = 1;

            foreach (var song in songPerformers)
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
