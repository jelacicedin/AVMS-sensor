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
    Versions:
      - V03: non-blocking scanning (begin with 'startscan', stop with 'stopscan')
      - V04: Elevation and Azimuth control (arm and base), help

*/




#include <Stepper.h>
#include "Adafruit_VL53L0X.h"


Adafruit_VL53L0X lox = Adafruit_VL53L0X();


// Define number of steps per rotation:
const int stepsPerRevolution = 2048;
const int stepsPerMovePhi = 50;
const int stepsPerMoveTheta = 50;

const int phiWindow = stepsPerRevolution / 4;
const int thetaWindow = stepsPerRevolution / 8;

int absStepsBase = 0;
int absStepsArm = stepsPerRevolution/4;
bool scanActive = 0;
bool sendDistance = 0;
bool goHome = 0;

unsigned long targetStepsBase = absStepsBase; // unsigned long to not overflow degrees-to-steps computation
unsigned long targetStepsArm = absStepsArm;
bool targetingStepsActive = 0;

// Create stepper object called 'myStepper', note the pin order:
Stepper motor_base = Stepper(stepsPerRevolution, 8, 10, 9, 11);
Stepper motor_arm = Stepper(stepsPerRevolution, 4, 6, 5, 7);


// Scan "for loops" stuff:
// Loop a - outer loop (theta)
int i_a;
int loop_a_Max;
// Loop b - inner loop (phi)
int i_b;
int loop_b_Max;


// Serial communication:
bool printAll = 0; // To have all the messages printed

char incomingChar = 0;
int recievingNumber = 0;
const char incomingCommandMaxLength = 20;
char incomingCommand[incomingCommandMaxLength] = "";
int incomingCommandIndex = 0;






void setup() {
  Serial.begin(9600);
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

  // Initialize scanning loop:
  loop_a_Max = thetaWindow/stepsPerMoveTheta;
  loop_b_Max = phiWindow / stepsPerMovePhi;
  i_a = loop_a_Max;
  i_b = loop_b_Max;

}


