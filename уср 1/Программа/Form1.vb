Public Class Form1
    Public V0 As Double
    Dim A As Double
    Public H0 As Double
    Public L As Double
    Public Hmax As Double
    Public Time As Double
    Public Const g = 9.81
    Public SinA As Double
    Public CosA As Double
    Dim D As Double

    Dim t As Double
    Dim dt As Double
    Dim x As Double
    Dim y As Double
    Dim Kx As Double
    Dim Ky As Double
    Dim x1scr As Integer
    Dim y1scr As Integer
    Dim x2scr As Integer
    Dim y2scr As Integer

    Dim Gr1 As Graphics
    Dim Bm1 As Bitmap
    Dim Gr2 As Graphics
    Dim Bm2 As Bitmap

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

        t = 0
        dt = Time / 1000
        Kx = 0.9 * Bm1.Width / L
        Ky = 0.9 * Bm1.Height / Hmax
        x1scr = 0
        y1scr = CInt(Bm1.Height - Ky * H0)
        Gr1.Clear(PictureBox1.BackColor)

        Timer1.Enabled = True



    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Bm1 = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Gr1 = Graphics.FromImage(Bm1)
        Bm2 = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Gr2 = Graphics.FromImage(Bm2)


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        t = t + dt
        x = V0 * CosA * t
        y = H0 + V0 * SinA * t - g * t * t / 2
        x2scr = CInt(Kx * x)
        y2scr = CInt(Bm1.Height - Ky * y)
        Gr1.DrawLine(P2, x1scr, y1scr, x2scr, y2scr)
        Gr2.DrawImage(Bm1, 0, 0)
        Gr2.DrawEllipse(P1, x2scr - 5, y2scr - 5, 11, 11)

        PictureBox1.Image = Bm2

        x1scr = x2scr
        y1scr = y2scr

        If (t >= Time) Then
            Timer1.Enabled = False
            MessageBox.Show("Движение завершено", "Сообщение", MessageBoxButtons.OK)
        End If

    End Sub

    Private Sub ПоказатьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПоказатьToolStripMenuItem.Click
        Form2.Visible = True
        Form2.DG1()
        Form2.DG2()

        'Также и остальные
    End Sub
End Class
