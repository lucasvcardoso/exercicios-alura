function inserePlacar() {
    //find() busca dentro do elemento selecionado. Neste caso procura um tbody dentro da section que tem a classe .placar
    var corpoTabela = $(".placar").find("tbody");
    var usuario = "Lucas";
    var numPalavras = $("#contador-palavras").text();
    var linha = novaLinha(usuario, numPalavras);
    linha.find(".botao-remover").click(removeLinha);
    corpoTabela.prepend(linha);
}

function removeLinha() {
    event.preventDefault();
    $(this).parent().parent().remove();
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