Attribute VB_Name = "表格"

Sub 沉降成果表()
'
' 沉降成果表 宏
'

'

    Cells.Select
    Selection.Delete Shift:=xlUp

    Range("A5").Select
    ActiveCell.FormulaR1C1 = "点号"
    Range("B5").Select
    ActiveCell.FormulaR1C1 = "高程"
    Range("C5").Select
    ActiveCell.FormulaR1C1 = "沉降量"
    Range("D5").Select
    ActiveCell.FormulaR1C1 = "累计沉降量"
    Range("E5").Select
    ActiveCell.FormulaR1C1 = "本期沉降速率"
    Range("F5").Select

    ActiveCell.FormulaR1C1 = "备注"
    Range("A6").Select
    Columns("E:E").ColumnWidth = 11.13
    Columns("E:E").ColumnWidth = 12.38
    Columns("D:D").ColumnWidth = 10.25
    
    Range("A5:A6").Select
    
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    
    
    Selection.Merge
    Range("F5:F6").Select
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    
    Selection.Merge
    
    
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlCenter
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = True
    End With
    
    
    Range("A5:A6").Select
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlCenter
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = True
    End With
    
    
    Range("B6").Select
    ActiveCell.FormulaR1C1 = "（）"
    Range("B6").Select
    ActiveCell.FormulaR1C1 = "（m）"
    Range("C6").Select
    ActiveCell.FormulaR1C1 = "（mm）"
    Range("C6").Select
    Selection.Copy
    Range("D6").Select
    ActiveSheet.Paste
    Range("E6").Select
    ActiveSheet.Paste
    Application.CutCopyMode = False
    ActiveCell.FormulaR1C1 = "（mm/d）"
    Range("A4").Select
    ActiveCell.FormulaR1C1 = "观测日期："
    Range("A3").Select
    ActiveCell.FormulaR1C1 = "观测期数："
    Range("C1").Select
    ActiveCell.FormulaR1C1 = "沉降观测成果表："
    Range("A2").Select
    ActiveCell.FormulaR1C1 = "项目名称："
    Range("C2").Select
    ActiveCell.FormulaR1C1 = "项目编号："
    Range("E2").Select

    ActiveCell.FormulaR1C1 = "天气："
    Range("G2").Select


    ActiveCell.FormulaR1C1 = "第  页/共 页"
    Rows("6:6").Select
    Range("B6").Activate
    
    
    Rows("7:7").Select
    Selection.Insert Shift:=xlDown, CopyOrigin:=xlFormatFromLeftOrAbove
    Selection.Insert Shift:=xlDown, CopyOrigin:=xlFormatFromLeftOrAbove
    

    Range("A11").Select
    ActiveCell.FormulaR1C1 = "工况："
    Range("A12").Select
    ActiveCell.FormulaR1C1 = "说明："
    Range("A14").Select
    ActiveCell.FormulaR1C1 = "项目负责人："
    Range("C14").Select
    ActiveCell.FormulaR1C1 = "观测："
    Range("E14").Select
    ActiveCell.FormulaR1C1 = "计算："
    Range("A15").Select
    ActiveCell.FormulaR1C1 = "检查："
    Range("C15").Select
    ActiveCell.FormulaR1C1 = "测量单位："
    Range("D15").Select
    ActiveWorkbook.Save

End Sub
Sub 位移观测成果表()
'
' 位移观测成果表 宏
'

