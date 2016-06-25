window.trocaDePrecos = (function () {
    var _self = {};
    var _opcoesDoAutoNumeric = {
        aSep: '',
        aDec: ','
    };

    _self.iniciar = function () {
        $('body')
            .on('click', 'span[data-js="preco"]', function () {
                var preco = $(this);
                habilitarTrocaDePreco(preco);
            })
            .on('keypress', 'input[data-js="novo-valor"]', enviarNovoValor);
    };

    function habilitarTrocaDePreco(preco) {
        retornarParaExibicoesEmTexto();

        preco.hide();
        preco.next().show().focus().autoNumeric('init', _opcoesDoAutoNumeric).select();
    }

    function retornarParaExibicoesEmTexto() {
        $('input[data-js="novo-valor"]:visible').each(function() {
            var campo = $(this);
            campo.hide().autoNumeric('destroy');
            campo.prev().show().text(campo.val());
        });
    }

    function enviarNovoValor(evento) {
        var campo = $(this);
        var tecla = evento.keyCode;

        if (tecla === 13)
            trocarPreco(campo);
    }

    function trocarPreco(novoValor) {
        var parametros = {
            codPro: novoValor.data('codpro'),
            formaDeVenda: novoValor.data('formadevenda'),
            novoValor: novoValor.autoNumeric('get').replace(',', '.')
        };

        $.post('/TabelaDePrecos/Atualizar', parametros)
            .done(function () {
                retornarParaExibicoesEmTexto();
            }).fail(function () {
                console.log('falhou');
            });
    }

    return _self;
})();