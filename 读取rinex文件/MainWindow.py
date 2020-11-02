# -*- coding: utf-8 -*-

"""
Module implementing MainWindow.
"""
import sys
import numpy as np
#from math import pi, atan, sqrt
#from datetime import datetime

#import matplotlib
#matplotlib.use("Qt5Agg")  # 声明使用QT5
#from matplotlib.backends.backend_qt5agg import FigureCanvasQTAgg as FigureCanvas
#from matplotlib.figure import Figure

from PyQt5.QtCore import pyqtSlot
from PyQt5.QtGui import *
from PyQt5.QtWidgets import *
from Ui_MainWindow import Ui_MainWindow

np.set_printoptions(suppress=True)
ephemeris = []

lines = []

class Ephemeris:
    def __init__(self):
        e = []
        
    def print(self):
        str = str(e)
        return str


endofhead = 'END OF HEADER'

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
    def on_action_Open_triggered(self):
        """
        Slot documentation goes here.
        """
        # 
        global ephemeris
        
        filename,_ = QFileDialog.getOpenFileName(self,  '输入星历文件', './',  'All Files (*);;2020 RINEX N Files (*.20n)');
        if filename == '':
            return 0
        print(filename)
        f=open(filename,'r', encoding='utf-8')
        global lines 
        for line in f.readlines():
            line=line.strip('\n') #去掉换行符\n
            lines.append(line)
        f.close()
        t = 0
        for line in lines:
            if  t > 0:
                if line[1] != ' ':
                    
                    self.plainTextEdit.appendPlainText(line)
                elif line[1] == ' ' and line[4] != 0:
                    
                    self.plainTextEdit.appendPlainText(line)
            
            if line[60:73] == 'END OF HEADER':
                t = 1   
            
        
    
    @pyqtSlot()
    def on_action_Close_triggered(self):
        """
        Slot documentation goes here.
        """
        # TODO: not implemented yet
        raise NotImplementedError
    
    @pyqtSlot()
    def on_action_Save_triggered(self):
        """
        Slot documentation goes here.
        """
        # TODO: not implemented yet
        raise NotImplementedError
    
    @pyqtSlot()
    def on_action_Quit_triggered(self):
        self.close()


if __name__ == '__main__':
    app = QApplication(sys.argv)
    dlg = MainWindow()
    dlg.show()
    sys.exit(app.exec_())
