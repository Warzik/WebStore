var trafficChart = null;
var usersTypeChart = null;
var productsSoldChart = null;
var productsByCategoryChart = null;
var productsBySupplierChart = null;

window.Body = {
    ChangeWishesAndOrders: function (userID)
    {
        DotNet.invokeMethodAsync('WebStore.WebApplication', 'ChangeWishesAndOrdersInHomePage', userID);
    },
    Overflow: function (set) {
        //if (window.innerWidth <= 768) {
            if(!set)
                document.body.className = 'modal-open';
            else
                document.body.className = '';
        //}
    },
    FooterGrowContent: function (measuringWrapper) {
        var growDiv = document.getElementById(measuringWrapper+'-content');
        if (growDiv.clientHeight) {
            growDiv.style.height = 0;
        } else {
            var wrapper = document.querySelector('.' + measuringWrapper +'-measuring-wrapper');
            growDiv.style.height = wrapper.clientHeight + "px";
        }
    },
    SignalRReconnect: function () {
        window.Blazor.reconnect();
    },
    SignalRReload: function () {
        location.reload();
    },
    ScrollToTop: function() {
        var target = document.getElementById("scroll-here");
        var speed = window.pageYOffset / 10;
        var isChrome = !!window.chrome && (!!window.chrome.webstore || !!window.chrome.runtime);
        var isSmoothScrollSupported = 'scrollBehavior' in document.documentElement.style;
        if (isChrome && isSmoothScrollSupported) speed = 0;
        animate(document.scrollingElement || document.documentElement, "scrollTop", "", window.pageYOffset, target.offsetTop, speed, true);
    },
    ToggleDropDown: function (dropDownName) {
        let show = document.getElementsByClassName(dropDownName)[0];
        if (show !== undefined)
            show.classList.toggle("show");
    },
    ShowChartLoader: function (chartName)
    {
        let show = document.getElementsByClassName(chartName)[0];
        if (show !== undefined)
            show.style.display = "block";
    },
    HideChartLoader: function (chartName) {
        let hide = document.getElementsByClassName(chartName)[0];
        if (hide !== undefined)
            hide.style.display = "none";
    },
    SaveAs: function (filename, bytesBase64)
    {
            var link = document.createElement('a');
            link.download = filename;
            link.href = "data:application/octet-stream;base64," + bytesBase64;
            document.body.appendChild(link); // Needed for Firefox
            link.click();
            document.body.removeChild(link);
        
    },

    DrawLineChart: function (days, traffic) {

        if (trafficChart !== null) {
            trafficChart.destroy();
        }

            trafficChart = new Chart(document.getElementById("trafficChart"), {
            type: 'line',
            lineTension: 0.3,
            backgroundColor: "rgba(78, 115, 223, 0.05)",
            borderColor: "rgba(78, 115, 223, 1)",
            pointRadius: 3,
            pointBackgroundColor: "rgba(78, 115, 223, 1)",
            pointBorderColor: "rgba(78, 115, 223, 1)",
            pointHoverRadius: 3,
            pointHoverBackgroundColor: "rgba(78, 115, 223, 1)",
            pointHoverBorderColor: "rgba(78, 115, 223, 1)",
            pointHitRadius: 10,
            pointBorderWidth: 2,
            data: {
                labels: days,
                datasets: [
                    {
                        data: traffic,
                        label: "Visitors",
                        borderColor: "#3e95cd",
                        fill: true
                    }
                ]
            },
            options: {
                maintainAspectRatio: false,
                layout: {
                    padding: {
                        left: 10,
                        right: 25,
                        top: 25,
                        bottom: 0
                    }
                },
                scales: {
                    xAxes: [{
                        time: {
                            unit: 'date'
                        },
                        gridLines: {
                            display: false,
                            drawBorder: false
                        },
                        ticks: {
                            maxTicksLimit: 7
                        }
                    }],
                    yAxes: [{
                        ticks: {
                            maxTicksLimit: 5,
                            padding: 10,
                            callback: function (value, index, values) {
                                return  number_format(value);
                            }
                        },
                        gridLines: {
                            color: "rgb(234, 236, 244)",
                            zeroLineColor: "rgb(234, 236, 244)",
                            drawBorder: false,
                            borderDash: [2],
                            zeroLineBorderDash: [2]
                        }
                    }],
                },
                tooltips: {
                    backgroundColor: "rgb(255,255,255)",
                    bodyFontColor: "#858796",
                    titleMarginBottom: 10,
                    titleFontColor: '#6e707e',
                    titleFontSize: 14,
                    borderColor: '#dddfeb',
                    borderWidth: 1,
                    xPadding: 15,
                    yPadding: 15,
                    displayColors: false,
                    intersect: false,
                    mode: 'index',
                    caretPadding: 10,
                    callbacks: {
                        label: function (tooltipItem, chart) {
                            var datasetLabel = chart.datasets[tooltipItem.datasetIndex].label || '';
                            return datasetLabel + ': ' + number_format(tooltipItem.yLabel);
                        }
                    }
                
                }, legend: {
                    display: false
                }
              
            }
            });

        Body.HideChartLoader("trafficChartLoader");
    },
    DrawDoughnutChart: function (newUsers, returningUsers, totalUsers)
    {
        if (usersTypeChart !== null) {
            usersTypeChart.destroy();
        }

        var newUsersPercent = (newUsers / totalUsers) * 100;
        var returningUsersPercent = (returningUsers / totalUsers) * 100;

         usersTypeChart = new Chart(document.getElementById("usersTypeChart"), {
            type: 'doughnut',
            data: {
                labels: ["New Users", "Returning Users"],
                datasets: [{
                    data: [newUsersPercent, returningUsersPercent],
                    backgroundColor: ['#4e73df', '#36b9cc' ],
                    hoverBackgroundColor: ['#2e59d9','#2c9faf' ],
                    hoverBorderColor: "rgba(234, 236, 244, 1)",
                }],
            },
            options: {
                maintainAspectRatio: false,
                tooltips: {
                    backgroundColor: "rgb(255,255,255)",
                    bodyFontColor: "#858796",
                    borderColor: '#dddfeb',
                    borderWidth: 1,
                    xPadding: 15,
                    yPadding: 15,
                    displayColors: false,
                    caretPadding: 10,
                    callbacks: {

                        label: function (tooltipItem, data) {
                            var dataLabel = data.labels[tooltipItem.index];
                            var value = ': '+ data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index].toLocaleString() + '%';
                            if (dataLabel === "New Users") {
                                value = ': ' + newUsers + ' (' + data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index].toLocaleString() + '%)';
                            } else if (dataLabel === "Returning Users")
                            {
                                value = ': ' + returningUsers + ' (' + data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index].toLocaleString() + '%)';
                            }

                            dataLabel += value;
                            return dataLabel;
                        }

                    }
                },
                legend: {
                    position: "bottom"
                },
                cutoutPercentage: 60,
            }
         });
        Body.HideChartLoader("usersTypeChartLoader");
    },
    DrawBarChart: function (dates,solds)
    {
        if (productsSoldChart !== null) {
            productsSoldChart.destroy();
        }

        productsSoldChart = new Chart(document.getElementById("productsSoldChart"), {
            type: 'bar',
            data: {
                labels: dates,
                datasets: [{
                    label: "Solds",
                    backgroundColor: "#4e73df",
                    hoverBackgroundColor: "#2e59d9",
                    borderColor: "#4e73df",
                    data: solds,
                }],
            },
            options: {
                maintainAspectRatio: false,
                layout: {
                    padding: {
                        left: 10,
                        right: 25,
                        top: 25,
                        bottom: 0
                    }
                },
                scales: {
                    xAxes: [{
                        time: {
                            unit: 'days'
                        },
                        gridLines: {
                            display: false,
                            drawBorder: false
                        },
                        ticks: {
                            maxTicksLimit: 25
                        },
                        maxBarThickness: 25,
                    }],
                    yAxes: [{
                        ticks: {
                            min: 0,
                            maxTicksLimit: 5,
                            padding: 10,
                            callback: function (value, index, values) {
                                return number_format(value);
                            }
                        },
                        gridLines: {
                            color: "rgb(234, 236, 244)",
                            zeroLineColor: "rgb(234, 236, 244)",
                            drawBorder: false,
                            borderDash: [2],
                            zeroLineBorderDash: [2]
                        }
                    }],
                },
                legend: {
                    display: false
                },
                tooltips: {
                    titleMarginBottom: 10,
                    titleFontColor: '#6e707e',
                    titleFontSize: 14,
                    backgroundColor: "rgb(255,255,255)",
                    bodyFontColor: "#858796",
                    borderColor: '#dddfeb',
                    borderWidth: 1,
                    xPadding: 15,
                    yPadding: 15,
                    displayColors: false,
                    caretPadding: 10,
                    callbacks: {
                        label: function (tooltipItem, chart) {
                            var datasetLabel = chart.datasets[tooltipItem.datasetIndex].label || '';
                            return datasetLabel + ': ' + number_format(tooltipItem.yLabel);
                        }
                    }
                },
            }
        });
        Body.HideChartLoader("productsSoldChartLoader");
    },
    DrawPolarChartForCategory: function (categories, solds, colors) {
        if (productsByCategoryChart !== null) {
            productsByCategoryChart.destroy();
        }

        productsByCategoryChart = new Chart(document.getElementById("productsByCategoryChart"), {
            type: 'polarArea',
            data: {
                labels: categories,
                datasets: [{
                    data: solds,
                    backgroundColor: colors,
                    hoverBorderColor: "rgba(234, 236, 244, 1)",
                }],
            },
            options: {
                maintainAspectRatio: false,
                tooltips: {
                    backgroundColor: "rgb(255,255,255)",
                    bodyFontColor: "#858796",
                    borderColor: '#dddfeb',
                    borderWidth: 1,
                    xPadding: 15,
                    yPadding: 15,
                    displayColors: false,
                    caretPadding: 10
                },
                legend: {
                    position: "bottom"

                },
            }
        });
        Body.HideChartLoader("productsByCategoryChartLoader");
    },
    DrawPolarChartForSupplier: function (suppliers,solds,colors) {
        if (productsBySupplierChart !== null) {
            productsBySupplierChart.destroy();
        }

        productsBySupplierChart = new Chart(document.getElementById("productsBySupplierChart"), {
            type: 'polarArea',
            data: {
                labels: suppliers,
                datasets: [{
                    data: solds,
                    backgroundColor: colors,
                    hoverBorderColor: "rgba(234, 236, 244, 1)",
                }],
            },
            options: {
                maintainAspectRatio: false,
                tooltips: {
                    backgroundColor: "rgb(255,255,255)",
                    bodyFontColor: "#858796",
                    borderColor: '#dddfeb',
                    borderWidth: 1,
                    xPadding: 15,
                    yPadding: 15,
                    displayColors: false,
                    caretPadding: 10,
                    //callbacks: {

                    //    label: function (tooltipItem, data) {
                    //        var dataLabel = data.labels[tooltipItem.index];
                    //        var value = ': ' + data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index].toLocaleString() + '%';
                    //        if (dataLabel === "New Users") {
                    //            value = ': ' + newUsers + ' (' + data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index].toLocaleString() + '%)';
                    //        } else if (dataLabel === "Returning Users") {
                    //            value = ': ' + returningUsers + ' (' + data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index].toLocaleString() + '%)';
                    //        }

                    //        dataLabel += value;
                    //        return dataLabel;
                    //    }

                    //}
                },
                legend: {
                    position: "bottom"

                },
            }
        });
        Body.HideChartLoader("productsBySupplierChartLoader");
    }
};

