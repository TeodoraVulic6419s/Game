<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "RVAS_Projekat1";

//Promenljive koje korisnik salje
$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
} 

$sql = "SELECT username,password FROM users WHERE username = '" . $loginUser . "'";

$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    if($row["password"] == $loginPass){
        echo "0";
        echo $loginUser . " " . $loginPass;
    }
    //Uzimamo podatke od usera


    //Menjamo mu podatke

    else{
        echo "Wrong Password";
    }
}
}
else {
  echo "Username doesn't exist";
}
$conn->close();



?>