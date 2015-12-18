Imports System.Text

Public Class ConvertRmb
    Public Shared Function ToRMB(ByVal value As Decimal) As String
        Dim str1 As String = "零壹贰叁肆伍陆柒捌玖"
        Dim str2 As String = "万仟佰拾亿仟佰拾万仟佰拾元角分"
        Dim buffer As Byte() = New Byte() {1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1}
        Dim builder As New StringBuilder
        '处理溢出
        If (value >= 10000000000000) Then
            Return "溢出"
        End If
        '处理零元
        If (value = 0) Then
            Return "零元整"
        End If
        '处理负数
        If (value < 0) Then
            value = (value * -1)
            builder.Append("负")
        End If
        Dim str As String = value.ToString("0000000000000.00").Replace(".", "")
        Dim length As Integer = str.Length
        Dim end1 As Integer = str.Length - 1    '最后一个不为0的
        Dim first As Integer = 0    '首个不为0的
        Dim i As Integer
        For i = 0 To length - 1
            If (str.Chars(i) <> "0"c) Then
                Exit For
            End If
            first += 1
        Next

        i = length - 1
        Do While (i >= 0)
            If (str.Chars(i) <> "0"c) Then
                Exit Do
            End If
            end1 -= 1
            i -= 1
        Loop

        '设置最后一个不为0的位置
        If (end1 < 4) Then
            end1 = 4
        ElseIf (end1 < 8) Then
            end1 = 8
        ElseIf (end1 < 12) Then
            end1 = 12
        End If

        Dim hasValue As Boolean = False '标志前一段落是否有值
        i = first
        Do While (i <= end1)
            Dim j As Integer = Val(str.Chars(i))
            If (j <> 0) Then
                Dim ch As Char = str1.Chars(j)
                builder.Append((ch.ToString & str2.Chars(i)))
                hasValue = True
            Else
                If ((buffer(i) = 1) AndAlso (str.Chars((i + 1)) <> "0"c)) Then
                    builder.Append("零")
                End If
                If ((buffer(i) = 0) AndAlso hasValue) Then
                    builder.Append(str2.Chars(i))
                    hasValue = False
                End If
            End If
            i += 1
        Loop

        Dim result As String = builder.ToString
        '处理无角分时显示“元整”
        If ((str.Chars(13) = "0"c) AndAlso (str.Chars(14) = "0"c)) Then
            If result.EndsWith("元") Then
                result = (result & "整")
            Else
                result = (result & "元整")
            End If
        End If
        Return result
    End Function
End Class
