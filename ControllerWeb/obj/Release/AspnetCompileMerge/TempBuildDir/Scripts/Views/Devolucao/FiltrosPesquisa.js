
var Iniciar = {

    Inicializador: function () {
        this.Eventos.Inicializar();
    },

    Eventos: {
        Inicializar: function () {
            this.AoEntrarColocarDatepicker();
        },

        AoEntrarColocarDatepicker: function () {
            $.fn.datepicker.defaults.format = "dd/mm/yyyy";
            $('#DataDevolucao').datepicker();
            $('#DataDevolucao').mask('99/99/9999');
        },

        AoClicarImprimir: function () {
            $('#btnGerarRelatorio').off('click');
            $('#btnGerarRelatorio').on('click', function () {

                var lDataDevolucao = $('#DataDevolucao').val();
                var lProduto = $('#Produto').val();
                var lVendedor = $('#IdVendedor').val();

                var ProdutoSelecionado = new Object();

                ProdutoSelecionado.DataDevolucao = lDataDevolucao;
                ProdutoSelecionado.Produto = lProduto;
                ProdutoSelecionado.IdVendedor = lVendedor;

                $.ajax(
                    {
                        url: '/Devolucao/GerarRelatorio',
                        type: 'POST',
                        dataType: 'json',
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify({ 'pDevolucao': ProdutoSelecionado })
                    });
                })
        }
    }
}