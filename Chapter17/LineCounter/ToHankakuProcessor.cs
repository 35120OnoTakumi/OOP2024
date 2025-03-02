﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;
using TextNumberSizeChange.Framework;

namespace TextNumberSizeChange {
    class ToHankakuProcessor : ITextFileService {

        private int _count;
        private StringBuilder _text = new StringBuilder();

        public void Initialize(string fname) {
            _count = 0;
        }

        public void Execute(string line) {
            // 全角数字を半角数字に置き換え
            string convertedLine = ConvertToHankakuNumbers(line);
            _text.AppendLine(convertedLine); // 半角にしたものを追加する
            _count++;
        }

        public void Terminate() {
            Console.WriteLine("{0} 行", _count);
            Console.WriteLine(_text.ToString());
        }

        private string ConvertToHankakuNumbers(string input) {
            // 全角数字と半角数字の割当表
            char[] fullWidthDigits = { '０', '１', '２', '３', '４', '５', '６', '７', '８', '９' };
            char[] halfWidthDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            for (int i = 0; i < fullWidthDigits.Length; i++) {
                input = input.Replace(fullWidthDigits[i], halfWidthDigits[i]);
            }

            return input;
        }

    }
}
