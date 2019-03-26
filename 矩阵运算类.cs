class CMat
    {
        //构建零矩阵
        public double[,] MatZero(int m, int n)
        {
            double[,] result = new double[m, n];
            int i, j;
            for (i = 0; i <= m - 1; i++)
            {
                for (j = 0; j <= n - 1; j++)
                {
                    result[i, j] = 0.0;
                }
            }
            return result;
        }

        public double[] MatZero(int m)
        {
            double[] result = new double[m];
            int i;
            for (i = 0; i <= m - 1; i++)
            {
                result[i] = 0.0;
            }
            return result;
        }
        //乘-1
        public double[] MatNegat(double[] a)
        {
            int m = a.GetLength(0);
            double[] result = new double[m];
            int i;
            for (i = 0; i <= m - 1; i++)
            {
                result[i] = (-1) * a[i];
            }
            return result;
        }
        //求矩阵转置
        public double[,] MatTrans(double[,] a)
        {
            double[,] result = null;
            int m = a.GetLength(0);
            int n = a.GetLength(1);
            double[,] b = new double[n, m];
            int i, j;
            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    b[j, i] = a[i, j];
                }
            }
            result = b;
            return result;
        }

        //求矩阵相乘
        public double[,] MatMulti(double[,] a, double[,] b)
        {
            double[,] result = null;
            int m1 = a.GetLength(0);
            int n1 = a.GetLength(1);
            int m2 = b.GetLength(0);
            int n2 = b.GetLength(1);
            if (n1 != m2) return null;
            double[,] c = new double[m1, n2];
            int i, j, k;
            for (i = 0; i < m1; i++)
            {
                for (j = 0; j < n2; j++)
                {
                    c[i, j] = 0;
                    for (k = 0; k < n1; k++)
                    {
                        c[i, j] = c[i, j] + a[i, k] * b[k, j];
                    }
                }
            }
            result = c;
            return result;
        }

        //二维矩阵乘以一维矩阵
        public double[] MatMulti(double[,] a, double[] b)
        {
            double[] result = null;
            int m1 = a.GetLength(0);
            int n1 = a.GetLength(1);
            int m2 = b.GetLength(0);
            if (n1 != m2) return null;
            double[] c = new double[m1];
            int i, j, k;
            for (i = 0; i < m1; i++)
            {
                c[i] = 0;
                for (k = 0; k < n1; k++)
                {
                    c[i] = c[i] + a[i, k] * b[k];
                }
            }
            result = c;
            return result;
        }

        //求矩阵方差
        public double MatVaria(double[,] a)
        {
            int m = a.GetLength(0);
            int n = a.GetLength(1);
            int i, j;
            double sum = 0;
            double aeve = MatAvera(a);

            for (i = 0; i <= m - 1; i++)
            {
                for (j = 0; j <= n - 1; j++)
                {
                    sum = sum + Math.Pow((a[i, j] - aeve), 2);
                }
            }
            double result = sum / m / n;
            return result;
        }

        //求方差   int型
        public double MatVaria(int[,] a)
        {
            int m = a.GetLength(0);
            int n = a.GetLength(1);
            int i, j;
            double sum = 0;
            double aeve = MatAvera(a);//矩阵均值

            for (i = 0; i <= m - 1; i++)
            {
                for (j = 0; j <= n - 1; j++)
                {
                    sum = sum + Math.Pow((a[i, j] - aeve), 2);
                }
            }
            double result = sum / m / n;
            return result;
        }

        //求矩阵均值
        public double MatAvera(double[,] a)
        {
            double result = 0;
            int m = a.GetLength(0);
            int n = a.GetLength(1);

            int i, j;
            double sum = 0;
            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    sum = sum + a[i, j];
                }
            }
            result = sum / m / n;
            return result;
        }

        //求矩阵均值
        public double MatAvera(int[,] a)
        {
            double result = 0;
            int m = a.GetLength(0);
            int n = a.GetLength(1);

            int i, j;
            double sum = 0;
            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    sum = sum + a[i, j];
                }
            }
            result = sum / m / n;
            return result;
        }

        //求两个矩阵协方差
        public double MatCovar(double[,] a, double[,] b)
        {
            //还需要先判断两个矩阵形式
            int m = a.GetLength(0);
            int n = a.GetLength(1);
            int i, j;
            double aev1 = MatAvera(a);
            double aev2 = MatAvera(b);
            double sum = 0;
            for (i = 0; i <= m - 1; i++)
            {
                for (j = 0; j <= n - 1; j++)
                {
                    sum = sum + (a[i, j] - aev1) * (b[i, j] - aev2);//协方差
                }
            }
            double result = sum / m / n;
            return result;
        }

        public double MatCovar(int[,] a, int[,] b)
        {
            int m = a.GetLength(0);
            int n = a.GetLength(1);
            int i, j;
            double aev1 = MatAvera(a);
            double aev2 = MatAvera(b);
            double sum = 0;
            for (i = 0; i <= m - 1; i++)
            {
                for (j = 0; j <= n - 1; j++)
                {
                    sum = sum + (a[i, j] - aev1) * (b[i, j] - aev2);
                }
            }
            double result = sum / m / n;
            return result;
        }

        //求两个矩阵相关系数
        public double MatCorr(double[,] a, double[,] b)
        {
            double var1 = MatVaria(a);
            double var2 = MatVaria(b);
            double cov12 = MatCovar(a, b);
            double result = cov12 / Math.Sqrt(var1 * var2);
            return result;
        }
        public double MatCorr(int[,] a, int[,] b)
        {
            double var1 = MatVaria(a);
            double var2 = MatVaria(b);
            double cov12 = MatCovar(a, b);
            double result = cov12 / Math.Sqrt(var1 * var2);
            return result;
        }

        //求逆函数
        public double[,] MatInver(double[,] n) //求逆函数
        {
            int m = n.GetLength(0);
            double[,] q = new double[m, m]; //法方程系数逆矩阵;
            double u;
            int i, j, k;
            //置零
            for (i = 0; i <= m - 1; i++)
            {
                for (j = 0; j <= m - 1; j++)
                {
                    if (i == j)
                    {
                        q[i, j] = 1;
                    }
                    else
                    {
                        q[i, j] = 0;
                    }
                }
            }
            // 求左下
            for (i = 0; i <= m - 2; i++)
            {
                //提取各行的主对角线元素
                u = n[i, i];
                for (j = 0; j <= m - 1; j++)//使i行的主对角线元素为1
                {
                    n[i, j] = n[i, j] / u;
                    q[i, j] = q[i, j] / u;
                }
                for (k = i + 1; k <= m - 1; k++)
                {
                    u = n[k, i];
                    for (j = 0; j <= m - 1; j++)
                    {
                        n[k, j] = n[k, j] - u * n[i, j];
                        q[k, j] = q[k, j] - u * q[i, j];
                    }
                }
            }

            u = n[m - 1, m - 1];
            n[m - 1, m - 1] = 1;
            for (j = 0; j <= m - 1; j++)
            {
                q[m - 1, j] = q[m - 1, j] / u;
            }

            // 求右上
            for (i = m - 1; i >= 0; i--)
            {
                for (k = i - 1; k >= 0; k--)
                {
                    u = n[k, i];
                    for (j = 0; j <= m - 1; j++)
                    {
                        n[k, j] = n[k, j] - u * n[i, j];
                        q[k, j] = q[k, j] - u * q[i, j];
                    }
                }

            }
            return q;
        }


    }
