'''
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
        writer = pd.ExcelWriter("C:\\Users\\sheld\\Desktop\\yq\\2\\"+ name + ".xlsx")
        data.to_excel(writer, "page_1", float_format = '%.6f')
        writer.save()
        writer.close()



def init_GNSSNet(G):
    with open('data.csv','r') as f:
        for line in f.readlines():
            b= Baseline()
            b.init_baseline(line.split(','))
            G.insert_Baseline(b)
        f.close()
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
u = 3
c = 42

global G
G = GNSSNet()
init_GNSSNet(G)


##a = ["G02", "g03"]
##print(a)
##a,b,c = G.BaselineSet[3].baseline_match(a)
##print(a,b,c )
##if a:
##    print(G.BaselineSet[c-1].baseline_inf())


A = np.zeros([c,n], dtype = float)
A0 = np.zeros([c,1], dtype = float)

B =  np.zeros([c,u], dtype = float)
X0 = np.zeros([u,1], dtype = float)
x = np.zeros([u,1], dtype = float)

P = np.zeros([n,n], dtype = float)
L = np.zeros([n,1], dtype = float)

#写入A矩阵   
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

##                    print("已知点坐标，第几个条件：", num ,"用的基线：",binf,"正向还是反向",e ," 计算了一次A和W矩阵")
##                    print(A[num*3-3])
##                    print(A[num*3-2])
##                    print(A[num*3-1])



                A0[num*3-3][0] =  b[2] - d[2]
                A0[num*3-2][0] =  b[3] - d[3]
                A0[num*3-1][0] =  b[4] - d[4]
                


                print(A0[num*3-3])
                print(A0[num*3-2])
                print(A0[num*3-1])
                
            else:
                print("发现了一行错误的条件")

f.close()

#写入B矩阵
#假装我读取了文件
str1 = "G10"
str2 = "G07"
baseline_name = [str1 , str2] 
baseline_towards,baseline_inf = G.Net_baseline_match(baseline_name)
_,controlpoint_inf_G10 = G.controlpoint_match(str1)
_,controlpoint_inf_G07 = G.controlpoint_match(str2)

A[r][3*baseline_inf[0] -3] = 1
A[r+1][3*baseline_inf[0] -2] = 1
A[r+2][3*baseline_inf[0] -1] = 1

print(A[39])
print(A[40])
print(A[41])

A0[r][0] = controlpoint_inf_G10[2]
A0[r+1][0] = controlpoint_inf_G10[3]
A0[r+2][0] = controlpoint_inf_G10[4]



B[r][0] = -1
B[r+1][1] = -1
B[r+2][2] = -1

X0[0][0] = controlpoint_inf_G10[2] + baseline_towards * baseline_inf[4]
X0[1][0] = controlpoint_inf_G10[3] + baseline_towards * baseline_inf[5]
X0[2][0] = controlpoint_inf_G10[4] + baseline_towards * baseline_inf[6]



#定权
P = G.init_P(P)
L = G.init_L(L)
#
P = np.matrix(P)
A = np.matrix(A)
A0 = np.matrix(A0)
B = np.matrix(B)
L = np.matrix(L)
X0 = np.matrix(X0)
##print("A0:\n",A0)
##print("L:\n",L)

W = np.dot(A,L) + np.dot(B, X0) + A0

##print("AL + A0:\n",W0)
##print("W:\n",W)

#化成毫米单位
W = np.matrix(np.dot(W, 1000))

#A矩阵的秩
print(np.linalg.matrix_rank(A, tol=None, hermitian=False))
print(np.linalg.matrix_rank(B, tol=None, hermitian=False))

Q = P.I
Naa = np.dot(np.dot(A, Q), A.T)
Nbb = np.dot(np.dot(B.T, Naa.I), B)

x = - np.dot(np.dot(np.dot( Nbb.I,B.T), Naa.I),W)

V = - np.dot(np.dot(np.dot(Q, A.T), Naa.I),(np.dot(B, x) + W))

time =  1
V_total = V
x_total = x

while  abs(V.max()) > 0.000001 and time < 100:
	L = L + V/1000
	X0 = X0 + x/1000
	W = np.dot(A,L) + np.dot(B, X0) + A0

	x = - np.dot(np.dot(np.dot( Nbb.I,B.T), Naa.I),W)
	V = - np.dot(np.dot(np.dot(Q, A.T), Naa.I),(np.dot(B, x) + W))
	V_total = V_total + V
	x_total = x_total + x
	time = time + 1

        

print("time:",time,'\n')
print(V_total,'\n')
print(x_total,'\n')

sigema02 = np.dot(np.dot(V_total.T,P),V_total)/r

sigema0 = math.sqrt(sigema02)

print(math.sqrt(sigema02))

Save2Excel(V_total,"V")
Save2Excel(x_total,"x")
Save2Excel(A,"A")
Save2Excel(B,"B")
Save2Excel(P,"P")
Save2Excel(Naa,"Naa")
Save2Excel(Nbb,"Nbb")
Save2Excel(X0+x/1000,"X^")
Save2Excel(L+V/1000,"L^")
