var Iniciar = {
    Inicializador: function () {
        this.Eventos.Inicializar();
    },

    Eventos: {
        Inicializar: function () {
            this.AoDigitar();
        },

        AoDigitar: function () {
            $('#txtFabricanteTeste').typeahead({
                ajax: {
                    url: '/Produtos/AutoCompletarFabricantesLeave',
                    ////////triggerLength: 3
                    triggerLength: 1,
                }
            });
        }
    }
}
