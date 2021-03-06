'''
间接平差
已知G07-G11边长为定值
main.py
'''

import pandas as pd
import numpy as np
import sys
np.set_printoptions(threshold=sys.maxsize) #print显示完整array
from gnssnet import *
import math

def Save2Excel(mats,name):
        data = pd.DataFrame(mats)
        writer = pd.ExcelWriter("C:\\Users\\sheld\\Desktop\\111\\附有限制条件的间接平差的"+ name + ".xlsx")
        data.to_excel(writer, "page_1", float_format = '%.6f')#浮点数，精确到6位小数
        writer.save()
        writer.close()



def init_GNSSNet(G):

#读入所有的基线坐标信息
    with open("data.csv",'r') as f:
        for line in f.readlines():
            b= Baseline()
            b.init_baseline(line.split(','))
            G.insert_Baseline(b)

        f.close()

#已经手算过近似坐标了
    with open("zhandian.csv",'r',encoding='UTF-8-sig') as f:
        i = 1
        for line in f.readlines():
                
                p = station()
                p.init_station2(line)

                if not p.cat_match():
                        p.beizhu(i)
                        i = i + 1
                G.insert_Station(p)
        f.close()


n = 63
t = 24
r = n - t
s = 1
u = t + s

S = math.sqrt(366.6087**2 + (252.4815)**2 + 72.1291**2)

global G
G = GNSSNet()
init_GNSSNet(G)

P = np.zeros([n,n], dtype = float)
L = np.zeros([n,1], dtype = float)
l = np.zeros([n,1], dtype = float)




'''
L^ = BX^ + d
Fai(X^) = 0

l = L - (BX0 + d)
V = Bx^ - l
'''
B =  np.zeros([n,u], dtype = float)
d = np.zeros([n,1], dtype = float)

X0 = np.zeros([u,1], dtype = float)
x = np.zeros([u,1], dtype = float)


'''
Cx^ + Wx = 0
'''

C =  np.zeros([s,u], dtype = float)
Wx = np.zeros([s,1], dtype = float)

#写入B,d矩阵
for baseline in G.BaselineSet:
        bl_inf = baseline.baseline_inf()
        num = bl_inf[0]
        origin = bl_inf[1]
        target = bl_inf[2]

        #起点
        found,ifknow,stat_inf  = G.Station_Cat_Match(origin)
        if ifknow:
                d[3 * num - 3][0] = d[3 * num - 3][0] - stat_inf[2]
                d[3 * num - 2][0] = d[3 * num - 2][0] - stat_inf[3]
                d[3 * num - 1][0] = d[3 * num - 1][0] - stat_inf[4]
##                print(num,bl_inf,"起点是已知点",stat_inf)
        elif not ifknow:
                B[3 * num - 3][3 * stat_inf[6] - 3] = -1
                B[3 * num - 2][3 * stat_inf[6] - 2] = -1
                B[3 * num - 1][3 * stat_inf[6] - 1] = -1
##                print(num,bl_inf,"起点是未知点",stat_inf)
                
        else:
                print("有错误的站点名")
        
        #末尾
        found,ifknow,stat_inf  = G.Station_Cat_Match(target)
        if ifknow:
                d[3 * num - 3][0] = d[3 * num - 3][0] + stat_inf[2]
                d[3 * num - 2][0] = d[3 * num - 2][0] + stat_inf[3]
                d[3 * num - 1][0] = d[3 * num - 1][0] + stat_inf[4]
##                print(num,bl_inf,"终点是已知点",stat_inf)
                
        elif not ifknow:
                B[3 * num - 3][3 * stat_inf[6] - 3] = 1
                B[3 * num - 2][3 * stat_inf[6] - 2] = 1
                B[3 * num - 1][3 * stat_inf[6] - 1] = 1
##                print(num,bl_inf,"终点是未知点",stat_inf)
        else:
                print("有错误的站点名")


