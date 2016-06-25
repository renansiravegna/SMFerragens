window.trocaDePrecos = (function () {
    var _self = {};

    _self.iniciar = function () {
        $('body').on('keypress', 'input[data-js="novo-valor"]', enviarNovoValor);
    };

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
                window.editorDePrecos.retornarParaExibicoesEmTexto();
            }).fail(function () {
                console.log('falhou');
            });
    }

    return _self;
})();