using System;
using System.Xml;

namespace Exercise01 {
    internal class DataContractSerializer {
        private Type type;

        public DataContractSerializer(Type type) {
            this.type = type;
        }

        internal void WriteObject(XmlWriter writer, Employee[] emps) {
        }
    }
}