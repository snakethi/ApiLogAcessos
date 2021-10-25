var host2 = window.location.hostname;
/*Variavel para Controle de Senha se foi preenchido o Nome
 * */
let VNome = false;
/*Variavel para Controle de Senha se foi preenchido o Login */
let VLogin = false;
/*Variavel para Controle de Senha se a senha esta no padrão */
let VSenha = false;
/*Variavel para Controle de Senha se as senhas digitadas são iguais*/
let VSenhaS = false;
let MouseSair = false;
/*Variavel para Controle de Senha Pagina atual da Grid de LogAcesso */
let PagnationCurent = 0;
/*Variavel para Controle de Senha Limite de Paginas mostradas no Pagnation */
let LimitePagination = 10;
/*Variavel para Controle de Senha Pagina atual da Grid de Controle de Usuarios */
let PagnationCurentUser = 0;
/*Variavel que armazena do usuario selecionado para passar o montar o Grafico*/
let IdGrafico = 0;

$(document).ready(function () {

    /*Controle para mudar o caminho das Paginas , se for em ambiente de Teste ou Produção*/
    if (host2 === 'localhost') {
        host2 = '';
    }
    else {
        host2 = '/WEBAplication';
    };

    /*Mostra a Pagina de Alteração dos Dados do Usuario logado*/
    $("#BTNUsuario").click(function () {

        $('#LogAcesso').addClass('d-none');
        $('#CadastroADM').addClass('d-none');
        $('#UpdUsuario').removeClass('d-none');
        Valida('Valida', 'NomeUpd');
        Valida('Valida', 'LoginUpd');

        $("#txtPassUpd").val('');
        HabilitaVSenha('', 'PassUpd');
        $("#txtPassUpd2").val('');
        ValidaSenhaS('', 'PassUpd', 'PassUpd2')

        $("#MPassUpd").removeClass("valid");
        $("#MPassUpd").addClass("invalid");
        $("#mPassUpd").removeClass("valid");
        $("#mPassUpd").addClass("invalid");
        $("#BPassUpd").removeClass("valid");
        $("#BPassUpd").addClass("invalid");
        $("#NPassUpd").removeClass("valid");
        $("#NPassUpd").addClass("invalid");
        $("#SPassUpd").removeClass("valid");
        $("#SPassUpd").addClass("invalid");
        $("#TPassUpd").removeClass("valid");
        $("#TPassUpd").addClass("invalid");
        $("#RPassUpd").removeClass("valid");
        $("#RPassUpd").addClass("invalid");
        $('#dvPassUpd').removeClass('bg-success');
        $('#dvPassUpd').removeClass('bg-danger');

        $('#txtPassUpd2').get(0).type = 'password';
        $('#icRevPassUpd2').removeClass("fa-eye-slash");
        $('#icRevPassUpd2').addClass("fa-eye");

        $('#txtPassUpd').get(0).type = 'password';
        $('#icRevPassUpd').removeClass("fa-eye-slash");
        $('#icRevPassUpd').addClass("fa-eye");
    });
    /*Função do Botão de Logout*/
    $("#BTNSair").click(function () {

        Logout();

    });
    /*Mostra a Pagina de Controle de Usuarios*/
    $("#LinkAdmUser").click(function () {

        $('#LogAcesso').addClass('d-none');
        $('#UpdUsuario').addClass('d-none');

        $.ajax({
            url: 'url',
            dataType: 'html',
            url: host2 + '/Home/_ADMUsuariosGrid',
            data: {},
            success: function (data) {

                $('#ADMUsuariosGrid').html(data);

                $.ajax({
                    url: 'url',
                    dataType: 'html',
                    url: host2 + '/Home/_PaginationUser',
                    data: {},
                    success: function (data) {
                        $('#PaginationUser').html(data);
                        $('#CadastroADM').removeClass('d-none');
                    }
                });
            }
        });



    });
    /*Mostra a Pagina de LogAcesso*/
    $("#LinkLogAcessos").click(function () {

        FecharAbertos();

        $.ajax({
            url: 'url',
            dataType: 'html',
            url: host2 + '/Home/_LogAcessoGrid',
            data: {},
            success: function (data) {

                $('#LogAcessoGrid').html(data);

                $.ajax({
                    url: 'url',
                    dataType: 'html',
                    url: host2 + '/Home/_Pagination',
                    data: {},
                    success: function (data) {
                        $('#Pagination').html(data);
                        //$('#LogAcesso2').removeClass('d-none');
                        //$('#LogAcesso2').addClass('d-block');
                    }
                });

            }
        });

    });
    /*Revela a Senha no Campo*/
    $("#revelaPassEdt").click(function () {

        if ($('#txtPassEdt').get(0).type == "text") {
            $('#txtPassEdt').get(0).type = 'password';
            $('#icRevPassEdt').removeClass("fa-eye-slash");
            $('#icRevPassEdt').addClass("fa-eye");
        }
        else {
            $('#txtPassEdt').get(0).type = 'text';
            $('#icRevPassEdt').removeClass("fa-eye");
            $('#icRevPassEdt').addClass("fa-eye-slash");
        }

    })
    /*Muda o fundo do icone de mostrar a senha*/
    $("#revelaPassEdt").mouseover(function () {
        $("#revelaPassEdt").removeClass("bg-transparent");
        $("#revelaPassEdt").addClass("bg-secondary");
    })
    /*Muda o fundo do icone de mostrar a senha*/
    $("#revelaPassEdt").mouseleave(function () {
        $("#revelaPassEdt").removeClass("bg-secondary");
        $("#revelaPassEdt").addClass("bg-transparent");
    })
    /*Revela a Senha no Campo*/
    $("#revelaPassEdt2").click(function () {

        if ($('#txtPassEdt2').get(0).type == "text") {
            $('#txtPassEdt2').get(0).type = 'password';
            $('#icRevPassEdt2').removeClass("fa-eye-slash");
            $('#icRevPassEdt2').addClass("fa-eye");
        }
        else {
            $('#txtPassEdt2').get(0).type = 'text';
            $('#icRevPassEdt2').removeClass("fa-eye");
            $('#icRevPassEdt2').addClass("fa-eye-slash");
        }

    })
    /*Muda o fundo do icone de mostrar a senha*/
    $("#revelaPassEdt2").mouseover(function () {
        $("#revelaPassEdt2").removeClass("bg-transparent");
        $("#revelaPassEdt2").addClass("bg-secondary");
    })
    /*Muda o fundo do icone de mostrar a senha*/
    $("#revelaPassEdt2").mouseleave(function () {
        $("#revelaPassEdt2").removeClass("bg-secondary");
        $("#revelaPassEdt2").addClass("bg-transparent");
    })
    /*Revela a Senha no Campo*/
    $("#revelaPassUpd").click(function () {

        if ($('#txtPassUpd').get(0).type == "text") {
            $('#txtPassUpd').get(0).type = 'password';
            $('#icRevPassUpd').removeClass("fa-eye-slash");
            $('#icRevPassUpd').addClass("fa-eye");
        }
        else {
            $('#txtPassUpd').get(0).type = 'text';
            $('#icRevPassUpd').removeClass("fa-eye");
            $('#icRevPassUpd').addClass("fa-eye-slash");
        }

    })
    /*Muda o fundo do icone de mostrar a senha*/
    $("#revelaPassUpd").mouseover(function () {
        $("#revelaPassUpd").removeClass("bg-transparent");
        $("#revelaPassUpd").addClass("bg-secondary");
    })
    /*Muda o fundo do icone de mostrar a senha*/
    $("#revelaPassUpd").mouseleave(function () {
        $("#revelaPassUpd").removeClass("bg-secondary");
        $("#revelaPassUpd").addClass("bg-transparent");
    })
    /*Revela a Senha no Campo*/
    $("#revelaPassUpd2").click(function () {

        if ($('#txtPassUpd2').get(0).type == "text") {
            $('#txtPassUpd2').get(0).type = 'password';
            $('#icRevPassUpd2').removeClass("fa-eye-slash");
            $('#icRevPassUpd2').addClass("fa-eye");
        }
        else {
            $('#txtPassUpd2').get(0).type = 'text';
            $('#icRevPassUpd2').removeClass("fa-eye");
            $('#icRevPassUpd2').addClass("fa-eye-slash");
        }

    })
    /*Muda o fundo do icone de mostrar a senha*/
    $("#revelaPassUpd2").mouseover(function () {
        $("#revelaPassUpd2").removeClass("bg-transparent");
        $("#revelaPassUpd2").addClass("bg-secondary");
    })
    /*Muda o fundo do icone de mostrar a senha*/
    $("#revelaPassUpd2").mouseleave(function () {
        $("#revelaPassUpd2").removeClass("bg-secondary");
        $("#revelaPassUpd2").addClass("bg-transparent");
    })
    /*Função para Pegar o Usuario Selecionado no Combo e Carregar as Informações na Pagina de LogAcesso*/
    $("input[name='UsuariosList']").on('input', function (e) {
        let Val = $(this).val();
        let opt = $('option[value="' + $(this).val() + '"]');
        let id = opt.attr('id')
        if (id == undefined) {
            id = 0
            IdGrafico = 0;
        }
        else {
            IdGrafico = id;
        }

        $.ajax({
            url: 'url',
            dataType: 'html',
            url: host2 + '/Home/_LogAcessoGrid',
            data: { ID: id },
            success: function (data) {

                $('#LogAcessoGrid').html(data);

                $.ajax({
                    url: 'url',
                    dataType: 'html',
                    url: host2 + '/Home/_Pagination',
                    data: {},
                    success: function (data) {

                        $('#Pagination').html(data);
                    }
                });
            }
        });

    });

});

