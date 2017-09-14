//Para adicionar um event listener, deve-se passar o nome do evento
//e uma função como param. Pode-se usar uma função nomeada, ou uma função
//anônima.
/*
titulo.addEventListener("click", function(){
    console.log("Anonymous function");
});

function mostraMensagem(){
    console.log("Olá, eu fui clicado!");
}
*/
var botaoAdicionar = document.querySelector("#adicionar-paciente");

botaoAdicionar.addEventListener("click", function(event){
    //Para evitar que o botão chame o evento default (submit)
    //precisamos receber o event como param da função
    //e utilizar a linha abaixo:
    event.preventDefault();
    //console.log("Botão clicado");
    var form = document.querySelector("#form-adiciona");
    
    var nome = form.nome.value;
    var peso = form.peso.value;
    var altura = form.altura.value;
    var gordura = form.gordura.value;

    var pacienteTr = document.createElement("tr");
    
    var nomeTd = document.createElement("td");
    var pesoTd = document.createElement("td");
    var alturaTd = document.createElement("td");
    var gorduraTd = document.createElement("td");
    var imcTd = document.createElement("td");

    nomeTd.textContent = nome;
    pesoTd.textContent = peso;
    alturaTd.textContent = altura;
    gorduraTd.textContent = gordura;
    imcTd.textContent = calculaImc(peso, altura);

    pacienteTr.appendChild(nomeTd);
    pacienteTr.appendChild(pesoTd);
    pacienteTr.appendChild(alturaTd);
    pacienteTr.appendChild(gorduraTd);
    pacienteTr.appendChild(imcTd);

    var tabela = document.querySelector("#tabela-pacientes");

    tabela.appendChild(pacienteTr);
    
    //Para utilizar uma função nomeada, passamos o nome da função
    //sem os parênteses como param do addEventListener()
});
