Attribute VB_Name = "����"
Sub ���()


    Cells.Select
    Selection.Delete Shift:=xlUp
    Range("A1").Select
    
    User_Name = ""
    target_num = 0
    target_name = ""

End Sub

Sub ���Թ���()


  '  Debug.Print "Hello, World!"
 '   MsgBox "Hello, World!"
    

    Range("B9") = Evaluate("=SUM(B2:B6*C2:C6)") - 0.5
    Range("B8:B9").Select
    Selection.Merge
    
    
End Sub



Sub helloworld2()


    Debug.Print "\nHello, World!"
     
    
    Debug.Print "���ú� ���Թ���()"
    Call ���Թ���
    Debug.Print "���óɹ�"
    Debug.Print "a = " & CStr(a)
    
    Debug.Print "���ú��� d()"
    Call d
    Debug.Print "���óɹ�"
    
    
    
    Range("A1").Select
    ActiveCell.FormulaR1C1 = a + d
    
    Call ��ʼ��
    Range("B1") = User_Name
    
    
End Sub


Sub ����()

    Debug.Print "Hello, World!"
    MsgBox "Hello, World!"

End Sub

Function d() As Integer

    Range("A10") = "��������"
    Dim b As Double
    a = 40
    d = 40
End Function

Function LastRow() As Long
' �ҳ�������һ��
'
    Dim ix As Long
    ix = ActiveSheet.UsedRange.Row - 1 + ActiveSheet.UsedRange.Rows.Count
    LastRow = ix
        
End Function

Function LastColumn() As Long
' �ҳ�������һ��
'
    Dim ix As Long
    ix = ActiveSheet.UsedRange.Column - 1 + ActiveSheet.UsedRange.Columns.Count
    LastColumn = ix

End Function

Function DMS(sec As Long) As Variant
    
    
    DMS = Application.Transpose(Array(0, 0, 0))
    Debug.Print DMS
End Function
