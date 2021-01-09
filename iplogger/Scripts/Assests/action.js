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

//function table() { 
//    const new_div = '<div class="container-fluid"><table class="table table-borderless"><thead><tr><th scope="col">IP address</th><th scope="col">Browser</th><th scope="col">OS</th><th scope="col">Device Type</th><th scope="col">Time (IST)</th></tr></thead>';
//    debugger;
   

//}