/*Valida os Campos de Nome e Login das Paginas de Cadatro e Alteração de Usuario*/
function Valida(tipo, componente) {

    let texto = $('#txt' + componente).val();

    if (tipo == 'Valida') {

        if (texto != '') {
            $('#Valida' + componente).removeClass('d-block');
            $('#Valida' + componente).addClass('d-none');
            $('#dv' + componente).addClass('bg-success');
            $('#dv' + componente).removeClass('bg-dange');
            if (componente.indexOf('Login') > -1) {
                VLogin = true;
            }
            else {
                VNome = true;
            }

        }
        else {

            $('#Valida' + componente).removeClass('d-none');
            $('#Valida' + componente).addClass('d-block');
            $('#dv' + componente).removeClass('bg-success');
            $('#dv' + componente).addClass('bg-danger');
            if (componente.indexOf('Login') > -1) {
                VLogin = false;
            }
            else {
                VNome = false;
            }

        }
    }
    else {
        $('#Valida' + componente).removeClass('d-block');
        $('#Valida' + componente).addClass('d-none');
        $('#dv' + componente).removeClass('bg-success');
        $('#dv' + componente).removeClass('bg-danger');
    }


}
/*Função para fechar todas as Paginas abertar no centro do Site*/
function FecharAbertos() {

    var Abertos = document.getElementsByClassName("controlePagInicial");

    for (var i = 0; i < Abertos.length; i++) {
        Abertos[i].classList.add("d-none");
        Abertos[i].classList.remove("d-block");
    }

}
/*Valida os Campos de Senhas da Paginas de Cadastro e Alteração de Usuario*/
function HabilitaVSenha(tipo, componente) {

    if (tipo == 'Valida') {
        $('#Verifica' + componente).removeClass('d-none');
        $('#Verifica' + componente).addClass('d-block');
    }
    else {
        if (!MouseSair) {
            $('#Verifica' + componente).removeClass('d-block');
            $('#Verifica' + componente).addClass('d-none');
        }

    }

}
/*Verifica se a senha digita esta no Padrão solitidado pelo Site*/
function ValidaSenha(componente) {

    let texto = $("#txt" + componente).val();
    let resutado = true;
    VSenha = false;

    var maiusculo = /[A-Z]/g;
    if (texto.match(maiusculo)) {
        $("#M" + componente).removeClass("invalid");
        $("#M" + componente).addClass("valid");
    } else {
        resutado = false;
        $("#M" + componente).removeClass("valid");
        $("#M" + componente).addClass("invalid");
    }

    var miusculo = /[a-z]/g;
    if (texto.match(miusculo)) {
        $("#m" + componente).removeClass("invalid");
        $("#m" + componente).addClass("valid");
    } else {
        resutado = false;
        $("#m" + componente).removeClass("valid");
        $("#m" + componente).addClass("invalid");
    }

    var branco = /[ ]/g;
    if (!texto.match(branco)) {
        $("#B" + componente).removeClass("invalid");
        $("#B" + componente).addClass("valid");
    } else {
        resutado = false;
        $("#B" + componente).removeClass("valid");
        $("#B" + componente).addClass("invalid");
    }

    var numero = /[0-9]/g;
    if (texto.match(numero)) {
        $("#N" + componente).removeClass("invalid");
        $("#N" + componente).addClass("valid");
    } else {
        resutado = false;
        $("#N" + componente).removeClass("valid");
        $("#N" + componente).addClass("invalid");
    }

    var especial = /[!@#$%^&*()-+]/g;
    if (texto.match(especial)) {
        $("#S" + componente).removeClass("invalid");
        $("#S" + componente).addClass("valid");
    } else {
        resutado = false;
        $("#S" + componente).removeClass("valid");
        $("#S" + componente).addClass("invalid");
    }

    if (texto.length >= 10) {
        $("#T" + componente).removeClass("invalid");
        $("#T" + componente).addClass("valid");
    } else {
        resutado = false;
        $("#T" + componente).removeClass("valid");
        $("#T" + componente).addClass("invalid");
    }

    if (duplicateCount(texto) == 0) {
        $("#R" + componente).removeClass("invalid");
        $("#R" + componente).addClass("valid");
    }
    else {
        resutado = false;
        $("#R" + componente).removeClass("valid");
        $("#R" + componente).addClass("invalid");
    }

    if (resutado == true) {
        $('#dv' + componente).removeClass('bg-danger');
        $('#dv' + componente).addClass('bg-success');
        VSenha = true;
    }
    else {
        $('#dv' + componente).removeClass('bg-success');
        $('#dv' + componente).addClass('bg-danger');
    }

}
/*Função para verificar repetição de Caracter*/
function duplicateCount(string) {
    const charMap = {};

    for (const char of string.toLowerCase()) {
        charMap[char] = (charMap[char] || 0) + 1;
    }

    return Object.values(charMap).filter((count) => count > 1).length;
}
/*Verifica se as senhas digitadas são Iguais*/
function ValidaSenhaS(tipo, Senha, Componente) {

    VSenhaS = false;
    let txtSenha = $('#txt' + Senha).val();
    let txtSenha2 = $('#txt' + Componente).val();

    if ((txtSenha != '') && (txtSenha2 != '')) {
        if (tipo == 'Valida') {

            if (txtSenha != txtSenha2) {

                $('#ValidaSenhas' + Componente).removeClass('d-none');
                $('#ValidaSenhas' + Componente).addClass('d-block');
                $('#dv' + Componente).removeClass('bg-success');
                $('#dv' + Componente).addClass('bg-danger');
            }
            else {
                $('#ValidaSenhas' + Componente).removeClass('d-block');
                $('#ValidaSenhas' + Componente).addClass('d-none');
                $('#dv' + Componente).removeClass('bg-danger');
                $('#dv' + Componente).addClass('bg-success');
                VSenhaS = true;
            }

        }
        else {

            $('#ValidaSenhas' + Componente).removeClass('d-block');
            $('#ValidaSenhas' + Componente).addClass('d-none');
            $('#dv' + Componente).removeClass('bg-success');
            $('#dv' + Componente).removeClass('bg-danger');
        }
    }
    else {
        $('#ValidaSenhas' + Componente).removeClass('d-block');
        $('#ValidaSenhas' + Componente).addClass('d-none');
        $('#dv' + Componente).removeClass('bg-success');
        $('#dv' + Componente).removeClass('bg-danger');
    }
}
/*Processo de Cadastro de Novo Usuario*/
function CadastrarUser() {

    let verifica = true;

    if (VLogin == false) {
        $('#ValidaLogin').removeClass('d-none');
        $('#ValidaLogin').addClass('d-block');
        $('#dvLogin').removeClass('bg-success');
        $('#dvLogin').addClass('bg-danger');
        verifica = false;
    }

    if (VNome == false) {
        $('#ValidaNome').removeClass('d-none');
        $('#ValidaNome').addClass('d-block');
        $('#dvNome').removeClass('bg-success');
        $('#dvNome').addClass('bg-danger');
        verifica = false;
    }

    if (VSenha == false) {
        $('#dvPass').removeClass('bg-success');
        $('#dvPass').addClass('bg-danger');
        $('#PassVerifica').removeClass('d-none');
        $('#PassVerifica').addClass('d-block');
        verifica = false;
    }

    if (VSenhaS == false) {
        $('#ValidaSenhas').removeClass('d-none');
        $('#ValidaSenhas').addClass('d-block');
        $('#dvPassS').removeClass('bg-success');
        $('#dvPassS').addClass('bg-danger');
        verifica = false;
    }

    if (verifica) {

        VNome = false;
        VLogin = false;
        VSenha = false;
        VSenhaS = false;

        var senha = $('#txtPassCad').val();
        var nome = $('#txtNomeCad').val();
        var login = $('#txtLoginCad').val();



        $.ajax({
            type: "POST",
            url: host2 + "/Home/Cadastar",
            data: { Nome: nome, Senha: senha, Login: login },
            success: function (response) {
                if (response == 200) {
                    alert("Usuario Cadastrado Com Sucesso!");
                    $("#BtnCadastroSair").click();
                }
                else {
                    alert("Erro Ao Cadastrar Usuario!");
                }
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    }

}
/*Processo de Alteração de Usuario*/
function AlterarUser(id) {

    let verifica = true;

    if (VLogin == false) {
        $('#ValidaLoginUpd').removeClass('d-none');
        $('#ValidaLoginUpd').addClass('d-block');
        $('#dvLoginUpd').removeClass('bg-success');
        $('#dvLoginUpd').addClass('bg-danger');
        verifica = false;
    }

    if (VNome == false) {
        $('#ValidaNomeUpd').removeClass('d-none');
        $('#ValidaNomeUpd').addClass('d-block');
        $('#dvNomeUpd').removeClass('bg-success');
        $('#dvNomeUpd').addClass('bg-danger');
        verifica = false;
    }

    if (VSenha == false) {
        $('#dvPasUpds').removeClass('bg-success');
        $('#dvPassUpd').addClass('bg-danger');
        $('#PassVerificaUpd').removeClass('d-none');
        $('#PassVerificaUpd').addClass('d-block');
        verifica = false;
    }

    if (VSenhaS == false) {
        $('#ValidaSenhasUpd').removeClass('d-none');
        $('#ValidaSenhasUpd').addClass('d-block');
        $('#dvPassSUpd').removeClass('bg-success');
        $('#dvPassSUpd').addClass('bg-danger');
        verifica = false;
    }

    if (verifica) {

        VNome = false;
        VLogin = false;
        VSenha = false;
        VSenhaS = false;

        var senha = $('#txtPassUpd').val();
        var nome = $('#txtNomeUpd').val();
        var login = $('#txtLoginUpd').val();
        var ADM = false;
        if ($('#ADMCheck').is(":checked")) {
            ADM = true;
        }

        $.ajax({
            type: "POST",
            url: host2 + "/Home/UpdUsuario",
            data: { Nome: nome, Senha: senha, Login: login, ID: id },
            success: function (response) {
                if (response == 200) {
                    alert("Usuario Alterado Com Sucesso!");
                    $('#UpdUsuario').removeClass('d-block');
                    $('#UpdUsuario').addClass('d-none');
                }
                else {
                    alert("Erro Ao Alterado o Usuario!");
                }
            },
            failure: function (response) {
                alert("Erro Ao Alterado o Usuario!");
            },
            error: function (response) {
                alert(response);
            }
        });
    }

}
/*Processo de Alteração de Usuario*/
function EditUser(id) {

    let verifica = true;

    if (VLogin == false) {
        $('#ValidaLoginEdt').removeClass('d-none');
        $('#ValidaLoginEdt').addClass('d-block');
        $('#dvLoginEdt').removeClass('bg-success');
        $('#dvLoginEdt').addClass('bg-danger');
        verifica = false;
    }

    if (VNome == false) {
        $('#ValidaNomeEdt').removeClass('d-none');
        $('#ValidaNomeEdt').addClass('d-block');
        $('#dvNomeEdt').removeClass('bg-success');
        $('#dvNomeEdt').addClass('bg-danger');
        verifica = false;
    }

    if (VSenha == false) {
        $('#dvPassEdt').removeClass('bg-success');
        $('#dvPassEdt').addClass('bg-danger');
        $('#PassVerificaEdt').removeClass('d-none');
        $('#PassVerificaEdt').addClass('d-block');
        verifica = false;
    }

    if (VSenhaS == false) {
        $('#ValidaSenhasEdt').removeClass('d-none');
        $('#ValidaSenhasEdt').addClass('d-block');
        $('#dvPassEdt').removeClass('bg-success');
        $('#dvPassEdt').addClass('bg-danger');
        verifica = false;
    }

    if (verifica) {

        VNome = false;
        VLogin = false;
        VSenha = false;
        VSenhaS = false;

        var senha = $('#txtPassEdt').val();
        var nome = $('#txtNomeEdt').val();
        var login = $('#txtLoginEdt').val();
        var ADM = false;
        if ($('#ADMCheck').is(":checked")) {
            ADM = true;
        }

        $.ajax({
            type: "POST",
            url: host2 + "/Home/UpdUsuario",
            data: { Nome: nome, Senha: senha, Login: login, ID: id, Check: ADM },
            success: function (response) {
                if (response == 200) {
                    alert("Usuario alterado com sucesso!")
                    VoltaControlesSenha();
                    FecharEdtModal();

                    $.ajax({
                        url: 'url',
                        dataType: 'html',
                        url: host2 + "/Home/_ADMUsuariosGrid",
                        success: function (data) {
                            $('#ADMUsuariosGrid').html(data);

                            $.ajax({
                                url: 'url',
                                dataType: 'html',
                                url: host2 + '/Home/_PaginationUser',
                                data: {},
                                success: function (data) {
                                    $('#PaginationUser').html(data);

                                }
                            });


                        },
                        failure: function (response) {
                            alert("Erro Ao Alterado o Usuario!");
                        },
                        error: function (response) {
                            alert(response);
                        }
                    });


                }
                else {
                    alert("Erro Ao Alterado o Usuario!");
                }
            },
            failure: function (response) {
                alert("Erro Ao Alterado o Usuario!");
            },
            error: function (response) {
                alert(response);
            }
        });
    }

}
/*Processo de Cadastro de Novo Usuario*/
function CadUser() {

    let verifica = true;

    if (VLogin == false) {
        $('#ValidaLoginEdt').removeClass('d-none');
        $('#ValidaLoginEdt').addClass('d-block');
        $('#dvLoginEdt').removeClass('bg-success');
        $('#dvLoginEdt').addClass('bg-danger');
        verifica = false;
    }

    if (VNome == false) {
        $('#ValidaNomeEdt').removeClass('d-none');
        $('#ValidaNomeEdt').addClass('d-block');
        $('#dvNomeEdt').removeClass('bg-success');
        $('#dvNomeEdt').addClass('bg-danger');
        verifica = false;
    }

    if (VSenha == false) {
        $('#dvPassEdt').removeClass('bg-success');
        $('#dvPassEdt').addClass('bg-danger');
        $('#PassVerificaEdt').removeClass('d-none');
        $('#PassVerificaEdt').addClass('d-block');
        verifica = false;
    }

    if (VSenhaS == false) {
        $('#ValidaSenhasEdt').removeClass('d-none');
        $('#ValidaSenhasEdt').addClass('d-block');
        $('#dvPassEdt').removeClass('bg-success');
        $('#dvPassEdt').addClass('bg-danger');
        verifica = false;
    }

    if (verifica) {


        var senha = $('#txtPassEdt').val();
        var nome = $('#txtNomeEdt').val();
        var login = $('#txtLoginEdt').val();
        var ADM = false;
        if ($('#ADMCheck').is(":checked")) {
            ADM = true;
        }


        $.ajax({
            type: "POST",
            url: host2 + "/Home/Cadastar",
            data: { Nome: nome, Senha: senha, Login: login, Check: ADM },
            success: function (response) {
                if (response == 200) {
                    alert("Usuario Cadastrado Com Sucesso!");
                    VoltaControlesSenha();
                    FecharEdtModal();

                    $.ajax({
                        url: 'url',
                        dataType: 'html',
                        url: host2 + "/Home/_ADMUsuariosGrid",
                        success: function (data) {
                            $('#ADMUsuariosGrid').html(data);
                            $.ajax({
                                url: 'url',
                                dataType: 'html',
                                url: host2 + "/Home/_PaginationUser",
                                success: function (data) {
                                    $('#PaginationUser').html(data);
                                },
                                failure: function (response) {
                                    alert("Erro Ao Cadastrar o Usuario!");
                                },
                                error: function (response) {
                                    alert(response);
                                }
                            });
                        },
                        failure: function (response) {
                            alert("Erro Ao Cadastrar Usuario!");
                        },
                        error: function (response) {
                            alert("Erro Ao Cadastrar Usuario!");
                        }
                    });

                }
                else {
                    alert("Erro Ao Cadastrar Usuario!");
                }
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    }

}
/*Processo de Exclusão de Usuario*/
function ExcluirUser(id) {

    $.ajax({
        type: "POST",
        url: host2 + "/Home/ExcluirUsuario",
        data: { ID: id },
        success: function (response) {
            if (response) {
                alert("Usuario Excluido com sucesso!")
                $.ajax({
                    url: 'url',
                    dataType: 'html',
                    url: host2 + "/Home/_ADMUsuarios",
                    success: function (data) {
                        $('#CadastroADM').html(data);
                    },
                    failure: function (response) {
                        alert("Erro Ao Excluir o Usuario!");
                    },
                    error: function (response) {
                        alert("Erro Ao Excluir o Usuario!");
                    }
                });
            }
            else {
                alert("Erro Ao Excluir o Usuario!");
            }
        },
        failure: function (response) {
            alert("Erro Ao Excluir o Usuario!");
        },
        error: function (response) {
            alert("Erro Ao Excluir o Usuario!");
        }
    });

}
/*Volta Variaveis de Controle dos Campos de Cadastro para Padrão*/
function VoltaControlesSenha() {
    VNome = false;
    VLogin = false;
    VSenha = false;
    VSenhaS = false;
}
/*Redirecionar para a Pagina de Login*/
function GoLogin() {
    window.location.href = host2 + '/Home/Login';
}
/*Processo de Logout do Site*/
function Logout() {
    $.ajax({
        url: 'url',
        dataType: 'html',
        url: host2 + "/Home/Logout",
        success: function (data) {
            window.location.href = host2 + '/Home/Login';
        }
    });
}
/*Chama o Modal de Edição de Usuario na Pagina de Controle de Usuarios*/
function EdtUser(ID, Nome, Login, ADM) {

    $("#txtNomeEdt").val(Nome);
    Valida("Valida", "NomeEdt");
    $("#txtLoginEdt").val(Login);
    Valida("Valida", "LoginEdt");
    if (ADM) {
        $("#ADMCheck").prop("checked", true);
    }
    else {
        $("#ADMCheck").prop("checked", false);
    }

    $("#BtnEditUser").attr("onclick", "EditUser('" + ID + "')");
    /*$("#BtnExcluirUser").attr("onclick", "ExcluirUser('"+ID+"')");*/
    $("#myModaltEditUser").modal("show");

}
/*Chama o Modal de Cadastro de Usuario na Pagina de Controle de Usuarios*/
function AbriCadUser() {

    $("#BtnEditUser").attr("onclick", "CadUser()");
    $('#myModaltEditUser').modal('show');
}
/*Fecha o Modal de Edição de Cadatro da Pagina de Controle de Usuarios*/
function FecharEdtModal() {
    $('#myModaltEditUser').modal('hide');
    VoltaModalEstadoInicial();
}
/*Função para trazer os dados da  Pagina Selecionada na Grid da Pagina LodAcessos*/
function CarregaPaginaLog(pagina) {

    let Actv = document.getElementsByClassName("pg");
    for (var i = 0; i < Actv.length; i++) {
        Actv[i].classList.remove("active");
    }
    Actv[pagina - 1].classList.add("active");

    $.ajax({
        url: 'url',
        dataType: 'html',
        url: host2 + "/Home/_LogAcessoGrid",
        data: { Pagina: pagina },
        success: function (data) {
            $('#LogAcessoGrid').html(data);
        },
        failure: function (response) {
            alert("Erro Ao Carregar Pagina!");
        },
        error: function (response) {
            alert(response);
        }
    });

}
/*Função para Trazer as Proximas Paginas no Pagination da Pagina LogAcessos*/
function ControlePaginationProx() {

    $("#AntLogAcesso").removeClass("pgNone");

    const paginas = document.getElementsByClassName("pg");
    const Inicia = PagnationCurent + LimitePagination;
    let Fim = Inicia + LimitePagination;

    if (Fim > paginas.length) {

        let aux = Fim - paginas.length;
        Fim = Inicia + aux;
        $("#PrxLogAcesso").addClass("pgNone");
    }

    LimpaPagination(paginas);

    CarregaPagination(paginas, Inicia, Fim);

    PagnationCurent = Inicia;

}
/*Função para Trazer as Proximas Paginas no Pagination da Pagina LogAcessos*/
function ControlePaginationAnt() {

    $("#PrxLogAcesso").removeClass("pgNone");

    const paginas = document.getElementsByClassName("pg");
    let Fim = PagnationCurent;
    let Inicia = Fim - LimitePagination;

    if (Fim == LimitePagination) {
        $("#AntLogAcesso").addClass("pgNone");
    }

    LimpaPagination(paginas);

    CarregaPagination(paginas, Inicia, Fim);

    PagnationCurent = Inicia;

}
/*Função para trazer os dados da  Pagina Selecionada na Grid da Pagina Controle de Usuarios*/
function CarregaPaginaLogUser(pagina) {

    let Actv = document.getElementsByClassName("pgUser");
    for (var i = 0; i < Actv.length; i++) {
        Actv[i].classList.remove("active");
    }
    Actv[pagina - 1].classList.add("active");

    $.ajax({
        url: 'url',
        dataType: 'html',
        url: host2 + "/Home/_ADMUsuariosGrid",
        data: { Pagina: pagina },
        success: function (data) {
            $('#ADMUsuariosGrid').html(data);
        },
        failure: function (response) {
            alert("Erro Ao Carregar Pagina!");
        },
        error: function (response) {
            alert(response);
        }
    });

}
/*Função para Trazer as Proximas Paginas no Pagination da Pagina Controle de Usuarios*/
function ControlePaginationUserProx() {

    $("#AntLogAcessoUser").removeClass("pgNone");
    $("#AntLogAcessoUser").addClass("pgBlock");

    const paginas = document.getElementsByClassName("pg");
    const Inicia = PagnationCurentUser + LimitePagination;
    let Fim = Inicia + LimitePagination;

    if (Fim > paginas.length) {

        let aux = Fim - paginas.length;
        Fim = Inicia + aux;
        $("#PrxLogAcessoUser").removeClass("pgBlock");
        $("#PrxLogAcessoUser").addClass("pgNone");
    }

    LimpaPagination(paginas);

    CarregaPagination(paginas, Inicia, Fim);

    PagnationCurentUser = Inicia;

}
/*Função para Trazer as Proximas Paginas no Pagination da Pagina Controle de Usuarios*/
function ControlePaginationUserAnt() {

    $("#PrxLogAcessoUser").removeClass("pgNone");
    $("#PrxLogAcessoUser").addClass("pgBlock");

    const paginas = document.getElementsByClassName("pg");
    let Fim = PagnationCurentUser;
    let Inicia = Fim - LimitePagination;

    if (Fim == LimitePagination) {
        $("#PrxLogAcessoUser").removeClass("pgBlock");
        $("#PrxLogAcessoUser").addClass("pgNone");
    }

    LimpaPagination(paginas);

    CarregaPagination(paginas, Inicia, Fim);

    PagnationCurentUser = Inicia;

}
/*Limpa todos os item do Pagnation para poder carregar so os Selecionados pelo Usuario */
function LimpaPagination(Paginas) {

    for (var i = 0; i < Paginas.length; i++) {
        Paginas[i].classList.add("pgNone");
        Paginas[i].classList.remove("pgBlock");
    }

}
/*Carrega os item do Pagnation selecionados pelo Usuario*/
function CarregaPagination(Paginas, Inicio, Fim) {
    for (var i = Inicio; i < Fim; i++) {
        Paginas[i].classList.add("pgBlock");
        Paginas[i].classList.remove("pgNone");
    }
}
/*Monta o Grafico da Pagina LogAcesso*/
function Grafico() {

    if ($("#chartdiv").hasClass("d-none")) {

        $("#chartdiv").removeClass("d-none");

        let dados;

        $.ajax({
            type: "POST",
            data: { Id: IdGrafico },
            url: '/Home/PegarDadosGrafico',
            success: function (respond) {
                dados = respond;
                CriaGrafico(dados);
            }
        });

    }
    else {
        $("#chartdiv").addClass("d-none");
    }
}//); // end am4core.ready()
/*Cria o Grafico da Pagina LogAcesso*/
function CriaGrafico(dados) {

    // Themes begin
    am4core.useTheme(am4themes_frozen);
    am4core.useTheme(am4themes_animated);
    // Themes end

    // Create chart instance
    var chart = am4core.create("chartdiv", am4charts.XYChart);
    chart.scrollbarX = new am4core.Scrollbar();

    chart.data = dados

    // Create axes
    var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
    categoryAxis.dataFields.category = "Hora";
    categoryAxis.renderer.grid.template.location = 0;
    categoryAxis.renderer.minGridDistance = 30;
    categoryAxis.renderer.labels.template.horizontalCenter = "right";
    categoryAxis.renderer.labels.template.verticalCenter = "middle";
    categoryAxis.renderer.labels.template.rotation = 270;
    categoryAxis.tooltip.disabled = true;
    categoryAxis.renderer.minHeight = 110;

    var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
    valueAxis.renderer.minWidth = 50;

    // Create series
    var series = chart.series.push(new am4charts.ColumnSeries());
    series.sequencedInterpolation = true;
    series.dataFields.valueY = "Quantidade";
    series.dataFields.categoryX = "Hora";
    series.tooltipText = "[{categoryX}: bold]{valueY}[/]";
    series.columns.template.strokeWidth = 0;

    series.tooltip.pointerOrientation = "vertical";

    series.columns.template.column.cornerRadiusTopLeft = 10;
    series.columns.template.column.cornerRadiusTopRight = 10;
    series.columns.template.column.fillOpacity = 0.8;

    // on hover, make corner radiuses bigger
    var hoverState = series.columns.template.column.states.create("hover");
    hoverState.properties.cornerRadiusTopLeft = 0;
    hoverState.properties.cornerRadiusTopRight = 0;
    hoverState.properties.fillOpacity = 1;

    series.columns.template.adapter.add("fill", function (fill, target) {
        return chart.colors.getIndex(target.dataItem.index);
    });

    // Cursor
    chart.cursor = new am4charts.XYCursor();
}
/*Gera o Arquivo XML para Download*/
function GeraXML() {


    $.ajax({
        type: "POST",
        data: { Id: IdGrafico },
        url: '/Home/GeraXML',
        success: function (respond) {
            if (respond) {
                alert("XML Garado com sucesso!");
                $('#arquivoXML').removeClass('d-none');
            }
            else {
                alert("Erro ao Gerar XML");
            }
        }
    });

}
/*Depois de Gravar ou Editar Voltar Campos para Estado Inicial*/
function VoltaModalEstadoInicial(){

    $("#txtNomeEdt").val('');
    Valida("", "NomeEdt");
    $("#txtLoginEdt").val('');
    Valida("", "LoginEdt");
    $("#txtPassEdt").val('');
    HabilitaVSenha('', 'PassEdt');
    $("#txtPassEdt2").val('');
    ValidaSenhaS('', 'PassEdt', 'PassEdt2')


    $("#MPassEdt").removeClass("valid");
    $("#MPassEdt").addClass("invalid");
    $("#mPassEdt").removeClass("valid");
    $("#mPassEdt").addClass("invalid");
    $("#BPassEdt").removeClass("valid");
    $("#BPassEdt").addClass("invalid");
    $("#NPassEdt").removeClass("valid");
    $("#NPassEdt").addClass("invalid");
    $("#SPassEdt").removeClass("valid");
    $("#SPassEdt").addClass("invalid");
    $("#TPassEdt").removeClass("valid");
    $("#TPassEdt").addClass("invalid");
    $("#RPassEdt").removeClass("valid");
    $("#RPassEdt").addClass("invalid");
    $('#dvPassEdt').removeClass('bg-success');
    $('#dvPassEdt').removeClass('bg-danger');

    $('#txtPassEdt2').get(0).type = 'password';
    $('#icRevPassEdt2').removeClass("fa-eye-slash");
    $('#icRevPassEdt2').addClass("fa-eye");

    $('#txtPassEdt').get(0).type = 'password';
    $('#icRevPassEdt').removeClass("fa-eye-slash");
    $('#icRevPassEdt').addClass("fa-eye");
}

