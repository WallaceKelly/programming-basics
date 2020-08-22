<html>

<head>
    <title>The PHP Movie List</title>
</head>

<body>
    <h1>The PHP Movie List</h1>


    <?php
        $servername = "198.71.225.54:3306";
        $dbname = "wekelly3_phpdemo";
        $username = "phpdemo";
        $password = "bd!0u96A";
        $movies = array();

        // Create connection
        $conn = new mysqli($servername, $username, $password, $dbname);
        if ($conn->connect_error) {
            die("Connection failed: " . $conn->connect_error);
        }

        $sql = "SELECT MovieId, Movie FROM Movies";
        $result = $conn->query($sql);

        if (mysqli_num_rows($result) > 0) {
            while($row = mysqli_fetch_assoc($result)) {
                array_push($movies, $row["Movie"]);
            }
        }
        mysqli_close($conn);

        ?>

    <ul>
    <?php
        foreach ($movies as $movie) {
            echo "\t<li>$movie</li>\n";
        };
    ?>
    </ul>
    <!-- <ul>
        <li>Raiders of the Lost Ark</li>
        <li>The Return of the Jedi</li>
        <li>ET: The Extra-Terrestrial</li>
    </ul> -->

    <?php
        echo "Today is " . date("l");
    ?>

</body>

</html>