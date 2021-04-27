VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} UserForm1 
   Caption         =   "录入测站信息"
   ClientHeight    =   3780
   ClientLeft      =   120
   ClientTop       =   465
   ClientWidth     =   5460
   OleObjectBlob   =   "UserForm1.frx":0000
   StartUpPosition =   1  '所有者中心
End
Attribute VB_Name = "UserForm1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Button_No_Click()
    cancel = 111
    TextBox_Num.Value = ""
    TextBox_Name.Value = ""
    TextBox_beizhu.Value = ""
    TextBox_Cehuishu.Value = ""
    UserForm1.Hide
End Sub

Private Sub Button_Yes_Click()
    
    cancel = 0
    
    If TextBox_Num.Value = "" Then
        MsgBox "未录入测站观测目标数目"
    End If
    
    
    If TextBox_Num.Value <> "" Then
        
        Dim a As Integer
        target_name = TextBox_Name.Value
        
        a = Val(TextBox_Num.Value)
        target_num = a
        If target_num = 0 Then target_num = 1
        
        a = Val(TextBox_Cehuishu.Value)
        target_cehuishu = a
        If target_cehuishu = 0 Then target_num = 1
        
        target_beizhu = TextBox_beizhu.Value
        
        MsgBox "录入成功! 测站名为：" & TextBox_Name.Value & "； 目标数为：" & TextBox_Num
        
        TextBox_Num.Value = ""
        TextBox_Name.Value = ""
        TextBox_beizhu.Value = ""
        TextBox_Cehuishu.Value = ""
        UserForm1.Hide
    End If
        
       
    
End Sub
