# DeltaRobot
## Comms Protocol
This uses a 12 byte message to sent data of stepper:

- Byte 0 is the start of command marker. This is always decimal 16 converted to byte.
- Byte 1 is the type of command: 

		127 = Send data to pins
		128 = Identify
		129 = Get data from arduino
		130 = Set data to stepper motor
		131 = Calibrate

##### Set data for 1st stepper(byte 2,3,4).		
- Byte 2 direction of stepper 1st:
		0 = LOW
		1 = HIGH
- Byte 3 is the number of steps of stepper 1st
- Byte 4 is the number of steps of stepper 1st

		Byte 3 = numSteps / 256
		Byte 4 = numSteps % 256
		(Number of steps between 0 to 65535)

##### Set data for 2nd stepper(byte 5,6,7).
- Byte 5 direction of stepper 2nd:
		0 = LOW
		1 = HIGH
- Byte 6 is the number of steps of stepper 2nd
- Byte 7 is the number of steps of stepper 2nd

		Byte 6 = numSteps / 256
		Byte 7 = numSteps % 256
		(Number of steps between 0 to 65535)

##### Set data for 3rd stepper(byte 8,9,10).
- Byte 8 direction of stepper 3rd:
		0 = LOW
		1 = HIGH
- Byte 9 is the number of steps of stepper 3rd
- Byte 10 is the number of steps of stepper 3rd

		Byte 9 = numSteps / 256
		Byte 10 = numSteps % 256
		(Number of steps between 0 to 65535)
- Byte 11 was used as an "end of Message" marker but is redundant 

## Version
Beta

## Tech
null

## Plugins
null

## Todos
 * Control delta robot using C# and Arduino.
