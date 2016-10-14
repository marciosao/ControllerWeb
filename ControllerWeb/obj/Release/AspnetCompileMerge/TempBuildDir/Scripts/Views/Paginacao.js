var Paginar = {

    ValMinPag: 0,

    Paginacao: function (linhas, tabela, seletor) {
        $(tabela).hide();
        var seletorEach = seletor + ' > ul > li';

        if (linhas > 20) {
            var valor = Paginar.PaginacaoHelper(linhas);

            $(tabela).slice(Paginar.ValMinPag, linhas).show();

            $(seletor).bootpag({
                total: valor,
                maxVisible: valor,
                page: valor,
                next: '&raquo;',
                prev: '&laquo;'
            }).on("page", function (event, num) {
                linhas = Paginar.PaginacaoOnClickHelper(num);

                $(tabela).hide();

                $(tabela).slice(Paginar.ValMinPag, linhas).show();

                $(seletorEach).each(function () {
                    if ($(this).attr('class') == 'disabled') {
                        $(this).find('a').css('background', '#428bca').css('color', 'white');
                    }
                    else {
                        $(this).find('a').css('background', 'white').css('color', '#428bca');
                    }
                });
            });

            $(seletorEach).each(function () {
                if ($(this).attr('class') == 'disabled') {
                    $(this).find('a').css('background', '#428bca').css('color', 'white');
                }
                else {
                    $(this).find('a').css('background', 'white').css('color', '#428bca');
                }
            });
        }
        else if (linhas == 0) {
            $(seletorEach).remove();
        }
        else {
            $(tabela).slice(0, linhas).show();

            $(seletor).bootpag({
                total: 1,
                maxVisible: 1,
                next: null,
                prev: null
            }).on("page", function (event, num) {
                $(tabela).hide();

                $(tabela).slice(0, linhas).show();

                $(seletorEach).each(function () {
                    if ($(this).attr('class') == 'disabled') {
                        $(this).find('a').css('background', '#428bca').css('color', 'white');
                    }
                    else {
                        $(this).find('a').css('background', 'white').css('color', '#428bca');
                    }
                });
            });

            $(seletorEach).each(function () {
                if ($(this).attr('class') == 'disabled') {
                    $(this).find('a').css('background', '#428bca').css('color', 'white');
                }
                else {
                    $(this).find('a').css('background', 'white').css('color', '#428bca');
                }
            });
        }
    },

    PaginacaoHelper: function (linhas) {
        if (linhas > 20 && linhas <= 40) {
            Paginar.ValMinPag = 20;
            return 2;
        }
        else if (linhas > 40 && linhas <= 60) {
            Paginar.ValMinPag = 40;
            return 3;
        }
        else if (linhas > 60 && linhas <= 80) {
            Paginar.ValMinPag = 60;
            return 4;
        }
        else if (linhas > 80 && linhas <= 100) {
            Paginar.ValMinPag = 80;
            return 5;
        }
        else {
            Paginar.ValMinPag = 100;
            return 6;
        }
    },

    PaginacaoOnClickHelper: function (numero) {
        if (numero == 1) {
            Paginar.ValMinPag = 0;
            return Paginar.ValMinPag + 20;
        }
        if (numero == 2) {
            Paginar.ValMinPag = 20;
            return Paginar.ValMinPag + 20;
        }
        else if (numero == 3) {
            Paginar.ValMinPag = 40;
            return Paginar.ValMinPag + 20;
        }
        else if (numero == 4) {
            Paginar.ValMinPag = 60;
            return Paginar.ValMinPag + 20;
        }
        else if (numero == 5) {
            Paginar.ValMinPag = 80;
            return Paginar.ValMinPag + 20;
        }
        else {
            Paginar.ValMinPag = 100;
            return Paginar.ValMinPag + 20;
        }
    }
}