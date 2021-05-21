import warnings  # 忽略警告
warnings.filterwarnings('ignore')

import pandas as pd #表格和数据操作
import numpy as np
import matplotlib.pyplot as plt

from statsmodels.tsa.arima_model import ARMA
from statsmodels.tsa.arima_model import ARIMA
from statsmodels.api import tsa
import statsmodels.api as sm

from itertools import product


dta0=pd.read_csv('data.CSV',header=0)
dta0.index = pd.to_datetime(dta0['date'])

##data = pd.DataFrame()
##data['date'] = ['2008/1/11','2008/2/6','2008/3/17','2008/4/13','2008/5/17','2008/6/15','2008/7/1','2008/7/12','2008/8/10','2008/9/14','2008/10/12','2008/11/16','2008/12/13','2009/1/19','2009/2/16','2009/3/13','2009/4/18','2009/5/16','2009/6/20','2009/7/11','2009/8/15','2009/9/19','2009/10/16','2009/11/14','2009/12/11','2010/1/15','2010/2/20','2010/3/13','2010/4/17','2010/5/15','2010/6/12','2010/7/16','2010/8/14','2010/9/18','2010/10/16','2010/11/19','2010/12/24','2011/1/21','2011/2/18','2011/3/19','2011/4/17','2011/5/15','2011/6/18','2011/7/16','2011/8/20','2011/9/24','2011/10/22','2011/11/19','2011/12/24','2012/1/14']
##data['dy'] = [0.62,1.01,1.78,1.29,0.11,-0.35,-0.44,-0.3,-1.11,-1.78,-1.39,-0.94,-0.36,1.47,1.75,2.04,1.03,0.02,-0.59,-1.35,-2.14,-1.96,-1.46,-0.56,0.04,0.96,1.58,1.43,0.95,0.14,-0.3,-1.35,-1.6,-1.98,-1.58,-0.98,0.56,1.14,1.19,1.18,0.61,0.76,-0.66,-1.14,-1.35,-1.85,-0.95,-0.65,0.44,1.09]
##data.index = pd.to_datetime(data['date'])


p=0
d=1
q=1

arima = ARIMA(dta0['H'].dropna(), (p,d,q)).fit()

print(arima.summary())

dta_pred = arima.predict(typ = 'levels') #预测

###拟合
##fig1 = plt.figure(figsize=(12,8))
##plt.plot(dta0['dy'], color='green')
##plt.plot(dta_pred, color='yellow')
##fig1.show()

#模型预测
forecast_ts = arima.forecast(10)
fore = pd.DataFrame()
fore['date'] = ['2021-01-24','2021-01-25','2021-01-26']
fore['result'] = pd.DataFrame(forecast_ts[0])
fore.index = pd.to_datetime(fore['date'])

print(fore['result'])

#绘制成果表
dta0['H'].plot(color='blue', label='Original',figsize=(12,8))
dta_pred.plot(color='red', label='Predict',figsize=(12,8))
dta0.H.plot(color='green', label='Original',figsize=(12,8))
fore.result.plot(color='yellow', label='Forecast',figsize=(12,8))

plt.show()

