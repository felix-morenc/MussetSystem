$("#loginbtn").click(function(){
let username = $("#username").val();
let password = $("#password").val();
if(username == ""){
    alert("Please fill the username box!");
    event.preventDefault();
    return false;
}
if(password == ""){
    alert("Please fill the password box");
    event.preventDefault();
    return false;
}
event.preventDefault();
$.ajax({

    type: "POST",
    url: "login.php",
    data:  "username="+username+"&password="+password,
    success: function(d) {
        if(d == "succsess"){
        alert(d);
        window.location.href = "index.php?page=shifts";   }
        else if(d == "password is wrong"){
                alert("password is wrong!");
        }
        else{
            alert("this username doesnt exists!");
        }

  }


  });

 
});