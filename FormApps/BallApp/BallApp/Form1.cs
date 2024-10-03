using static System.Formats.Asn1.AsnWriter;

namespace BallApp {
    public partial class Form1 : Form {

        private int scoreCount = 0; //スコアカウント用

        //Listコレクション
        private List<Obj> balls = new List<Obj>();    //ボールインスタンス格納用
        private List<PictureBox> pbs = new List<PictureBox>();      //表示用

        //バー用
        private Bar bar;
        private PictureBox pbBar;

        //コンストラクタ
        public Form1() {
            InitializeComponent();
        }

        //フォームが最初にロードされるとき一度だけ実行される
        private void Form1_Load(object sender, EventArgs e) {
            this.Text = "BallApp SoccerBall:0  TennisBall:0";

            score.Text = "スコア：" + this.scoreCount;

            bar = new Bar(340, 500);
            pbBar = new PictureBox();

            pbBar.Image = bar.Image;
            pbBar.Location = new Point((int)bar.PosX, (int)bar.PosY);
            pbBar.Size = new Size(150, 10);
            pbBar.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBar.Parent = this;
        }

        private void timer1_Tick(object sender, EventArgs e) {

            for (int i = 0; i < balls.Count; i++) {
                int ret = balls[i].Move(pbBar, pbs[i]);
                if (ret == 1) {
                    //落下したボールインスタンスを削除する 
                    balls.RemoveAt(i);
                    pbs[i].Location = new Point(2000, 2000);
                    pbs.RemoveAt(i);

                    this.scoreCount -= 10;
                    score.Text = "スコア：" + this.scoreCount;

                } else if (ret == 2) {

                    pbs[i].Location = new Point((int)balls[i].PosX, (int)balls[i].PosY);
                    score.Text = "スコア：" + ++this.scoreCount;

                } else {
                    //正常移動
                    pbs[i].Location = new Point((int)balls[i].PosX, (int)balls[i].PosY);
                }


            }
        }

        //マウスクリックイベントハンドラ
        private void Form1_MouseClick(object sender, MouseEventArgs e) {
            PictureBox pb = new PictureBox();   //画像を表示するコントロール
            Obj ball = null;

            if (e.Button == MouseButtons.Left) {
                ball = new SoccerBall(e.X - 25, e.Y - 25);
                pb.Size = new Size(50, 50);

            } else if (e.Button == MouseButtons.Right) {
                ball = new TennisBall(e.X - 12, e.Y - 12);
                pb.Size = new Size(25, 25);
            }
            pb.Image = ball.Image;
            pb.Location = new Point((int)ball.PosX, (int)ball.PosY);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Parent = this;
            timer1.Start();

            balls.Add(ball);
            pbs.Add(pb);

            this.Text = "BallApp SoccerBall:" + SoccerBall.Count + "  TennisBall:" + TennisBall.Count;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            bar.Move(e.KeyCode);
            pbBar.Location = new Point((int)bar.PosX, (int)bar.PosY);
        }
    }
}
