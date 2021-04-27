Attribute VB_Name = "其他"
Sub 清空()


    Cells.Select
    Selection.Delete Shift:=xlUp
    Range("A1").Select
    
    User_Name = ""
    target_num = 0
    target_name = ""

End Sub

Sub 测试功能()


  '  Debug.Print "Hello, World!"
 '   MsgBox "Hello, World!"
    

    Range("B9") = Evaluate("=SUM(B2:B6*C2:C6)") - 0.5
    Range("B8:B9").Select
    Selection.Merge
    
    
End Sub



Sub helloworld2()


    Debug.Print "\nHello, World!"
     
    
    Debug.Print "调用宏 测试功能()"
    Call 测试功能
    Debug.Print "调用成功"
    Debug.Print "a = " & CStr(a)
    
    Debug.Print "调用函数 d()"
    Call d
    Debug.Print "调用成功"
    
    
    
    Range("A1").Select
    ActiveCell.FormulaR1C1 = a + d
    
    Call 初始化
    Range("B1") = User_Name
    
    
End Sub


Sub 引用()

    Debug.Print "Hello, World!"
    MsgBox "Hello, World!"

End Sub

Function d() As Integer

    Range("A10") = "函数功能"
    Dim b As Double
    a = 40
    d = 40
End Function

Function LastRow() As Long
' 找出表格最后一行
'
    Dim ix As Long
    ix = ActiveSheet.UsedRange.Row - 1 + ActiveSheet.UsedRange.Rows.Count
    LastRow = ix
        
End Function

Function LastColumn() As Long
' 找出表格最后一列
'
    Dim ix As Long
    ix = ActiveSheet.UsedRange.Column - 1 + ActiveSheet.UsedRange.Columns.Count
    LastColumn = ix

End Function

Function DMS(sec As Long) As Variant
    
    
    DMS = Application.Transpose(Array(0, 0, 0))
    Debug.Print DMS
End Function
