window.editorDePrecos = (function() {
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
            });
    };

    _self.retornarParaExibicoesEmTexto = function() {
        $('input[data-js="novo-valor"]:visible').each(function () {
            var campo = $(this);

            campo.autoNumeric('set', campo.val());
            campo.hide().autoNumeric('destroy');
            campo.prev().show().text(campo.val());
        });
    }

    function habilitarTrocaDePreco(preco) {
        _self.retornarParaExibicoesEmTexto();

        preco.hide();
        preco.next().show().focus().autoNumeric('init', _opcoesDoAutoNumeric).select();
    }

    return _self;
})();