jQuery(function ($) {

    // Telefone 
    // @class = "maskTel"
    $('.maskTel').focusout(function () {

        $(this).val($(this).val().replace(/\D/g, '').replace('_', ''));
        var phone, element;
        element = $(this);
        element
        phone = element.val().replace(/\D/g, '');
        if (phone.length > 11) {
            element.mask("(999) 99999-999?9");
        } else {
            element.mask("(999) 9999-9999?9");
        }
    }).trigger('focusout');

    $('.maskTel').on('paste', function () {
        return false;
    });

    $('.maskTel').bind('cut', function () {
        return false;
    });

    // Calendario
    // @class = "maskDate"
    $.fn.datepicker.defaults.format = "dd/mm/yyyy";
    //sobrecarga para traduzir datepicker
    $.fn.datepicker.dates['en'] = {
        days: ["Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado", "Domingo"],
        daysShort: ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sáb", "Dom"],
        daysMin: ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sab", "Dom"],
        months: ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"],
        monthsShort: ["Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez"],
        today: "Hoje"
    };

    $('.maskDate').datepicker().datepicker('update');

    $('.maskDate').mask("99/99/9999");

    // Telefone
    $('.maskTel').mask("(999) 99999-999?9");

    // RG
    $('.maskRg').mask("99999999-**");

    // CPF
    $('.maskCpf').mask("999.999.999-99");

    // CNPJ
    $('.maskCnpj').mask("99.999.999/9999-99");

    // CEP
    $(".maskCep").mask("99999-999");
    // Moeda

    // Entre outros que serão uteis....

    // **************** modo de usar ****************

    // Adicione a class ao controle
    // @Html.TextBox("txtTelefoneRep", null, new { maxlength = 20, style = "width:120px", @class = "maskTel" })

    // **************** modo de usar ****************

    $(".numericOnly").keypress(function (e) {
        if (String.fromCharCode(e.keyCode).match(/[^0-9]/g)) return false;
    });

    // Máscara de dinheiro
    $('.maskMoeda').maskMoney();

    // Máscara de dinheiro que aceita negativos
    $('.maskMoedaPermiteNegativo').maskMoney({ allowNegative: true });

    $(".maskNumIdentificacaoPA").mask("?999 - 999.999 / 9999", { autoClear: false });


});


function mascaraMutuario(o, f) {
    v_obj = o
    v_fun = f
    setTimeout('execmascara()', 1)
}

function execmascara() {
    v_obj.value = v_fun(v_obj.value)
}

function cpfCnpj(v) {

    //Remove tudo o que não é dígito
    v = v.replace(/\D/g, "")

    if (v.length <= 11) { //CPF

        //Coloca um ponto entre o terceiro e o quarto dígitos
        v = v.replace(/(\d{3})(\d)/, "$1.$2")

        //Coloca um ponto entre o terceiro e o quarto dígitos
        //de novo (para o segundo bloco de números)
        v = v.replace(/(\d{3})(\d)/, "$1.$2")

        //Coloca um hífen entre o terceiro e o quarto dígitos
        v = v.replace(/(\d{3})(\d{1,2})$/, "$1-$2")

    } else {

        //Coloca ponto entre o segundo e o terceiro dígitos
        v = v.replace(/^(\d{2})(\d)/, "$1.$2")

        //Coloca ponto entre o quinto e o sexto dígitos
        v = v.replace(/^(\d{2})\.(\d{3})(\d)/, "$1.$2.$3")

        //Coloca uma barra entre o oitavo e o nono dígitos
        v = v.replace(/\.(\d{3})(\d)/, ".$1/$2")
        //v = v.replace(/\.(\d{4})(\d)/, ".$1/$2")

        //Coloca um hífen depois do bloco de quatro dígitos
        v = v.replace(/(\d{4})(\d)/, "$1-$2")

    }

    return v

}

function base64_encode(data) {
    //  discuss at: http://phpjs.org/functions/base64_encode/
    // original by: Tyler Akins (http://rumkin.com)
    // improved by: Bayron Guevara
    // improved by: Thunder.m
    // improved by: Kevin van Zonneveld (http://kevin.vanzonneveld.net)
    // improved by: Kevin van Zonneveld (http://kevin.vanzonneveld.net)
    // improved by: Rafał Kukawski (http://kukawski.pl)
    // bugfixed by: Pellentesque Malesuada
    //   example 1: base64_encode('Kevin van Zonneveld');
    //   returns 1: 'S2V2aW4gdmFuIFpvbm5ldmVsZA=='
    //   example 2: base64_encode('a');
    //   returns 2: 'YQ=='

    var b64 = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=';
    var o1, o2, o3, h1, h2, h3, h4, bits, i = 0,
      ac = 0,
      enc = '',
      tmp_arr = [];

    if (!data) {
        return data;
    }

    do { // pack three octets into four hexets
        o1 = data.charCodeAt(i++);
        o2 = data.charCodeAt(i++);
        o3 = data.charCodeAt(i++);

        bits = o1 << 16 | o2 << 8 | o3;

        h1 = bits >> 18 & 0x3f;
        h2 = bits >> 12 & 0x3f;
        h3 = bits >> 6 & 0x3f;
        h4 = bits & 0x3f;

        // use hexets to index into b64, and append result to encoded string
        tmp_arr[ac++] = b64.charAt(h1) + b64.charAt(h2) + b64.charAt(h3) + b64.charAt(h4);
    } while (i < data.length);

    enc = tmp_arr.join('');

    var r = data.length % 3;

    return (r ? enc.slice(0, r - 3) : enc) + '==='.slice(r || 3);
}

function desabilitarLinha(linha) {
    linha.prop("disabled", true);
    linha.css("background-color", "#BBBBBB");
    linha.css("color", "#EDEDED");

    var campos = linha.find('td input');
    campos.each(function () {
        $(this).prop("disabled", true);
        $(this).css("color", "#BDBDBD");
    });
}

function RemoveMascaraValorDecimal(lValor) {

    var valor = lValor;
   
    var lContemPonto = '';
    if (lValor != 'undefined' && typeof lValor != 'undefined') {
       
        lContemPonto = lValor.indexOf(".");

        if (lContemPonto != -1) {
            valor = lValor.replace(/[\.]/g, "");
        }
    }

    return valor;
}

function ConverterFloat(lValor) {

    var valor = '0';
    //console.log("lValor: " + lValor);
    valor = RemoveMascaraValorDecimal(lValor);
    //console.log("valor: " + valor);
    valor = valor.replace(/[\,]/g, ".");   
    return parseFloat(valor);
}

function ConverterFloat2CasasDecimais(lValor) {

    var valor = '0';
    //console.log("lValor: " + lValor);
    valor = RemoveMascaraValorDecimal(lValor);
    //console.log("valor: " + valor);
    valor = valor.replace(/[\,]/g, ".");
    var value = parseFloat(valor).toFixed(2);
    return value;
}
