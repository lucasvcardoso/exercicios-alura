$("#botao-frase").click(fraseAleatoria);

function fraseAleatoria() {
    //$.get() realiza uma chamada GET para o endereço informado, e executa a function passada no segundo param
    $.get("http://localhost:3000/frases", function(){
        console.log("Fiz a requisição e retornei");
    });
}