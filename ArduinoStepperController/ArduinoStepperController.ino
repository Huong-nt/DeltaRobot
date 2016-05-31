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
  lcd.begin(16, 2);
  lcd.print("Delta robot!");
  printLCD();
  pinMode(stepPin_0,OUTPUT); 
  pinMode(dirPin_0,OUTPUT);
  pinMode(enbPin_0,OUTPUT);
  pinMode(stepPin_1,OUTPUT); 
  pinMode(dirPin_1,OUTPUT);
  pinMode(enbPin_1,OUTPUT);
  pinMode(stepPin_2,OUTPUT); 
  pinMode(dirPin_2,OUTPUT);
  pinMode(enbPin_2,OUTPUT);

  digitalWrite(enbPin_0, LOW);
  digitalWrite(enbPin_1, LOW);
  digitalWrite(enbPin_2, LOW);
  
  stepper0.setMaxSpeed(V_MAX);
  stepper1.setMaxSpeed(V_MAX);
  stepper2.setMaxSpeed(V_MAX);
}
bool checkthis = true;
void loop(){
  printLCD();
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
            Serial.print("[HELLO FROM ARDUINO]");
            break;
          case 127:
             //Set PIN and value
             switch (inputByte_2)
            {
              case 9:
              //   analogWrite(ledPin_9, inputByte_3);
              //  if(inputByte_3 == 255)
              //  {
              //    digitalWrite(ledPin_3, HIGH); 
              //    break;
              //  }
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
          case 130:
            //Control stepper motor
            steppers[0].dir = inputByte_2;
            steppers[0].numSteps = STEP_RESOLUTION*(inputByte_3 * 256 + inputByte_4);
            steppers[1].dir = inputByte_5;
            steppers[1].numSteps = STEP_RESOLUTION*(inputByte_6 * 256 + inputByte_7);
            steppers[2].dir = inputByte_8;
            steppers[2].numSteps = STEP_RESOLUTION*(inputByte_9 * 256 + inputByte_10);
            move_steppers();
            printStatus();
            Serial.print("[Done move stepper]");
            break;
          case 131:
            //Calibration
            calibrate();
            resetCurrentPossition(0);
            setEnablePin(HIGH); //disable stepper
            Serial.print("[Calibration completed]");
            printStatus();
            break;
          case 132:
            //disable stepper
            setEnablePin(HIGH); //disable stepper
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
  setEnablePin(LOW); //enable stepper
  count = 0;
  int speed[3];
  float acceleration[3];
  int position[3];
  
  //Set periodic for each stepper
  if(steppers[0].dir == 0)
      position[0] = stepper0.currentPosition() - steppers[0].numSteps;
  else 
      position[0] = stepper0.currentPosition() + steppers[0].numSteps;
  if(steppers[1].dir == 0) 
      position[1] = stepper1.currentPosition() - steppers[1].numSteps;
  else 
      position[1] = stepper1.currentPosition() + steppers[1].numSteps;
  if(steppers[2].dir == 0) 
      position[2] = stepper2.currentPosition() - steppers[2].numSteps;
  else 
      position[2] = stepper2.currentPosition() + steppers[2].numSteps;
  
  int maxSteps = getMaxSteps(steppers[0], steppers[1], steppers[2]);
  //Serial.println(maxSteps);
  
  for(int j = 0; j < 3; j++) {
    //Serial.println(steppers[j].numSteps);
    speed[j] = round(steppers[j].numSteps * MAX_SPEED / maxSteps);
    acceleration[j] = (steppers[j].numSteps * MAX_ACCELERATION / maxSteps);
    //Serial.println(speed[j]);
    
  }
  stepper0.setAcceleration(acceleration[0]);
  stepper1.setAcceleration(acceleration[1]);
  stepper2.setAcceleration(acceleration[2]);
  stepper0.moveTo(position[0]);
  stepper1.moveTo(position[1]);
  stepper2.moveTo(position[2]);

  while(1) {
    count++;
    stepper0.run();
    stepper1.run();
    stepper2.run();
    if(stepper0.distanceToGo() == 0 && stepper1.distanceToGo() == 0 && stepper2.distanceToGo() == 0 ) {
      //Serial.println(count);
      break;
    }
  }

  resetVariable();
  printLCD();
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

void setEnablePin (bool value) {  //value = HIGH: disable, value = LOW: enable 
  digitalWrite(enbPin_0, value);
  digitalWrite(enbPin_1, value);
  digitalWrite(enbPin_2, value);
}

void resetCurrentPossition(long value) {
  stepper0.setCurrentPosition(value);
  stepper1.setCurrentPosition(value);
  stepper2.setCurrentPosition(value);
}
//--------------------------------------------------------------------
//-----------------------------Calibration----------------------------
void calibrate() {
    int value[3];
    value[0] = analogRead(A1);
    value[1] = analogRead(A2);
    value[2] = analogRead(A3);
    for(int i = 0; i < 3; i++) {
      steppers[i] = getStatusStepperByPotentiometterValue(i,value[i]);
    }
    //printStatus();
    move_steppers();
    //printStatus();
    //delay(2000);
    //check status of stepper
    boolean pass = true;
    value[0] = analogRead(A1);
    value[1] = analogRead(A2);
    value[2] = analogRead(A3);
    for(int i = 0; i < 3; i++) {
      int zero_value;
      if(i == 0) zero_value = STEPPER_STEP_ZERO_0;
      else if(i == 1) zero_value = STEPPER_STEP_ZERO_1;
      else zero_value = STEPPER_STEP_ZERO_2;
      if(abs(value[i] - zero_value) > 2) {
        pass = false;
        Serial.println("false");
      }
    }
    if(!pass) {
      calibrate();
    }
}

stepper getStatusStepperByPotentiometterValue(int stepperNo,int value) {
  
  stepper tmp;
  int zero_value;
  if(stepperNo == 0) zero_value = STEPPER_STEP_ZERO_0;
  else if(stepperNo == 1) zero_value = STEPPER_STEP_ZERO_1;
  else zero_value = STEPPER_STEP_ZERO_2;
  
  if (value > zero_value)
    tmp.dir = STEPPER_DN;
  else
    tmp.dir = STEPPER_UP;
  
  int diff = abs(value - zero_value);
  //Serial.println(diff);
  double angle = (double)(diff * 300.0) / 1024.0;
  //Serial.println(angle);
  tmp.numSteps = round(angle / STEPPER_STEP_SIZE)*STEP_RESOLUTION;
  
  //Serial.println(tmp.dir);
  //Serial.println(tmp.numSteps);
  return tmp;
}
//--------------------------------------------------------------------

void printStatus() {
  int value[3];
  value[0] = analogRead(A1);
  value[1] = analogRead(A2);
  value[2] = analogRead(A3);
  String tmp = "Status:" ;
  for (int i = 0; i < 3; i++) {
    if(i != 2) tmp = tmp + value[i] + ":";
    else tmp = tmp + value[i];
  }
  tmp = "[" + tmp + "]";
  Serial.print(tmp);
}

void printLCD() {
  int value[3];
  value[0] = analogRead(A1);
  value[1] = analogRead(A2);
  value[2] = analogRead(A3);
  String tmp = "" ;
  for (int i = 0; i < 3; i++) {
    if(i != 2) tmp = tmp + value[i] + ":";
    else tmp = tmp + value[i];
  }
  tmp = "(" + tmp + ")";
  lcd.setCursor(0, 1);
  lcd.print(tmp);
}

