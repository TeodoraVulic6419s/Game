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
echo "Connected successfully";

$sql = "SELECT user_id, username, wins, losses FROM users";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    echo "<br>id: " . $row["user_id"]. " - Username: " . $row["username"]. " Wins: " . $row["wins"]. " Losses: " . $row["losses"];
  }
} else {
  echo "0 results";
}
$conn->close();

?>