var Page = function () { };
Page.prototype = {
    Loading: "<img src='/Content/Scripts/Datapager/loading.gif /><span>正在加载数据，请稍等...</span>",
    NoResult: "暂无相关数据！",
    Count: 10,
    Current: 1,
    Total: 0,
    Url: "",
    Dom: null,
    Container: null,
    Data: {},
    EXP: null,//扩展参数
    type: 0,
    CallBack: null,
    GetPageData: function () {
        $this = this;
        //if ($this.Dom) {
        //   $this.Data = new JSONSerializer().Serialize($this.Dom);
        //}
        
        this.Data.PageSize = this.Count;
        this.Data.PageNum = this.Current;
        this.Data.type = this.type;
        this.Data.EXP = this.EXP;
        this.Data._ = Math.random();

        $("#filter").hide();
        $("#dataArea").hide();
        $("#caption").html($this.Loading);
        $.ajax({
            url: $this.Url,
            async: false,
            cache: false,
            dataType: "json",
            data: $this.Data,
            success: function (result) {
                if (result.ReturnType) {
                    if (result.ReturnCount > 0) {
                        $("#pagers").show();
                        if ($this.CallBack) {
                            if ($this.Container) {
                                $this.Container.empty();
                            }
                            $this.CallBack(result.ReturnData);
                            // $this.Total = result.ReturnData[0].TotalItems;//原来写法
                            $this.Total = result.ReturnCount;//当前写法
                        }
                    }
                    else {
                        if ($this.Container) {
                            $this.Container.empty();
                        }
                        $("#mtitle").html("信息提示");
                        $("#msg").html(result.ReturnMsg);
                        $("#msg_btn").html("<a class=\"btn btn-warning\" style='border-radius:6px;'  data-dismiss=\"modal\">OK</a>");
                        $('#alertModel').modal('show');
                        $("#pagers").hide();
                    }
                }
                else {
                    if ($this.Container) {
                        $this.Container.empty();
                    }
                    $("#mtitle").html("信息提示");
                    $("#msg").html(result.ReturnMsg);
                    $("#msg_btn").html("<a class=\"btn btn-warning\" style='border-radius:6px;'  data-dismiss=\"modal\">OK</a>");
                    $('#alertModel').modal('show');
                    $("#pagers").hide();
                }
            },
            complete: function () {
                $this.Paged();
            }
        });
    },
    Paged: function () {
        var max = Math.ceil(this.Total / this.Count);
        $this = this;
        $("#btnSearch").unbind("click").click(function () {
            $this.Current = 1;
            $this.GetPageData();
        });
        $("#firstPage").unbind("click").click(function () {
            $this.Current = 1;
            $this.GetPageData();
        });
        $("#prePage").unbind("click").click(function () {
            if ($this.Current > 1) {
                $this.Current--;
                $this.GetPageData();
            }
        });


        $("#nextPage").unbind("click").click(function () {
            if ($this.Current < max) {
                $this.Current++;
                $this.GetPageData();
            }

        });
        $("#lastPage").unbind("click").click(function () {
            if ($this.Current < max) {
                $this.Current = max;
                $this.GetPageData();
            }

        });
        if ($this.Current == 1) {
            $("#firstPage,#prePage").addClass("disabled");
            $("#prePage").unbind("click");
            if ($this.Current == max) {
                $("#lastPage,#nextPage").addClass("disabled");
            }
            else {
                $("#lastPage,#nextPage").removeClass("disabled");
            }
        }
        else if ($this.Current == max) {
            $("#lastPage,#nextPage").addClass("disabled");
            $("#firstPage,#prePage").removeClass("disabled");
        }
        else {
            $("#lastPage,#nextPage,#firstPage,#prePage").removeClass("disabled");
        }
        $("#pages").val("当前第" + $this.Current + "页 共" + max + "页");
        $("#pages").unbind("blur").blur(function () {
            var page = parseInt($("#pages").val());
            if (page > 0 && page < max + 1) {
                $this.Current = page;
                $this.GetPageData();
            }
            else {
                $("#pages").val("当前第" + $this.Current + "页 共" + max + "页");
            }
        });

        $("#pages").unbind("focus").focus(function () {
            var page = $("#pages").val("");
        });
    },
    Pchange: function () {
        $this.Count = parseInt($("#selelct_PageCount").val());
        $this.Current = 1;
        $this.GetPageData();

    }

}


//初始化分页
$(function () {
    $("#selelct_PageCount").change(function () {
        var page = new Page();
        page.Pchange();
    });
});

