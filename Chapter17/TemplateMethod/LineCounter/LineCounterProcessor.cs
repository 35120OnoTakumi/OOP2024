using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;

namespace LineCounter {
    class LineCounterProcessor : TextProcessor{

        private int _count;
        //string _text = "";

        protected override void Initialize(string fname) {
            _count = 0;
        }

        protected override void Execute(string line) {
           // _text += line;
            _count++;
        }

        protected override void Terminate() {
            Console.WriteLine("{0} 行",_count);
           // Console.WriteLine(_text);
        }
    }
}
