$("#updateEmpDetailsBtn").click(function(){
  
    

    let email = $('#email').val();
    let phoneN = $('#phoneNumber').val();
    let address = $('#address').val();
 

    
if (!(/^[a-zA-z\S]{1,}@{1,}[a-zA-Z\S]{1,}[.]{1}[a-zA-Z.]{1,}$/.test(email)))
  {
    alert("wrong email");
    event.preventDefault();
    return false;
  }
  else if(phoneN == ""){
      alert("please fill the phone number");
      event.preventDefault();
      return false;
  }
  else if(address == ""){
    alert("please fill the address");
    event.preventDefault();
    return false;
}
  else{
    event.preventDefault();
    $.ajax({

        type: "POST",
        url: "updateEmployeeDetails.php",
        data:  "email="+email+"&phoneN="+phoneN+"&address="+address,
        success: function(d) {
            alert(d);
            event.preventDefault();
    
      }
    
    
      });
      event.preventDefault();
  }

    });