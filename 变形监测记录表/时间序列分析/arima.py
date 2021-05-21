import warnings  # 忽略警告
warnings.filterwarnings('ignore')


import pandas as pd #表格和数据操作
import numpy as np
import matplotlib.pyplot as plt
from random import randrange
from statsmodels.tsa.stattools import adfuller as ADF
from statsmodels.stats.diagnostic import acorr_ljungbox #白噪声检验
from statsmodels.graphics.tsaplots import plot_acf, plot_pacf
from statsmodels.tsa.arima_model import ARMA
from statsmodels.tsa.arima_model import ARIMA
from statsmodels.api import tsa
import statsmodels.api as sm
from statsmodels.graphics.api import qqplot
from itertools import product

#数据第一行是表头，不是数据
dta=pd.read_csv('data.CSV',header=0 ,index_col=0)
print("-------------------------------------------------------------")

dta = dta.dropna() #去除不完整项数据
print(dta)

print("-------------------------------------------------------------")
print(dta.describe()) #数据统计
print("-------------------------------------------------------------")
#用单位根检验（ADF）进行平稳性检验

dta1= dta
diff=0
adf=ADF(dta1)
if adf[1]>0.05:
    print (u'原始序列经检验不平稳，p值为:%s'%(adf[1]))
else:
    print (u'原始序列经检验平稳，p值为:%s'%(adf[1]))

print("-------------------------------------------------------------")

while adf[1]>=0.05:#adf[1]为p值，p值小于0.05认为是平稳的
    diff=diff+1
    adf=ADF(dta1.diff(diff).dropna())
print (u'原始序列经过%s阶差分后归于平稳，p值为%s'%(diff,adf[1]))


print("-------------------------------------------------------------")
for i in range(1,4):
    dta1 = dta1.diff(i).dropna()
    adf = ADF(dta1)
    print(u'原始序列经过%s阶差分,p值为%s'%(i,adf[1]))

print("-------------------------------------------------------------")

#采用LB统计量的方法进行白噪声检验

dta2 = dta
[[lb],[p]]=acorr_ljungbox(dta2,lags=1)
if p<0.05:
    print (u'原始序列为非白噪声序列，p值为:%s'%p)
else:
    print (u'原始序列为白噪声序列，p值为:%s'%p)
[[lb],[p]]=acorr_ljungbox(dta2.diff(1).dropna(),lags=1)
if p<0.05:
    print (u'一阶差分序列为非白噪声序列，p值为:%s'%p)
else:
    print (u'一阶差分序列为白噪声序列，p值为:%s'%p)

print("-------------------------------------------------------------")

dta.plot()
plt.show()



#绘制自相关和偏向关图
fig = plt.figure(figsize=(8,7))
ax1= fig.add_subplot(211)
ax2= fig.add_subplot(212)
fig = plot_acf(dta,ax=ax1)
fig = plot_pacf(dta,ax=ax2)
fig.show()


#模型识别
#确定最佳p,d,q值

#定阶
pmax = int(len(dta)/10) #一般阶数不超过length/10
qmax = int(len(dta)/10) #一般阶数不超过length/10
bic_matrix = [] #bic矩阵
for p in range(pmax+1):
    tmp = []
    for q in range(qmax+1):
        try: #存在部分报错，所以用try来跳过报错。
            tmp.append(ARIMA(dta, (p,1,q)).fit().bic)
        except:
            tmp.append(None)
    bic_matrix.append(tmp)

bic_matrix = pd.DataFrame(bic_matrix) #从中可以找出最小值

p,q = bic_matrix.stack().astype('float64').idxmin() #先用stack展平，然后用idxmin找出最小值位置。
print (u'BIC最小的p值和q值为：%s、%s' %(p,q))

#一阶插分的p值最小，效果最好
#建立ARIMA(p,1,q)模型
arima = ARIMA(dta.dropna(), (p,1,q)).fit()
print("-------------------------------------------------------------")
print("最优模型", arima.summary())

#模型检验：模型确立后，检验其残差序列是否为白噪声

dta3 = dta.drop(axis = 0, index = '2021-01-01')#删除首项，对应差分缺失

dta_pred = arima.predict(typ = 'levels') #按模型预测

print("-------------------------------------------------------------")
print(dta_pred) #手动操作。

#绘拟合图
dta.plot()
dta_pred.plot()
plt.show()

###修正残差序列格式  error是原始数据减去pred的结果，直接算我算不出来，用excel手算的

pred_error = pd.read_csv('data_dta_pred_error.CSV',header=0 ,index_col=0).dropna()#计算残差

lb,p_l= acorr_ljungbox(pred_error, lags = 1)#LB检验
print(p_l)
h = (p_l < 0.05).sum() #p值小于0.05，认为是非白噪声。
if h > 0:
    print (u'模型ARIMA(%s,1,%s)不符合白噪声检验'%(p,q))
else:
    print (u'模型ARIMA(%s,1,%s)符合白噪声检验' %(p,q))


#残差的自相关图
fig = plt.figure(figsize=(12,8))
ax1 = fig.add_subplot(211)
fig = plot_acf(pred_error,ax=ax1)
ax2 = fig.add_subplot(212)
fig = plot_pacf(pred_error, ax=ax2)
fig.show()

#D-W检验
print(sm.stats.durbin_watson(pred_error))

#绘制qq图
fig = plt.figure(figsize=(12,8))
fig = qqplot(pred_error, line='q', fit=True)
fig.show()

###不同差分次数的精度
##print(ARIMA(dta, (p,0,q)).fit().bic)
##print(ARIMA(dta, (p,1,q)).fit().bic)
##
##print(ARIMA(dta, (p,0,q)).fit().aic)
##print(ARIMA(dta, (p,1,q)).fit().aic)
###print(ARIMA(dta, (p,2,q)).fit().aic) #MA系数不可逆
##
###差分比较
##fig1 = plt.figure(figsize=(8,7))
##ax1= fig1.add_subplot(211)
##diff1 = dta.diff(1)
##diff1.plot(ax=ax1)
##ax2= fig1.add_subplot(212)
##diff2 = dta.diff(2)
##diff2.plot(ax=ax2)
##fig1.show()
##
###差分后的自相关图
##dta= dta.diff(1)#1阶差分
##dta = dta.dropna()
##
##fig2 = plt.figure(figsize=(8,7))
##ax1=fig2.add_subplot(211)
##fig2 = plot_acf(dta,ax=ax1)
##ax2 = fig2.add_subplot(212)
##fig2 = plot_pacf(dta,ax=ax2)
##fig2.show()
