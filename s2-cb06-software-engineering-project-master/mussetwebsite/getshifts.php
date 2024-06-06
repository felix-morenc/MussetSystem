<?php
if (!isset($_SESSION)) {
    session_start();
  }
try{
    $id =$_SESSION['id'];
    $conn = new PDO("mysql:host=studmysql01.fhict.local;dbname=dbi432295", 'dbi432295','qwerty');
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    $sql = "SELECT `Shift`,`Date` FROM shifts WHERE Id= :id";
    $sth = $conn->prepare($sql);
    $sth->execute([':id'=>$id]);
    $result = $sth->fetchAll();
    echo '<table>';
    echo '<tr><th>Date</th><th>Shift</th></tr>';
    foreach($result as $row){
        echo '<tr>';
        echo'<td>'.$row['Date'].'</td>';
        echo'<td>'.$row['Shift'].'</td>';
        echo '</tr>';
        
    }
    echo '</table>';
}
  
catch(PDOException $e) {
        echo $e->getMessage();
    }


?>