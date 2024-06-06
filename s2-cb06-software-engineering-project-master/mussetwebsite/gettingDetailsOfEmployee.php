<?php
if (!isset($_SESSION)) {
    session_start();
  }

function getDetailsOfEmployeeById($id){
    try{
        
        $conn = new PDO("mysql:host=studmysql01.fhict.local;dbname=dbi432295", 'dbi432295','qwerty');
        $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        $sql = "SELECT `Id`,`Email`,`PhoneN`,`Address` FROM extrainfo WHERE Id= :id LIMIT 1";
        $sth = $conn->prepare($sql);
        $sth->execute([':id'=>$id]);
        $result = $sth->fetch();
        $_SESSION['id'] = $result[0];
        return $result;
        
        
    }
      
    catch(PDOException $e) {
            echo $e->getMessage();
        }
    
}


?>