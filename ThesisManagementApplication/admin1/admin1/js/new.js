

var x = 0;
function w3_close() {

    if (x == 0) {
        document.getElementById("mySidenav").style.display = "none";
        var elements = document.querySelectorAll('.main');
        for (var i = 0; i < elements.length; i++) {
            elements[i].style.width = 100 + "%";
            elements[i].style.marginLeft = 0 + "px";
        }
        ++x;
    }
    else {
        var elements = document.querySelectorAll('.main');
        for (var i = 0; i < elements.length; i++) {
            elements[i].style.width = "calc(100% - 225px)";
            elements[i].style.marginLeft = 225 + "px";
        }
        document.getElementById("mySidenav").style.display = "block";

        --x;
    }
}