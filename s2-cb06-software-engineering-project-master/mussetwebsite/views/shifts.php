<?php
if (!isset($_SESSION)) {
    session_start();
  }
$content = <<<EOT
<button id = "shiftsbtn">My shifts</button>
<div id="responsecontainer" >

</div>

EOT

?>