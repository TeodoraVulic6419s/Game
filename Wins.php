<?php
$servername = "localhost";
$user = "root";
$password = "";
$dbname = "RVAS_Projekat1";

// Create connection
$conn = new mysqli($servername, $user, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
  }

$username = $_POST["username"];

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
} 

$sql = "UPDATE users SET wins = wins+1 WHERE username = '". $username ."'" ;

//Ubacujemo username i password u bazu

if($conn->query($sql) === TRUE )
{
    echo "REGISTRACIJA USPESNA!";
}
else
{
    echo "nije";
}


?>