Public Class Form1
    Dim V0 As Double
    Dim A As Double
    Dim H0 As Double
    Dim L As Double
    Dim Hmax As Double
    Dim Time As Double
    Const g = 9.81
    Dim SinA As Double
    Dim CosA As Double
    Dim D As Double

    Dim Gr1 As Graphics
    Dim Bm1 As Bitmap
    Dim P1 As Pen = New Pen(Color.Red, 2)
    Dim P2 As Pen = New Pen(Color.Blue, 1)

    Dim B1 As SolidBrush = New SolidBrush(Color.Green)
    Dim B2 As SolidBrush = New SolidBrush(Color.Yellow)



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        V0 = Val(TextBox1.Text)
        A = Val(TextBox2.Text) * Math.PI / 180
        H0 = Val(TextBox3.Text)

        SinA = Math.Sin(A)
        CosA = Math.Cos(A)
        D = V0 * V0 * SinA * SinA + 2 * g * H0
        Time = (V0 * SinA + Math.Sqrt(D)) / g
        L = V0 * CosA * Time
        Hmax = H0 + (V0 * V0 * SinA * SinA) / (2 * g)

        TextBox4.Text = Str(L)
        TextBox5.Text = Str(Hmax)
        TextBox6.Text = Str(Time)

        'Gr1.DrawLine(P1, 50, 70, 150, 200)
        'Gr1.FillEllipse(B1, 50, 70, 150, 200)
        'Gr1.DrawRectangle(P2, 50, 70, 150, 200)
        'PictureBox1.Image = Bm1



    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Bm1 = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Gr1 = Graphics.FromImage(Bm1)



    End Sub
End Class
