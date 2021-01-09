function url() {
    var txtBox = document.getElementById("URL").value;
    //console.log(txtBox);
    //var obj = { data: txtBox }
    
    $.ajax({
        url: "/home/index?link=" + txtBox,
        type: "POST",
        success: function (data) {
            console.log(data);
            let a = data.dName;
            let b = data.trackingurl;
            
            document.getElementsByTagName("p")[0].innerHTML = "<br /><strong>Shortened URL:</strong>" + a;
            document.getElementsByTagName("p")[1].innerHTML = "<strong>Tracking URL :</strong>" + b;  
        },
        error: function (err) {

        }
    });

}
