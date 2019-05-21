# learn-surveying-software-designing
测绘软件设计课程学习 无指定教材
语言 C#
IDE Microsoft Visual Studio



## Part 1 c#编程基础


## Part 2 水准路线计算

### 1>计算近似值

已知：n, t, r=n-6
 A矩阵 n*t阶   数值为1，-1，0组成的稀疏矩阵 
 两个整性矩阵    B n*2   In n*2
 
 V = A * dx + l
 Pi=C/Si    C取1
 Naa=A.T*P*A
 Naa[i,j] =n*pij*n+ 
 
 实现： 同时组误差方程和法方程


### 2>精度评定

m0 = sqrt( [pvv] / (n - t))      [pvv]在组成误差方程时计算   注意统计值初始化
mxi = m0 * sqrt(Qxixi)

###3>拓展


## Part 3 测绘软件设计
