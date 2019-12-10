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

    //滾後一個刪一個黏監聽
    window.addEventListener('scroll', stick);
    const navbar = document.querySelector('#mainhead');
    const header = document.querySelector('.topbody');

    function stick(event) {
        //取得 header 元素的高度
        const condition = header.offsetHeight;
        //當捲動高度大於header 元素的高度 執行下列程式碼
        if (window.scrollY >= condition) {
            //將 nav 元素的 position 屬性修改為 fixed

            $(navbar).addClass("fixedhead");
            $(header).remove();
            //將 body 加上 paddingTop 將內容物往下移動
            document.body.style.paddingTop = navbar.offsetHeight + 'px';
        }
    };
    //滾後一個刪一個黏監聽//

    //抓到滾動後自動滾動（僅一次
    var sc = 0;
    $(window).scroll(function() {
        if (sc == 0) {
            if ($(this).scrollTop() > 10) {
                let vh = ($(window).height()) * 1.4
                $("html,body").animate({
                    scrollTop: vh
                }, 1000);
                $("html,body").animate({
                    scrollTop: 0
                }, 700);
                $('#mainhead').animate({
                    opacity: 1
                }, 2000)
                sc++
            }
        }
    });
    //抓到滾動後自動滾動（僅一次//

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
                height: "20vh"
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
$('.row_btn').bind('click', function() {

    $(this).addClass('disabled');
    let a = $(this).attr("id");
    console.log(a);
    $('#mainhead').addClass(a + "B")

})



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