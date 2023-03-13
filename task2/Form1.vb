Public Class Form1

    Dim gendar As String = "男性"
    Dim age As Integer = 0
    Dim weight As Double = 0
    Dim stature As Double = 0  '身長
    Dim fatPar As Double = 0
    Dim metabolism As Double
    Dim result As Double

    '厚生労働省の計算式
    Private Function koserodosyo(gendar As String, age As Integer, weight As Double) As Double
        Me.TextBox1.Text = ""

        gendar = CStr(Me.ComboBox1.SelectedItem)
        age = CInt(Me.NumericUpDown3.Value)
        weight = CDbl(Me.NumericUpDown1.Value)

        If age <= 0 AndAlso weight <= 0 Then
            message()
        End If

        If age >= 1 AndAlso age <= 2 Then
            If gendar = "男性" Then
                metabolism = 61.0 * weight
            ElseIf gendar = "女性" Then
                metabolism = 59.7 * weight
            End If
        End If

        If age >= 3 AndAlso age <= 5 Then
            If gendar = "男性" Then
                metabolism = 54.8 * weight
            ElseIf gendar = "女性" Then
                metabolism = 52.2 * weight
            End If
        End If

        If age >= 6 AndAlso age <= 7 Then
            If gendar = "男性" Then
                metabolism = 44.3 * weight
            ElseIf gendar = "女性" Then
                metabolism = 41.9 * weight
            End If
        End If

        If age >= 8 AndAlso age <= 9 Then
            If gendar = "男性" Then
                metabolism = 40.8 * weight
            ElseIf gendar = "女性" Then
                metabolism = 38.3 * weight
            End If
        End If

        If age >= 10 AndAlso age <= 11 Then
            If gendar = "男性" Then
                metabolism = 37.4 * weight
            ElseIf gendar = "女性" Then
                metabolism = 34.8 * weight
            End If
        End If

        If age >= 12 AndAlso age <= 14 Then
            If gendar = "男性" Then
                metabolism = 31.0 * weight
            ElseIf gendar = "女性" Then
                metabolism = 29.6 * weight
            End If
        End If

        If age >= 15 AndAlso age <= 17 Then
            If gendar = "男性" Then
                metabolism = 27.0 * weight
            ElseIf gendar = "女性" Then
                metabolism = 25.3 * weight
            End If
        End If

        If age >= 18 AndAlso age <= 29 Then
            If gendar = "男性" Then
                metabolism = 24.0 * weight
            ElseIf gendar = "女性" Then
                metabolism = 22.1 * weight
            End If
        End If

        If age >= 30 AndAlso age <= 49 Then
            If gendar = "男性" Then
                metabolism = 22.3 * weight
            ElseIf gendar = "女性" Then
                metabolism = 21.7 * weight
            End If
        End If

        If age >= 50 AndAlso age <= 69 Then
            If gendar = "男性" Then
                metabolism = 21.5 * weight
            ElseIf gendar = "女性" Then
                metabolism = 20.7 * weight
            End If
        End If

        If age >= 70 Then
            If gendar = "男性" Then
                metabolism = 21.5 * weight
            ElseIf gendar = "女性" Then
                metabolism = 20.7 * weight
            End If
        End If

        result = Math.Round(metabolism, 0, MidpointRounding.AwayFromZero)
        Return result

    End Function


    '国立健康・栄養研究所の計算式
    Private Function kenkoEyo(gendar As String, age As Integer, weight As Double, stature As Double) As Double
        Me.TextBox1.Text = ""

        gendar = CStr(Me.ComboBox1.SelectedItem)
        age = CInt(Me.NumericUpDown3.Value)
        weight = CDbl(Me.NumericUpDown1.Value)
        stature = CDbl(Me.NumericUpDown4.Value)
        Dim gendarNumber As Double

        If age <= 0 AndAlso weight <= 0 AndAlso stature <= 0 Then
            message()
            result = 0
        Else
            If gendar = "男性" Then
                gendarNumber = 0.5473 * 1
            ElseIf gendar = "女性" Then
                gendarNumber = 0.5473 * 2
            End If
            metabolism = ((0.1238 + (0.0481 * weight) + (0.0234 * stature) - (0.0138 * age) - gendarNumber * 1)) * 1000 / 4.186

            result = Math.Round(metabolism, 0, MidpointRounding.AwayFromZero)
        End If

        Return result

    End Function


    '国立スポーツ科学センターの計算式
    Private Function sports(weight As Double, fatPar As Double) As Double
        Me.TextBox1.Text = ""

        weight = CDbl(Me.NumericUpDown1.Value)
        fatPar = CDbl(Me.NumericUpDown2.Value)
        Dim ffm As Double

        If weight <= 0 AndAlso fatPar <= 0 Then
            message()
        End If

        ffm = weight - (weight * (fatPar / 100))
        metabolism = 28.5 * ffm

        result = Math.Round(metabolism, 0, MidpointRounding.AwayFromZero)
        Return result

    End Function


    '選択可否の切り替え
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Me.TextBox1.Text = ""

        ComboBox1.Enabled = True
        NumericUpDown1.Enabled = True
        NumericUpDown2.Enabled = False
        NumericUpDown3.Enabled = True
        NumericUpDown4.Enabled = False
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Me.TextBox1.Text = ""

        ComboBox1.Enabled = True
        NumericUpDown1.Enabled = True
        NumericUpDown2.Enabled = False
        NumericUpDown3.Enabled = True
        NumericUpDown4.Enabled = True
    End Sub
    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        Me.TextBox1.Text = ""

        ComboBox1.Enabled = False
        NumericUpDown1.Enabled = True
        NumericUpDown2.Enabled = True
        NumericUpDown3.Enabled = False
        NumericUpDown4.Enabled = False
    End Sub


    '基礎代謝計算の結果の出力
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton1.Checked Then
            koserodosyo(gendar, age, weight)
        ElseIf RadioButton2.Checked Then
            kenkoEyo(gendar, age, weight, stature)
        ElseIf RadioButton3.Checked Then
            sports(weight, fatPar)
        End If
        Me.TextBox1.Text = CStr(result)
    End Sub


    'エラーメッセージ
    Private Sub message()
        MessageBox.Show("値が正しくありません。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                )
    End Sub


End Class
