 private double DmsToRad(double dms)
        {
            double result = 0;
            double d = Math.Floor(dms);
            double t = (dms - d) * 100;
            double m = Math.Floor(t);
            double s = (t - m) * 100;
            result = (d + m / 60 + s / 3600) * Math.PI / 180;
            return result;
        }

private double RadToDms(double rad)
        {
            double result = 0;
            double deg = 180 * rad / Math.PI;
            double d = Math.Floor(deg);
            double t = (deg - d) * 60;
            double m = Math.Floor(t);
            double s = (t - m) * 60;
            result = d + m / 100 + s / 10000;
            return result;
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
        
