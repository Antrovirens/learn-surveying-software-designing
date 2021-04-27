Attribute VB_Name = "编辑"
Sub 添加记录行()
    
    Dim i As Integer
    Call LastRow
    i = LastRow
    
    If i = 1 Then
        MsgBox "请先创建表格"
        GoTo cancel_end
    End If
    
    
    UserForm1.Show
    
    If cancel = 111 Then
        GoTo cancel_end
    End If
    
    '测站栏
    Range("A" & Trim(CStr(i + 1)) & ":" & "A" & Trim(CStr(i + (target_num + 2) * target_cehuishu))).Select
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlCenter
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Selection.Merge
    ActiveCell.FormulaR1C1 = target_name

    '计数
    Dim j As Integer
    Dim k As Integer

    '单元格计算公式的参数
    Dim spell As String

    Dim str0 As String
    Dim str1 As String
    Dim str2 As String
    Dim str3 As String
    Dim str4 As String

    Dim d1 As String
    Dim m1 As String
    Dim s1 As String
    Dim d2 As String
    Dim m2 As String
    Dim s2 As String

    Dim d3 As String
    Dim m3 As String
    Dim s3 As String
    Dim d4 As String
    Dim m4 As String
    Dim s4 As String

    Dim t0 As String
    Dim t1 As String
    Dim t2 As String
    
    Dim d As Integer
    Dim m As Integer
    Dim s As Integer

    '按照测回数初始化表格
    For j = 1 To target_cehuishu

        '测绘栏标上数字
        Range("B" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1))) & ":" & "B" & Trim(CStr(i + (target_num + 2) * j))).Select
            With Selection
            .HorizontalAlignment = xlCenter
            .VerticalAlignment = xlCenter
            .WrapText = False
            .Orientation = 0
            .AddIndent = False
            .IndentLevel = 0
            .ShrinkToFit = False
            .ReadingOrder = xlContext
            .MergeCells = False
        End With
        Selection.Merge
        ActiveCell.FormulaR1C1 = j
        
        '测回内按顺序目标编号，第一行空出
        For k = 1 To (target_num + 1)
            If k > 1 Then
                Range("C" & Trim(CStr(i + (target_num + 2) * (j - 1) + k))).Select
                ActiveCell.FormulaR1C1 = k - 1
            End If
        Next
        '最后一行和第一行标注的内容一致
        Range("C" & Trim(CStr(i + (target_num + 2) * j))).Select
        ActiveCell.FormulaR1C1 = 1


        '第一行合并
        Dim tttt As String
        tttt = "C" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1))) & ":" & "C" & Trim(CStr(i + 2 + (target_num + 2) * (j - 1)))
        Range(tttt).Select
        Selection.Merge
        tttt = "D" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1))) & ":" & "D" & Trim(CStr(i + 2 + (target_num + 2) * (j - 1)))
        Range(tttt).Select
        Selection.Merge
        tttt = "E" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1))) & ":" & "E" & Trim(CStr(i + 2 + (target_num + 2) * (j - 1)))
        Range(tttt).Select
        Selection.Merge
        tttt = "F" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1))) & ":" & "F" & Trim(CStr(i + 2 + (target_num + 2) * (j - 1)))
        Range(tttt).Select
        Selection.Merge
        tttt = "G" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1))) & ":" & "G" & Trim(CStr(i + 2 + (target_num + 2) * (j - 1)))
        Range(tttt).Select
        Selection.Merge
        tttt = "H" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1))) & ":" & "H" & Trim(CStr(i + 2 + (target_num + 2) * (j - 1)))
        Range(tttt).Select
        Selection.Merge
        tttt = "I" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1))) & ":" & "I" & Trim(CStr(i + 2 + (target_num + 2) * (j - 1)))
        Range(tttt).Select
        Selection.Merge
        tttt = "J" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1))) & ":" & "J" & Trim(CStr(i + 2 + (target_num + 2) * (j - 1)))
        Range(tttt).Select
        Selection.Merge
        tttt = "N" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1))) & ":" & "N" & Trim(CStr(i + 2 + (target_num + 2) * (j - 1)))
        Range(tttt).Select
        Selection.Merge
        tttt = "O" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1))) & ":" & "O" & Trim(CStr(i + 2 + (target_num + 2) * (j - 1)))
        Range(tttt).Select
        Selection.Merge
        tttt = "P" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1))) & ":" & "P" & Trim(CStr(i + 2 + (target_num + 2) * (j - 1)))
        Range(tttt).Select
        Selection.Merge
        tttt = "Q" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1))) & ":" & "Q" & Trim(CStr(i + 2 + (target_num + 2) * (j - 1)))
        Range(tttt).Select
        Selection.Merge
        tttt = "R" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1))) & ":" & "R" & Trim(CStr(i + 2 + (target_num + 2) * (j - 1)))
        Range(tttt).Select
        Selection.Merge
        tttt = "S" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1))) & ":" & "S" & Trim(CStr(i + 2 + (target_num + 2) * (j - 1)))
        Range(tttt).Select
        Selection.Merge
        tttt = "T" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1))) & ":" & "T" & Trim(CStr(i + 2 + (target_num + 2) * (j - 1)))
        Range(tttt).Select
        Selection.Merge
        tttt = "U" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1))) & ":" & "U" & Trim(CStr(i + 2 + (target_num + 2) * (j - 1)))
        Range(tttt).Select
        Selection.Merge
        tttt = "V" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1))) & ":" & "V" & Trim(CStr(i + 2 + (target_num + 2) * (j - 1)))
        Range(tttt).Select
        Selection.Merge
        tttt = "X" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1))) & ":" & "X" & Trim(CStr(i + 2 + (target_num + 2) * (j - 1)))
        Range(tttt).Select
        Selection.Merge
      

        '按行给其他表格内容赋值
        For k = (i + 1 + (target_num + 2) * (j - 1)) To (i + (target_num + 2) * j)

            d1 = "D" & Trim(CStr(k))
            m1 = "E" & Trim(CStr(k))
            s1 = "F" & Trim(CStr(k))
            d2 = "G" & Trim(CStr(k))
            m2 = "H" & Trim(CStr(k))
            s2 = "I" & Trim(CStr(k))

            '2c
            str1 = "(" & d1 & "*3600+" & m1 & "*60+" & s1 & ")"
            str2 = "(" & d2 & "*3600+" & m2 & "*60+" & s2 & ")"

            spell = "=IF((ABS(" & str1 & "-" & str2 & ")>3600),IF(" & str1 & ">" & str2 & "," & str1 & "-" & str2 & "-180*3600," & str1 & "-" & str2 & "+180*3600),"" - "")"

            Range("J" & Trim(CStr(k))) = spell


            '左右平均值
            '第一个目标第一行
            If k = (i + 1 + (target_num + 2) * (j - 1)) Then

                d3 = "K" & Trim(CStr(i + 2 + (target_num + 2) * (j - 1)))
                m3 = "L" & Trim(CStr(i + 2 + (target_num + 2) * (j - 1)))
                s3 = "M" & Trim(CStr(i + 2 + (target_num + 2) * (j - 1)))

                d4 = "K" & Trim(CStr(i + (target_num + 2) * j))
                m4 = "L" & Trim(CStr(i + (target_num + 2) * j))
                s4 = "M" & Trim(CStr(i + (target_num + 2) * j))

                str0 = "K" & Trim(CStr(i + (target_num + 2) * j))

                str3 = "(" & d3 & "*3600+" & m3 & "*60+" & s3 & ")"
                str4 = "(" & d4 & "*3600+" & m4 & "*60+" & s4 & ")"

                spell = "=IF(" & str0 & "<>""-"", TRUNC(((" & str3 & "+" & str4 & ")/2)/3600),""-"")"
                Range("K" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1)))) = spell

                t1 = "K" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1)))

                spell = "=IF(" & str0 & "<>""-"", TRUNC(((" & str3 & "+" & str4 & ")/2 - " & t1 & "*3600 )/60),""-"")"
                Range("L" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1)))) = spell

                t2 = "L" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1)))

                spell = "=IF(" & str0 & "<>""-"", TRUNC((" & str3 & "+" & str4 & ")/2 - " & t1 & "*3600 - " & t2 & "*60),""-"")"
                Range("M" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1)))) = spell

            '第一个目标第二行
            ElseIf k = (i + 2 + (target_num + 2) * (j - 1)) Then
                d3 = "D" & Trim(CStr(k - 1))
                m3 = "E" & Trim(CStr(k - 1))
                s3 = "F" & Trim(CStr(k - 1))
                d4 = "G" & Trim(CStr(k - 1))
                m4 = "H" & Trim(CStr(k - 1))
                s4 = "I" & Trim(CStr(k - 1))

            
                str3 = "(" & d3 & "*3600+" & m3 & "*60+" & s3 & ")"
                str4 = "(" & d4 & "*3600+" & m4 & "*60+" & s4 & ")"

                spell = "=IF((ABS(" & str3 & "-" & str4 & ")>3600),IF(" & str3 & ">" & str4 & "," & "TRUNC((( " & str3 & "+" & str4 & " + 180*3600)/2)/3600),TRUNC((( " & str3 & "+" & str4 & " - 180*3600)/2)/3600)),""-"")"

                Range("K" & Trim(CStr(k))) = spell
            
                t1 = "K" & Trim(CStr(k))
            
                spell = "=IF((ABS(" & str3 & "-" & str4 & ")>3600),IF(" & str3 & ">" & str4 & "," & "TRUNC((( " & str3 & "+" & str4 & " + 180*3600)/2 - " & t1 & "*3600 )/60),TRUNC((( " & str3 & "+" & str4 & " - 180*3600)/2 - " & t1 & "*3600)/60)),""-"")"
            
                Range("L" & Trim(CStr(k))) = spell
            
                t2 = "L" & Trim(CStr(k))
            
                spell = "=IF((ABS(" & str3 & "-" & str4 & ")>3600),IF(" & str3 & ">" & str4 & "," & "TRUNC((( " & str3 & "+" & str4 & " + 180*3600)/2 - " & t1 & "*3600 - " & t2 & " *60 )),TRUNC((( " & str3 & "+" & str4 & " - 180*3600)/2 - " & t1 & "*3600 - " & t2 & " *60 ))),""-"")"

                Range("M" & Trim(CStr(k))) = spell

            '第二个目标开始
            ElseIf k > (i + 2 + (target_num + 2) * (j - 1)) Then

                spell = "=IF((ABS(" & str1 & "-" & str2 & ")>3600),IF(" & str1 & ">" & str2 & "," & "TRUNC((( " & str1 & "+" & str2 & " + 180*3600)/2)/3600),TRUNC((( " & str1 & "+" & str2 & " - 180*3600)/2)/3600)),""-"")"

                Range("K" & Trim(CStr(k))) = spell
            
                t1 = "K" & Trim(CStr(k))
            
                spell = "=IF((ABS(" & str1 & "-" & str2 & ")>3600),IF(" & str1 & ">" & str2 & "," & "TRUNC((( " & str1 & "+" & str2 & " + 180*3600)/2 - " & t1 & "*3600 )/60),TRUNC((( " & str1 & "+" & str2 & " - 180*3600)/2 - " & t1 & "*3600)/60)),""-"")"
            
                Range("L" & Trim(CStr(k))) = spell
            
                t2 = "L" & Trim(CStr(k))
            
                spell = "=IF((ABS(" & str1 & "-" & str2 & ")>3600),IF(" & str1 & ">" & str2 & "," & "TRUNC((( " & str1 & "+" & str2 & " + 180*3600)/2 - " & t1 & "*3600 - " & t2 & " *60 )),TRUNC((( " & str1 & "+" & str2 & " - 180*3600)/2 - " & t1 & "*3600 - " & t2 & " *60 ))),""-"")"

                Range("M" & Trim(CStr(k))) = spell
            End If
        Next
        '归零后方向值 最后一行不填
            
        d3 = "K" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1)))
        m3 = "L" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1)))
        s3 = "M" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1)))
        str3 = "(" & d3 & "*3600+" & m3 & "*60+" & s3 & ")"
        str0 = "K" & Trim(CStr(i + 1 + (target_num + 2) * (j - 1)))

        For k = (i + 1 + (target_num + 2) * (j - 1)) To (i + (target_num + 2) * j - 1)
            If k <> (i + 2 + (target_num + 2) * (j - 1)) Then
                If k = (i + 1 + (target_num + 2) * (j - 1)) Then
                    d4 = d3
                    m4 = m3
                    s4 = s3
                    str4 = "(" & d4 & "*3600+" & m4 & "*60+" & s4 & ")"
                ElseIf k > (i + 1 + (target_num + 2) * (j - 1)) Then
                    d4 = "K" & Trim(CStr(k))
                    m4 = "L" & Trim(CStr(k))
                    s4 = "M" & Trim(CStr(k))
                    str4 = "(" & d4 & "*3600+" & m4 & "*60+" & s4 & ")"
                End If

            spell = "=IF(" & str0 & "<>""-"", TRUNC((" & str4 & "-" & str3 & ")/3600),""-"")"
            Range("N" & Trim(CStr(k))) = spell

            t1 = "N" & Trim(CStr(k))
            spell = "=IF(" & str0 & "<>""-"", TRUNC((" & str4 & "-" & str3 & " - " & t1 & "*3600)/60),""-"")"
            Range("O" & Trim(CStr(k))) = spell

            t2 = "O" & Trim(CStr(k))
            spell = "=IF(" & str0 & "<>""-"", TRUNC(" & str4 & "-" & str3 & " - " & t1 & "*3600 - " & t2 & "*60),""-"")"
            Range("P" & Trim(CStr(k))) = spell

            End If
        Next


    Next
    
    '计算测回间平均值
    For j = 1 To (1 + target_num)
        If j <> 2 Then
            str0 = ""
            For k = 1 To target_cehuishu

                d1 = "N" & Trim(CStr(i + j + (target_num + 2) * (k - 1)))
                m1 = "O" & Trim(CStr(i + j + (target_num + 2) * (k - 1)))
                s1 = "P" & Trim(CStr(i + j + (target_num + 2) * (k - 1)))
                str1 = "(" & d1 & "*3600+" & m1 & "*60+" & s1 & ") + "
                str0 = str0 & str1
            Next
            str0 = "(" & str0 & "0)"

            
            str1 = "B" & Trim(CStr(i + 1 + (target_num + 2) * (target_cehuishu - 1)))
            str2 = "N" & Trim(CStr(i - 1 + (target_num + 2) * target_cehuishu))

             
            spell = "=IF(" & str2 & "<>""-"", TRUNC((" & str0 & "/" & str1 & ")/3600),""-"")"
            Range("Q" & Trim(CStr(i + j))) = spell
            
            t1 = "Q" & Trim(CStr(i + j))
            spell = "=IF(" & str2 & "<>""-"", TRUNC((" & str0 & "/" & str1 & " - " & t1 & "*3600)/60),""-"")"
            Range("R" & Trim(CStr(i + j))) = spell
            
            t2 = "R" & Trim(CStr(j + i))
            spell = "=IF(" & str2 & "<>""-"", TRUNC(" & str0 & "/" & str1 & " - " & t1 & "*3600 - " & t2 & "*60 ),""-"")"
            Range("S" & Trim(CStr(i + j))) = spell

        End If
    Next

    '备注栏
    Range("W" & Trim(CStr(i + 1)) & ":" & "W" & Trim(CStr(i + (target_num + 2) * target_cehuishu))).Select
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlCenter
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Selection.Merge
    ActiveCell.FormulaR1C1 = target_beizhu

    '添加表格边框和居中
    Range("A" & Trim(CStr(i + 1)) & ":" & "X" & Trim(CStr(i + (target_num + 2) * target_cehuishu))).Select
    Selection.Borders(xlDiagonalDown).LineStyle = xlNone
    Selection.Borders(xlDiagonalUp).LineStyle = xlNone
    With Selection.Borders(xlEdgeLeft)
        .LineStyle = xlContinuous
        .ColorIndex = xlAutomatic
        .TintAndShade = 0
        .Weight = xlThin
    End With
    With Selection.Borders(xlEdgeTop)
        .LineStyle = xlContinuous
        .ColorIndex = xlAutomatic
        .TintAndShade = 0
        .Weight = xlThin
    End With
    With Selection.Borders(xlEdgeBottom)
        .LineStyle = xlContinuous
        .ColorIndex = xlAutomatic
        .TintAndShade = 0
        .Weight = xlThin
    End With
    With Selection.Borders(xlEdgeRight)
        .LineStyle = xlContinuous
        .ColorIndex = xlAutomatic
        .TintAndShade = 0
        .Weight = xlThin
    End With
    With Selection.Borders(xlInsideVertical)
        .LineStyle = xlContinuous
        .ColorIndex = xlAutomatic
        .TintAndShade = 0
        .Weight = xlThin
    End With
    With Selection.Borders(xlInsideHorizontal)
        .LineStyle = xlContinuous
        .ColorIndex = xlAutomatic
        .TintAndShade = 0
        .Weight = xlThin
    End With
    With Selection
        .HorizontalAlignment = xlLeft
        .VerticalAlignment = xlCenter
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
    End With
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlCenter
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
    End With
   
    Range("A" & Trim(CStr(i + 1))).Select
    
cancel_end:

End Sub



Sub 锁定输入数据()

End Sub
Sub 添加记录信息()


End Sub
Sub 撤销()

    If target_num > 0 Then
    
        Dim i As Integer
    
        Call LastRow
    
        i = LastRow - target_num
    
   
        Range("A" & Trim(CStr(i + 1)) & ":" & "X" & Trim(CStr(i + (target_num + 2) * target_cehuishu))).Select
    
        Selection.Delete Shift:=xlUp
    
        Range("A12").Select
    
        target_num = 0
    ElseIf Target = 0 Then
        MsgBox "已经不能再删除了"
    End If
    
    
End Sub

Sub 边角网()

    Cells.Select
    Selection.Delete Shift:=xlUp
    Range("A1").Select
    
    User_Name = ""
    target_num = 0
    target_name = ""
    
    Call 水平角记录表表头

End Sub
