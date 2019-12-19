$(function() {
    //滾到最上動畫
    $('#BackTop').click(function() {
        $('html,body').animate({
            scrollTop: 0
        }, 333);
    });
    //滾到600才顯示
    $(window).scroll(function() {
        if ($(this).scrollTop() > 300) {
            $('#BackTop').fadeIn(222);
            $('.up1').addClass('up1t');
            $('.up2').addClass('up2t');
        } else {
            $('#BackTop').stop().fadeOut(222);
            $('.up1').removeClass('up1t');
            $('.up2').removeClass('up2t');
        }
    }).scroll();

    $(window).scroll(function() {
        if ($(this).scrollTop() > 1) {
            $('#bottomfunc').fadeIn(222);           
        } else {
            $('#bottomfunc').stop().fadeOut(222);           
        }
    }).scroll();


    //晚上head動畫
    var date = new Date;
    var HH = date.getHours();
    if (HH > 18/*||HH<6*/) {
       
        $(window).scroll(function () {
            if ($(this).scrollTop() > 1) {
                $('#mainhead').css({ "background": "rgba(52, 58, 64, 1)" ,"color":"white"})
            } else {
                $('#mainhead').css({ "background": "rgba(52, 58, 64, 0)", "color":"rgb(52, 58, 64)" })
            }
        }).scroll();
    }
   
    //晚上head動畫//


    //功能列滾動跟隨
    (function(wnd, $) {

        // query for elements once
        var $dlg = $(".lgFuncRight").parent(),
            $wnd = $(wnd),
            // get the initial position of dialog
            initialTop = $dlg.offset().top - $wnd.scrollTop();

        $wnd.scroll(function() {
                // when qscrolling, animate the 'top' property
                $dlg.stop()
                    .animate({
                        "top": ($wnd.scrollTop()) + "px"
                    }, "slow");
            })
            .resize(function() {
                // in case of resize, re-set the initial top position of the dialog
                initialTop = $dlg.offset().top - $wnd.scrollTop();
            });

        // if you close/open the dialog, it will mess up the 'initialTop'
        // this will re-set the correct 'initialTop' when the dialog opens again
        $dlg.bind('dialogcreate dialogopen', function(e) {
            initialTop = $dlg.offset().top - $wnd.scrollTop();
        });

    })(window, jQuery); //功能列滾動跟隨//

    //點擊側邊登入先關掉側邊欄>再開模態框
    $("#loginnavside").bind('click', function() {
        $("#mySidenav").css("width", "0"),
            $("#movenav").css({
                'marginLeft': "0",
            });
        for (i = 1; i <= 3; i++) {
            $(".X" + i).removeClass('X' + i + 'Closs');
        }
        $('#cliphead').removeClass('cliphead');
    });

})

//lg簡易搜尋展開
var sear = 0;
$('.searchhelp').click(function() {
        if (sear % 2 == 0) {
            $('.searchbox').animate({
                height: "16px"
            }, 20).animate({
                width: "50vw"
            }, 1000).animate({
                height: "8rem"
            }, 500)

        } else {
            $('.searchbox').animate({
                height: "16px"
            }, 1000).animate({
                width: "0vw"
            }, 1000).animate({
                height: "0vh"
            }, 300)
        }
        sear++;
    }) //lg簡易搜尋展開//


//header按鈕缺角.作廢以不同LAYOUT解決




//側邊欄動畫
var x = false;
$('.opennav').on('click', function() {
    if (!x) {

        $("#mySidenav").css("width", "250px");
        $("#movenav").css({
            'marginLeft': "250px",
            'width': "100%",
        });
        for (i = 1; i <= 3; i++) {
            $(".X" + i).addClass('X' + i + 'Closs');
        };
        $('#cliphead').addClass('cliphead');

        x = true;
    } else {

        $("#mySidenav").css("width", "0"),
            $("#movenav").css({
                'marginLeft': "0",
            });
        for (i = 1; i <= 3; i++) {
            $(".X" + i).removeClass('X' + i + 'Closs');
        }
        $('#cliphead').removeClass('cliphead');
        x = false;
    }
})

$('[data-toggle="tooltip"]').tooltip();