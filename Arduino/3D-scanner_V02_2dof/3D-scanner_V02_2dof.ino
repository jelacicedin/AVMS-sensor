/*
  Made by Erik (14.3.2020)

  2 DOF system for a 3D scanner 

  Equipement:
  - Arduino Nano
  - 2x (28BYJ-48 stepper motor with ULN2003 driver board)
  - VL53L0X distance sensor

  Based on:
  - Example sketch to control a 28BYJ-48 stepper motor with ULN2003 driver board and Arduino UNO. More info:
    https://www.makerguides.com/28byj-48-stepper-motor-arduino-tutorial/
  - example from Adafruit_VL53L0X.h library, with some explanation on:
    https://learn.adafruit.com/adafruit-vl53l0x-micro-lidar-distance-sensor-breakout/arduino-code
*/


/*
   Connections:

   ## VL53L0X distance sensor: ##
    Pins on VL53L0X to connect:
      VIN(5V), GND, SDA, SCL
    Arduino Nano side:
      SDA - A4
      SCL - A5

   ## 28BYJ-48 stepper motor ##
    Pins on ULN2003 driver board (for the Base motor):
      Pin 8 to IN1 on the ULN2003 driver
      Pin 9 to IN2 on the ULN2003 driver
      Pin 10 to IN3 on the ULN2003 driver
      Pin 11 to IN4 on the ULN2003 driver

    Pins on ULN2003 driver board (for the Arm motor):
      Pin 4 to IN1 on the ULN2003 driver
      Pin 5 to IN2 on the ULN2003 driver
      Pin 6 to IN3 on the ULN2003 driver
      Pin 7 to IN4 on the ULN2003 driver

*/

/*
    Functionality:
      -

*/




#include <Stepper.h>
#include "Adafruit_VL53L0X.h"


Adafruit_VL53L0X lox = Adafruit_VL53L0X();


// Define number of steps per rotation:
const int stepsPerRevolution = 2048;
const int stepsPerMovePhi = 10;
const int stepsPerMoveTheta = 10;

const int phiWindow = stepsPerRevolution / 3;
const int thetaWindow = 350;

int absStepsBase = 0;
int absStepsArm = stepsPerRevolution/4;

// Create stepper object called 'myStepper', note the pin order:
Stepper motor_base = Stepper(stepsPerRevolution, 8, 10, 9, 11);
Stepper motor_arm = Stepper(stepsPerRevolution, 4, 6, 5, 7);



void setup() {
  Serial.begin(115200);
  // wait until serial port opens for native USB devices
  while (! Serial) {
    delay(1);
  }

//  Serial.println(F("System setting up..."));
  if (!lox.begin()) {
    Serial.println(F("Failed to boot VL53L0X"));
    while (1);
  }


  // Set the speed to 5 rpm:
  char stepper_speed = 5;
  motor_base.setSpeed(stepper_speed);
  motor_arm.setSpeed(stepper_speed);


}


void loop() {
  
  if (Serial.read() == 'b') {
    // Scan (scanning procedure is blocking)

    // Move theta to starting position
    motor_arm.step(-thetaWindow/2);
    absStepsArm += -thetaWindow/2;

    for(int j = 0; j < thetaWindow/stepsPerMoveTheta; j++){
      
      for (int i = 0; i < (phiWindow / stepsPerMovePhi); i++) { // ######## (kjer si delil z 4 * stepsP..... - daj 4->2 da bo pol kroga
    
        VL53L0X_RangingMeasurementData_t measure;
        lox.rangingTest(&measure, false); // pass in 'true' to get debug data printout!
    
        
        if (measure.RangeStatus != 4) {  // phase failures have incorrect data
          Serial.print("s");
          Serial.print(measure.RangeMilliMeter);
          Serial.print("d"); 
          Serial.print(absStepsBase); Serial.print("p");
          Serial.print(absStepsArm); Serial.print("t");
          Serial.print('\n');
        } else {
          // Serial.print("2500");
          // No point to see
        }
        
    
        // Move phi
        motor_base.step(stepsPerMovePhi);
        absStepsBase += stepsPerMovePhi;
      }
//      delay(10);
      // Return phi to zero
      motor_base.step(-absStepsBase);
      absStepsBase += -absStepsBase;
//      delay(10);
      // Move theta
      motor_arm.step(stepsPerMoveTheta);
      absStepsArm += stepsPerMoveTheta;
      

    }
    
    // Scan is finished
    Serial.print("stop\n");
    
    // Return theta to start position
    motor_arm.step(stepsPerRevolution/4 - absStepsArm);
    absStepsArm += stepsPerRevolution/4 - absStepsArm;
  }

  
  
}
