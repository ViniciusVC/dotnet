Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub btnSalvar_Click1(ByVal sender As Object, ByVal e As System.EventArgs)

        lblResumo.Text = "<h3>Dados Pessoais</h3>" & _
                         "<b>Nome: </b>" & txtNome.Text & "<br/>" & _
                         "<b>CPF: </b>" & txtCPF.Text & "<br/>" & _
                         "<b>E-mail: </b>" & txtEmail.Text & _
                         "<h3>Dados Comerciais</h3>" & _
                         "<b>Empresa: </b>" & txtEmpresa.Text & "<br/>" & _
                         "<b>Cargo: </b>" & txtCargo.Text & "<br/>" & _
                         "<b>Dt. Admissão: </b>" & txtAdmissao.Text
        aba3.Enabled = True
        Tabs.ActiveTabIndex = 2
    End Sub

    Protected Sub btnLimpar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        lblResumo.Text = ""
        txtNome.Text = ""
        txtCPF.Text = ""
        txtEmail.Text = ""
        txtEmpresa.Text = ""
        txtCargo.Text = ""
        txtAdmissao.Text = ""

        aba3.Enabled = False
        Tabs.ActiveTabIndex = 0
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        aba3.Enabled = False
    End Sub

End Class
