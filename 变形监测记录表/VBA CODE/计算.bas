Attribute VB_Name = "����"
Sub ¼��ɹ���()

    UserForm2.Show

End Sub

Sub ����Ԥ��()


End Sub
Sub λ��Ԥ��()


End Sub

Sub ����Ԥ��()
    
    Sheets("Sheet3").Activate
    
    Range("B6:B11,F6:F11").Select
    Range("F6").Activate
    ActiveWorkbook.CreateForecastSheet Timeline:=Sheets("Sheet3").Range("B6:B11") _
        , Values:=Sheets("Sheet3").Range("F6:F11"), ForecastEnd:="2021/3/19", _
        ConfInt:=0.95, Seasonality:=1, ChartType:=xlForecastChartTypeLine, _
        Aggregation:=xlForecastAggregationAverage, DataCompletion:= _
        xlForecastDataCompletionInterpolate, ShowStatsTable:=False
End Sub

Sub ����Ԥ��2()
    
    Sheets(4).Activate
    

    
    Dim str0000 As String
    
    str0000 = ActiveSheet.Name
    
    Debug.Print str0000
    
End Sub