void loop() {

  // Check serial
  while (Serial.available()) {
    incomingChar = Serial.read();
    
    if (incomingChar == '\n') {
// ###################################################
// ###
// ##   Execute the commands recieved over serial
// #


// Start or Stop the scan
    if (strcmp(incomingCommand, "stopscan") == 0 || strcmp(incomingCommand, "startscan") == 0) {
      // stop scan
      // stop foor loops
      i_a = loop_a_Max;
      i_b = loop_b_Max;
      // Do stuff that need to be done at stop:
      if (printAll) Serial.println("Stopping the scan.");
      // Return motors to start position
      // Return phi to zero
      motor_base.step(-absStepsBase);
      absStepsBase += -absStepsBase;
      // Return theta to start position
      motor_arm.step(stepsPerRevolution/4 - absStepsArm);
      absStepsArm += stepsPerRevolution/4 - absStepsArm;
      scanActive = 0;
      
      if (strcmp(incomingCommand, "startscan") == 0) {
        // begin scan
        // start foor loops
        i_a = 0;
        i_b = 0;
        // Do stuff that needs to be done at start:
        if (printAll) Serial.println(F("Begining the scan."));
        // Move theta to starting position
        motor_arm.step(-thetaWindow/2);
        absStepsArm += -thetaWindow/2;
        scanActive = 1;
      } 
    } else if (strcmp(incomingCommand, "Azimuth") == 0) {
      if (!scanActive) {
        targetStepsBase = recievingNumber*long(stepsPerRevolution)/360;
        if (printAll) {Serial.print(F("targetStepsBase = ")); Serial.println(targetStepsBase);}
        targetingStepsActive = 1;
      } else {
        if (printAll) Serial.println(F("Custom moves are ignored when scan is in progress.")) ;
      }
    } else if (strcmp(incomingCommand, "Elevation") == 0) {
      if (!scanActive) {
        targetStepsArm = (90-recievingNumber)*long(stepsPerRevolution)/360;
        if (printAll) {Serial.print(F("targetStepsArm = ")); Serial.println(targetStepsBase);}
        targetingStepsActive = 1;
      } else {
        if (printAll) Serial.println(F("Custom moves are ignored when scan is in progress."));
      }
    } else if (strcmp(incomingCommand, "homemotors") == 0) {
      goHome = 1;
    }
    
    
    
    
    else if (strcmp(incomingCommand, "printall") == 0) {
      printAll = recievingNumber;
      Serial.println(F("printAll toggled."));
    } else if (strcmp(incomingCommand, "help") == 0) {
      Serial.println(F("Available commands:"));
      Serial.println(F("startscan, stopscan"));
      Serial.println(F("Azimuth [deg], Elevation [deg]"));
      Serial.println(F("homemotors,"));

      Serial.println(F("printall [bool], help"));
    } else {
      if (printAll) Serial.println(F("Command ignored because it was not recognized."));
    }
    


// #
// ##   Execute the commands recieved over serial
// ###
// ###################################################
      // Reset recieving buffer variables
      recievingNumber = 0;
      incomingCommandIndex = 0;
      incomingCommand[0] = '\0';
    } else {
      // Continue reading the command
      if ( ('0' <= incomingChar) && (incomingChar <= '9')  ) {
        recievingNumber = recievingNumber*10 + (incomingChar - '0');
      } else if (incomingChar == ' ' || incomingChar == '.') {
        // Ignore those characters.
      } else {
        if (incomingCommandIndex + 1 < incomingCommandMaxLength) {
          incomingCommand[incomingCommandIndex++] = incomingChar;
          incomingCommand[incomingCommandIndex] = '\0';
        } else {
          if (printAll) Serial.println(F("Recieved command string too long."));
        }
      }
    }
  } // - end of serial while


// #########################################
// Move motors to home position (base 0, arm = stepsPerRevolution/4)

  if (goHome) {
    // Home base:

    // Home arm:
    motor_arm.step(-stepsPerRevolution/2); //It will bump into frame - cheap reference point
    motor_arm.step(61*long(stepsPerRevolution)/360); // Measured by hand (design specific)
    absStepsArm = stepsPerRevolution/4; //Now we know where the motor is

    goHome = 0;
  }







// #########################################
// Moving to targeted steps:
  if (targetingStepsActive) {
    if (!scanActive) {
      // Move phi to target position
      motor_base.step(targetStepsBase - absStepsBase);
      absStepsBase += targetStepsBase - absStepsBase;
  
      // Move theta to target position
      motor_arm.step(targetStepsArm - absStepsArm);
      absStepsArm += targetStepsArm - absStepsArm;

      // raise the flag to send the distance over serial
      sendDistance = 1;
      
      // Reset targeting
      targetingStepsActive = 0;

    } else {
      if (printAll) Serial.println(F("Custom moves are ignored when scan is in progress."));
    }
  }



// #########################################
  // Measure and send distance over serial
  if (sendDistance) {
    VL53L0X_RangingMeasurementData_t measure;
    lox.rangingTest(&measure, false); // pass in 'true' to get debug data printout!
    if (measure.RangeStatus != 4) {  // phase failures have incorrect data
      if (printAll) Serial.print(F("Measured range in mm = "));
      Serial.println(measure.RangeMilliMeter);
    } else {
      Serial.println(5000);
      if (printAll) Serial.println(F("distance out of range"));
    }
    sendDistance = 0;
  }
  
  
  
// ###################################################
// ###
// ##   Scanning procedure (non-blocking)
// #
  if (i_a < loop_a_Max) {
    // ### Start outer Loop: ### -------------------------
    if ( (i_b == 0) || (loop_b_Max <= i_b) ) {
      // do stuff before inner loop:
        // none (just inner loop initialization)
  
      // Inner loop initialization:
      i_b = 0;
    }
    
    // ### Inner Loop: ### -------------------------
    if (i_b < loop_b_Max) {
        // loop b:
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

        // Inner loop mechanics:
        i_b++;
    }

    // ### Continue outer loop: ### ----------------
    if (loop_b_Max <= i_b) {
      // Return phi to zero
      motor_base.step(-absStepsBase);
      absStepsBase += -absStepsBase;
      // Move theta
      motor_arm.step(stepsPerMoveTheta);
      absStepsArm += stepsPerMoveTheta;


      // Outer loop mechanics
      i_a++;

      // after the last outer loop iteration (finish scan)
      if (loop_a_Max <= i_a) {
        // Scan is finished
        Serial.print("stop\n");
        
        // Return theta to start position
        motor_arm.step(stepsPerRevolution/4 - absStepsArm);
        absStepsArm += stepsPerRevolution/4 - absStepsArm;
        scanActive = 0;
      }
    } // - end of part after inner loop
  } // - end of outer loop
// #
// ##   Scanning procedure
// ###
// ###################################################



}
