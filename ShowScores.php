<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "RVAS_Projekat1";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
} 

$sql = "SELECT username,wins,losses FROM users";

$result = $conn->query($sql);

while ($row = mysqli_fetch_assoc($result)) 
{
        $data[] =  $row['username'] . " " . $row['wins'] . " " . $row['losses'];
    
   
}
echo json_encode(array($data));
?>