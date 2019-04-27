        private double DmsToRad(double dms)
        {
            //判断正负
            bool flag = true;
            if (dms < 0)
            {
                dms *= -1;
                flag = !flag;
            }

            dms += 0.00000001;    //加上一个很小的数字0.000001s
            double d = Math.Floor(dms);

            double t = (dms - d) * 100;
            double m = Math.Floor(t);

            double s = (t - m) * 100 - 0.0001;  //消去加上的数字的影响

            double result = (d + m / 60 + s / 3600) * Math.PI / 180;

            if (flag)
                return result;
            else
                return -result;

        }
        private double RadToDms(double rad)
        {
            bool flag = true;
            if (rad < 0)
            {
                rad *= -1;
                flag = !flag;
            }

            double deg = 180 * rad / Math.PI;
            double d = Math.Floor(deg);  //取整数 deg
            double t = (deg - d) * 60;
            double m = Math.Floor(t);    //min
            double s = (t - m) * 60;  //sec
            double result = d + m / 100 + s / 10000;

            if (flag)
                return result;
            else
                return -result;
        }
  //求两点的方为角
        public double azimuth(double x1, double y1, double x2, double y2)
        {
            double a;
            double dx = x2 - x1;
            double dy = y2 - y1;
            if (dx == 0)//东西方向
            {
                if (dy >= 0)
                {
                    a = Math.PI / 2;
                }
                else
                {
                    a = Math.PI * 3 / 2;
                }
            }
            else if (dy == 0)//南北方向
            {
                if (dx >= 0)
                {
                    a = 0;
                }
                else
                {
                    a = Math.PI;
                }
            }
            else//任意方向
            {
                a = Math.Atan(dy / dx);
                if (dx <= 0)//二、三象限
                {
                    a = a + Math.PI;
                }
                else if (dy <= 0)//第四象限
                {
                    a = a + 2 * Math.PI;
                }               
            }
            return a;
        }
        
