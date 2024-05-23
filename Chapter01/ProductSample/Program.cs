using SampleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {
    internal class Program {
        static void Main(string[] args) {

            /*ブレイクポイント↓F9=ブレイクポイントの設定/解除*/
            Product karinto = new Product(123, "かりんとう", 180);
            Product daifuku = new Product(223, "大福", 250);
            Product dorayaki = new Product(98, "どら焼き", 210);

            int price = karinto.Price;//税抜き金額
            int taxIncluded = karinto.GetPriceIncludingTax();//税込み金額

            int daifukuprice = daifuku.Price;//税抜き金額
            int daifukutaxIncluded = daifuku.GetPriceIncludingTax();//税込み金額

            int dorayakiprice = dorayaki.Price;
            int dorayakitaxIncluded = dorayaki.GetPriceIncludingTax();

            Console.WriteLine(karinto.Name + "の税込金額"
                + "【" + "税抜き" + price + "円】");

            Console.WriteLine(daifuku.Name + "の税込金額" +daifukutaxIncluded
                + "【" + "税抜き" + daifukuprice + "円】");

            Console.WriteLine(dorayaki.Name + "の税込金額" + dorayakitaxIncluded
                + "【" + "税抜き" + dorayakiprice + "円】");

            /*Console.WriteLine($"{dorayakiTax}円"); *///←こんな書き方もある(コード)

        }
    }
}
