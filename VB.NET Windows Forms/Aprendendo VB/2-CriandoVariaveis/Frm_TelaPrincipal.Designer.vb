<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_TelaPrincipal
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
        Btm_Principal = New Button()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' Btm_Principal
        ' 
        Btm_Principal.Location = New Point(176, 118)
        Btm_Principal.Margin = New Padding(4, 3, 4, 3)
        Btm_Principal.Name = "Btm_Principal"
        Btm_Principal.Size = New Size(149, 62)
        Btm_Principal.TabIndex = 0
        Btm_Principal.Text = "Clique aqui"
        Btm_Principal.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(114, 15)
        Label1.TabIndex = 1
        Label1.Text = "2 - Criando Variáveis"
        ' 
        ' Frm_TelaPrincipal
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(520, 333)
        Controls.Add(Label1)
        Controls.Add(Btm_Principal)
        Margin = New Padding(4, 3, 4, 3)
        Name = "Frm_TelaPrincipal"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Aplicação Alô Mundo"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Btm_Principal As Button
    Friend WithEvents Label1 As Label
End Class
