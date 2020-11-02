





```c
            ////平均角速度n
            //double miu = 3986005e8; //GM
            //double n0 = Math.Sqrt(miu)/Math.Pow(sats.EpochSats[0].Paras[7], 3);
            //double n = n0 + sats.EpochSats[0].Paras[2];
            ////归化观测时间tk
            
            //long t = get_gpstime(sats.EpochSats[0], 's');
            //long tk = t - long.Parse(sats.EpochSats[0].Paras[8].ToString());

            //////////////////////

            ////计算观测时刻的卫星平近点角Mk
            //double Mk = sats.EpochSats[0].Paras[3] + n * tk;
            ////观测时刻的偏近点角Ek
            //double e1 = sats.EpochSats[0].Paras[5]; //偏心率命名为e1
            //double Ek = Mk;
            //double t1 = 0.0;
            //while ((Ek - t) > 0.00000001)
            //{
            //    t1 = Ek;
            //    Ek += e1 * Math.Sin(Ek);
            //}
            ////计算真近点角Vk

            //double Vk = 2 * Math.Atan(Math.Sqrt((1 + e1) / (1 - e1)) * Math.Tan(Ek / 2));
            ////计算升交距Faik
            //double Faik = Vk + sats.EpochSats[0].Paras[14];
            ////计算摄动改正项
            //double du,dr,di;
            //double Cuc = sats.EpochSats[0].Paras[4];
            //double Cus = sats.EpochSats[0].Paras[6];
            //double Crc = sats.EpochSats[0].Paras[13];
            //double Crs = sats.EpochSats[0].Paras[1];
            //double Cic = sats.EpochSats[0].Paras[9];
            //double Cis = sats.EpochSats[0].Paras[11];
            //du = Cuc * Math.Cos(2 * Faik) + Cus * Math.Sin(2 * Faik);
            //dr = Crc * Math.Cos(2 * Faik) + Crs * Math.Sin(2 * Faik);
            //di = Cic * Math.Cos(2 * Faik) + Cis * Math.Sin(2 * Faik);
            ////计算经摄动改正的升交距角uk卫星矢径rk轨道倾角ik
            //double uk = Faik + du;
            //double rk = Math.Pow(sats.EpochSats[0].Paras[7], 2) * (1 - e1 * Math.Cos(Ek)) + dr;
            //double ik = sats.EpochSats[0].Paras[12] + di + sats.EpochSats[0].Paras[16] * tk;
            ////计算卫星在轨道坐标系的坐标
            //double xk = rk * Math.Cos(uk);
            //double yk = rk * Math.Sin(uk);
            //double zk = 0;
            ////计算观测时刻t的升交点经度Lk
            //double omigae = 729211515e-5;
            //double Lk = sats.EpochSats[0].Paras[10] + (sats.EpochSats[0].Paras[15] - omigae)* tk - omigae * sats.EpochSats[0].Paras[8];
            ////计算卫星在WGS84下的坐标
            //double Xk = xk * Math.Cos(Lk) - yk * Math.Cos(ik) * Math.Sin(Lk);
            //double Yk = xk * Math.Sin(Lk) + yk * Math.Cos(ik) * Math.Cos(Lk);
            //double Zk = yk * Math.Sin(ik);

```