using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BallApp {
    internal class SoccerBall : Obj {
        Random random = new Random();   //乱数インスタンス

        public static int Count {  get; set; }

        public SoccerBall(double xp, double yp)
            : base(xp, yp, @"Picture\soccer_ball.png") {

#if DEBUG
            MoveX = 5;
            MoveY = 5;
#else
        
            MoveX = random.Next(-25, 25); //移動量設定
            MoveY = random.Next(-25, 25); 
#endif


            Count++;
        }
        //戻り値: 0…移動OK　1…落下  2…バーに当たる
        public override int Move(PictureBox pbBar, PictureBox pbBall) {
            int ret = 0;
            Rectangle rBar = new Rectangle(pbBar.Location.X,pbBar.Location.Y,
                                                         pbBar.Width, pbBar.Height);

            Rectangle rBall = new Rectangle(pbBall.Location.X, pbBall.Location.Y,
                                                         pbBall.Width, pbBall.Height);


            if (PosX > 750 || PosX < 0) {
                //移動量の符号を反転
                MoveX = -MoveX;
            }

            if (PosY < 0) {
                //移動量の符号を反転
                MoveY = -MoveY;
            }

            //バーに当たったかの判定（IntersectsWith）
            if (rBar.IntersectsWith(rBall)) {
                MoveY = -MoveY;
                ret = 2;
            }

            PosX += MoveX;
            PosY += MoveY;

            //下に落下したか？
            if (PosY > 500)
                ret = 1;
                                   
            //移動完了
            return ret;
        }

        public override bool Move(Keys direction) {
            return true;
        }
    }
}
