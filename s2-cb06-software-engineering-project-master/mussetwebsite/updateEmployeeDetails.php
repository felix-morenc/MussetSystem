<?php
if (!isset($_SESSION)) {
    session_start();
  }
$email = $_POST['email'];
$phoneN = $_POST['phoneN'];
$address = $_POST['address'];
$id = $_SESSION['id'];

try{
        
    $conn = new PDO("mysql:host=studmysql01.fhict.local;dbname=dbi432295", 'dbi432295','qwerty');
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    $sql = "UPDATE `extrainfo` SET `Email`=:email,`PhoneN`=:phoneN,`Address`=:address WHERE `Id`=:id; ";
    $sth = $conn->prepare($sql);
    $sth->execute([':id'=>$id,':email'=>$email,':phoneN'=>$phoneN,':address'=>$address]);
    echo $sth->rowCount() . " records UPDATED successfully";
    
    
}
  
catch(PDOException $e) {
        echo $e->getMessage();
    }


?>