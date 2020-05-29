#LIDAR-app

For running the final version of the application, just run LIDAR-app.exe shortcut

The commands it sends to the arduino are of the form _._
where the first _ can be either "Azimuth" (which means the base motor) or "Elevation" (which means the sensor motor). 
The second _ is the int value of the angle (in degrees, int!) that the chosen motor needs to achieve.

The data it should receive is just ints for the distance. It is assumed that the motors will "obey" the commands given by the app and 
that just the distance data is necessary. I don't know yet what the best units are, but I will let you see that on the Arduino side :D 