##        print(B[3 * num - 3])
##        print(B[3 * num - 2])
##        print(B[3 * num - 1])
##        print(d[3 * num - 3])
##        print(d[3 * num - 2])
##        print(d[3 * num - 1])


#定权
P = G.init_P(P)
L = G.init_L(L)
x0 = G.init_X0(X0)

X0[3*8][0] = math.sqrt(366.6087**2 + (252.4815)**2 + 72.1291**2)

#写入C、W矩阵 G01-G02

G01_X = -2612808.8378000
G01_Y = 4748993.2784000
G01_Z = 3350430.6698000

G02_X0 = -2613175.4394000
G02_Y0 = 4748740.7892000
G02_Z0 = 3350502.7893000

S0 = math.sqrt(366.6087**2 + (252.4815)**2 + 72.1291**2)

C[0][3] = 2* G02_X0
C[0][4] = 2* G02_Y0
C[0][5] = 2* G02_Z0

C[0][24] = -2 * S0

Wx[0][0] = -2*G01_X - 2*G01_Y -2*G01_Z



P = np.matrix(P)
L = np.matrix(L)
X0 = np.matrix(X0)
d = np.matrix(d)
B = np.matrix(B)

C = np.matrix(C)
Wx = np.matrix(Wx)

#矩阵的秩
print(np.linalg.matrix_rank(B, tol=None, hermitian=False))
print(np.linalg.matrix_rank(Wx, tol=None, hermitian=False))


print("C:\n",C)
Save2Excel(C,"C")
print("Wx:\n",Wx)

Q = P.I


##print("X0:\n",X0)
##print("L:\n",L)
##
##print("d:\n",d)

print("B:\n",B)
Save2Excel(B,"B")
l = L - np.dot(B,X0) - d
##print("l:\n",l)


###化成毫米单位
##l = np.matrix(np.dot(l, 1000))

#Nbbx^ - W = 0
Nbb = np.dot(np.dot(B.T, P), B)
Save2Excel(Nbb,"Nbb")

print("Nbb:\n",Nbb,Nbb.shape)
W = np.dot(np.dot(B.T, P), l)

Ncc = np.dot(np.dot(C, Nbb.I), C.T)


#矩阵的秩
print(np.linalg.matrix_rank(B, tol=None, hermitian=False))
print(np.linalg.matrix_rank(P, tol=None, hermitian=False))

#x^
x =  np.dot((Nbb.I - np.dot(np.dot(np.dot(np.dot(Nbb.I, C.T ), Ncc.I ) , C ) ,  Nbb.I))  , W ) - np.dot( np.dot( np.dot( Nbb.I , C.T ) , Ncc.I ) , Wx )

V = np.dot(B,x) - l




print('x',x,'\n')

print('V',V,'\n')

time =  1
V_total = V
x_total = x
##
##while  abs(V.max()) > 0.00001 and time < 10000:
##        L = L + V/1000
##        X0 = X0 + x/1000
##
##        l = L - np.dot(B,X0) - d
##
##        l = np.matrix(np.dot(l, 1000))
##        x =  np.dot(Nbb.I,W)
##        V = np.dot(B,x) - l
##        
##        V_total = V_total + V
##        x_total = x_total + x
##        time = time + 1
##
##

L = L + V
X0 = X0 + x


##L = L + V/1000
##X0 = X0 + x/1000

print('L^',L)

print("time:",time,'\n')
print('V_total',V_total,'\n')
print('x_total',x_total,'\n')




sigema02 = np.dot(np.dot(V_total.T,P),V_total)/r

sigema0 = math.sqrt(sigema02)

print(sigema0)


Save2Excel(B,"B")
Save2Excel(d,"d")
Save2Excel(L,"L^")
Save2Excel(l,"l")
Save2Excel(X0,"X^")
Save2Excel(V_total,"V_total")
Save2Excel(x_total,"x_total")


