var host = window.location.hostname;

$(document).ready(function () {

    /*Controle para mudar o caminho das Paginas , se for em ambiente de Teste ou Produção*/
    if (host === 'localhost') {
        host = '';
    }
    else {
        host = '/WEBAplication';
    };

    /*Revela a Senha no Campo*/
    $("#revelaPass").click(function () {

        if ($('#txtPass').get(0).type == "text") {
            $('#txtPass').get(0).type = 'password';
            $('#icRevPass').removeClass("fa-eye-slash");
            $('#icRevPass').addClass("fa-eye");
        }
        else {
            $('#txtPass').get(0).type = 'text';
            $('#icRevPass').removeClass("fa-eye");
            $('#icRevPass').addClass("fa-eye-slash");
        }

    })
    /*Muda o fundo do icone de mostrar a senha*/
    $("#revelaPass").mouseover(function () {
        $("#revelaPass").removeClass("bg-transparent");
        $("#revelaPass").addClass("bg-secondary");
    })
    /*Muda o fundo do icone de mostrar a senha*/
    $("#revelaPass").mouseleave(function () {
        $("#revelaPass").removeClass("bg-secondary");
        $("#revelaPass").addClass("bg-transparent");
    })
    /*Revela a Senha no Campo*/
    $("#revelaPassCad").click(function () {

        if ($('#txtPass2').get(0).type == "text") {
            $('#txtPass2').get(0).type = 'password';
            $('#icRevPass2').removeClass("fa-eye-slash");
            $('#icRevPass2').addClass("fa-eye");
        }
        else {
            $('#txtPass2').get(0).type = 'text';
            $('#icRevPass2').removeClass("fa-eye");
            $('#icRevPass2').addClass("fa-eye-slash");
        }

    })
    /*Muda o fundo do icone de mostrar a senha*/
    $("#revelaPassCad").mouseover(function () {
        $("#revelaPass2").removeClass("bg-transparent");
        $("#revelaPass2").addClass("bg-secondary");
    })
    /*Muda o fundo do icone de mostrar a senha*/
    $("#revelaPassCad").mouseleave(function () {
        $("#revelaPass2").removeClass("bg-secondary");
        $("#revelaPass2").addClass("bg-transparent");
    })
    /*Revela a Senha no Campo*/
    $("#revelaPassCad2").click(function () {

        if ($('#txtPass3').get(0).type == "text") {
            $('#txtPass3').get(0).type = 'password';
            $('#icRevPass3').removeClass("fa-eye-slash");
            $('#icRevPass3').addClass("fa-eye");
        }
        else {
            $('#txtPass3').get(0).type = 'text';
            $('#icRevPass3').removeClass("fa-eye");
            $('#icRevPass3').addClass("fa-eye-slash");
        }

    })
    /*Muda o fundo do icone de mostrar a senha*/
    $("#revelaPassCad2").mouseover(function () {
        $("#revelaPass3").removeClass("bg-transparent");
        $("#revelaPass3").addClass("bg-secondary");
    })
    /*Muda o fundo do icone de mostrar a senha*/
    $("#revelaPassCad2").mouseleave(function () {
        $("#revelaPass3").removeClass("bg-secondary");
        $("#revelaPass3").addClass("bg-transparent");
    })
    /*Função para mostrar a Pagina de Cadatro de Usuario na Pagina de Login*/
    $("#BtnCadastro").click(function () {
        $("#txtNome").val("");
        $("#txtLoginCad").val("");
        $("#txtPass2").val("");
        $("#txtPass3").val("");
        $('#Login').removeClass('d-block');
        $('#Login').addClass('d-none');
        $('#Cadastro').removeClass('d-none');
        $('#Cadastro').addClass('d-block');
    })
    /*Fechar a Pagina de Cadastro na Pagina de Login*/
    $("#BtnCadastroSair").click(function () {
        $('#Cadastro').removeClass('d-block');
        $('#Cadastro').addClass('d-none');
        $('#Login').removeClass('d-none');
        $('#Login').addClass('d-block');
    })

});

/*Função de controle de Login do Site*/
function Logar() {

    let user = $("#txtLogin").val();
    let log = $("#txtPass").val();

    if (user != "" && log != "") {
        $.ajax({
            type: "POST",
            url: host + "/Home/Logar",
            data: { Login: user, Senha: log },
            success: function (response) {
                if (response) {
                    window.location.href = host + '/Home/Index'
                }
                else {
                    alert("Usuario não encontrado");
                }
            },
            failure: function (response) {
                alert("Usuario não encontrato!");
            },
            error: function (response) {
                alert("Usuario não encontrato!");
            }
        });
    }
    else {
        alert("Preencha todos os Campos antes!");
    }



}



