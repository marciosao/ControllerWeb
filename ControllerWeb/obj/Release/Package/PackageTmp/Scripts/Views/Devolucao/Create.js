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
        }
    }
}
