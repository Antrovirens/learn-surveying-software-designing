Attribute VB_Name = "记录表"
Sub 水平角记录表表头()
'
    Range("A1").Select
    ActiveCell.FormulaR1C1 = "测站"
    Range("A1:A2").Select
    
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
    
    
    
    
    Range("B1").Select
    ActiveCell.FormulaR1C1 = "测回"
    Range("B1:B2").Select
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
    
    
    
    Range("C1").Select
    ActiveCell.FormulaR1C1 = "目标"
    Range("C1:C2").Select
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
    
    Range("D1:I1").Select
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
    
    ActiveCell.FormulaR1C1 = "水平度盘读数"
    
    Range("D2:F2").Select
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
    
    Range("G2:I2").Select
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
    
    Range("D2:F2").Select
    ActiveCell.FormulaR1C1 = "盘左"
    Range("G2:I2").Select
    ActiveCell.FormulaR1C1 = "盘右"
    

    Range("J1").Select
    ActiveCell.FormulaR1C1 = "2c"


    Range("J1:J2").Select
    Range("J2").Activate
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
    
  


    Range("K1:M2").Select
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
    Range("K1:M2").Select
    ActiveCell.FormulaR1C1 = "盘坐、盘右平均值"

    Range("N1:P2").Select
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
    
    Range("N1:P2").Select
    ActiveCell.FormulaR1C1 = "归零方向值"
    

    Range("Q1:S2").Select
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
    
    Range("Q1:S2").Select
    ActiveCell.FormulaR1C1 = "各测回归零方向值"
    
    Range("T1:V2").Select
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
    
    Range("T1:V2").Select
    ActiveCell.FormulaR1C1 = "水平角值"
    
    Range("W1").Select
    ActiveCell.FormulaR1C1 = "备注"
    Range("W1:W2").Select
    
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
    
    
    Range("X1").Select
    ActiveCell.FormulaR1C1 = "检查"
    Range("X1:X2").Select
    
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
    
    
    
    Range("A3").Select
    ActiveCell.FormulaR1C1 = "1"
    Range("B3").Select
    ActiveCell.FormulaR1C1 = "2"
    Range("C3").Select
    ActiveCell.FormulaR1C1 = "3"
    Range("D3").Select
    ActiveCell.FormulaR1C1 = "4"
    Range("E3").Select
    ActiveCell.FormulaR1C1 = "5"
    Range("F3").Select
    ActiveCell.FormulaR1C1 = "6"
    Range("G3").Select
    ActiveCell.FormulaR1C1 = "7"
    Range("H3").Select
    ActiveCell.FormulaR1C1 = "8"
    Range("I3").Select
    ActiveCell.FormulaR1C1 = "9"
    Range("J3").Select
    ActiveCell.FormulaR1C1 = "0"
    Range("J3").Select
    ActiveCell.FormulaR1C1 = "10"
    Range("K3").Select
    ActiveCell.FormulaR1C1 = "11"
    Range("L3").Select
    ActiveCell.FormulaR1C1 = "12"
    Range("M3").Select
    ActiveCell.FormulaR1C1 = "13"
    Range("N3").Select
    ActiveCell.FormulaR1C1 = "14"
    Range("O3").Select
    ActiveCell.FormulaR1C1 = "15"
    Range("P3").Select
    ActiveCell.FormulaR1C1 = "16"
    Range("Q3").Select
    ActiveCell.FormulaR1C1 = "17"
    Range("R3").Select
    ActiveCell.FormulaR1C1 = "18"
    Range("S3").Select
    ActiveCell.FormulaR1C1 = "19"
    Range("T3").Select
    ActiveCell.FormulaR1C1 = "20"
    Range("U3").Select
    ActiveCell.FormulaR1C1 = "21"
    Range("V3").Select
    ActiveCell.FormulaR1C1 = "22"
    Range("W3").Select
    ActiveCell.FormulaR1C1 = "23"
    Range("X3").Select
    ActiveCell.FormulaR1C1 = "24"
    
        
    Range("D4").Select
    ActiveCell.FormulaR1C1 = "°"
    Range("E4").Select
    ActiveCell.FormulaR1C1 = "′"
    Range("F4").Select
    ActiveCell.FormulaR1C1 = "″"
    Range("D4:F4").Select
    Selection.Copy
    Range("G4").Select
    ActiveSheet.Paste
    Range("K4").Select
    ActiveSheet.Paste
    Range("N4").Select
    ActiveSheet.Paste
    Range("Q4").Select
    ActiveSheet.Paste
    Range("T4").Select
    ActiveSheet.Paste
    Range("I4").Select
    Application.CutCopyMode = False
    Selection.Copy
    Range("J4").Select
    ActiveSheet.Paste
    
    Columns("D:V").Select
    Range("D3").Activate
    Selection.ColumnWidth = 5
   
    Range("A1:X4").Select
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
    
    Range("A5").Select
   
   
