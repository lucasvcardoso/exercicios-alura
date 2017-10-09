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
    
    var paciente = obtemPacienteDoFormulario(form);

    var pacienteTr = montaTr(paciente);
   
    var tabela = document.querySelector("#tabela-pacientes");

    tabela.appendChild(pacienteTr);

    form.reset();
    
    //Para utilizar uma função nomeada, passamos o nome da função
    //sem os parênteses como param do addEventListener()
});

function obtemPacienteDoFormulario(form){
    var paciente = {
        nome: form.nome.value,
        peso: form.peso.value,
        altura: form.altura.value,
        gordura: form.gordura.value, 
        imc: calculaImc(form.peso.value, form.altura.value)
    }

    return paciente;
}

function montaTr(paciente){
    var pacienteTr = document.createElement("tr");
    
    pacienteTr.classList.add("paciente");

    var nomeTd = montaTd(paciente.nome, "info-nome");
    var pesoTd = montaTd(paciente.peso, "info-peso");
    var alturaTd = montaTd(paciente.altura, "info-altura");
    var gorduraTd = montaTd(paciente.gordura, "info-gordura");
    var imcTd = montaTd(paciente.imc, "info-imc");

    pacienteTr.appendChild(nomeTd);
    pacienteTr.appendChild(pesoTd);
    pacienteTr.appendChild(alturaTd);
    pacienteTr.appendChild(gorduraTd);
    pacienteTr.appendChild(imcTd);

    return pacienteTr;
}

function montaTd(dado, classe){
    var td = document.createElement("td");
    td.TextContent = dado;
    td.classList.add(classe);

    return td;
}