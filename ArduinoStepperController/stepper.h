
#define STEPPER_MIN_ANGLE -1.01922088
#define STEPPER_MAX_ANGLE  1.49077498
#define STEPPER_STEP_SIZE  0.3473684211
#define STEPPER_STEP_ZERO  512

#define STEPPER_UP 1
#define STEPPER_DN 0

typedef struct {
  int index;    // Index of stepper
  int dir;      // direction
  int numSteps; // number of steps rotate
 } stepper;

/*
 * Setup Output
 */
//Stepper 1st 
const int stepPin_0 = 3; 
const int dirPin_0 = 4;
//Stepper 2nd 
const int stepPin_1 = 5;
const int dirPin_1 = 6;
//Stepper 3rd
const int stepPin_2 = 7; 
const int dirPin_2 = 8;


//Variables
stepper steppers[3];

