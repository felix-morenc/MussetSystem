<?php
if (!isset($_SESSION)) {
    session_start();
  }

include 'gettingDetailsOfEmployee.php';
$employee = getDetailsOfEmployeeById($_SESSION['id']);

$content = <<<EOT
<form id="UpdateEmployeeDetailsForm">
<p>Email:</p>
<input type= "email" name = "email" id="email" value="{$employee['Email']}"><br>
<p>Phone number:</p><br>
<input type = "text" id="phoneNumber" name = "phoneNumber" id="phoneNumber" value="{$employee['PhoneN']}">
<p>Address:</p><br>
<input type ="text" id= "address" name = "address" id="address" value="{$employee['Address']}"><br>

<button id = "updateEmpDetailsBtn">Update</button>

</form>

EOT
?>