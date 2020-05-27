Public Class Form2
    Dim Bm1 As Bitmap
    Dim Bm2 As Bitmap


    Dim Gr1 As Graphics
    Dim Gr2 As Graphics


    Dim P0 As Pen = New Pen(Color.Gray, 1)
    Dim P1 As Pen = New Pen(Color.Red, 2)
    Dim P2 As Pen = New Pen(Color.Green, 2)


    Dim t As Double
    Dim x As Double
    Dim y As Double
    Dim Kh1 As Double
    Dim Kv1 As Double
    Dim Kh2 As Double
    Dim Kv2 As Double


    Dim X1scr As Integer
    Dim Y1scr As Integer
    Dim X2scr As Integer
    Dim Y2scr As Integer


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Bm1 = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Gr1 = Graphics.FromImage(Bm1)

        Bm2 = New Bitmap(PictureBox2.Width, PictureBox2.Height)
        Gr2 = Graphics.FromImage(Bm2)


    End Sub

    Public Sub DG1()
        Kh1 = (Bm1.Width / Form1.Time) * Math.Pow(1.5, TrackBar1.Value)
        Kv1 = (Bm1.Height / Form1.L) * Math.Pow(1.5, TrackBar2.Value)
        Gr1.Clear(PictureBox1.BackColor)
        For i = 0 To 10
            Gr1.DrawLine(P0, 0, CInt(i * Bm1.Height / 10), Bm1.Width, CInt(i * Bm1.Height / 10))
            Gr1.DrawLine(P0, CInt(i * Bm1.Width / 10), 0, CInt(i * Bm1.Width / 10), Bm1.Height)
        Next


        X1scr = 0
        Y1scr = Bm1.Height
        For i = 1 To Bm1.Width
            X2scr = i
            t = X2scr / Kh1
            If t <= Form1.Time Then
                x = (Form1.V0 * Form1.CosA) * t
            Else
                x = Form1.L
            End If
            Y2scr = CInt(Bm1.Height - Kv1 * x)
            Gr1.DrawLine(P1, X1scr, Y1scr, X2scr, Y2scr)
            X1scr = X2scr
            Y1scr = Y2scr
        Next

        PictureBox1.Image = Bm1


    End Sub

    Public Sub DG2()
        Kh2 = (Bm2.Width / Form1.Time) * Math.Pow(1.5, TrackBar3.Value)
        Kv2 = (Bm2.Height / Form1.Hmax) * Math.Pow(1.5, TrackBar4.Value)
        Gr2.Clear(PictureBox2.BackColor)
        For i = 0 To 10
            Gr2.DrawLine(P0, 0, CInt(i * Bm2.Height / 10), Bm2.Width, CInt(i * Bm2.Height / 10))
            Gr2.DrawLine(P0, CInt(i * Bm2.Width / 10), 0, CInt(i * Bm2.Width / 10), Bm2.Height)
        Next


        X1scr = 0
        Y1scr = Bm2.Height - Kv2 * Form1.H0

        For i = 1 To Bm2.Width
            X2scr = i
            t = X2scr / Kh2
            If t <= Form1.Time Then
                y = Form1.H0 + Form1.V0 * Form1.SinA * t - (Form1.g * t * t) / 2
            Else
                x = 0
            End If

            Y2scr = CInt(Bm2.Height - Kv2 * y)

            Gr2.DrawLine(P2, X1scr, Y1scr, X2scr, Y2scr)
            X1scr = X2scr
            Y1scr = Y2scr
        Next

        PictureBox2.Image = Bm2


    End Sub
    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        DG1()

    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        DG1()

    End Sub

    Private Sub PictureBox1_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox1.MouseEnter
        Label1.Visible = True

    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        Label1.Visible = False

    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        Label1.Left = PictureBox1.Left + e.X + 7
        Label1.Top = PictureBox1.Top + e.Y + 7
        Label1.Text = String.Format(("{0:f2}, {1:f2}"), e.X / Kh1, (Bm1.Height - e.Y) / Kv1)

    End Sub



    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles TrackBar3.Scroll
        DG2()
    End Sub

    Private Sub TrackBar4_Scroll(sender As Object, e As EventArgs) Handles TrackBar4.Scroll
        DG2()
    End Sub

    Private Sub PictureBox3_MouseEnter(sender As Object, e As EventArgs)
        Label2.Visible = True
    End Sub

    Private Sub PictureBox3_MouseLeave(sender As Object, e As EventArgs)
        Label2.Visible = False
    End Sub

    Private Sub PictureBox3_MouseMove(sender As Object, e As MouseEventArgs)
        Label2.Left = PictureBox2.Left + e.X + 7
        Label2.Top = PictureBox2.Top + e.Y + 7
        Label2.Text = String.Format(("{0:f2}, {1:f2}"), e.X / Kh2, (Bm2.Height - e.Y) / Kv2)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub
End Class