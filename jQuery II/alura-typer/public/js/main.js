var campo = $(".campo-digitacao");
var tempoInicial = $("#tempo-digitacao").text();

//Função ready() para executar código após o load da página
// $(document).ready()
//Passar uma função direto para o $ é um atalho para $(document).ready()
$(
    function(){
    atualizaTamanhoFrase();
    inicializaContadores();
    inicializaCronometro();
    inicializaMarcadores();
    //Para eventos mais comuns, como click e focus, temos funções próprias
    $("#botao-reiniciar").click(reiniciaJogo);
    atualizaPlacar();
    
    $("#usuarios").selectize({
        create: true,
        sortField: "text"
    });

    $(".tooltip").tooltipster({
        trigger: "custom"
    });
});

function atualizaTamanhoFrase() {
    //Usamos text() para pegar ou setar o valor de texto de tags de exibição de texto, como span, h1 ou p.
    var frase = $(".frase").text();
    var numPalavras = frase.split(/\S+/).length;
    var tamanhoFrase = $("#tamanho-frase");
    tamanhoFrase.text(numPalavras);
}    

function inicializaContadores() {
    campo.on("input", function(){
        //Para ler o VALOR de um campo de input, utilizamos val()
        var conteudo = campo.val();
        //Utilizamos a RegEx /\S+/ para separar por espaço + 1.
        var qtdPalavras = conteudo.split(/\S+/).length - 1;
        $("#contador-palavras").text(qtdPalavras);
        $("#contador-caracteres").text(conteudo.length);
    });
}

function atualizaTempoInicial(tempo) {
    $("#tempo-digitacao").text(tempo);
    tempoInicial = tempo;
}

function inicializaCronometro() {    
    //Podemos utilizar a função one() para executar o código do evento apenas na primeira vez que o evento ocorrer
    campo.one("focus", function(){
        var tempoRestante = $("#tempo-digitacao").text();
        $("#botao-reiniciar").attr("disabled", true);
        //Todo setInterval retorna seu próprio ID, podemos guardá-lo em uma variável.
        var cronometroId = setInterval(function(){
            tempoRestante--;
            $("#tempo-digitacao").text(tempoRestante);
            if(tempoRestante < 1){            
                campo.attr("disabled", true);
                //Podemos utilizar este ID do setInterval para fazê-lo parar
                clearInterval(cronometroId);
                finalizaJogo();                
            }
        }, 1000);
    });
}

function finalizaJogo() {
    $("#botao-reiniciar").attr("disabled", false);
    campo.toggleClass("campo-desativado");
    inserePlacar();
}

function inicializaMarcadores() {
    campo.on("input", function(){
        var frase = $(".frase").text();
        var digitado = campo.val();
        var comparavel = frase.substr(0, digitado.length);
        if(digitado == comparavel){
            campo.addClass("campo-correto");
            campo.removeClass("campo-errado");
        }else{
            campo.addClass("campo-errado");   
            campo.removeClass("campo-correto");
        }
    });
}

function reiniciaJogo() {
    campo.attr("disabled", false);
    campo.val("");
    $("#tempo-digitacao").text(tempoInicial);
    $("#contador-palavras").text("0");
    $("#contador-caracteres").text("0");
    inicializaCronometro();
    campo.toggleClass("campo-desativado");
    campo.removeClass("campo-correto");
    campo.removeClass("campo-errado");
}

