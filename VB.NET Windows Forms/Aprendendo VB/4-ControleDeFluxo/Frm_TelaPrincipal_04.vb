Public Class Frm_TelaPrincipal_04


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Const TITULO As String = "4 - Controle de Fluxo"

        Lbl_NomeProjeto.Text = TITULO
        Btn_Principal.Text = "Checagem da permissão de entrada"
        Me.Text = TITULO

        lblIdade.Text = "Idade"
        lblResultado.Text = "Resultado"
        lblPais.Text = "Está acompanhado dos pais?"
    End Sub

    Private Sub Btn_Principal_Click(sender As Object, e As EventArgs) Handles Btn_Principal.Click

        txtResultado.Text = ""

        Dim idade As Integer
        idade = CInt(txtIdade.Text)

        Dim acompanhadoPais As String
        acompanhadoPais = txtPais.Text

        Dim isMaiorDeIdade As Boolean = idade >= 18

        Dim isDezesseisOuMais As Boolean = idade >= 16

        Dim isNotAcompanhadoPais As Boolean = "N".Equals(txtPais.Text)

        Dim isAcompanhadoPais As Boolean = "S".Equals(txtPais.Text)

        If isMaiorDeIdade Then
            txtResultado.Text = "A pessoa pode assistir a peça porque tem mais de 18 anos."
        ElseIf isAcompanhadoPais And isDezesseisOuMais Then
            txtResultado.Text = "A pessoa tem entre 16 e 18 anos e está acompanhada dos pais. Pode assistir."
        ElseIf isNotAcompanhadoPais And isDezesseisOuMais Then
            txtResultado.Text = "A pessoa tem entre 16 e 18 anos mas não está acompanhada dos pais. Não pode assistir."
        Else
            txtResultado.Text = "A pessoa não pode assistir a peça porque tem menos de 16 anos."
        End If

    End Sub
End Class
