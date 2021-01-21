'''
之前测的一个控制网，12个点，4个已知，一共7个同步环，21根基线，现进行网平差

半自动化条件平差，手动输入列条件方程时用到的闭合环路线（1~10  互相独立，皆为最小环）或者坐标附和条件（11~13， 四个已知点之间的三条线）
n = 21 * 3 =63
t = 8 * 3 =24
r = n - t= 63 - 25 = 39
一共39个方程，需要39/3 = 13 个条件。 条件需要手动输入路线 如paths.csv, 如果生成的A矩阵不满秩（不是39），说明Naa不可逆，有重复用到的条件。

main.py
'''

import pandas as pd
import numpy as np
import sys
np.set_printoptions(threshold=sys.maxsize)
from gnssnet import *
import math

def Save2Excel(mats,name):
        data = pd.DataFrame(mats)
        writer = pd.ExcelWriter("C:\\Users\\sheld\\Desktop\\result\\"+ name + ".xlsx")
        data.to_excel(writer, "page_1", float_format = '%.6f')
        writer.save()
        writer.close()



def init_GNSSNet(G):
	#读取基线数据
    with open('data.csv','r') as f:
        for line in f.readlines():
            b= Baseline()
            b.init_baseline(line.split(','))
            G.insert_Baseline(b)
        f.close()
        
    #读取控制点文件
    with open('ControlPoints.csv','r') as f:
        for line in f.readlines():
            p = ControlPoint()
            p.init_controlpoint(line)
            G.insert_ControlPoint(p)
        f.close()

def init_lines(lines,t):
    i = 0
    l = len(t)
    while i < l - 1:
        a = str(t[i])
        b = str(t[i + 1])
        lines.append([a,b])
        i = i+ 1




n = 63
t = 24
r = 39

#初始化GNSS网
global G
G = GNSSNet()
init_GNSSNet(G)


##a = ["G02", "g03"]
##print(a)
##a,b,c = G.BaselineSet[3].baseline_match(a)
##print(a,b,c )
##if a:
##    print(G.BaselineSet[c-1].baseline_inf())

 
A = np.zeros([39,63], dtype = int)

A0 = np.zeros([39,1], dtype = float)
W = np.zeros([39,1], dtype = float)

P = np.zeros([63,63], dtype = float)
L = np.zeros([63,1], dtype = float)

#写入A、W矩阵   
with open('paths.csv',encoding='utf-8') as f:
    
    for line in f.readlines():
        line = line.rstrip('\n')
        #print(line)
        t = line.split(',')
        num = int(t[0])
        del t[0]
        

        if t[0] == t[len(t)-1]:

            circles = []
            init_lines(circles,t)
            #print(circles)
            for baseline in circles:
                c,binf = G.Net_baseline_match(baseline)
                A[num*3-3][binf[0]*3-3] = c
                A[num*3-2][binf[0]*3-2] = c
                A[num*3-1][binf[0]*3-1] = c
                W[num*3-3][0] = W[num*3-3][0] + c * binf[4]
                W[num*3-2][0] = W[num*3-2][0] + c * binf[5]
                W[num*3-1][0] = W[num*3-1][0] + c * binf[6]
##                print("闭合差为0，第几个条件：", num ,"用的基线：",binf,"正向还是反向",c ," 计算了一次A和W矩阵")
##                print(A[num*3-3])
##                print(A[num*3-2])
##                print(A[num*3-1])
        else:
            a,b = G.controlpoint_match(t[0])
            c,d = G.controlpoint_match(t[len(t) - 1])
            if a and c:
                print(b,'\n',d,'\n')
                lines = []
                init_lines(lines , t)

                for baseline in lines:
                    e,binf = G.Net_baseline_match(baseline)
                    A[num*3-3][binf[0]*3-3] = e
                    A[num*3-2][binf[0]*3-2] = e
                    A[num*3-1][binf[0]*3-1] = e
                    W[num*3-3][0] = W[num*3-3][0] + e * binf[4] 
                    W[num*3-2][0] = W[num*3-2][0] + e * binf[5] 
                    W[num*3-1][0] = W[num*3-1][0] + e * binf[6]
##                    print("已知点坐标，第几个条件：", num ,"用的基线：",binf,"正向还是反向",e ," 计算了一次A和W矩阵")
##                    print(A[num*3-3])
##                    print(A[num*3-2])
##                    print(A[num*3-1])


                W[num*3-3][0] = W[num*3-3][0] +  b[2] - d[2]
                W[num*3-2][0] = W[num*3-2][0] +  b[3] - d[3]
                W[num*3-1][0] = W[num*3-1][0] +  b[4] - d[4]

                A0[num*3-3][0] =  b[2] - d[2]
                A0[num*3-2][0] =  b[3] - d[3]
                A0[num*3-1][0] =  b[4] - d[4]
                


                print(A0[num*3-3])
                print(A0[num*3-2])
                print(A0[num*3-1])
                
            else:
                print("发现了一行错误的条件")

f.close()
#定权
P = G.init_P(P)
L = G.init_L(L)
#
P = np.matrix(P)
A = np.matrix(A)

A0 = np.matrix(A0)
L = np.matrix(L)

##print("A0:\n",A0)
##print("L:\n",L)

W0 = np.dot(A,L)+A0

##print("AL + A0:\n",W0)
##print("W:\n",W)


W = np.matrix(np.dot(W0, 1000))

#A矩阵的秩
print(np.linalg.matrix_rank(A, tol=None, hermitian=False))

Q = P.I
Naa = np.dot(np.dot(A, Q), A.T)
K = np.dot(np.dot(Naa.I,W),-1)
V = np.dot(np.dot(Q,A.T),K)

time =  1
V_total = V


while  abs(V.max()) > 0.000001 and time < 100:
        L = L + V/1000
        W0 = np.dot(A,L)+A0
        W = np.matrix(np.dot(W0, 1000))
        K = np.dot(np.dot(Naa.I,W),-1)
        V = np.dot(np.dot(Q,A.T),K)
        V_total = V_total + V
        time = time + 1

        

print("time:",time,'\n')
print(V_total)

sigema02 = np.dot(np.dot(V_total.T,P),V_total)/39

sigema0 = math.sqrt(sigema02)

print(math.sqrt(sigema02))
Save2Excel(L,"L")
Save2Excel(V_total,"V")
Save2Excel(A,"A")
Save2Excel(P,"P")
Save2Excel(Naa,"Naa")
