# -*- coding: utf-8 -*-

# Form implementation generated from reading ui file 'C:\GitHub\learn-surveying-software-designing\高斯投影坐标计算\MainWindow.ui'
#
# Created by: PyQt5 UI code generator 5.13.0
#
# WARNING! All changes made in this file will be lost!


from PyQt5 import QtCore, QtGui, QtWidgets


class Ui_MainWindow(object):
    def setupUi(self, MainWindow):
        MainWindow.setObjectName("MainWindow")
        MainWindow.resize(524, 384)
        self.centralWidget = QtWidgets.QWidget(MainWindow)
        self.centralWidget.setObjectName("centralWidget")
        self.label = QtWidgets.QLabel(self.centralWidget)
        self.label.setGeometry(QtCore.QRect(70, 40, 91, 21))
        self.label.setObjectName("label")
        self.label_2 = QtWidgets.QLabel(self.centralWidget)
        self.label_2.setGeometry(QtCore.QRect(300, 40, 91, 21))
        self.label_2.setObjectName("label_2")
        self.pushButton = QtWidgets.QPushButton(self.centralWidget)
        self.pushButton.setGeometry(QtCore.QRect(90, 250, 75, 23))
        self.pushButton.setObjectName("pushButton")
        self.pushButton_2 = QtWidgets.QPushButton(self.centralWidget)
        self.pushButton_2.setGeometry(QtCore.QRect(320, 250, 75, 23))
        self.pushButton_2.setObjectName("pushButton_2")
        self.plainTextEdit = QtWidgets.QPlainTextEdit(self.centralWidget)
        self.plainTextEdit.setGeometry(QtCore.QRect(50, 90, 161, 131))
        self.plainTextEdit.setObjectName("plainTextEdit")
        self.plainTextEdit_2 = QtWidgets.QPlainTextEdit(self.centralWidget)
        self.plainTextEdit_2.setGeometry(QtCore.QRect(270, 90, 161, 131))
        self.plainTextEdit_2.setObjectName("plainTextEdit_2")
        MainWindow.setCentralWidget(self.centralWidget)
        self.menuBar = QtWidgets.QMenuBar(MainWindow)
        self.menuBar.setGeometry(QtCore.QRect(0, 0, 524, 23))
        self.menuBar.setObjectName("menuBar")
        self.menu = QtWidgets.QMenu(self.menuBar)
        self.menu.setObjectName("menu")
        self.menu_2 = QtWidgets.QMenu(self.menuBar)
        self.menu_2.setObjectName("menu_2")
        MainWindow.setMenuBar(self.menuBar)
        self.action_Forward = QtWidgets.QAction(MainWindow)
        self.action_Forward.setObjectName("action_Forward")
        self.action_Backward = QtWidgets.QAction(MainWindow)
        self.action_Backward.setObjectName("action_Backward")
        self.action_Open = QtWidgets.QAction(MainWindow)
        self.action_Open.setObjectName("action_Open")
        self.action_Close = QtWidgets.QAction(MainWindow)
        self.action_Close.setObjectName("action_Close")
        self.action_Save = QtWidgets.QAction(MainWindow)
        self.action_Save.setObjectName("action_Save")
        self.action_Quit = QtWidgets.QAction(MainWindow)
        self.action_Quit.setObjectName("action_Quit")
        self.menu.addAction(self.action_Open)
        self.menu.addAction(self.action_Close)
        self.menu.addAction(self.action_Save)
        self.menu.addAction(self.action_Quit)
        self.menu_2.addAction(self.action_Forward)
        self.menu_2.addAction(self.action_Backward)
        self.menuBar.addAction(self.menu.menuAction())
        self.menuBar.addAction(self.menu_2.menuAction())

        self.retranslateUi(MainWindow)
        QtCore.QMetaObject.connectSlotsByName(MainWindow)

    def retranslateUi(self, MainWindow):
        _translate = QtCore.QCoreApplication.translate
        MainWindow.setWindowTitle(_translate("MainWindow", "MainWindow"))
        self.label.setText(_translate("MainWindow", "B,L"))
        self.label_2.setText(_translate("MainWindow", "X,Y"))
        self.pushButton.setText(_translate("MainWindow", "正算"))
        self.pushButton_2.setText(_translate("MainWindow", "反算"))
        self.menu.setTitle(_translate("MainWindow", "文件"))
        self.menu_2.setTitle(_translate("MainWindow", "计算"))
        self.action_Forward.setText(_translate("MainWindow", "正算"))
        self.action_Backward.setText(_translate("MainWindow", "反算"))
        self.action_Open.setText(_translate("MainWindow", "打开"))
        self.action_Close.setText(_translate("MainWindow", "&关闭"))
        self.action_Save.setText(_translate("MainWindow", "&保存"))
        self.action_Quit.setText(_translate("MainWindow", "&退出"))


if __name__ == "__main__":
    import sys
    app = QtWidgets.QApplication(sys.argv)
    MainWindow = QtWidgets.QMainWindow()
    ui = Ui_MainWindow()
    ui.setupUi(MainWindow)
    MainWindow.show()
    sys.exit(app.exec_())
