$("#shiftsbtn").click(function(){
                   
event.preventDefault();
        $.ajax({    //create an ajax request to display.php
          type: "GET",
          url: "getshifts.php",             
          dataType: "html",   //expect html to be returned                
          success: function(response){                    
             $("#responsecontainer").html(response); 
             
          }
        });
  
      
    });