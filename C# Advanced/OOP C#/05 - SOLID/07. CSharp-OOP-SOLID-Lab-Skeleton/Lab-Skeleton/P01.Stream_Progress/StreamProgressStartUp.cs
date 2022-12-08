using Models;
using P01.Stream_Progress.Models;
using P01.Stream_Progress.Models.Contracts;
using System;

namespace P01.Stream_Progress
{
    public class StreamProgressStartUp
    {
        static void Main()
        {
            IStreamable file = new File("OOP", 500, 1000);
            IStreamable music = new Music("Fyre", "Caesar", 600, 3000);
            IStreamable html = new HTML("../../../index.html", 200, 300);

            StreamProgressInfo spif = new StreamProgressInfo(file);
            StreamProgressInfo spim = new StreamProgressInfo(music);
            StreamProgressInfo spihtml = new StreamProgressInfo(html);
        }
    }
}
