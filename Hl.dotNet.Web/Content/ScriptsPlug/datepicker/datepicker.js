!
function (m) {
    function j() {
        return new Date(Date.UTC.apply(Date, arguments))
    }
    function h() {
        var a = new Date();
        return j(a.getUTCFullYear(), a.getUTCMonth(), a.getUTCDate(), a.getUTCHours(), a.getUTCMinutes(), a.getUTCSeconds(), 0)
    }
    var k = function (c, d) {
        var a = this;
        this.element = m(c);
        this.container = d.container || "body";
        this.language = d.language || this.element.data("date-language") || "en";
        this.language = this.language in l ? this.language : "en";
        this.isRTL = l[this.language].rtl || false;
        this.formatType = d.formatType || this.element.data("format-type") || "standard";
        this.format = n.parseFormat(d.format || this.element.data("date-format") || l[this.language].format || n.getDefaultFormat(this.formatType, "input"), this.formatType);
        this.isInline = false;
        this.isVisible = false;
        this.isInput = this.element.is("input");
        this.fontAwesome = d.fontAwesome || this.element.data("font-awesome") || false;
        this.bootcssVer = d.bootcssVer || (this.isInput ? (this.element.is(".form-control") ? 3 : 2) : (this.bootcssVer = this.element.is(".input-group") ? 3 : 2));
        this.component = this.element.is(".date") ? (this.bootcssVer == 3 ? this.element.find(".input-group-addon .glyphicon-th, .input-group-addon .glyphicon-time, .input-group-addon .glyphicon-calendar, .input-group-addon .glyphicon-calendar, .input-group-addon .fa-calendar, .input-group-addon .fa-clock-o").parent() : this.element.find(".add-on .icon-th, .add-on .icon-time, .add-on .icon-calendar .fa-calendar .fa-clock-o").parent()) : false;
        this.componentReset = this.element.is(".date") ? (this.bootcssVer == 3 ? this.element.find(".input-group-addon .glyphicon-remove .fa-times").parent() : this.element.find(".add-on .icon-remove .fa-times").parent()) : this.element.find("input").val("");
        this.hasInput = this.component && this.element.find("input").length;
        if (this.component && this.component.length === 0) {
            this.component = false
        }
        this.linkField = d.linkField || this.element.data("link-field") || false;
        this.linkFormat = n.parseFormat(d.linkFormat || this.element.data("link-format") || n.getDefaultFormat(this.formatType, "link"), this.formatType);
        this.minuteStep = d.minuteStep || this.element.data("minute-step") || 5;
        this.pickerPosition = d.pickerPosition || this.element.data("picker-position") || "bottom-right";
        this.showMeridian = d.showMeridian || this.element.data("show-meridian") || false;
        this.initialDate = d.initialDate || new Date();
        this.zIndex = d.zIndex || this.element.data("z-index") || undefined;
        this.icons = {
            leftArrow: this.fontAwesome ? "fa-arrow-left" : (this.bootcssVer === 3 ? "glyphicon-arrow-left" : "icon-arrow-left"),
            rightArrow: this.fontAwesome ? "fa-arrow-right" : (this.bootcssVer === 3 ? "glyphicon-arrow-right" : "icon-arrow-right")
        };
        this.icontype = this.fontAwesome ? "fa" : "glyphicon";
        this._attachEvents();
        this.formatViewType = "datetime";
        if ("formatViewType" in d) {
            this.formatViewType = d.formatViewType
        } else {
            if ("formatViewType" in this.element.data()) {
                this.formatViewType = this.element.data("formatViewType")
            }
        }
        this.minView = 0;
        if ("minView" in d) {
            this.minView = d.minView
        } else {
            if ("minView" in this.element.data()) {
                this.minView = this.element.data("min-view")
            }
        }
        this.minView = n.convertViewMode(this.minView);
        this.maxView = n.modes.length - 1;
        if ("maxView" in d) {
            this.maxView = d.maxView
        } else {
            if ("maxView" in this.element.data()) {
                this.maxView = this.element.data("max-view")
            }
        }
        this.maxView = n.convertViewMode(this.maxView);
        this.wheelViewModeNavigation = false;
        if ("wheelViewModeNavigation" in d) {
            this.wheelViewModeNavigation = d.wheelViewModeNavigation
        } else {
            if ("wheelViewModeNavigation" in this.element.data()) {
                this.wheelViewModeNavigation = this.element.data("view-mode-wheel-navigation")
            }
        }
        this.wheelViewModeNavigationInverseDirection = false;
        if ("wheelViewModeNavigationInverseDirection" in d) {
            this.wheelViewModeNavigationInverseDirection = d.wheelViewModeNavigationInverseDirection
        } else {
            if ("wheelViewModeNavigationInverseDirection" in this.element.data()) {
                this.wheelViewModeNavigationInverseDirection = this.element.data("view-mode-wheel-navigation-inverse-dir")
            }
        }
        this.wheelViewModeNavigationDelay = 100;
        if ("wheelViewModeNavigationDelay" in d) {
            this.wheelViewModeNavigationDelay = d.wheelViewModeNavigationDelay
        } else {
            if ("wheelViewModeNavigationDelay" in this.element.data()) {
                this.wheelViewModeNavigationDelay = this.element.data("view-mode-wheel-navigation-delay")
            }
        }
        this.startViewMode = 2;
        if ("startView" in d) {
            this.startViewMode = d.startView
        } else {
            if ("startView" in this.element.data()) {
                this.startViewMode = this.element.data("start-view")
            }
        }
        this.startViewMode = n.convertViewMode(this.startViewMode);
        this.viewMode = this.startViewMode;
        this.viewSelect = this.minView;
        if ("viewSelect" in d) {
            this.viewSelect = d.viewSelect
        } else {
            if ("viewSelect" in this.element.data()) {
                this.viewSelect = this.element.data("view-select")
            }
        }
        this.viewSelect = n.convertViewMode(this.viewSelect);
        this.forceParse = true;
        if ("forceParse" in d) {
            this.forceParse = d.forceParse
        } else {
            if ("dateForceParse" in this.element.data()) {
                this.forceParse = this.element.data("date-force-parse")
            }
        }
        var b = this.bootcssVer === 3 ? n.templateV3 : n.template;
        while (b.indexOf("{iconType}") !== -1) {
            b = b.replace("{iconType}", this.icontype)
        }
        while (b.indexOf("{leftArrow}") !== -1) {
            b = b.replace("{leftArrow}", this.icons.leftArrow)
        }
        while (b.indexOf("{rightArrow}") !== -1) {
            b = b.replace("{rightArrow}", this.icons.rightArrow)
        }
        this.picker = m(b).appendTo(this.isInline ? this.element : this.container).on({
            click: m.proxy(this.click, this),
            mousedown: m.proxy(this.mousedown, this)
        });
        if (this.wheelViewModeNavigation) {
            if (m.fn.mousewheel) {
                this.picker.on({
                    mousewheel: m.proxy(this.mousewheel, this)
                })
            } else {
                console.log("Mouse Wheel event is not supported. Please include the jQuery Mouse Wheel plugin before enabling this option")
            }
        }
        if (this.isInline) {
            this.picker.addClass("datetimepicker-inline")
        } else {
            this.picker.addClass("datetimepicker-dropdown-" + this.pickerPosition + " dropdown-menu")
        }
        if (this.isRTL) {
            this.picker.addClass("datetimepicker-rtl");
            var e = this.bootcssVer === 3 ? ".prev span, .next span" : ".prev i, .next i";
            this.picker.find(e).toggleClass(this.icons.leftArrow + " " + this.icons.rightArrow)
        }
        m(document).on("mousedown",
        function (f) {
            if (m(f.target).closest(".datetimepicker").length === 0) {
                a.hide()
            }
        });
        this.autoclose = false;
        if ("autoclose" in d) {
            this.autoclose = d.autoclose
        } else {
            if ("dateAutoclose" in this.element.data()) {
                this.autoclose = this.element.data("date-autoclose")
            }
        }
        this.keyboardNavigation = true;
        if ("keyboardNavigation" in d) {
            this.keyboardNavigation = d.keyboardNavigation
        } else {
            if ("dateKeyboardNavigation" in this.element.data()) {
                this.keyboardNavigation = this.element.data("date-keyboard-navigation")
            }
        }
        this.todayBtn = (d.todayBtn || this.element.data("date-today-btn") || false);
        this.todayHighlight = (d.todayHighlight || this.element.data("date-today-highlight") || false);
        this.weekStart = ((d.weekStart || this.element.data("date-weekstart") || l[this.language].weekStart || 0) % 7);
        this.weekEnd = ((this.weekStart + 6) % 7);
        this.startDate = -Infinity;
        this.endDate = Infinity;
        this.daysOfWeekDisabled = [];
        this.setStartDate(d.startDate || this.element.data("date-startdate"));
        this.setEndDate(d.endDate || this.element.data("date-enddate"));
        this.setDaysOfWeekDisabled(d.daysOfWeekDisabled || this.element.data("date-days-of-week-disabled"));
        this.setMinutesDisabled(d.minutesDisabled || this.element.data("date-minute-disabled"));
        this.setHoursDisabled(d.hoursDisabled || this.element.data("date-hour-disabled"));
        this.fillDow();
        this.fillMonths();
        this.update();
        this.showMode();
        if (this.isInline) {
            this.show()
        }
    };
    k.prototype = {
        constructor: k,
        _events: [],
        _attachEvents: function () {
            this._detachEvents();
            if (this.isInput) {
                this._events = [[this.element, {
                    focus: m.proxy(this.show, this),
                    keyup: m.proxy(this.update, this),
                    keydown: m.proxy(this.keydown, this)
                }]]
            } else {
                if (this.component && this.hasInput) {
                    this._events = [[this.element.find("input"), {
                        focus: m.proxy(this.show, this),
                        keyup: m.proxy(this.update, this),
                        keydown: m.proxy(this.keydown, this)
                    }], [this.component, {
                        click: m.proxy(this.show, this)
                    }]];
                    if (this.componentReset) {
                        this._events.push([this.componentReset, {
                            click: m.proxy(this.reset, this)
                        }])
                    }
                } else {
                    if (this.element.is("div")) {
                        this.isInline = true
                    } else {
                        this._events = [[this.element, {
                            click: m.proxy(this.show, this)
                        }]]
                    }
                }
            }
            for (var c = 0,
            b, a; c < this._events.length; c++) {
                b = this._events[c][0];
                a = this._events[c][1];
                b.on(a)
            }
        },
        _detachEvents: function () {
            for (var c = 0,
            b, a; c < this._events.length; c++) {
                b = this._events[c][0];
                a = this._events[c][1];
                b.off(a)
            }
            this._events = []
        },
        show: function (a) {
            this.picker.show();
            this.height = this.component ? this.component.outerHeight() : this.element.outerHeight();
            //alert(this.height);
            if (this.forceParse) {
                this.update()
            }
            this.place();
            m(window).on("resize", m.proxy(this.place, this));
            if (a) {
                a.stopPropagation();
                a.preventDefault()
            }
            this.isVisible = true;
            this.element.trigger({
                type: "show",
                date: this.date
            })
        },
        hide: function (a) {
            if (!this.isVisible) {
                return
            }
            if (this.isInline) {
                return
            }
            this.picker.hide();
            m(window).off("resize", this.place);
            this.viewMode = this.startViewMode;
            this.showMode();
            if (!this.isInput) {
                m(document).off("mousedown", this.hide)
            }
            if (this.forceParse && (this.isInput && this.element.val() || this.hasInput && this.element.find("input").val())) {
                this.setValue()
            }
            this.isVisible = false;
            this.element.trigger({
                type: "hide",
                date: this.date
            })
        },
        remove: function () {
            this._detachEvents();
            this.picker.remove();
            delete this.picker;
            delete this.element.data().datetimepicker
        },
        getDate: function () {
            var a = this.getUTCDate();
            return new Date(a.getTime() + (a.getTimezoneOffset() * 60000))
        },
        getUTCDate: function () {
            return this.date
        },
        setDate: function (a) {
            this.setUTCDate(new Date(a.getTime() - (a.getTimezoneOffset() * 60000)))
        },
        setUTCDate: function (a) {
            if (a >= this.startDate && a <= this.endDate) {
                this.date = a;
                this.setValue();
                this.viewDate = this.date;
                this.fill()
            } else {
                this.element.trigger({
                    type: "outOfRange",
                    date: a,
                    startDate: this.startDate,
                    endDate: this.endDate
                })
            }
        },
        setFormat: function (a) {
            this.format = n.parseFormat(a, this.formatType);
            var b;
            if (this.isInput) {
                b = this.element
            } else {
                if (this.component) {
                    b = this.element.find("input")
                }
            }
            if (b && b.val()) {
                this.setValue()
            }
        },
        setValue: function () {
            var a = this.getFormattedDate();
            if (!this.isInput) {
                if (this.component) {
                    this.element.find("input").val(a)
                }
                this.element.data("date", a)
            } else {
                this.element.val(a)
            }
            if (this.linkField) {
                m("#" + this.linkField).val(this.getFormattedDate(this.linkFormat))
            }
        },
        getFormattedDate: function (a) {
            if (a == undefined) {
                a = this.format
            }
            return n.formatDate(this.date, a, this.language, this.formatType)
        },
        setStartDate: function (a) {
            console.log(this.format);
            this.startDate = a || -Infinity;
            if (this.startDate !== -Infinity) {
                this.startDate = n.parseDate(this.startDate, this.format, this.language, this.formatType)
            }
            this.update();
            this.updateNavArrows()
        },
        setEndDate: function (a) {
            this.endDate = a || Infinity;
            if (this.endDate !== Infinity) {
                this.endDate = n.parseDate(this.endDate, this.format, this.language, this.formatType)
            }
            this.update();
            this.updateNavArrows()
        },
        setDaysOfWeekDisabled: function (a) {
            this.daysOfWeekDisabled = a || [];
            if (!m.isArray(this.daysOfWeekDisabled)) {
                this.daysOfWeekDisabled = this.daysOfWeekDisabled.split(/,\s*/)
            }
            this.daysOfWeekDisabled = m.map(this.daysOfWeekDisabled,
            function (b) {
                return parseInt(b, 10)
            });
            this.update();
            this.updateNavArrows()
        },
        setMinutesDisabled: function (a) {
            this.minutesDisabled = a || [];
            if (!m.isArray(this.minutesDisabled)) {
                this.minutesDisabled = this.minutesDisabled.split(/,\s*/)
            }
            this.minutesDisabled = m.map(this.minutesDisabled,
            function (b) {
                return parseInt(b, 10)
            });
            this.update();
            this.updateNavArrows()
        },
        setHoursDisabled: function (a) {
            this.hoursDisabled = a || [];
            if (!m.isArray(this.hoursDisabled)) {
                this.hoursDisabled = this.hoursDisabled.split(/,\s*/)
            }
            this.hoursDisabled = m.map(this.hoursDisabled,
            function (b) {
                return parseInt(b, 10)
            });
            this.update();
            this.updateNavArrows()
        },
        place: function () {
            if (this.isInline) {
                return
            }
            if (!this.zIndex) {
                var e = 0;
                m("div").each(function () {
                    var f = parseInt(m(this).css("zIndex"), 10);
                    if (f > e) {
                        e = f
                    }
                });
                this.zIndex = e + 10
            }
            var a, b, c, d;
            if (this.container instanceof m) {
                d = this.container.offset()
            } else {
                d = m(this.container).offset()
            }
            if (this.component) {
                a = this.component.offset();
                c = a.left;
                if (this.pickerPosition == "bottom-left" || this.pickerPosition == "top-left") {
                    c += this.component.outerWidth() - this.picker.outerWidth()
                }
            } else {
                a = this.element.offset();
                c = a.left
            }
            if (c + 220 > document.body.clientWidth) {
                c = document.body.clientWidth - 220
            }
            if (this.pickerPosition == "top-left" || this.pickerPosition == "top-right") {
                b = a.top - this.picker.outerHeight()
            } else {
                b = a.top + this.height
            }
            b = b - d.top;
            c = c - d.left - 40;
            
            this.picker.css({
                top: b,
                left: c,
                zIndex: this.zIndex
            })
        },
        update: function () {
            var b, a = false;
            if (arguments && arguments.length && (typeof arguments[0] === "string" || arguments[0] instanceof Date)) {
                b = arguments[0];
                a = true
            } else {
                b = (this.isInput ? this.element.val() : this.element.find("input").val()) || this.element.data("date") || this.initialDate;
                if (typeof b == "string" || b instanceof String) {
                    b = b.replace(/^\s+|\s+$/g, "")
                }
            }
            if (!b) {
                b = new Date();
                a = false
            }
            this.date = n.parseDate(b, this.format, this.language, this.formatType);
            if (a) {
                this.setValue()
            }
            if (this.date < this.startDate) {
                this.viewDate = new Date(this.startDate)
            } else {
                if (this.date > this.endDate) {
                    this.viewDate = new Date(this.endDate)
                } else {
                    this.viewDate = new Date(this.date)
                }
            }
            this.fill()
        },
        fillDow: function () {
            var b = this.weekStart,
            a = "<tr>";
            while (b < this.weekStart + 7) {
                a += '<th class="dow">' + l[this.language].daysMin[(b++) % 7] + "</th>"
            }
            a += "</tr>";
            this.picker.find(".datetimepicker-days thead").append(a)
        },
        fillMonths: function () {
            var a = "",
            b = 0;
            while (b < 12) {
                a += '<span class="month">' + l[this.language].monthsShort[b++] + "</span>"
            }
            this.picker.find(".datetimepicker-months td").html(a)
        },
        fill: function () {
            if (this.date == null || this.viewDate == null) {
                return
            }
            var N = new Date(this.viewDate),
            R = N.getUTCFullYear(),
            L = N.getUTCMonth(),
            aa = N.getUTCDate(),
            U = N.getUTCHours(),
            g = N.getUTCMinutes(),
            e = this.startDate !== -Infinity ? this.startDate.getUTCFullYear() : -Infinity,
            T = this.startDate !== -Infinity ? this.startDate.getUTCMonth() + 1 : -Infinity,
            Y = this.endDate !== Infinity ? this.endDate.getUTCFullYear() : Infinity,
            c = this.endDate !== Infinity ? this.endDate.getUTCMonth() + 1 : Infinity,
            X = (new j(this.date.getUTCFullYear(), this.date.getUTCMonth(), this.date.getUTCDate())).valueOf(),
            P = new Date();
            this.picker.find(".datetimepicker-days thead th:eq(1)").text(l[this.language].months[L] + " " + R);
            if (this.formatViewType == "time") {
                var ad = this.getFormattedDate();
                this.picker.find(".datetimepicker-hours thead th:eq(1)").text(ad);
                this.picker.find(".datetimepicker-minutes thead th:eq(1)").text(ad)
            } else {
                this.picker.find(".datetimepicker-hours thead th:eq(1)").text(aa + " " + l[this.language].months[L] + " " + R);
                this.picker.find(".datetimepicker-minutes thead th:eq(1)").text(aa + " " + l[this.language].months[L] + " " + R)
            }
            this.picker.find("tfoot th.today").text(l[this.language].today).toggle(this.todayBtn !== false);
            this.updateNavArrows();
            this.fillMonths();
            var d = j(R, L - 1, 28, 0, 0, 0, 0),
            W = n.getDaysInMonth(d.getUTCFullYear(), d.getUTCMonth());
            d.setUTCDate(W);
            d.setUTCDate(W - (d.getUTCDay() - this.weekStart + 7) % 7);
            var ae = new Date(d);
            ae.setUTCDate(ae.getUTCDate() + 42);
            ae = ae.valueOf();
            var V = [];
            var O;
            while (d.valueOf() < ae) {
                if (d.getUTCDay() == this.weekStart) {
                    V.push("<tr>")
                }
                O = "";
                if (d.getUTCFullYear() < R || (d.getUTCFullYear() == R && d.getUTCMonth() < L)) {
                    O += " old"
                } else {
                    if (d.getUTCFullYear() > R || (d.getUTCFullYear() == R && d.getUTCMonth() > L)) {
                        O += " new"
                    }
                }
                if (this.todayHighlight && d.getUTCFullYear() == P.getFullYear() && d.getUTCMonth() == P.getMonth() && d.getUTCDate() == P.getDate()) {
                    O += " today"
                }
                if (d.valueOf() == X) {
                    O += " active"
                }
                if ((d.valueOf() + 86400000) <= this.startDate || d.valueOf() > this.endDate || m.inArray(d.getUTCDay(), this.daysOfWeekDisabled) !== -1) {
                    O += " disabled"
                }
                V.push('<td class="day' + O + '">' + d.getUTCDate() + "</td>");
                if (d.getUTCDay() == this.weekEnd) {
                    V.push("</tr>")
                }
                d.setUTCDate(d.getUTCDate() + 1)
            }
            this.picker.find(".datetimepicker-days tbody").empty().append(V.join(""));
            V = [];
            var M = "",
            Q = "",
            S = "";
            var ac = this.hoursDisabled || [];
            for (var a = 0; a < 24; a++) {
                if (ac.indexOf(a) !== -1) {
                    continue
                }
                var K = j(R, L, aa, a);
                O = "";
                if ((K.valueOf() + 3600000) <= this.startDate || K.valueOf() > this.endDate) {
                    O += " disabled"
                } else {
                    if (U == a) {
                        O += " active"
                    }
                }
                if (this.showMeridian && l[this.language].meridiem.length == 2) {
                    Q = (a < 12 ? l[this.language].meridiem[0] : l[this.language].meridiem[1]);
                    if (Q != S) {
                        if (S != "") {
                            V.push("</fieldset>")
                        }
                        V.push('<fieldset class="hour"><legend>' + Q.toUpperCase() + "</legend>")
                    }
                    S = Q;
                    M = (a % 12 ? a % 12 : 12);
                    V.push('<span class="hour' + O + " hour_" + (a < 12 ? "am" : "pm") + '">' + M + "</span>");
                    if (a == 23) {
                        V.push("</fieldset>")
                    }
                } else {
                    M = a + ":00";
                    V.push('<span class="hour' + O + '">' + M + "</span>")
                }
            }
            this.picker.find(".datetimepicker-hours td").html(V.join(""));
            V = [];
            M = "",
            Q = "",
            S = "";
            var ab = this.minutesDisabled || [];
            for (var a = 0; a < 60; a += this.minuteStep) {
                if (ab.indexOf(a) !== -1) {
                    continue
                }
                var K = j(R, L, aa, U, a, 0);
                O = "";
                if (K.valueOf() < this.startDate || K.valueOf() > this.endDate) {
                    O += " disabled"
                } else {
                    if (Math.floor(g / this.minuteStep) == Math.floor(a / this.minuteStep)) {
                        O += " active"
                    }
                }
                if (this.showMeridian && l[this.language].meridiem.length == 2) {
                    Q = (U < 12 ? l[this.language].meridiem[0] : l[this.language].meridiem[1]);
                    if (Q != S) {
                        if (S != "") {
                            V.push("</fieldset>")
                        }
                        V.push('<fieldset class="minute"><legend>' + Q.toUpperCase() + "</legend>")
                    }
                    S = Q;
                    M = (U % 12 ? U % 12 : 12);
                    V.push('<span class="minute' + O + '">' + M + ":" + (a < 10 ? "0" + a : a) + "</span>");
                    if (a == 59) {
                        V.push("</fieldset>")
                    }
                } else {
                    M = a + ":00";
                    V.push('<span class="minute' + O + '">' + U + ":" + (a < 10 ? "0" + a : a) + "</span>")
                }
            }
            this.picker.find(".datetimepicker-minutes td").html(V.join(""));
            var b = this.date.getUTCFullYear();
            var Z = this.picker.find(".datetimepicker-months").find("th:eq(1)").text(R).end().find("span").removeClass("active");
            if (b == R) {
                Z.eq(this.date.getUTCMonth() + 2).addClass("active")
            }
            if (R < e || R > Y) {
                Z.addClass("disabled")
            }
            if (R == e) {
                Z.slice(0, T + 1).addClass("disabled")
            }
            if (R == Y) {
                Z.slice(c).addClass("disabled")
            }
            V = "";
            R = parseInt(R / 10, 10) * 10;
            var f = this.picker.find(".datetimepicker-years").find("th:eq(1)").text(R + "-" + (R + 9)).end().find("td");
            R -= 1;
            for (var a = -1; a < 11; a++) {
                V += '<span class="year' + (a == -1 || a == 10 ? " old" : "") + (b == R ? " active" : "") + (R < e || R > Y ? " disabled" : "") + '">' + R + "</span>";
                R += 1
            }
            f.html(V);
            this.place()
        },
        updateNavArrows: function () {
            var a = new Date(this.viewDate),
            c = a.getUTCFullYear(),
            b = a.getUTCMonth(),
            d = a.getUTCDate(),
            e = a.getUTCHours();
            switch (this.viewMode) {
                case 0:
                    if (this.startDate !== -Infinity && c <= this.startDate.getUTCFullYear() && b <= this.startDate.getUTCMonth() && d <= this.startDate.getUTCDate() && e <= this.startDate.getUTCHours()) {
                        this.picker.find(".prev").css({
                            visibility: "hidden"
                        })
                    } else {
                        this.picker.find(".prev").css({
                            visibility: "visible"
                        })
                    }
                    if (this.endDate !== Infinity && c >= this.endDate.getUTCFullYear() && b >= this.endDate.getUTCMonth() && d >= this.endDate.getUTCDate() && e >= this.endDate.getUTCHours()) {
                        this.picker.find(".next").css({
                            visibility: "hidden"
                        })
                    } else {
                        this.picker.find(".next").css({
                            visibility: "visible"
                        })
                    }
                    break;
                case 1:
                    if (this.startDate !== -Infinity && c <= this.startDate.getUTCFullYear() && b <= this.startDate.getUTCMonth() && d <= this.startDate.getUTCDate()) {
                        this.picker.find(".prev").css({
                            visibility: "hidden"
                        })
                    } else {
                        this.picker.find(".prev").css({
                            visibility: "visible"
                        })
                    }
                    if (this.endDate !== Infinity && c >= this.endDate.getUTCFullYear() && b >= this.endDate.getUTCMonth() && d >= this.endDate.getUTCDate()) {
                        this.picker.find(".next").css({
                            visibility: "hidden"
                        })
                    } else {
                        this.picker.find(".next").css({
                            visibility: "visible"
                        })
                    }
                    break;
                case 2:
                    if (this.startDate !== -Infinity && c <= this.startDate.getUTCFullYear() && b <= this.startDate.getUTCMonth()) {
                        this.picker.find(".prev").css({
                            visibility: "hidden"
                        })
                    } else {
                        this.picker.find(".prev").css({
                            visibility: "visible"
                        })
                    }
                    if (this.endDate !== Infinity && c >= this.endDate.getUTCFullYear() && b >= this.endDate.getUTCMonth()) {
                        this.picker.find(".next").css({
                            visibility: "hidden"
                        })
                    } else {
                        this.picker.find(".next").css({
                            visibility: "visible"
                        })
                    }
                    break;
                case 3:
                case 4:
                    if (this.startDate !== -Infinity && c <= this.startDate.getUTCFullYear()) {
                        this.picker.find(".prev").css({
                            visibility: "hidden"
                        })
                    } else {
                        this.picker.find(".prev").css({
                            visibility: "visible"
                        })
                    }
                    if (this.endDate !== Infinity && c >= this.endDate.getUTCFullYear()) {
                        this.picker.find(".next").css({
                            visibility: "hidden"
                        })
                    } else {
                        this.picker.find(".next").css({
                            visibility: "visible"
                        })
                    }
                    break
            }
        },
        mousewheel: function (c) {
            c.preventDefault();
            c.stopPropagation();
            if (this.wheelPause) {
                return
            }
            this.wheelPause = true;
            var d = c.originalEvent;
            var a = d.wheelDelta;
            var b = a > 0 ? 1 : (a === 0) ? 0 : -1;
            if (this.wheelViewModeNavigationInverseDirection) {
                b = -b
            }
            this.showMode(b);
            setTimeout(m.proxy(function () {
                this.wheelPause = false
            },
            this), this.wheelViewModeNavigationDelay)
        },
        click: function (g) {
            g.stopPropagation();
            g.preventDefault();
            var f = m(g.target).closest("span, td, th, legend");
            if (f.is("." + this.icontype)) {
                f = m(f).parent().closest("span, td, th, legend")
            }
            if (f.length == 1) {
                if (f.is(".disabled")) {
                    this.element.trigger({
                        type: "outOfRange",
                        date: this.viewDate,
                        startDate: this.startDate,
                        endDate: this.endDate
                    });
                    return
                }
                switch (f[0].nodeName.toLowerCase()) {
                    case "th":
                        switch (f[0].className) {
                            case "switch":
                                this.showMode(1);
                                break;
                            case "prev":
                            case "next":
                                var v = n.modes[this.viewMode].navStep * (f[0].className == "prev" ? -1 : 1);
                                switch (this.viewMode) {
                                    case 0:
                                        this.viewDate = this.moveHour(this.viewDate, v);
                                        break;
                                    case 1:
                                        this.viewDate = this.moveDate(this.viewDate, v);
                                        break;
                                    case 2:
                                        this.viewDate = this.moveMonth(this.viewDate, v);
                                        break;
                                    case 3:
                                    case 4:
                                        this.viewDate = this.moveYear(this.viewDate, v);
                                        break
                                }
                                this.fill();
                                this.element.trigger({
                                    type: f[0].className + ":" + this.convertViewModeText(this.viewMode),
                                    date: this.viewDate,
                                    startDate: this.startDate,
                                    endDate: this.endDate
                                });
                                break;
                            case "today":
                                var u = new Date();
                                u = j(u.getFullYear(), u.getMonth(), u.getDate(), 0, 0, 0, 0);
                                if (u < this.startDate) {
                                    u = this.startDate
                                } else {
                                    if (u > this.endDate) {
                                        u = this.endDate
                                    }
                                }
                                this.viewMode = this.startViewMode;
                                this.showMode(0);
                                this._setDate(u);
                                this.fill();
                                if (this.autoclose) {
                                    this.hide()
                                }
                                break
                        }
                        break;
                    case "span":
                        if (!f.is(".disabled")) {
                            var d = this.viewDate.getUTCFullYear(),
                            e = this.viewDate.getUTCMonth(),
                            c = this.viewDate.getUTCDate(),
                            b = this.viewDate.getUTCHours(),
                            t = this.viewDate.getUTCMinutes(),
                            a = this.viewDate.getUTCSeconds();
                            if (f.is(".month")) {
                                this.viewDate.setUTCDate(1);
                                e = f.parent().find("span").index(f);
                                c = this.viewDate.getUTCDate();
                                this.viewDate.setUTCMonth(e);
                                this.element.trigger({
                                    type: "changeMonth",
                                    date: this.viewDate
                                });
                                if (this.viewSelect >= 3) {
                                    this._setDate(j(d, e, c, b, t, a, 0))
                                }
                            } else {
                                if (f.is(".year")) {
                                    this.viewDate.setUTCDate(1);
                                    d = parseInt(f.text(), 10) || 0;
                                    this.viewDate.setUTCFullYear(d);
                                    this.element.trigger({
                                        type: "changeYear",
                                        date: this.viewDate
                                    });
                                    if (this.viewSelect >= 4) {
                                        this._setDate(j(d, e, c, b, t, a, 0))
                                    }
                                } else {
                                    if (f.is(".hour")) {
                                        b = parseInt(f.text(), 10) || 0;
                                        if (f.hasClass("hour_am") || f.hasClass("hour_pm")) {
                                            if (b == 12 && f.hasClass("hour_am")) {
                                                b = 0
                                            } else {
                                                if (b != 12 && f.hasClass("hour_pm")) {
                                                    b += 12
                                                }
                                            }
                                        }
                                        this.viewDate.setUTCHours(b);
                                        this.element.trigger({
                                            type: "changeHour",
                                            date: this.viewDate
                                        });
                                        if (this.viewSelect >= 1) {
                                            this._setDate(j(d, e, c, b, t, a, 0))
                                        }
                                    } else {
                                        if (f.is(".minute")) {
                                            t = parseInt(f.text().substr(f.text().indexOf(":") + 1), 10) || 0;
                                            this.viewDate.setUTCMinutes(t);
                                            this.element.trigger({
                                                type: "changeMinute",
                                                date: this.viewDate
                                            });
                                            if (this.viewSelect >= 0) {
                                                this._setDate(j(d, e, c, b, t, a, 0))
                                            }
                                        }
                                    }
                                }
                            }
                            if (this.viewMode != 0) {
                                var s = this.viewMode;
                                this.showMode(-1);
                                this.fill();
                                if (s == this.viewMode && this.autoclose) {
                                    this.hide()
                                }
                            } else {
                                this.fill();
                                if (this.autoclose) {
                                    this.hide()
                                }
                            }
                        }
                        break;
                    case "td":
                        if (f.is(".day") && !f.is(".disabled")) {
                            var c = parseInt(f.text(), 10) || 1;
                            var d = this.viewDate.getUTCFullYear(),
                            e = this.viewDate.getUTCMonth();
                            if (f.is(".old")) {
                                if (e === 0) {
                                    e = 11;
                                    d -= 1
                                } else {
                                    e -= 1
                                }
                            } else {
                                if (f.is(".new")) {
                                    if (e == 11) {
                                        e = 0;
                                        d += 1
                                    } else {
                                        e += 1
                                    }
                                }
                            }
                            this._setDate(j(d, e, c, 0, 0, 0, 0));
                            this.hide()
                        }
                        break
                }
            }
        },
        _setDate: function (c, a) {
            if (!a || a == "date") {
                this.date = c
            }
            if (!a || a == "view") {
                this.viewDate = c
            }
            this.fill();
            this.setValue();
            var b;
            if (this.isInput) {
                b = this.element
            } else {
                if (this.component) {
                    b = this.element.find("input")
                }
            }
            if (b) {
                b.change();
                if (this.autoclose && (!a || a == "date")) { }
            }
            this.element.trigger({
                type: "changeDate",
                date: this.date
            })
        },
        moveMinute: function (b, c) {
            if (!c) {
                return b
            }
            var a = new Date(b.valueOf());
            a.setUTCMinutes(a.getUTCMinutes() + (c * this.minuteStep));
            return a
        },
        moveHour: function (b, c) {
            if (!c) {
                return b
            }
            var a = new Date(b.valueOf());
            a.setUTCHours(a.getUTCHours() + c);
            return a
        },
        moveDate: function (b, c) {
            if (!c) {
                return b
            }
            var a = new Date(b.valueOf());
            a.setUTCDate(a.getUTCDate() + c);
            return a
        },
        moveMonth: function (s, r) {
            if (!r) {
                return s
            }
            var e = new Date(s.valueOf()),
            a = e.getUTCDate(),
            d = e.getUTCMonth(),
            f = Math.abs(r),
            b,
            c;
            r = r > 0 ? 1 : -1;
            if (f == 1) {
                c = r == -1 ?
                function () {
                    return e.getUTCMonth() == d
                } : function () {
                    return e.getUTCMonth() != b
                };
                b = d + r;
                e.setUTCMonth(b);
                if (b < 0 || b > 11) {
                    b = (b + 12) % 12
                }
            } else {
                for (var g = 0; g < f; g++) {
                    e = this.moveMonth(e, r)
                }
                b = e.getUTCMonth();
                e.setUTCDate(a);
                c = function () {
                    return b != e.getUTCMonth()
                }
            }
            while (c()) {
                e.setUTCDate(--a);
                e.setUTCMonth(b)
            }
            return e
        },
        moveYear: function (a, b) {
            return this.moveMonth(a, b * 12)
        },
        dateWithinRange: function (a) {
            return a >= this.startDate && a <= this.endDate
        },
        keydown: function (e) {
            if (this.picker.is(":not(:visible)")) {
                if (e.keyCode == 27) {
                    this.show()
                }
                return
            }
            var c = false,
            q, b, d, a, r;
            switch (e.keyCode) {
                case 27:
                    this.hide();
                    e.preventDefault();
                    break;
                case 37:
                case 39:
                    if (!this.keyboardNavigation) {
                        break
                    }
                    q = e.keyCode == 37 ? -1 : 1;
                    viewMode = this.viewMode;
                    if (e.ctrlKey) {
                        viewMode += 2
                    } else {
                        if (e.shiftKey) {
                            viewMode += 1
                        }
                    }
                    if (viewMode == 4) {
                        a = this.moveYear(this.date, q);
                        r = this.moveYear(this.viewDate, q)
                    } else {
                        if (viewMode == 3) {
                            a = this.moveMonth(this.date, q);
                            r = this.moveMonth(this.viewDate, q)
                        } else {
                            if (viewMode == 2) {
                                a = this.moveDate(this.date, q);
                                r = this.moveDate(this.viewDate, q)
                            } else {
                                if (viewMode == 1) {
                                    a = this.moveHour(this.date, q);
                                    r = this.moveHour(this.viewDate, q)
                                } else {
                                    if (viewMode == 0) {
                                        a = this.moveMinute(this.date, q);
                                        r = this.moveMinute(this.viewDate, q)
                                    }
                                }
                            }
                        }
                    }
                    if (this.dateWithinRange(a)) {
                        this.date = a;
                        this.viewDate = r;
                        this.setValue();
                        this.update();
                        e.preventDefault();
                        c = true
                    }
                    break;
                case 38:
                case 40:
                    if (!this.keyboardNavigation) {
                        break
                    }
                    q = e.keyCode == 38 ? -1 : 1;
                    viewMode = this.viewMode;
                    if (e.ctrlKey) {
                        viewMode += 2
                    } else {
                        if (e.shiftKey) {
                            viewMode += 1
                        }
                    }
                    if (viewMode == 4) {
                        a = this.moveYear(this.date, q);
                        r = this.moveYear(this.viewDate, q)
                    } else {
                        if (viewMode == 3) {
                            a = this.moveMonth(this.date, q);
                            r = this.moveMonth(this.viewDate, q)
                        } else {
                            if (viewMode == 2) {
                                a = this.moveDate(this.date, q * 7);
                                r = this.moveDate(this.viewDate, q * 7)
                            } else {
                                if (viewMode == 1) {
                                    if (this.showMeridian) {
                                        a = this.moveHour(this.date, q * 6);
                                        r = this.moveHour(this.viewDate, q * 6)
                                    } else {
                                        a = this.moveHour(this.date, q * 4);
                                        r = this.moveHour(this.viewDate, q * 4)
                                    }
                                } else {
                                    if (viewMode == 0) {
                                        a = this.moveMinute(this.date, q * 4);
                                        r = this.moveMinute(this.viewDate, q * 4)
                                    }
                                }
                            }
                        }
                    }
                    if (this.dateWithinRange(a)) {
                        this.date = a;
                        this.viewDate = r;
                        this.setValue();
                        this.update();
                        e.preventDefault();
                        c = true
                    }
                    break;
                case 13:
                    if (this.viewMode != 0) {
                        var f = this.viewMode;
                        this.showMode(-1);
                        this.fill();
                        if (f == this.viewMode && this.autoclose) {
                            this.hide()
                        }
                    } else {
                        this.fill();
                        if (this.autoclose) {
                            this.hide()
                        }
                    }
                    e.preventDefault();
                    break;
                case 9:
                    this.hide();
                    break
            }
            if (c) {
                var g;
                if (this.isInput) {
                    g = this.element
                } else {
                    if (this.component) {
                        g = this.element.find("input")
                    }
                }
                if (g) {
                    g.change()
                }
                this.element.trigger({
                    type: "changeDate",
                    date: this.date
                })
            }
        },
        showMode: function (b) {
            if (b) {
                var a = Math.max(0, Math.min(n.modes.length - 1, this.viewMode + b));
                if (a >= this.minView && a <= this.maxView) {
                    this.element.trigger({
                        type: "changeMode",
                        date: this.viewDate,
                        oldViewMode: this.viewMode,
                        newViewMode: a
                    });
                    this.viewMode = a
                }
            }
            this.picker.find(">div").hide().filter(".datetimepicker-" + n.modes[this.viewMode].clsName).css("display", "block");
            this.updateNavArrows()
        },
        reset: function (a) {
            this._setDate(null, "date")
        },
        convertViewModeText: function (a) {
            switch (a) {
                case 4:
                    return "decade";
                case 3:
                    return "year";
                case 2:
                    return "month";
                case 1:
                    return "day";
                case 0:
                    return "hour"
            }
        }
    };
    var i = m.fn.datetimepicker;
    m.fn.datetimepicker = function (a) {
        var c = Array.apply(null, arguments);
        c.shift();
        var b;
        this.each(function () {
            var d = m(this),
            e = d.data("datetimepicker"),
            f = typeof a == "object" && a;
            if (!e) {
                d.data("datetimepicker", (e = new k(this, m.extend({},
                m.fn.datetimepicker.defaults, f))))
            }
            if (typeof a == "string" && typeof e[a] == "function") {
                b = e[a].apply(e, c);
                if (b !== undefined) {
                    return false
                }
            }
        });
        if (b !== undefined) {
            return b
        } else {
            return this
        }
    };
    m.fn.datetimepicker.defaults = {};
    m.fn.datetimepicker.Constructor = k;
    var l = m.fn.datetimepicker.dates = {
        en: {
            days: ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期天"],
            daysShort: ["日", "一", "二", "三", "四", "五", "六", "日"],
            daysMin: ["日", "一", "二", "三", "四", "五", "六", "日"],
            months: ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"],
            monthsShort: ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"],
            meridiem: ["am", "pm"],
            suffix: ["st", "nd", "rd", "th"],
            today: "Today"
        }
    };
    var n = {
        modes: [{
            clsName: "minutes",
            navFnc: "Hours",
            navStep: 1
        },
        {
            clsName: "hours",
            navFnc: "Date",
            navStep: 1
        },
        {
            clsName: "days",
            navFnc: "Month",
            navStep: 1
        },
        {
            clsName: "months",
            navFnc: "FullYear",
            navStep: 1
        },
        {
            clsName: "years",
            navFnc: "FullYear",
            navStep: 10
        }],
        isLeapYear: function (a) {
            return (((a % 4 === 0) && (a % 100 !== 0)) || (a % 400 === 0))
        },
        getDaysInMonth: function (b, a) {
            return [31, (n.isLeapYear(b) ? 29 : 28), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31][a]
        },
        getDefaultFormat: function (b, a) {
            if (b == "standard") {
                if (a == "input") {
                    return "yyyy-mm-dd"
                } else {
                    return "yyyy-mm-dd"
                }
            } else {
                if (b == "php") {
                    if (a == "input") {
                        return "Y-m-d H:i"
                    } else {
                        return "Y-m-d H:i:s"
                    }
                } else {
                    throw new Error("Invalid format type.")
                }
            }
        },
        validParts: function (a) {
            if (a == "standard") {
                return /hh?|HH?|p|P|ii?|ss?|dd?|DD?|mm?|MM?|yy(?:yy)?/g
            } else {
                if (a == "php") {
                    return /[dDjlNwzFmMnStyYaABgGhHis]/g
                } else {
                    throw new Error("Invalid format type.")
                }
            }
        },
        nonpunctuation: /[^ -\/:-@\[-`{-~\t\n\rTZ]+/g,
        parseFormat: function (a, c) {
            var d = a.replace(this.validParts(c), "\0").split("\0"),
            b = a.match(this.validParts(c));
            if (!d || !d.length || !b || b.length == 0) {
                throw new Error("Invalid date format.")
            }
            return {
                separators: d,
                parts: b
            }
        },
        parseDate: function (f, G, c, I) {
            if (f instanceof Date) {
                var E = new Date(f.valueOf() - f.getTimezoneOffset() * 60000);
                E.setMilliseconds(0);
                return E
            }
            if (typeof format === "string") {
                G = DPGlobal.parseFormat("yyyy-mm-dd")
            }
            if (/^\d{4}\-\d{1,2}\-\d{1,2}$/.test(f)) {
                G = this.parseFormat("yyyy-mm-dd", I)
            }
            if (/^\d{4}\-\d{1,2}\-\d{1,2}[T ]\d{1,2}\:\d{1,2}$/.test(f)) {
                G = this.parseFormat("yyyy-mm-dd hh:ii", I)
            }
            if (/^\d{4}\-\d{1,2}\-\d{1,2}[T ]\d{1,2}\:\d{1,2}\:\d{1,2}[Z]{0,1}$/.test(f)) {
                G = this.parseFormat("yyyy-mm-dd hh:ii:ss", I)
            }
            if (/^[-+]\d+[dmwy]([\s,]+[-+]\d+[dmwy])*$/.test(f)) {
                var D = /([-+]\d+)([dmwy])/,
                e = f.match(/([-+]\d+)([dmwy])/g),
                B,
                g;
                f = new Date();
                for (var d = 0; d < e.length; d++) {
                    B = D.exec(e[d]);
                    g = parseInt(B[1]);
                    switch (B[2]) {
                        case "d":
                            f.setUTCDate(f.getUTCDate() + g);
                            break;
                        case "m":
                            f = k.prototype.moveMonth.call(k.prototype, f, g);
                            break;
                        case "w":
                            f.setUTCDate(f.getUTCDate() + g * 7);
                            break;
                        case "y":
                            f = k.prototype.moveYear.call(k.prototype, f, g);
                            break
                    }
                }
                return j(f.getUTCFullYear(), f.getUTCMonth(), f.getUTCDate(), f.getUTCHours(), f.getUTCMinutes(), f.getUTCSeconds(), 0)
            }
            var e = f && f.toString().match(this.nonpunctuation) || [],
            f = new Date(0, 0, 0, 0, 0, 0, 0),
            a = {},
            H = ["hh", "h", "ii", "i", "ss", "s", "yyyy", "yy", "M", "MM", "m", "mm", "D", "DD", "d", "dd", "H", "HH", "p", "P"],
            F = {
                hh: function (p, o) {
                    return p.setUTCHours(o)
                },
                h: function (p, o) {
                    return p.setUTCHours(o)
                },
                HH: function (p, o) {
                    return p.setUTCHours(o == 12 ? 0 : o)
                },
                H: function (p, o) {
                    return p.setUTCHours(o == 12 ? 0 : o)
                },
                ii: function (p, o) {
                    return p.setUTCMinutes(o)
                },
                i: function (p, o) {
                    return p.setUTCMinutes(o)
                },
                ss: function (p, o) {
                    return p.setUTCSeconds(o)
                },
                s: function (p, o) {
                    return p.setUTCSeconds(o)
                },
                yyyy: function (p, o) {
                    return p.setUTCFullYear(o)
                },
                yy: function (p, o) {
                    return p.setUTCFullYear(2000 + o)
                },
                m: function (p, o) {
                    o -= 1;
                    while (o < 0) {
                        o += 12
                    }
                    o %= 12;
                    p.setUTCMonth(o);
                    while (p.getUTCMonth() != o) {
                        if (isNaN(p.getUTCMonth())) {
                            return p
                        } else {
                            p.setUTCDate(p.getUTCDate() - 1)
                        }
                    }
                    return p
                },
                d: function (p, o) {
                    return p.setUTCDate(o)
                },
                p: function (p, o) {
                    return p.setUTCHours(o == 1 ? p.getUTCHours() + 12 : p.getUTCHours())
                }
            },
            s,
            b,
            B;
            F.M = F.MM = F.mm = F.m;
            F.dd = F.d;
            F.P = F.p;
            f = j(f.getFullYear(), f.getMonth(), f.getDate(), f.getHours(), f.getMinutes(), f.getSeconds());
            if (e.length == G.parts.length) {
                for (var d = 0,
                A = G.parts.length; d < A; d++) {
                    s = parseInt(e[d], 10);
                    B = G.parts[d];
                    if (isNaN(s)) {
                        switch (B) {
                            case "MM":
                                b = m(l[c].months).filter(function () {
                                    var o = this.slice(0, e[d].length),
                                    p = e[d].slice(0, o.length);
                                    return o == p
                                });
                                s = m.inArray(b[0], l[c].months) + 1;
                                break;
                            case "M":
                                b = m(l[c].monthsShort).filter(function () {
                                    var o = this.slice(0, e[d].length),
                                    p = e[d].slice(0, o.length);
                                    return o.toLowerCase() == p.toLowerCase()
                                });
                                s = m.inArray(b[0], l[c].monthsShort) + 1;
                                break;
                            case "p":
                            case "P":
                                s = m.inArray(e[d].toLowerCase(), l[c].meridiem);
                                break
                        }
                    }
                    a[B] = s
                }
                for (var d = 0,
                C; d < H.length; d++) {
                    C = H[d];
                    if (C in a && !isNaN(a[C])) {
                        F[C](f, a[C])
                    }
                }
            }
            return f
        },
        formatDate: function (e, q, f, b) {
            if (e == null) {
                return ""
            }
            var g;
            if (b == "standard") {
                g = {
                    yy: e.getUTCFullYear().toString().substring(2),
                    yyyy: e.getUTCFullYear(),
                    m: e.getUTCMonth() + 1,
                    M: l[f].monthsShort[e.getUTCMonth()],
                    MM: l[f].months[e.getUTCMonth()],
                    d: e.getUTCDate(),
                    D: l[f].daysShort[e.getUTCDay()],
                    DD: l[f].days[e.getUTCDay()],
                    p: (l[f].meridiem.length == 2 ? l[f].meridiem[e.getUTCHours() < 12 ? 0 : 1] : ""),
                    h: e.getUTCHours(),
                    i: e.getUTCMinutes(),
                    s: e.getUTCSeconds()
                };
                if (l[f].meridiem.length == 2) {
                    g.H = (g.h % 12 == 0 ? 12 : g.h % 12)
                } else {
                    g.H = g.h
                }
                g.HH = (g.H < 10 ? "0" : "") + g.H;
                g.P = g.p.toUpperCase();
                g.hh = (g.h < 10 ? "0" : "") + g.h;
                g.ii = (g.i < 10 ? "0" : "") + g.i;
                g.ss = (g.s < 10 ? "0" : "") + g.s;
                g.dd = (g.d < 10 ? "0" : "") + g.d;
                g.mm = (g.m < 10 ? "0" : "") + g.m
            } else {
                if (b == "php") {
                    g = {
                        y: e.getUTCFullYear().toString().substring(2),
                        Y: e.getUTCFullYear(),
                        F: l[f].months[e.getUTCMonth()],
                        M: l[f].monthsShort[e.getUTCMonth()],
                        n: e.getUTCMonth() + 1,
                        t: n.getDaysInMonth(e.getUTCFullYear(), e.getUTCMonth()),
                        j: e.getUTCDate(),
                        l: l[f].days[e.getUTCDay()],
                        D: l[f].daysShort[e.getUTCDay()],
                        w: e.getUTCDay(),
                        N: (e.getUTCDay() == 0 ? 7 : e.getUTCDay()),
                        S: (e.getUTCDate() % 10 <= l[f].suffix.length ? l[f].suffix[e.getUTCDate() % 10 - 1] : ""),
                        a: (l[f].meridiem.length == 2 ? l[f].meridiem[e.getUTCHours() < 12 ? 0 : 1] : ""),
                        g: (e.getUTCHours() % 12 == 0 ? 12 : e.getUTCHours() % 12),
                        G: e.getUTCHours(),
                        i: e.getUTCMinutes(),
                        s: e.getUTCSeconds()
                    };
                    g.m = (g.n < 10 ? "0" : "") + g.n;
                    g.d = (g.j < 10 ? "0" : "") + g.j;
                    g.A = g.a.toString().toUpperCase();
                    g.h = (g.g < 10 ? "0" : "") + g.g;
                    g.H = (g.G < 10 ? "0" : "") + g.G;
                    g.i = (g.i < 10 ? "0" : "") + g.i;
                    g.s = (g.s < 10 ? "0" : "") + g.s
                } else {
                    throw new Error("Invalid format type.")
                }
            }
            var e = [],
            a = m.extend([], q.separators);
            for (var c = 0,
            d = q.parts.length; c < d; c++) {
                if (a.length) {
                    e.push(a.shift())
                }
                e.push(g[q.parts[c]])
            }
            if (a.length) {
                e.push(a.shift())
            }
            return e.join("")
        },
        convertViewMode: function (a) {
            switch (a) {
                case 4:
                case "decade":
                    a = 4;
                    break;
                case 3:
                case "year":
                    a = 3;
                    break;
                case 2:
                case "month":
                    a = 2;
                    break;
                case 1:
                case "day":
                    a = 1;
                    break;
                case 0:
                case "hour":
                    a = 0;
                    break
            }
            return a
        },
        headTemplate: '<thead><tr><th class="prev"><i class="{leftArrow}"/></th><th colspan="5" class="switch"></th><th class="next"><i class="{rightArrow}"/></th></tr></thead>',
        headTemplateV3: '<thead><tr><th class="prev"><span class="{iconType} {leftArrow}"></span> </th><th colspan="5" class="switch"></th><th class="next"><span class="{iconType} {rightArrow}"></span> </th></tr></thead>',
        contTemplate: '<tbody><tr><td colspan="7"></td></tr></tbody>',
        footTemplate: '<tfoot><tr><th colspan="7" class="today"></th></tr></tfoot>'
    };
    n.template = '<div class="datetimepicker"><div class="datetimepicker-minutes"><table class=" table-condensed">' + n.headTemplate + n.contTemplate + n.footTemplate + '</table></div><div class="datetimepicker-hours"><table class=" table-condensed">' + n.headTemplate + n.contTemplate + n.footTemplate + '</table></div><div class="datetimepicker-days"><table class=" table-condensed">' + n.headTemplate + "<tbody></tbody>" + n.footTemplate + '</table></div><div class="datetimepicker-months"><table class="table-condensed">' + n.headTemplate + n.contTemplate + n.footTemplate + '</table></div><div class="datetimepicker-years"><table class="table-condensed">' + n.headTemplate + n.contTemplate + n.footTemplate + "</table></div></div>";
    n.templateV3 = '<div class="datetimepicker"><div class="datetimepicker-minutes"><table class=" table-condensed">' + n.headTemplateV3 + n.contTemplate + n.footTemplate + '</table></div><div class="datetimepicker-hours"><table class=" table-condensed">' + n.headTemplateV3 + n.contTemplate + n.footTemplate + '</table></div><div class="datetimepicker-days"><table class=" table-condensed">' + n.headTemplateV3 + "<tbody></tbody>" + n.footTemplate + '</table></div><div class="datetimepicker-months"><table class="table-condensed">' + n.headTemplateV3 + n.contTemplate + n.footTemplate + '</table></div><div class="datetimepicker-years"><table class="table-condensed">' + n.headTemplateV3 + n.contTemplate + n.footTemplate + "</table></div></div>";
    m.fn.datetimepicker.DPGlobal = n;
    m.fn.datetimepicker.noConflict = function () {
        m.fn.datetimepicker = i;
        return this
    };
    m(document).on("focus.datetimepicker.data-api click.datetimepicker.data-api", '[data-provide="datetimepicker"]',
    function (a) {
        var b = m(this);
        if (b.data("datetimepicker")) {
            return
        }
        a.preventDefault();
        b.datetimepicker("show")
    });
    m(function () {
        m('[data-provide="datetimepicker-inline"]').datetimepicker()
    })
}(window.jQuery);
function closes(a) {
    $("#" + a + "").val("")
};