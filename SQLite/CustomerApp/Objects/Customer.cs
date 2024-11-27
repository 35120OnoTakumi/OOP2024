using SQLite;

namespace CustomerApp.Objects {
    public class Customer {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 電話番号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 住所
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 画像 (byte[] に変更)
        /// </summary>
        public byte[] Picture { get; set; }

        public override string ToString() {
            return $"{Id}   {Name}  {Phone}    {Address}";
        }
    }
}