'

    Cells.Select
    Selection.Delete Shift:=xlUp

    Range("A5").Select

    ActiveCell.FormulaR1C1 = "点号"
    Range("B5").Select
    ActiveCell.FormulaR1C1 = "初始观测值"
    Range("B6").Select
    ActiveCell.FormulaR1C1 = "（m）"
    Range("B7").Select
    ActiveCell.FormulaR1C1 = "X"
    Range("C7").Select
    ActiveCell.FormulaR1C1 = "Y"
    Range("D5").Select
    ActiveCell.FormulaR1C1 = "上期观测值"
    Range("F5").Select
    ActiveCell.FormulaR1C1 = "本期观测值"
    Range("H5").Select
    ActiveCell.FormulaR1C1 = "单期观测值"
    Range("J5").Select
    ActiveCell.FormulaR1C1 = "累计变化量"
    Range("L5").Select
    ActiveCell.FormulaR1C1 = "本期变化速率"
    Range("D6").Select
    ActiveCell.FormulaR1C1 = "（）"
    Range("D6").Select
    ActiveCell.FormulaR1C1 = "（m）"
    Range("F6").Select
    ActiveCell.FormulaR1C1 = "（m）"
    Range("H6").Select
    ActiveCell.FormulaR1C1 = "（m）"
    Range("H6").Select
    ActiveCell.FormulaR1C1 = "（mm）"
    Range("J6").Select
    ActiveCell.FormulaR1C1 = "（）"
    Range("J6").Select
    ActiveCell.FormulaR1C1 = "（mm）"
    Range("H5").Select
    ActiveCell.FormulaR1C1 = "单期变化量"
    Range("D7").Select
    ActiveCell.FormulaR1C1 = "X"
    Range("E7").Select
    ActiveCell.FormulaR1C1 = "Y"
    Range("F7").Select
    ActiveCell.FormulaR1C1 = "X"
    Range("G7").Select
    ActiveCell.FormulaR1C1 = "Y"
    Range("H7").Select
    ActiveCell.FormulaR1C1 = "ΔX"
    Range("I7").Select
    ActiveCell.FormulaR1C1 = "ΔY"
    Range("J7").Select
    ActiveCell.FormulaR1C1 = "ΔX"
    Range("K7").Select
    ActiveCell.FormulaR1C1 = "ΔY"
    Range("L7").Select
    ActiveCell.FormulaR1C1 = "ΔX/D"
    Range("M7").Select
    ActiveCell.FormulaR1C1 = "ΔY/D"
    Range("L6").Select
    ActiveCell.FormulaR1C1 = "（mm/d）"
    Range("L5:M5").Select
    Range("M5").Activate
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Selection.Merge
    Range("J5:K5").Select
    Range("K5").Activate
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Selection.Merge
    Range("H5:I5").Select
    Range("I5").Activate
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Selection.Merge
    Range("F5:G5").Select
    Range("G5").Activate
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Selection.Merge
    Range("D5:E5").Select
    Range("E5").Activate
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Selection.Merge
    Range("B5:C5").Select
    Range("C5").Activate
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Selection.Merge
    Range("B7:M7").Select
    Selection.Font.Italic = True
    With Selection.Font
        .Name = "Arial Unicode MS"
        .Size = 11
        .Strikethrough = False
        .Superscript = False
        .Subscript = False
        .OutlineFont = False
        .Shadow = False
        .Underline = xlUnderlineStyleNone
        .ThemeColor = xlThemeColorLight1
        .TintAndShade = 0
        .ThemeFont = xlThemeFontNone
    End With
    With Selection.Font
        .Name = "Arial"
        .Size = 11
        .Strikethrough = False
        .Superscript = False
        .Subscript = False
        .OutlineFont = False
        .Shadow = False
        .Underline = xlUnderlineStyleNone
        .ThemeColor = xlThemeColorLight1
        .TintAndShade = 0
        .ThemeFont = xlThemeFontNone
    End With
    Range("B6:C6").Select
    Range("C6").Activate
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Selection.Merge
    Range("D6:E6").Select
    Range("E6").Activate
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Selection.Merge
    Range("F6:G6").Select
    Range("G6").Activate
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Selection.Merge
    Range("H6:I6").Select
    Range("I6").Activate
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Selection.Merge
    Range("J6:K6").Select
    Range("K6").Activate
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Selection.Merge
    Range("L6:M6").Select
    Range("M6").Activate
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Selection.Merge
    Range("A5:A7").Select
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Selection.Merge
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlCenter
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = True
    End With
    Range("B7:M7").Select
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
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
        .MergeCells = False
    End With
    Range("A3").Select
    ActiveCell.FormulaR1C1 = "项目名称："
    Range("A4").Select
    ActiveCell.FormulaR1C1 = "上次观测日期："
    Range("J4").Select
    ActiveCell.FormulaR1C1 = "本次观测日期："
    Range("A3:C3").Select
    Range("C3").Activate
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Selection.Merge
    With Selection
        .HorizontalAlignment = xlLeft
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = True
    End With
    Range("A4:B4").Select
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Selection.Merge
    With Selection
        .HorizontalAlignment = xlLeft
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = True
    End With
    Range("C4").Select
    ActiveCell.FormulaR1C1 = "年   月  日"
    Range("C4").Select
    ActiveCell.FormulaR1C1 = "年   月  日"
    Range("C4").Select
    ActiveCell.FormulaR1C1 = "    年    月    日"
    Range("C4:D4").Select
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Selection.Merge
    With Selection
        .HorizontalAlignment = xlLeft
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = True
    End With
    Range("L4:M4").Select
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Selection.Merge
    With Selection
        .HorizontalAlignment = xlLeft
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = True
    End With
    Range("C4:D4").Select
    ActiveCell.FormulaR1C1 = "    年    月    日"
    Range("L4:M4").Select
    ActiveCell.FormulaR1C1 = "    年    月    日"
    Range("F3").Select
    ActiveCell.FormulaR1C1 = "项目编号："
    Range("F3:H3").Select
    Range("H3").Activate
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Selection.Merge
    With Selection
        .HorizontalAlignment = xlLeft
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = True
    End With
    Range("K3").Select
    ActiveCell.FormulaR1C1 = "第    页"
    Range("L3").Select
    ActiveCell.FormulaR1C1 = "共    页"
    Range("L4:M4").Select

    Range("A1:M1").Select
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Selection.Merge
    ActiveCell.FormulaR1C1 = "建筑位移观测成果表"
    Range("A11").Select
    ActiveCell.FormulaR1C1 = "工况："
    Range("A12").Select
    ActiveCell.FormulaR1C1 = "说明："
    Range("A13").Select


    Range("G11:G12").Select
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Selection.Merge
    ActiveCell.FormulaR1C1 = "简要分析："
    Range("G11:G12").Select
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlCenter
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = True
    End With
    Rows("9:9").Select
    Selection.Insert Shift:=xlDown, CopyOrigin:=xlFormatFromLeftOrAbove
    Selection.Insert Shift:=xlDown, CopyOrigin:=xlFormatFromLeftOrAbove
    Rows("11:11").Select
    Selection.Insert Shift:=xlDown, CopyOrigin:=xlFormatFromLeftOrAbove
    Selection.Insert Shift:=xlDown, CopyOrigin:=xlFormatFromLeftOrAbove
    Range("B10").Select
    ActiveWorkbook.Save
End Sub

