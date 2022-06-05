<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "RVAS_Projekat1";

//Promenljive koje korisnik salje
$RegUser = $_POST["RegUser"];
$RegPass = $_POST["RegPass"];
$RegConfirm = $_POST["RegConfirm"]; 

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
} 

$sql = "SELECT username FROM users WHERE username = '" . $RegUser . "'";


$result = $conn->query($sql);

if ($result->num_rows > 0) {
  //Obavestavamo korisnika da je username zauzet
  echo "Username vec postoji";

}
elseif($RegPass!=$RegConfirm)
{
    echo "Sifra nije ista";
}
else {
  //Ubacujemo username i password u bazu
  $sql2 = "INSERT INTO users (username,password) VALUES ('" . $RegUser . "' ,'" . $RegPass . "')";
    if($conn->query($sql2) === TRUE )
    {
        echo "REGISTRACIJA USPESNA!";
    }
    else
    {
        echo "Error" .$sql2. "<br>" . $conn->error;
    }
 
}
$conn->close();

?>