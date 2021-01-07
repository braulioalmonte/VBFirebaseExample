Imports FireSharp.Config
Imports FireSharp.Response
Imports FireSharp.Interfaces

Public Class Form1

    Private fcon As New FirebaseConfig() With
    {
         .AuthSecret = "ZsPtUUsc0svyz6dQx4iou49JSIAW2bf7czgdHIQq",
         .BasePath = "https://fir-vb-15ab0.firebaseio.com/"
    }

    Private fclient As IFirebaseClient

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            fclient = New FireSharp.FirebaseClient(fcon)
        Catch
            MessageBox.Show("Conenction Failed")

        End Try

    End Sub

    Private Sub insert_btn_Click(sender As Object, e As EventArgs) Handles insert_btn.Click
        Dim vgid, title, developer, publisher As String
        Dim price As Integer

        vgid = TextBox1.Text
        title = TextBox2.Text
        developer = TextBox3.Text
        publisher = TextBox4.Text
        price = Int32.Parse(TextBox5.Text)


        Dim videogame = New Videogame() With
        {
            .VGID = vgid,
            .Title = title,
            .Developer = developer,
            .Publisher = publisher,
            .Price = price
        }

        Dim setit = fclient.Set("VGTable/" + vgid, videogame)
        MessageBox.Show("Record Inserted")


    End Sub

    Private Sub update_btn_Click(sender As Object, e As EventArgs) Handles update_btn.Click
        Dim vgid, title, developer, publisher As String
        Dim price As Integer

        vgid = TextBox1.Text
        title = TextBox2.Text
        developer = TextBox3.Text
        publisher = TextBox4.Text
        price = Int32.Parse(TextBox5.Text)


        Dim videogame = New Videogame() With
        {
            .VGID = vgid,
            .Title = title,
            .Developer = developer,
            .Publisher = publisher,
            .Price = price
        }

        Dim updateit = fclient.Update("VGTable/" + vgid, videogame)
        MessageBox.Show("Record Updated")

    End Sub

    Private Sub delete_btn_Click(sender As Object, e As EventArgs) Handles delete_btn.Click
        Dim vgid As String

        vgid = TextBox1.Text
        Dim deleteit = fclient.Delete("VGTable/" + vgid)
        MessageBox.Show("Record Deleted")

    End Sub

    Private Sub select_btn_Click(sender As Object, e As EventArgs) Handles select_btn.Click
        Dim vgid As String
        vgid = TextBox1.Text
        Dim videogame As New Videogame
        Dim result = fclient.Get("VGTable/" + vgid)
        videogame = result.ResultAs(Of Videogame)
        TextBox2.Text = videogame.Title
        TextBox3.Text = videogame.Developer
        TextBox4.Text = videogame.Publisher
        TextBox5.Text = videogame.Price.ToString
    End Sub
End Class
