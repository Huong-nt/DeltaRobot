#include <AccelStepper.h>
#include <LiquidCrystal.h>

#define STEPPER_MIN_ANGLE     -1.01922088
#define STEPPER_MAX_ANGLE     1.49077498
#define STEPPER_STEP_SIZE     0.3473684211
#define MAX_SPEED             1000.0
#define MAX_ACCELERATION      2000.0
#define STEPPER_STEP_ZERO     380
#define STEPPER_STEP_ZERO_0   563
#define STEPPER_STEP_ZERO_1   441
#define STEPPER_STEP_ZERO_2   421

/*
 * step resolution:
 * 0 : Full step
 * 2 : Half step
 * 4 : Quarter step
 * 8 : Eighth step
 * 16: Sixteenth step
 */
#define STEP_RESOLUTION 2


#define STEPPER_UP 1
#define STEPPER_DN 0
#define V_MAX 2000


int STEPPER_STEP_ZERO_0_TEMP = 562;
int STEPPER_STEP_ZERO_1_TEMP = 429;
int STEPPER_STEP_ZERO_2_TEMP = 421;

typedef struct {
  int index;    // Index of stepper
  int dir;      // direction
  int numSteps; // number of steps rotate
 } stepper;

/*
 * Setup Output
 */
//Stepper 1st 
const int stepPin_0 = 6;
const int dirPin_0 = 7;
const int enbPin_0 = 5;
//Stepper 2nd 
const int stepPin_1 = 3;
const int dirPin_1 = 4;
const int enbPin_1 = 2;
//Stepper 3rd
const int stepPin_2 = 15;
const int dirPin_2 = 14;
const int enbPin_2 = 16;

AccelStepper stepper0(AccelStepper::DRIVER, stepPin_0, dirPin_0);
AccelStepper stepper1(AccelStepper::DRIVER, stepPin_1, dirPin_1);
AccelStepper stepper2(AccelStepper::DRIVER, stepPin_2, dirPin_2);

//Variables
stepper steppers[3];

int count_0 = 0;
int period_0 = 0;
bool flag_0 = false;

int count_1 = 0;
int period_1 = 0;
bool flag_1 = false;

int count_2 = 0;
int period_2 = 0;
bool flag_2 = false;

// initialize the library with the numbers of the interface pins
LiquidCrystal lcd(42, 44, 46, 48, 50, 52);