End Sub

Sub 边角网记录表表头()
'
    Range("A1").Select
    ActiveCell.FormulaR1C1 = "测站"
    Range("A1:A2").Select
    
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
    
    
    
    
    Range("B1").Select
    ActiveCell.FormulaR1C1 = "测回"
    Range("B1:B2").Select
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
    
    
    
    Range("C1").Select
    ActiveCell.FormulaR1C1 = "目标"
    Range("C1:C2").Select
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
    
    Range("D1:I1").Select
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
    
    ActiveCell.FormulaR1C1 = "水平度盘读数"
    
    Range("D2:F2").Select
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
    
    Range("G2:I2").Select
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
    
    Range("D2:F2").Select
    ActiveCell.FormulaR1C1 = "盘左"
    Range("G2:I2").Select
    ActiveCell.FormulaR1C1 = "盘右"
    

    Range("J1").Select
    ActiveCell.FormulaR1C1 = "2c"


    Range("J1:J2").Select
    Range("J2").Activate
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
    
  


    Range("K1:M2").Select
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
    Range("K1:M2").Select
    ActiveCell.FormulaR1C1 = "盘坐、盘右平均值"

    Range("N1:P2").Select
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
    
    Range("N1:P2").Select
    ActiveCell.FormulaR1C1 = "归零方向值"
    

    Range("Q1:S2").Select
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
    
    Range("Q1:S2").Select
    ActiveCell.FormulaR1C1 = "各测回归零方向值"
    
    Range("T1:V2").Select
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
    
    Range("T1:V2").Select
    ActiveCell.FormulaR1C1 = "水平角值"
    
    Range("W1").Select
    ActiveCell.FormulaR1C1 = "备注"
    Range("W1:W2").Select
    
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
    
    
    Range("X1").Select
    ActiveCell.FormulaR1C1 = "检查"
    Range("X1:X2").Select
    
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
    
    
    
    Range("A3").Select
    ActiveCell.FormulaR1C1 = "1"
    Range("B3").Select
    ActiveCell.FormulaR1C1 = "2"
    Range("C3").Select
    ActiveCell.FormulaR1C1 = "3"
    Range("D3").Select
    ActiveCell.FormulaR1C1 = "4"
    Range("E3").Select
    ActiveCell.FormulaR1C1 = "5"
    Range("F3").Select
    ActiveCell.FormulaR1C1 = "6"
    Range("G3").Select
    ActiveCell.FormulaR1C1 = "7"
    Range("H3").Select
    ActiveCell.FormulaR1C1 = "8"
    Range("I3").Select
    ActiveCell.FormulaR1C1 = "9"
    Range("J3").Select
    ActiveCell.FormulaR1C1 = "0"
    Range("J3").Select
    ActiveCell.FormulaR1C1 = "10"
    Range("K3").Select
    ActiveCell.FormulaR1C1 = "11"
    Range("L3").Select
    ActiveCell.FormulaR1C1 = "12"
    Range("M3").Select
    ActiveCell.FormulaR1C1 = "13"
    Range("N3").Select
    ActiveCell.FormulaR1C1 = "14"
    Range("O3").Select
    ActiveCell.FormulaR1C1 = "15"
    Range("P3").Select
    ActiveCell.FormulaR1C1 = "16"
    Range("Q3").Select
    ActiveCell.FormulaR1C1 = "17"
    Range("R3").Select
    ActiveCell.FormulaR1C1 = "18"
    Range("S3").Select
    ActiveCell.FormulaR1C1 = "19"
    Range("T3").Select
    ActiveCell.FormulaR1C1 = "20"
    Range("U3").Select
    ActiveCell.FormulaR1C1 = "21"
    Range("V3").Select
    ActiveCell.FormulaR1C1 = "22"
    Range("W3").Select
    ActiveCell.FormulaR1C1 = "23"
    Range("X3").Select
    ActiveCell.FormulaR1C1 = "24"
    
        
    Range("D4").Select
    ActiveCell.FormulaR1C1 = "°"
    Range("E4").Select
    ActiveCell.FormulaR1C1 = "′"
    Range("F4").Select
    ActiveCell.FormulaR1C1 = "″"
    Range("D4:F4").Select
    Selection.Copy
    Range("G4").Select
    ActiveSheet.Paste
    Range("K4").Select
    ActiveSheet.Paste
    Range("N4").Select
    ActiveSheet.Paste
    Range("Q4").Select
    ActiveSheet.Paste
    Range("T4").Select
    ActiveSheet.Paste
    Range("I4").Select
    Application.CutCopyMode = False
    Selection.Copy
    Range("J4").Select
    ActiveSheet.Paste
    
    Columns("D:V").Select
    Range("D3").Activate
    Selection.ColumnWidth = 5
   
    Range("A1:X4").Select
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
    
    Range("A5").Select
   
   
End Sub

Sub 水准网记录表表头()


End Sub
