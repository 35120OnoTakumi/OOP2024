using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    internal class Bar : Obj {

        public Bar(double xp, double yp)
            : base(xp, yp, @"Picture\bar.png") {

            MoveX = 10;
            MoveY = 0;
        }

        public override int Move(PictureBox pbBar, PictureBox pbBall) {
            return 0;
        }

        public override bool Move(Keys direction) {
            if (direction == Keys.Right) {
                if (PosX < 635) {
                    PosX += MoveX;
                }
            } else if (direction == Keys.Left) {
                if (PosX > 0) {
                    PosX -= MoveX;
                }
            }
            return true;
        }
    }
}
