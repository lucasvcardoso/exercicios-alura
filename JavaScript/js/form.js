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

    var erros = validaPaciente(paciente);

    if(erros.length > 0){
        exibeMensagensDeErro(erros);
        return;
    }

    var pacienteTr = montaTr(paciente);
   
    var tabela = document.querySelector("#tabela-pacientes");

    tabela.appendChild(pacienteTr);
    
    form.reset();

    var mensagensDeErroUl = document.querySelector("#mensagens-erro");
    mensagensDeErroUl.innerHTML = "";
    
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
    td.textContent = dado;
    td.classList.add(classe);

    return td;
}

function validaPaciente(paciente){
    var erros = [];

    if(paciente.nome.length == 0){
        erros.push("O nome não pode estar em branco.");
    }
    
    if(!validaPeso(paciente.peso)){
        erros.push("Peso é inválido.");
    }

    if(paciente.peso.length == 0){
        erros.push("Peso não pode estar em branco.");
    }

    if(!validaAltura(paciente.altura)){
        erros.push("Altura é inválida.")
    }
    
    if(paciente.altura.length == 0){
        erros.push("Altura não pode estar em branco.");
    }

    if(paciente.gordura.length == 0){
        erros.push("Gordura não pode estar em branco.");
    }    

    return erros;
}

function exibeMensagensDeErro(erros){
    var ul = document.querySelector("#mensagens-erro");
    ul.innerHTML = "";
    erros.forEach(function(erro){
        var li = document.createElement("li");
        li.textContent = erro;
        li.classList.add("mensagem-erro");
        ul.appendChild(li);
    });
}