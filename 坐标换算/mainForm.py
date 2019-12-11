# -*- coding: utf-8 -*-

"""
Module implementing Dialog.
"""
import sys
import numpy as np
import math
from PyQt5.QtCore import pyqtSlot
#from PyQt5.QtWidgets import QDialog, QApplication
from PyQt5.QtWidgets import *
from Ui_mainForm import Ui_Dialog
 

class Dialog(QDialog, Ui_Dialog):
    """
    Class documentation goes here.
    """
    def __init__(self, parent=None):
        """
        Constructor
        
        @param parent reference to the parent widget
        @type QWidget
        """
        super(Dialog, self).__init__(parent)
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
    def on_pushButton_Open_clicked(self):
        """
        Slot documentation goes here.
        """
        # TODO: 打开文件并显示
        # raise NotImplementedError
        filename,_ = QFileDialog.getOpenFileName(self,  '输入坐标数据', './',  'All Files (*);;Text Files (*.txt)');
        text=open(filename,'r').read()
        print('文件打开成功')
        self.plainTextEdit_Input.setPlainText(text)
        
    @pyqtSlot()
    def on_pushButton_Save_clicked(self):
        """
        Slot documentation goes here.
        """
        # TODO: not implemented yet
        raise NotImplementedError
    
    @pyqtSlot()
    def on_pushButton_3_clicked(self):
        """
        Slot documentation goes here.
        """
        # TODO: not implemented yet
        raise NotImplementedError
    
    @pyqtSlot(int)
    def on_comboBox_currentIndexChanged(self, index):
        """
        Slot documentation goes here.
        
        @param index DESCRIPTION
        @type int
        """
        # TODO: not implemented yet
        raise NotImplementedError
        
    @pyqtSlot()
    def on_pushButton_4_clicked(self):
        """
        Slot documentation goes here.
        """
        # TODO: not implemented yet
        #raise NotImplementedError
        Xangle = Decimal(self.lineEdit_Xangle.text())
        Yangle = Decimal(self.lineEdit_Yangle.text())
        Zangle = Decimal(self.lineEdit_Zangle.text())
        R1 = np.array([[1, 0, 0], [0, math.cos(Xangle), math.sin(Xangle)], [0, -math.sin(Xangle), math.cos(Xangle)]], dtype = float)
        R2 = np.array([[ math.cos(Yangle), 0, -math.sin(Yangle)], [0, 1, 0], [math.sin(Yangle), 0, math.cos(Yangle)]], dtype = float)
        R3 = np.array([[math.cos(Zangle), math.sin(Zangle), 0], [-math.sin(Zangle), math.cos(Zangle), 0], [0, 0, 1]], dtype = float)
        

if __name__ == '__main__':
    app = QApplication(sys.argv)
    dlg = Dialog()
    dlg.show()
    sys.exit(app.exec_())
    