window.onclick = function (event) {
    if (!event.target.matches('.trafficCharDropownBtn')) {
        let trafficCharDropdowns = document.getElementsByClassName("trafficChartDropdown");
        if (trafficCharDropdowns[0] !== undefined)
        if (trafficCharDropdowns[0].classList.contains('show')) {
            trafficCharDropdowns[0].classList.remove('show');
        }
    }
    if (!event.target.matches('.usersTypeChartDropownBtn')) {
        let usersTypeCharDropdowns = document.getElementsByClassName("usersTypeChartDropdown");
        if (usersTypeCharDropdowns[0] !== undefined)
        if (usersTypeCharDropdowns[0].classList.contains('show')) {
            usersTypeCharDropdowns[0].classList.remove('show');
        }
    }
    if (!event.target.matches('.productsSoldChartDropownBtn')) {
        let productsSoldCharDropdowns = document.getElementsByClassName("productsSoldChartDropdown");
        if (productsSoldCharDropdowns[0] !== undefined)
        if (productsSoldCharDropdowns[0].classList.contains('show')) {
            productsSoldCharDropdowns[0].classList.remove('show');
        }
    }
    if (!event.target.matches('.productsByCategoryChartDropownBtn')) {
        let productsByCategoryCharDropdowns = document.getElementsByClassName("productsByCategoryChartDropdown");
        if (productsByCategoryCharDropdowns[0] !== undefined)
        if (productsByCategoryCharDropdowns[0].classList.contains('show')) {
            productsByCategoryCharDropdowns[0].classList.remove('show');
        }
    }
    if (!event.target.matches('.productsBySupplierChartDropownBtn')) {
        let productsBySupplierCharDropdowns = document.getElementsByClassName("productsBySupplierChartDropdown");
        if (productsBySupplierCharDropdowns[0] !== undefined)
        if (productsBySupplierCharDropdowns[0].classList.contains('show')) {
            productsBySupplierCharDropdowns[0].classList.remove('show');
        }
    }
};

