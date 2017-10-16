//Usamos text() para pegar ou setar o valor de texto de tags de exibição de texto, como span, h1 ou p.
var frase = $(".frase").text();
var numPalavras = frase.split(/\S+/).length;
var tamanhoFrase = $("tamanho-frase");
tamanhoFrase.text("numPalavras");

var campo = $(".campo-digitacao");

campo.on("input", function(){
    //Para ler o VALOR de um campo de input, utilizamos val()
    var conteudo = campo.val();
    //Utilizamos a RegEx /\S+/ para separar por espaço + 1.
    var qtdPalavras = conteudo.split(/\S+/).length - 1;
    $("#contador-palavras").text(qtdPalavras);
    $("#contador-caracteres").text(conteudo.length);
});

var tempoRestante = $("#tempo-digitacao").text();
//Podemos utilizar a função one() para executar o código do evento apenas na primeira vez que o evento ocorrer
campo.one("focus", function(){
    //Todo setInterval retorna seu próprio ID, podemos guardá-lo em uma variável.
    var cronometroId = setInterval(function(){
        if(tempoRestante > 0){
            tempoRestante--;
            $("#tempo-digitacao").text(tempoRestante);
        }else{
            campo.attr("disabled", true);
            //Podemos utilizar este ID do setInterval para fazê-lo parar
            clearInterval(cronometroId);
        }
    }, 1000);
});