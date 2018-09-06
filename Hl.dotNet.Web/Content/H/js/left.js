/********************** 三级菜单******************/
    	$(".glyphicon").click(function(){
    		if($(this).hasClass('glyphicon-minus')){
    			$(this).siblings("ul").css({"display":"none"});
    			$(this).removeClass('glyphicon-minus');
    			$(this).addClass('glyphicon-plus');
    		}else if($(this).hasClass('glyphicon-plus')){
    			$(this).siblings("ul").css({"display":"block"});
    			$(this).removeClass('glyphicon-plus');
    			$(this).addClass('glyphicon-minus');
    		}
    	})
        $(".lef-ul li").mouseenter(function(){
            if($(this).has("ul").length > 0){

            }else{
                $(this).css({"background":"#eee"});
                $(this).click(function(){
                    $(this).css({"color":"#f51909"});
                    $(this).siblings("li").css({"color":"#666"});
                    $(this).siblings("li").find("li").css({"color":"#666"});
                    $(this).parents("li").siblings("li").css({"color":"#666"});
                    $(this).parents("li").siblings("li").find("li").css({"color":"#666"});
                })
            }
        }).mouseleave(function(){
            $(this).css({"background":"#fff"});
        })
        // $(".lef-ul li").click(function(){
        //     if($(this).has("ul").length > 0){

        //     }else{
        //         $(this).css({"background":"#eee"});
        //         $(this).siblings("li").css({"background":"#fff"})
        //     }
        // })

    /*********************功能键*********************/
    	$(".rig-tright li").mouseenter(function(){
    		$(this).css({"background":"#eee"});
    		$(".rig-tright li").mousedown(function(){
	    		$(this).css({"background":"#ccc"});
	    	}).mouseup(function(){
	    		$(this).css({"background":"#eee"});
	    	})
    	}).mouseleave(function(){
    		$(this).css({"background":"#fff"});
    	})
        $(".pag-tright li").mouseenter(function(){
            $(this).css({"background":"#eee"});
            $(".pag-tright li").mousedown(function(){
                $(this).css({"background":"#ccc"});
            }).mouseup(function(){
                $(this).css({"background":"#eee"});
            })
        }).mouseleave(function(){
            $(this).css({"background":"#fff"});
        })
    /*****************刷新本页面******************/
    	$(".rig-trio").click(function(){
    		window.location.reload();
    	})
        $(".pag-trio").click(function(){
            window.location.reload();
        })

        // $(".rig-table td i").click(function(){
        //     if($(this).hasClass("fa-toggle-on")){
        //         $(this).removeClass("fa-toggle-on");
        //         $(this).addClass("fa-toggle-off");
        //     }else{
        //         $(this).removeClass("fa-toggle-off");
        //         $(this).addClass("fa-toggle-on");
        //     }
        // })
    
    /********************表格*******************/
        $(".rig-table tr").click(function(){
            $(this).find("td").addClass("rig-dele")
            $(this).find("td").css({"background":"#3498DB"});
            $(this).siblings("tr").find("td").css({"background":"#fff"});
            $(this).siblings("tr").find("td").removeClass("rig-dele");
        })
        $(".pag-table tr").click(function(){
            $(this).find("td").addClass("pag-dele");
            $(this).find("td").css({"background":"#3498DB"});
            $(this).siblings("tr").find("td").css({"background":"#fff"});
            $(this).siblings("tr").find("td").removeClass("pag-dele");
        })
    /**********************************************
                            搜索
    **********************************************/
    /********************lettreegage**************/
        $("#lef-button").click(function(){  
            var input = $("#lef-input").val();
            var arr = [];
            $(".rig-serial").each(function(){
                arr.push($(this).text()); 
            })
            var arro = [];
            $(".rig-bian").each(function(){
                arro.push($(this).text());
            })
            var arrt = [];
            $(".rig-city").each(function(){
                arrt.push($(this).text());
            })
            var arrh = [];
            $(".rig-jian").each(function(){
                arrh.push($(this).text());
            })
            var arrf = [];
            $(".rig-number").each(function(){
                arrf.push($(this).text());
            })
            for(var i = 0; i < arr.length; i++){
                if(arr[i] == input){
                    $(".rig-table .rig-tr").eq(i).show();
                }else if(arro[i] == input){
                    $(".rig-table .rig-tr").eq(i).show();
                }else if(arrt[i] == input){
                    $(".rig-table .rig-tr").eq(i).show();
                }else if(arrh[i] == input){
                    $(".rig-table .rig-tr").eq(i).show();
                }else if(arrf[i] == input){
                    $(".rig-table .rig-tr").eq(i).show();
                }else{
                    $(".rig-table .rig-tr").eq(i).hide();
                }
            }
        })
    /******************paging********************/
        $("#pag-butt").click(function(){
            var pagSearch = $("#pag-sear").val();
            var pagArr = [];
            $(".pag-bian").each(function(){
                pagArr.push($(this).text());

            })
            var pagArro = [];
            $(".pag-city").each(function(){
                pagArro.push($(this).text());
            })
            var pagArrt = [];
            $(".pag-jian").each(function(){
                pagArrt.push($(this).text());
            })
            var pagArrh = [];
            $(".number").each(function(){
                pagArrh.push($(this).text());
            })
            for(var i = 0; i < pagArr.length; i++){
                if(pagArr[i] == pagSearch){
                    $(".pag-tr").eq(i).show();
                }else if(pagArro[i] == pagSearch){
                    $(".pag-tr").eq(i).show();
                }else if(pagArrt[i] == pagSearch){
                    $(".pag-tr").eq(i).show();
                }else if(pagArrh[i] == pagSearch){
                    $(".pag-tr").eq(i).show();
                }else{
                    $(".pag-tr").eq(i).hide();
                }
            }
        })
    /*******************阴影********************/
    $("#lef-che").click(function(){
        if($(this).is(":checked")){
            $("#lef-yyla").html("有效");
        }else{
            $("#lef-yyla").html("无效");
        }
    })
    
    $(".lef-yyquer").click(function(){
        if($(".yy-number").val() == ""){
            $(".yy-number").focus();
            $(".yy-number").css({"border-color":"red"});
            $(".yy-name").css({"border-color":"#999"});
            $(".yy-jian").css({"border-color":"#999"});
            $(".yy-level").css({"border-color":"#999"});
            return false;
        }else if($(".yy-name").val() == ""){
            $(".yy-name").focus();
            $(".yy-name").css({"border-color":"red"});
            $(".yy-number").css({"border-color":"#999"});
            $(".yy-jian").css({"border-color":"#999"});
            $(".yy-level").css({"border-color":"#999"});
            return false;
        }else if($(".yy-jian").val() == ""){
            $(".yy-jian").focus();
            $(".yy-jian").css({"border-color":"red"});
            $(".yy-number").css({"border-color":"#999"});
            $(".yy-name").css({"border-color":"#999"});
            $(".yy-level").css({"border-color":"#999"});
            return false;
        }else if($(".yy-level").val() == ""){
            $(".yy-level").focus();
            $(".yy-level").css({"border-color":"red"});
            $(".yy-number").css({"border-color":"#999"});
            $(".yy-name").css({"border-color":"#999"});
            $(".yy-jian").css({"border-color":"#999"});
            return false;
        }else{
            $(".yy-number").css({"border-color":"#999"});
            $(".yy-name").css({"border-color":"#999"});
            $(".yy-jian").css({"border-color":"#999"});
            $(".yy-level").css({"border-color":"#999"});
            return true;
        }
        // if($(".yy-number").val() == ""){
        //     $(".yy-number").css({"border-color":"red"});
        //     if($(".yy-name").val() == ""){
        //         $(".yy-name").css({"border-color":"red"});
        //         if($(".yy-jian").val() == ""){
        //             $(".yy-jian").css({"border-color":"red"});
        //             if($(".yy-level").val() == ""){
        //                 $(".yy-level").css({"border-color":"red"});
        //             }else{
        //                 $(".yy-level").css({"border-color":"#999"});
        //             }
        //         }else{
        //             $(".yy-jian").css({"border-color":"#999"});
        //         }
        //     }else{
        //         $(".yy-name").css({"border-color":"#999"});
        //     }
        // }else{
        //     $(".yy-number").css({"border-color":"#999"});
        // }
    })
