/************************************
              paging
************************************/
/*************高级搜索**************/
$("#pag-search").click(function(){
	layer.open({
		type:2,
		area:['700px', '450px'],
		fixed:false,
		maxmin:true,
		content:'search.html',
		btn: ['确定'],
        yes: function (index, layero) {
            callBack(index, layero);
            return false;

            // layer.close(index); //如果设定了yes回调，需进行手工关闭
        },
        cancel: function () {
          //右上角关闭回调
        }
	});
})