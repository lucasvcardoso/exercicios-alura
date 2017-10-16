//Usamos text() para pegar ou setar o valor de texto de tags de exibição de texto, como span, h1 ou p.
var frase = $(".frase").text();
var numPalavras = frase.split(/\S+/).length;
var tamanhoFrase = $("tamanho-frase");
tamanhoFrase.text("numPalavras");

var campo = $(".campo-digitacao");

campo.on("input", function(){
    var campoDigitacao = $(".campo-digitacao");
    //Para ler o VALOR de um campo de input, utilizamos val()
    var conteudo = campo.val();
    //Utilizamos a RegEx /\S+/ para separar por espaço + 1.
    var qtdPalavras = conteudo.split(/\S+/).length - 1;
    $("#contador-palavras").text(qtdPalavras);
    $("#contador-caracteres").text(conteudo.length);
});