# -*- coding: utf-8 -*-

"""
Module implementing MainWindow.
"""


import sys
import numpy as np
import math
from PyQt5.QtCore import pyqtSlot
from PyQt5.QtWidgets import *
from Ui_mainForm import Ui_MainWindow
 

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
    def on_pushButton_clicked(self):
        """
        Slot documentation goes here.
        """
        # TODO: not implemented yet
        raise NotImplementedError
    
    @pyqtSlot()
    def on_pushButton_2_clicked(self):
        """
        Slot documentation goes here.
        """
        # TODO: not implemented yet
        raise NotImplementedError
    
    @pyqtSlot()
    def on_action_Forward_triggered(self):
        """
        Slot documentation goes here.
        """
        # TODO: not implemented yet
        raise NotImplementedError
    
    @pyqtSlot()
    def on_action_Backward_triggered(self):
        """
        Slot documentation goes here.
        """
        # TODO: not implemented yet
        raise NotImplementedError
    
    @pyqtSlot()
    def on_action_Open_triggered(self):
        """
        Slot documentation goes here.
        """
        # TODO: not implemented yet
        filename,_ = QFileDialog.getOpenFileName(self,  '输入坐标数据', './',  'All Files (*);;Text Files (*.txt)');
        text=open(filename,'r').read()
        print('文件打开成功')
        self.plainTextEdit_Input.setPlainText(text)
    
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
        """
        Slot documentation goes here.
        """
        # TODO: not implemented yet
        raise NotImplementedError

if __name__ == '__main__':
    app = QApplication(sys.argv)
    dlg = Dialog()
    dlg.show()
    sys.exit(app.exec_())
