
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
            $('#DataOcorrencia').datepicker();
            $('#DataOcorrencia').mask('99/99/9999');
        }
    },
}