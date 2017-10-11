//querySelector() traz UM ÚNICO elemento. Para trazer vários,
//utilizamos querySelectorAll().
var titulo = document.querySelector(".titulo");
titulo.textContent = "Aparecida Nutricionista";

var pacientes = document.querySelectorAll(".paciente");

for(var i = 0; i < pacientes.length; i++){
    var paciente = pacientes[i];

    var tdPeso = paciente.querySelector(".info-peso");
    var peso = tdPeso.textContent;

    var tdAltura = paciente.querySelector(".info-altura");
    var altura = tdAltura.textContent;

    var tdImc = paciente.querySelector(".info-imc");

    var pesoEhValido = validaPeso(peso);
    var alturaEhValida = validaAltura(altura);

    if(!pesoEhValido){
        //console.log("Peso inválido");
        pesoEhValido = false;
        tdImc.textContent = "Peso Inválido";
        //Podemos alterar o estilo de um elemento diretamente no JavaScript:
        //paciente.style.backgroundColor = "lightcoral";
        //Mas por questão de manutenibilidade e boas práticas alteramos a CLASSE 
        //do elemento, deixando as definições de estilo dentro do arquivo CSS que 
        //contém a classe:
        paciente.classList.add("paciente-invalido");
        //.classList é uma propriedade que contém todas as classes de um elemento
    }

    if(!alturaEhValida){
        //console.log("Altura inválida");
        alturaEhValida = false;
        tdImc.textContent = "Altura Inválida";
        paciente.classList.add("paciente-invalido");
    }

    if(pesoEhValido && alturaEhValida){
        var imc = calculaImc(peso, altura);
        tdImc.textContent = imc;
    }
}

function calculaImc(peso, altura){
    var imc = 0;

    imc = peso / (altura*altura);

    return imc.toFixed(2);
}

function validaPeso(peso){
    if(peso > 0 && peso < 1000){
        return true;
    }    
    else{
        return false;
    }
}

function validaAltura(altura){
    if(altura > 0 && altura < 3){
        return true;
    }
    else{
        return false;
    }
}
