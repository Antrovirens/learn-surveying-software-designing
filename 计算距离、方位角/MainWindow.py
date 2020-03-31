# -*- coding: utf-8 -*-

"""
Module implementing MainWindow.
"""

import sys
#import numpy as np
from math import pi, atan, sqrt
#import matplotlib.pyplot as plt
from datetime import datetime

import matplotlib
matplotlib.use("Qt5Agg")  # 声明使用QT5
from matplotlib.backends.backend_qt5agg import FigureCanvasQTAgg as FigureCanvas
from matplotlib.figure import Figure


from PyQt5.QtCore import pyqtSlot
from PyQt5.QtGui import *
from PyQt5.QtWidgets import *
from Ui_MainWindow import Ui_MainWindow


x = [0.0, 0.0]
y = [0.0, 0.0]
Sab = 0.0
Tab = 0.0

#计算方位角
def Azimuth():
    dx = x[1] - x[0]
    dy = y[1] - y[0]
    
    if dx ==0:
        if dy >=0 :
            a = pi/2
        else:
            a = pi * 3 / 2
    elif dy ==0:
        if dx >= 0:
            a=0
        else:
            a = pi
    else:
        a = atan(dy / dx)
        if dx <= 0:
            a = a + pi
        elif dy <= 0:
            a = a + 2 * pi
    return a

class Figure_Canvas(FigureCanvas):   # 通过继承FigureCanvas类，使得该类既是一个PyQt5的Qwidget，又是一个matplotlib的FigureCanvas，这是连接pyqt5与matplot                                          lib的关键

    def __init__(self, parent=None, width=5.1, height=4, dpi=10):
        fig = Figure(figsize=(width, height), dpi=80)  # 创建一个Figure，注意：该Figure为matplotlib下的figure，不是matplotlib.pyplot下面的figure

        FigureCanvas.__init__(self, fig) # 初始化父类
        self.setParent(parent)

        self.axes = fig.add_subplot(111) # 调用figure下面的add_subplot方法，类似于matplotlib.pyplot下面的subplot方法

    def StartPlot(self):
        self.axes.set_xlabel('Y')
        self.axes.set_ylabel('X')

        self.axes.scatter(y[0], x[0], c= 'red', marker='o')
        self.axes.scatter(y[1], x[1], c= 'yellow')
        self.axes.legend(('A', 'B'), loc='best')
        
        self.axes.set_title('Calculation Results',color = 'blue')
        
        self.axes.plot(y, x, c= 'blue', lw=0.5)
        
        self.axes.annotate('(' + str(x[0]) + ',' + str(y[0]) + ')',   xy=(y[0], x[0]), xytext=(-40, 6), textcoords='offset points', weight='heavy')
        self.axes.annotate('(' + str(x[1]) + ',' + str(y[1]) + ')',   xy=(y[1], x[1]), xytext=(-40, 6), textcoords='offset points', weight='heavy')
        
        t1 = (y[0]+y[1])/2
        t2 = (x[0]+x[1])/2
       
        self.axes.annotate('Sab = '+ str(Sab) + '; Tab = ' + str(Tab),   xy=(t1, t2), xytext=(-80, 80), textcoords='offset points',  color = 'blue',  arrowprops = dict( arrowstyle = '->', connectionstyle = 'arc3', color = 'b'))
        


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
        self.plainTextEdit.setPlainText('[' + str(datetime.now()) + ']' + '输入数据或从文件打开来开始计算')
    
    @pyqtSlot()
    def on_action_Open_triggered(self):
        filename,_ = QFileDialog.getOpenFileName(self,  '输入坐标数据', './',  'All Files (*);;Text Files (*.txt)');
        if filename == '':
            self.plainTextEdit.appendPlainText('[' + str(datetime.now()) + ']' + '打开失败 返回值为空')
            return 0
        f=open(filename,'r', encoding='utf-8')
        dic = []
        for line in f.readlines():
            line=line.strip('\n') #去掉换行符\n
            b=line.split(',') #将每一行以空格为分隔符转换成列表
            dic.append(b)
        
        
        self.lineEdit_XA.setText(dic[0][0])
        self.lineEdit_YA.setText(dic[0][1])
        self.lineEdit_XB.setText(dic[1][0])
        self.lineEdit_YB.setText(dic[1][1])
        
        self.plainTextEdit.appendPlainText('[' + str(datetime.now()) + ']' + '打开文件：' + str(filename))
        f.close()
        
        
    @pyqtSlot()
    def on_action_Save_triggered(self):
        """
        Slot documentation goes here.
        """
        # TODO: 保存结果        
        with open('输出结果.txt','a') as f:
            f.write('[' + str(datetime.now()) + ']' + '\n')
            f.write('A:'+str([x[0], y[0]]) + ';B:' + str([x[1],y[1]]) + '\n')
            f.write('Sab = '+ str(Sab) + '; Tab = ' + str(Tab) + '\n')
            f.write('\n')
        
        self.plainTextEdit.appendPlainText('[' + str(datetime.now()) + ']' + '保存成功')
    
    @pyqtSlot()
    def on_action_Close_triggered(self):
        self.close()
    
    @pyqtSlot()
    def on_action_Calculate_triggered(self):
        """
        Slot documentation goes here.
        """
        # TODO: 检查是否缺失条件， 进行计算， 绘制图形
        
        if self.lineEdit_XA.text() == '' or self.lineEdit_XB.text() == '' or self.lineEdit_YA.text() == '' or self.lineEdit_YB.text() == '':   #空的情况下，内容为‘’ (空白);不是None
            self.plainTextEdit.appendPlainText('[' + str(datetime.now()) + ']' + '中断：参数为空')
            return 0
            
        XA = float(self.lineEdit_XA.text())
        XB = float(self.lineEdit_XB.text())
        YA = float(self.lineEdit_YA.text())
        YB = float(self.lineEdit_YB.text())
        
        if XA ==XB and YA == YB:
            self.plainTextEdit.appendPlainText('[' + str(datetime.now()) + ']' + '中断：两点重合')
            return 0
        
        global x, y, Sab, Tab # 给全局变量赋值
        
        x = [XA, XB]
        y = [YA, YB]
        
        Sab = sqrt((XA - XB) * (XA - XB) + (YA - YB) * (YA - YB) )
        Tab = Azimuth()
        
        self.lineEdit_Sab.setText(str(Sab))
        self.lineEdit_tab.setText(str(Tab))
        
        self.plainTextEdit.appendPlainText('[' + str(datetime.now()) + ']' + '计算完成：' + 'Sab = '+ str(Sab) + '; Tab = ' + str(Tab))
        
        ins = Figure_Canvas() #实例化一个FigureCanvas
        ins.StartPlot()  # 画图
        graphicscene = QGraphicsScene()  #创建一个QGraphicsScene，因为加载的图形（FigureCanvas）不能直接放到graphicview控件中，必须先放到graphicScene，然后再把graphicscene放到graphicview中
        graphicscene.addWidget(ins)  # 把图形放到QGraphicsScene中，注意：图形是作为一个QWidget放到QGraphicsScene中的
        
#        graphicscene=graphicscene.scaled(self.graphicsView.width()-10,self.graphicsView.height()-10)
#        咋调大小暂时还没搞清楚

        self.graphicsView.setScene(graphicscene) # 把QGraphicsScene放入QGraphicsView
        self.graphicsView.show()  # 调用show方法呈现图形
    
    @pyqtSlot()
    def on_action_Quit_triggered(self):
        self.close()


if __name__ == '__main__':
    app = QApplication(sys.argv)
    dlg = MainWindow()
    dlg.show()
    sys.exit(app.exec_())
