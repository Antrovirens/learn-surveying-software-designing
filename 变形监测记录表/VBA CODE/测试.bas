Attribute VB_Name = "����"
Sub ��ʼ��()
    User_Name = "���μ��"

End Sub

Sub ��ʾȫ�ֱ���()
    Debug.Print User_Name
    
    Range("Z1") = "��ҵ��� " & User_Name

End Sub

Sub SimpleIfThen()
    Dim weeks As String
    On Error GoTo VeryEnd
    weeks = InputBox("How many weeks are in a year:", "Quiz")
    If weeks <> 52 Then MsgBox "Try Again": SimpleIfThen
    If weeks = 52 Then MsgBox "Congratulations!"
VeryEnd:
End Sub
