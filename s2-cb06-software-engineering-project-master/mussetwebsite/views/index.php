<?php
if (!isset($_SESSION)) {
    session_start();
  }
$content = <<<EOT
<form>
<p>Username:</p>
<input type="text" id = "username"><br>
<p>Password:</p>
<input type="password" id = "password"><br>
<button type="submit" id = "loginbtn">Login</button>

</form>

EOT
?>