$("#botao-frase").click(fraseAleatoria);
$("#botao-frase-id").click(buscaFrase);

function fraseAleatoria() {
    $("#spinner").toggle();
    //$.get() realiza uma chamada GET para o endereço informado, e executa a function passada no segundo param
    $.get("http://localhost:3000/frases", trocaFraseAleatoria)
    //fail() lida com exceções
    .fail(function(){
        $("#erro").toggle();            
        setTimeout(function() {
            $("#erro").toggle();            
        }, 2000);
    }).always(function(){
        $("#spinner").toggle();
    });
}

//Param data (poderia ser qualquer nome) é utilizado para acessar a resposta do GET
function trocaFraseAleatoria(data){
    var frase = $(".frase");
    var numeroAleatorio = Math.floor(Math.random() * data.length);
    frase.text(data[numeroAleatorio].texto);

    atualizaTamanhoFrase();
    atualizaTempoInicial(data[numeroAleatorio].tempo);
    
}

function buscaFrase() {
    var fraseId = $("#frase-id").val();
    var dados = {id: fraseId};
    $("#spinner").toggle();
    $.get("http://localhost:3000/frases", dados, trocaFrase)
    .fail(function(){
        $("#erro").toggle();            
        setTimeout(function() {
            $("#erro").toggle();            
        }, 2000);
    })
    .always(function(){
        $("#spinner").toggle();
    });
}

function trocaFrase(data) {
    var frase = $(".frase");
    frase.text(data.texto);

    atualizaTamanhoFrase();
    atualizaTempoInicial(data.tempo);
}