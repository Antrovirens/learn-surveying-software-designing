# -*- coding: utf-8 -*-

# Form implementation generated from reading ui file 'C:\GitHub\learn-surveying-software-designing\读取rinex文件\MainWindow.ui'
#
# Created by: PyQt5 UI code generator 5.13.0
#
# WARNING! All changes made in this file will be lost!


from PyQt5 import QtCore, QtGui, QtWidgets


class Ui_MainWindow(object):
    def setupUi(self, MainWindow):
        MainWindow.setObjectName("MainWindow")
        MainWindow.resize(567, 415)
        self.centralWidget = QtWidgets.QWidget(MainWindow)
        self.centralWidget.setObjectName("centralWidget")
        self.label = QtWidgets.QLabel(self.centralWidget)
        self.label.setGeometry(QtCore.QRect(30, 50, 54, 20))
        self.label.setObjectName("label")
        self.plainTextEdit = QtWidgets.QPlainTextEdit(self.centralWidget)
        self.plainTextEdit.setGeometry(QtCore.QRect(10, 80, 541, 301))
        self.plainTextEdit.setObjectName("plainTextEdit")
        self.lineEdit = QtWidgets.QLineEdit(self.centralWidget)
        self.lineEdit.setGeometry(QtCore.QRect(400, 20, 113, 20))
        self.lineEdit.setObjectName("lineEdit")
        self.label_path = QtWidgets.QLabel(self.centralWidget)
        self.label_path.setGeometry(QtCore.QRect(100, 50, 54, 12))
        self.label_path.setObjectName("label_path")
        MainWindow.setCentralWidget(self.centralWidget)
        self.menuBar = QtWidgets.QMenuBar(MainWindow)
        self.menuBar.setGeometry(QtCore.QRect(0, 0, 567, 23))
        self.menuBar.setObjectName("menuBar")
        self.menu = QtWidgets.QMenu(self.menuBar)
        self.menu.setObjectName("menu")
        MainWindow.setMenuBar(self.menuBar)
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
        self.menuBar.addAction(self.menu.menuAction())

        self.retranslateUi(MainWindow)
        QtCore.QMetaObject.connectSlotsByName(MainWindow)

    def retranslateUi(self, MainWindow):
        _translate = QtCore.QCoreApplication.translate
        MainWindow.setWindowTitle(_translate("MainWindow", "MainWindow"))
        self.label.setText(_translate("MainWindow", "读取结果"))
        self.label_path.setText(_translate("MainWindow", "filepath"))
        self.menu.setTitle(_translate("MainWindow", "文件"))
        self.action_Open.setText(_translate("MainWindow", "&Open"))
        self.action_Close.setText(_translate("MainWindow", "&Close"))
        self.action_Save.setText(_translate("MainWindow", "&Save"))
        self.action_Quit.setText(_translate("MainWindow", "&Quit"))


if __name__ == "__main__":
    import sys
    app = QtWidgets.QApplication(sys.argv)
    MainWindow = QtWidgets.QMainWindow()
    ui = Ui_MainWindow()
    ui.setupUi(MainWindow)
    MainWindow.show()
    sys.exit(app.exec_())
