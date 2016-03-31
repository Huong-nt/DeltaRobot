#include <math.h>
#include "stepper.h"



//Setup message bytes
byte inputByte_0;
byte inputByte_1;
byte inputByte_2;
byte inputByte_3;
byte inputByte_4;
byte inputByte_5;
byte inputByte_6;
byte inputByte_7;
byte inputByte_8;
byte inputByte_9;
byte inputByte_10;
byte inputByte_11;

unsigned long time;
unsigned long count;

void setup(){
  Serial.begin(9600);

  pinMode(stepPin_0,OUTPUT); 
  pinMode(dirPin_0,OUTPUT);
  pinMode(stepPin_1,OUTPUT); 
  pinMode(dirPin_1,OUTPUT);
  pinMode(stepPin_2,OUTPUT); 
  pinMode(dirPin_2,OUTPUT);
  
}

void loop(){
  //Read Buffer
  if (Serial.available() == 12) 
  {
    //Read buffer
    inputByte_0 = Serial.read();
    delay(10);    
    inputByte_1 = Serial.read();
    delay(10);      
    inputByte_2 = Serial.read();
    delay(10);      
    inputByte_3 = Serial.read();
    delay(10);
    inputByte_4 = Serial.read();
    delay(10);
    inputByte_5 = Serial.read();  
    delay(10);
    inputByte_6 = Serial.read();  
    delay(10);
    inputByte_7 = Serial.read();  
    delay(10);
    inputByte_8 = Serial.read();  
    delay(10);
    inputByte_9 = Serial.read();  
    delay(10);
    inputByte_10 = Serial.read();  
    delay(10);
    inputByte_11 = Serial.read();  
    delay(10);
  }
  //Check for start of Message
  if(inputByte_0 == 16)
  {    
       int numSteps = 0; 
       //Detect Command type
       switch (inputByte_1)
       {
          case 128:
            //Say hello
            Serial.print("HELLO FROM ARDUINO");
            break;
          case 130:
            //Control stepper motor
            steppers[0].dir = inputByte_2;
            steppers[0].numSteps = inputByte_3 * 256 + inputByte_4;
            steppers[1].dir = inputByte_5;
            steppers[1].numSteps = inputByte_6 * 256 + inputByte_7;
            steppers[2].dir = inputByte_8;
            steppers[2].numSteps = inputByte_9 * 256 + inputByte_10;
            move_steppers();
            Serial.print("Done move stepper");
            break;
          case 131:
            //Calibration
            calibrate();
            Serial.print("Calibration completed");
            break;
          case 127:
             //Set PIN and value
             switch (inputByte_2)
            {
              case 9:
                //analogWrite(ledPin_9, inputByte_3);
//                if(inputByte_3 == 255)
//                {
//                  digitalWrite(ledPin_3, HIGH); 
//                  break;
//                }
              break;
            } 
            break;
          case 129:
            //Get PIN value;
            switch(inputByte_2) 
            {
              case 10:
              case 11:
              case 12:
                break;
            }
            break;
        } 
        //Clear Message bytes
        inputByte_0 = 0;
        inputByte_1 = 0;
        inputByte_2 = 0;
        inputByte_3 = 0;
        inputByte_4 = 0;
        inputByte_5 = 0;
        inputByte_6 = 0;
        inputByte_6 = 0;
        inputByte_7 = 0;
        inputByte_8 = 0;
        inputByte_9 = 0;
        inputByte_10 = 0;
        inputByte_11 = 0;
        //Let the PC know we are ready for more data
        Serial.print("--READY TO RECEIVE--");
  }
}
//--------------------------------------------------------------------
//----------------------------Control stepper-------------------------
int move_steppers() 
{
  count = 0;
  bool  status_0 = LOW, status_1 = LOW, status_2 = LOW;
  int periodic[3];
  
  //Set direction for each stepper
  digitalWrite(dirPin_0, steppers[0].dir);
  digitalWrite(dirPin_1, steppers[1].dir);
  digitalWrite(dirPin_2, steppers[2].dir);
  //Set periodic for each stepper
  int maxSteps = getMaxSteps(steppers[0], steppers[1], steppers[2]);
  for(int j = 0; j < 3; j++) {
    periodic[j] = round(maxSteps * 100 / steppers[j].numSteps);
  }
  
  while(1) {
    count++;
    //time = micros();
    //Stepper 1st
    if(steppers[0].numSteps > 0 && count%periodic[0] == 0) {
      if(status_0== LOW)
        digitalWrite(stepPin_0,HIGH);
      else 
        digitalWrite(stepPin_0,LOW);
      status_0 = !status_0;
      steppers[0].numSteps--;
    }
    //Stepper 2nd
    if(steppers[1].numSteps > 0 && count%periodic[1] == 0) {
      if(status_1 == LOW)
        digitalWrite(stepPin_1,HIGH);
      else 
        digitalWrite(stepPin_1,LOW);
      status_1 = !status_1;
      steppers[1].numSteps--;
    }
    //Stepper 3rd
    if(steppers[2].numSteps > 0 && count%periodic[2] == 0) {
      if(status_2 == LOW)
        digitalWrite(stepPin_2,HIGH);
      else 
        digitalWrite(stepPin_2,LOW);
      status_2 = !status_2;
      steppers[2].numSteps--;
    }
    if(steppers[1].numSteps <=0 && steppers[1].numSteps <= 0  && steppers[1].numSteps <= 0)
      break;
    delayMicroseconds(10);
  }
  resetVariable();
  return 1;
}

int resetVariable() 
{
  for(int i = 0; i < 3; i++) 
  {
    steppers[i].dir = 0;
    steppers[i].numSteps = 0;    
  }
}

int getMaxSteps(stepper a, stepper b, stepper c)
{
  if(a.numSteps >= b.numSteps) {
    if(a.numSteps >= c.numSteps)
      return a.numSteps;
    else 
      return c.numSteps;  
  } else {
    if(b.numSteps >= c.numSteps)
      return b.numSteps;
    else 
      return c.numSteps;
  }
}
//--------------------------------------------------------------------
//-----------------------------Calibration----------------------------
void calibrate() {
    int value[3];
    value[0] = analogRead(A0);
    value[1] = analogRead(A1);
    value[2] = analogRead(A2);
    for(int i = 0; i < 3; i++) {
      steppers[i] = getStatusStepperByPotentiometterValue(value[i]);
    }
    move_steppers();
    
    //check status of stepper
    boolean pass = true;
    value[0] = analogRead(A0);
    value[1] = analogRead(A1);
    value[2] = analogRead(A2);
    for(int i = 0; i < 3; i++) {
      if(abs(value[0] - STEPPER_STEP_ZERO) > 5) {
        pass = false;
      }
    }
    if(!pass) {
      calibrate();
    }
}

stepper getStatusStepperByPotentiometterValue(int value) {
  stepper tmp;
  if(value > STEPPER_STEP_ZERO)
    tmp.dir = STEPPER_UP;
  else
    tmp.dir = STEPPER_DN;
  float angle = abs(value - STEPPER_STEP_ZERO)*300/1024;
  tmp.numSteps = round(angle/STEPPER_STEP_SIZE);
  return tmp;
}
//--------------------------------------------------------------------
