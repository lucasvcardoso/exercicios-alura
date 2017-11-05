$("#botao-placar").click(mostraPlacar);
$("#botao-sync").click(sincronizaPlacar);

function mostraPlacar(){
    // $(".placar").toggle();//Funciona como toggleClass(), para mostrar/ocultar o elemento
    // $(".placar").slideDown(600);//Mostra o elemento com uma animação para baixo. O oposto é slideUp(), que oculta o elemento.
    //Dá toggle em slideUp() e slideDown(). stop() serve para interomper alguma animação que já esteja correndo, e evitar enfileirar várias animações, que seriam executadas uma após a outra até a última.
    $(".placar").stop().slideToggle(600);
    scrollPlacar();
}

function inserePlacar() {
    //find() busca dentro do elemento selecionado. Neste caso procura um tbody dentro da section que tem a classe .placar
    var corpoTabela = $(".placar").find("tbody");
    var usuario = $("#usuarios").val();
    var numPalavras = $("#contador-palavras").text();
    var linha = novaLinha(usuario, numPalavras);
    linha.find(".botao-remover").click(removeLinha);
    corpoTabela.prepend(linha);
    $(".placar").slideDown(600);
    scrollPlacar();
}

function scrollPlacar(){
    var posicao = $(".placar").offset().top;//Pega a posição do topo do elemento.
    //animate() anima o elemento. O método recebe um JSON com as propriedades a serem animadas e um número de milissegundos para a duração da animação.
    $("html").animate(
    {
        scrollTop: posicao + "px"//scrollTop deve conter um valor em px para a animação.
    }, 1000);
}

function removeLinha() {
    event.preventDefault();
    var linha = $(this).parent().parent();
    linha.fadeOut(1000);//Remove com animação de fade out. Temos como opções também fadeIn() para exibir e fadeToggle().
    setTimeout(function(){
        linha.remove();
    },1000);
    //Pode-se também passar o linhe.remove() dentro de uma function anônima como argumento para o fadeOut(), que executaria a function() assim que terminasse a animação. Like so:
    // linha.fadeOut(1000,function(){
    //     linha.remove();
    // });
}

function novaLinha(usuario, palavras) {
    //Podemos utilizar desta forma para criar novos elementos
    var linha = $("<tr>");
    var colunaUsuario = $("<td>").text(usuario);
    var colunaPalavras = $("<td>").text(palavras);
    var colunaRemover = $("<td>");
    var link = $("<a>").addClass("botao-remover").attr("href", "#");
    var icone = $("<i>").addClass("small").addClass("material-icons").text("delete");
    link.append(icone);
    colunaRemover.append(link);
    linha.append(colunaUsuario);
    linha.append(colunaPalavras);
    linha.append(colunaRemover);

    return linha;
}

function sincronizaPlacar() {
    var placar = [];
    var linhas = $("tbody>tr");

    linhas.each(function() {
        var usuario = $(this).find("td:nth-child(1)").text();
        var palavras = $(this).find("td:nth-child(2)").text();

        var score = {
            usuario: usuario,
            pontos: palavras
        };
        placar.push(score);
    });

    var dados = {
        placar: placar
    };

    $.post("http://localhost:3000/placar", dados, function(){
        console.log("Placar sincronizado com sucesso.");
        $(".tooltip").tooltipster("open");
    })
    .fail(function(){
        $(".tooltip").tooltipster("open").tooltipster("content","Falha ao sincronizar");
    })
    .always(function(){
        setTimeout(function() {
            $(".tooltip").tooltipster("close");
        }, 1200);
    });
}

function atualizaPlacar() {
    $.get("http://localhost:3000/placar", function(data) {
       $(data).each(function(){
            var linha = novaLinha(this.usuario, this.pontos);
            linha.find(".botao-remover").click(removeLinha);
            $("tbody").append(linha);
       });
    });
}