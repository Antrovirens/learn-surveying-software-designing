# -*- coding: utf-8 -*-

"""
Module implementing MainWindow.
"""
import sys
import math
from PyQt5.QtCore import pyqtSlot
#from PyQt5.QtWidgets import QMainWindow
from PyQt5.QtWidgets import *
from Ui_MainWindow import Ui_MainWindow

[B1, L1, H1] = [0, 0, 0]
[B2, L2, H2] = [0, 0, 0]
S=0
A12=A21=0
rho = 206265   #常数
#WGS-84
a = 6378137
b = 6356752.3142
c = 6399593.6258
alpha = 1/298.257223562
e2 = 0.00669437999013   #e^2
e12 = 0.00673949674227   #e'^2


class MainWindow(QMainWindow, Ui_MainWindow):
    """
    Class documentation goes here.
    """
    def __init__(self, parent=None):
        """
        Constructor
        
        @param parent reference to the parent widget
        @type QWidget
        """
        super(MainWindow, self).__init__(parent)
        self.setupUi(self)
    
    @pyqtSlot()
    def on_action_1_triggered(self):
        """
        Slot documentation goes here.
        """
        # TODO: not implemented yet
        #raise NotImplementedError
        B1 = float((self.lineEdit_B1.text()))
        L1 = float((self.lineEdit_L1.text()))
        S = float((self.lineEdit_S.text()))
        A12 = float((self.lineEdit_A12.text()))
        
        B1 = DmsToDeg(B1)
        L1 = DmsToDeg(L1)
        A12 = DmsToDeg(A12)
        
        #赋初值
        B2 = B1
        L2 = L1
        A21 = A12
        t = -100  #判定条件
        
        #迭代：
        while abs(t - B2) > 0.000001:
            
            t = B2
            Bm = (B1 + B2)/2
            Lm = (L1 + L2)/2
            Am = (A12 + A21)/2
            
            
            Mm = a * (1 - e2) * math.pow((1 - e2 * math.pow(math.sin(Bm), 2)), -1.5)
            Nm = a * math.pow(1 - e2  * math.pow(math.sin(Bm), 2), -0.5)
            #秒为单位
            dB0 = rho/Mm*S*math.cos(Am)
            dL0 = rho/Nm*S*math.sin(Am)/math.cos(Bm)
            dA0 =dL0 * math.sin(Bm)
            
            dL = rho / Mm * S * math.sin(Am) / math.cos(Bm)*(1 + dA0**2/(24*rho**2) - dB0**2 / (24 * rho**2))
            dB = rho/Mm*S*math.cos(Am)*(1+dL0**2/(12*rho**2)+dA0**2/(24*rho**2))
            dA = rho/Nm*S*math.sin(Am)*math.tan(Bm)*(1+dB0**2/(12*rho**2)+dL0**2*math.cos(Bm)**2/(12*rho**2)+dA0**2/(24*rho**2))
            #度数为单位
            B2 = B1 + dB/3600
            L2 = L1 + dL/3600
            
            A21 = A12 + dA/3600  +180
            
            if A21 > 360:
                A21 = A21 - 360
            
            print("已经迭代了一次")
            
        
        #输出
        self.lineEdit_B2.setText(str(DegToDms(B2)))
        self.lineEdit_L2.setText(str(DegToDms(L2)))
        self.lineEdit_A21.setText(str(DegToDms(A21)))
    
    @pyqtSlot()
    def on_action_2_triggered(self):
        """
        高斯平均引数反算公式
        """
        
        # TODO: not implemented yet
        #raise NotImplementedError
        B1 = float((self.lineEdit_B1.text()))
        L1 = float((self.lineEdit_L1.text()))
        B2 = float((self.lineEdit_B2.text()))
        L2 = float((self.lineEdit_L2.text()))
        
        B1 = DmsToDeg(B1)
        L1 = DmsToDeg(L1)
        B2 = DmsToDeg(B2)
        L2 = DmsToDeg(L2)
        
        Bm = (B1 + B2)/2
        dB = B2 - B1
        dL = L2 - L1
        
        #度分秒化为秒  
         
        
        Nm = a * math.pow(1 - e2  * math.pow(math.sin(Bm), 2), -0.5)
        Vm = math.sqrt(1+e12*math.cos(Bm)**2)
        
        itam2 = e12 * math.cos(Bm)**2  # M点ita的平方值
        tm = math.tan(Bm)
        
        #计算系数
        r01 = Nm * math.cos(Bm) / rho
        r21 = math.cos(Bm) * Nm * (2 + 7*itam2 - 9 * itam2 * tm**2 * itam2**2)/(24 * rho**3 * Vm**4)
        r03 = - Nm * math.cos(Bm)**3 * tm**2 / (24 * rho**3)
        S10 = Nm/(rho * Vm**2)
        S12 = Nm * math.cos(Bm)**2 * (2 + 3 * tm**2 + 2*itam2)/(24*rho**3*Vm**2)
        S30 = Nm*(itam2 - tm**2 * itam2)
        #中间变量
        SsinAm = r01* dL + r21 * dB**2 * dL + r03 * dL**3
        ScosAm = S10 * dB + S12 * dB * dL**2 + S30 * dB**3
        
        #计算系数2
        t01 = tm * math.cos(Bm) 
        t21 = math.cos(Bm) * tm * (2 + 7 * itam2 + 9 * itam2 * tm**2 + 5* itam2**2) / (24 * rho**2 * Vm**4)
        t03 = (math.cos(Bm)) **3 * tm * (2 + tm**2 + 2 * itam2) / (24 * rho**2)
        
        #dA''
        
        dA = t01 * dL + t21 * dB**2 * dL + t03 * dL**3
        
        # Am
        
        tanAm = (SsinAm) / (ScosAm)
        
        Am = math.atan(tanAm)
        
        #判断Am的象限
        
        c = abs(ScosAm/SsinAm)
        
        b = B2 - B1
        l = L2 - L1
        
        if abs(b) > abs(l):
            T = math.atan(abs(SsinAm/ScosAm))
        else:
            T = 45 + math.atan(abs((1-c)/(1+c)))
        
        if b > 0 and l >= 0:
            Am = T
        
        if b < 0 and l >= 0:
            Am = 180 - T
        
        if b <=0 and l < 0:
            Am = 180 + T
            
        if b > 0 and l < 0:
            Am = 360 - T
        
        if b == 0 and l > 0:
            Am = 90
        
        # S A12 A21
        
        S = SsinAm / math.sin(Am)
        
        A12 = Am - 0.5 * dA       
        A21 = Am + 0.5 * dA + 180        
        if A21 > 360 :
             A21 = A21 - 360
        
        #判断象限
        
        self.lineEdit_S.setText(str(S))
        self.lineEdit_A12.setText(str(DegToDms(A12)))
        self.lineEdit_A21.setText(str(DegToDms(A21)))

# TODO: 数据格式化
def DmsToDeg(dms):
    d = int(dms)
    t = (dms - d) * 100
    m = int(t)
    t = (t - int(t)) * 100
    s = t
    return (d + m / 60 + s / 3600)

def DegToDms(deg):
    d = int(deg)
    t = (deg - int(deg))*60
    m = int(t)
    t = (t - int(t)) * 60
    s = t
    return (d + m/100 + s / 10000)
    
def PrintDms(dms):
    d = int(dms)
    t = (dms - d) * 100
    m = int(t)
    t = (t - int(t)) * 100
    s = t
    print("deg = " + d + '\t' + "min = "+ m + '\t' + "sec = " + s)
    return 0


if __name__ == '__main__':
    app = QApplication(sys.argv)
    dlg = MainWindow()
    dlg.show()
    sys.exit(app.exec_())