function number_format(number, decimals, dec_point, thousands_sep) {
    // *     example: number_format(1234.56, 2, ',', ' ');
    // *     return: '1 234,56'
    number = (number + '').replace(',', '').replace(' ', '');
    var n = !isFinite(+number) ? 0 : +number,
        prec = !isFinite(+decimals) ? 0 : Math.abs(decimals),
        sep = (typeof thousands_sep === 'undefined') ? ',' : thousands_sep,
        dec = (typeof dec_point === 'undefined') ? '.' : dec_point,
        s = '',
        toFixedFix = function (n, prec) {
            var k = Math.pow(10, prec);
            return '' + Math.round(n * k) / k;
        };
    // Fix for IE parseFloat(0.55).toFixed(0) = 0;
    s = (prec ? toFixedFix(n, prec) : '' + Math.round(n)).split('.');
    if (s[0].length > 3) {
        s[0] = s[0].replace(/\B(?=(?:\d{3})+(?!\d))/g, sep);
    }
    if ((s[1] || '').length < prec) {
        s[1] = s[1] || '';
        s[1] += new Array(prec - s[1].length + 1).join('0');
    }
    return s.join(dec);
}

function animate(elem, style, unit, from, to, time, prop) {
    if (!elem) {
        return;
    }
    var start = new Date().getTime(),
        timer = setInterval(function () {
            var step = Math.min(1, (new Date().getTime() - start) / time);
            if (prop) {
                elem[style] = (from + step * (to - from))+unit;
            } else {
                elem.style[style] = (from + step * (to - from))+unit;
            }
            if (step === 1) {
                clearInterval(timer);
            }
        }, 25);
    if (prop) {
          elem[style] = from+unit;
    } else {
          elem.style[style] = from+unit;
    }
}


var navbar = document.getElementsByClassName("desk-tnav");

var scrollBtn = document.getElementsByClassName("scroll-to-top");


window.onscroll = function () {
    if (window.pageYOffset >= 20) {
        navbar[0].classList.add("sticky");
        scrollBtn[0].classList.add("show");
    } else {
        navbar[0].classList.remove("sticky");
        scrollBtn[0].classList.remove("show");
    }
};


