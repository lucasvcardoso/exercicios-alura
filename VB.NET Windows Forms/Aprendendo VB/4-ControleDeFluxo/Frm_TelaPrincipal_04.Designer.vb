<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_TelaPrincipal_04
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Btn_Principal = New Button()
        Lbl_NomeProjeto = New Label()
        lblIdade = New Label()
        txtIdade = New TextBox()
        txtResultado = New TextBox()
        lblResultado = New Label()
        lblPais = New Label()
        txtPais = New TextBox()
        SuspendLayout()
        ' 
        ' Btn_Principal
        ' 
        Btn_Principal.Location = New Point(21, 159)
        Btn_Principal.Margin = New Padding(4, 5, 4, 5)
        Btn_Principal.Name = "Btn_Principal"
        Btn_Principal.Size = New Size(320, 83)
        Btn_Principal.TabIndex = 0
        Btn_Principal.Text = "Clique aqui"
        Btn_Principal.UseVisualStyleBackColor = True
        ' 
        ' Lbl_NomeProjeto
        ' 
        Lbl_NomeProjeto.AutoSize = True
        Lbl_NomeProjeto.Location = New Point(16, 35)
        Lbl_NomeProjeto.Margin = New Padding(4, 0, 4, 0)
        Lbl_NomeProjeto.Name = "Lbl_NomeProjeto"
        Lbl_NomeProjeto.Size = New Size(139, 20)
        Lbl_NomeProjeto.TabIndex = 1
        Lbl_NomeProjeto.Text = "1 - Primeiro Projeto"
        ' 
        ' lblIdade
        ' 
        lblIdade.AutoSize = True
        lblIdade.Location = New Point(21, 84)
        lblIdade.Name = "lblIdade"
        lblIdade.Size = New Size(45, 20)
        lblIdade.TabIndex = 2
        lblIdade.Text = "Label"
        ' 
        ' txtIdade
        ' 
        txtIdade.Location = New Point(21, 107)
        txtIdade.Name = "txtIdade"
        txtIdade.Size = New Size(125, 27)
        txtIdade.TabIndex = 3
        ' 
        ' txtResultado
        ' 
        txtResultado.Location = New Point(21, 282)
        txtResultado.Name = "txtResultado"
        txtResultado.Size = New Size(812, 27)
        txtResultado.TabIndex = 3
        ' 
        ' lblResultado
        ' 
        lblResultado.AutoSize = True
        lblResultado.Location = New Point(21, 259)
        lblResultado.Name = "lblResultado"
        lblResultado.Size = New Size(45, 20)
        lblResultado.TabIndex = 2
        lblResultado.Text = "Label"
        ' 
        ' lblPais
        ' 
        lblPais.AutoSize = True
        lblPais.Location = New Point(278, 84)
        lblPais.Name = "lblPais"
        lblPais.Size = New Size(45, 20)
        lblPais.TabIndex = 2
        lblPais.Text = "Label"
        ' 
        ' txtPais
        ' 
        txtPais.Location = New Point(278, 107)
        txtPais.Name = "txtPais"
        txtPais.Size = New Size(125, 27)
        txtPais.TabIndex = 3
        ' 
        ' Frm_TelaPrincipal_04
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(914, 445)
        Controls.Add(txtResultado)
        Controls.Add(txtPais)
        Controls.Add(txtIdade)
        Controls.Add(lblResultado)
        Controls.Add(lblPais)
        Controls.Add(lblIdade)
        Controls.Add(Lbl_NomeProjeto)
        Controls.Add(Btn_Principal)
        Margin = New Padding(4, 5, 4, 5)
        Name = "Frm_TelaPrincipal_04"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Aplicação Alô Mundo"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Btn_Principal As Button
    Friend WithEvents Lbl_NomeProjeto As Label
    Friend WithEvents lblIdade As Label
    Friend WithEvents txtIdade As TextBox
    Friend WithEvents txtResultado As TextBox
    Friend WithEvents lblResultado As Label
    Friend WithEvents lblPais As Label
    Friend WithEvents txtPais As TextBox
End Class

