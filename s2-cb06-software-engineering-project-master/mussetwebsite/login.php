<?php

$username = $_POST['username'];
$password = $_POST['password'];

try{
    $conn = new PDO("mysql:host=studmysql01.fhict.local;dbname=dbi432295", 'dbi432295','qwerty');
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

    $sql = "SELECT * FROM credentials WHERE Username=:username";
    $stmt = $conn->prepare($sql);
    $stmt->execute([':username'=>$username]);
  
    if ($stmt->rowCount() == 0) {
      echo "username is wrong";
      exit();
    }
  
    $sql = "SELECT * FROM credentials WHERE Username=:username AND Password= :password";
    $stmt = $conn->prepare($sql);
    $stmt->execute([':username'=>$username, 'password'=>$password]);
  
    if ($stmt->rowCount() == 0) {
      echo "password is wrong";
      exit();
     
    }
    if (!isset($_SESSION)) {
      ini_set('session.gc_maxlifetime',86400);
      session_start();
    }

    $result = $stmt->fetchAll();
    foreach($result as $row){
    $_SESSION['id'] = $row[0];
    }
    
    echo "succsess";
   
    $conn = null;

    
}catch(PDOException $e) {
    echo $e->getMessage();
}



?>