<?php
if (!isset($_SESSION)) {
    session_start();
  }
$content = '';
$supportedPages = [
    'index' => 'index.php',
    'shifts' => 'shifts.php',
    'modifyaccountdetails' => 'modifyaccountdetails.php',
    'logout'=>'logout.php'
];
if(isset($_GET['page']))
{
    $requestedPage = $_GET['page'];
}else
{
    $requestedPage = 'index';
}
if(array_key_exists($requestedPage, $supportedPages)){
    require "views/". $supportedPages[$requestedPage];
}
else{
    exit("This page is not supported!");
}

?>

<!DOCTYPE html>
<html>
<header>
<title>Musset</title>
</header>
<body>
<link rel="stylesheet" type="text/css" href="style.css">
<div>
<?php 
if(isset($_SESSION['id'])) {
    echo "<ul><li><a href="."index.php?page=modifyaccountdetails".">modifyaccountdetails</a></li>"."<li><а href="."index.php?page=logout".">Logout</a></li></ul>";
  }
?>
<img src="logodif.png" alt="">
</div>


   
    <?php echo $content; ?>
  
</body>

<footer>
    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script type="text/javascript" src="login.js"></script>
    <script type="text/javascript" src="getshifts.js"></script>
    <script type="text/javascript" src="updateEmployeeDetails.js"></script>

</footer>



</html>