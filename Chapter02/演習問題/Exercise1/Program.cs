using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    internal class Program {
        static void Main(string[] args) {
        //2.1.3
            var songs = new Song[] {
                new Song("ab","cd",255),
                new Song("gh","ef",245),
                new Song("ij","kl",222)
            };
            PrintSongs(songs);
        }
        //2.1.4
        private static void PrintSongs(Song[] songs) {

            foreach (var song in songs) {
                Console.WriteLine(@"{0},{1} {2:mm\:ss}", song.Title, song.ArtistName,
                    TimeSpan.FromSeconds(song.Length));
            }
        }
    }
}
