Attribute VB_Name = "测试"
Sub 初始化()
    User_Name = "变形监测"

End Sub

Sub 显示全局变量()
    Debug.Print User_Name
    
    Range("Z1") = "毕业设计 " & User_Name

End Sub

Sub SimpleIfThen()
    Dim weeks As String
    On Error GoTo VeryEnd
    weeks = InputBox("How many weeks are in a year:", "Quiz")
    If weeks <> 52 Then MsgBox "Try Again": SimpleIfThen
    If weeks = 52 Then MsgBox "Congratulations!"
VeryEnd:
End Sub
