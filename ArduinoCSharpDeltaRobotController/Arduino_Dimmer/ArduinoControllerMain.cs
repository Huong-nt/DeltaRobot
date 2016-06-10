using System.Threading;
using System.IO;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ArduinoControllerMain
{

    SerialPort currentPort;
    bool portFound;
    public ArduinoControllerMain()
    {

    }
    /*
     * Set value for pin 
     */
    public bool setData(int pinNumber, int data)
    {
        try
        {
            byte[] buffer = new byte[12];
            buffer[0] = Convert.ToByte(16);
            buffer[1] = Convert.ToByte(127);
            buffer[2] = Convert.ToByte(pinNumber);
            buffer[3] = Convert.ToByte(data);
            buffer[4] = Convert.ToByte(0);
            buffer[5] = Convert.ToByte(0);
            buffer[6] = Convert.ToByte(0);
            buffer[7] = Convert.ToByte(0);
            buffer[8] = Convert.ToByte(0);
            buffer[9] = Convert.ToByte(0);
            buffer[10] = Convert.ToByte(0);
            buffer[11] = Convert.ToByte(4);
            int intReturnASCII = 0;
            char charReturnValue = (Char)intReturnASCII;
            currentPort.Open();
            currentPort.Write(buffer, 0, 12);
            Thread.Sleep(1000);
            currentPort.Close();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    /*
     * Calibrate 
     */
    public bool calibrate()
    {
        try
        {
            byte[] buffer = new byte[12];
            buffer[0] = Convert.ToByte(16);
            buffer[1] = Convert.ToByte(131); //code 131
            buffer[2] = Convert.ToByte(0);
            buffer[3] = Convert.ToByte(0);
            buffer[4] = Convert.ToByte(0);
            buffer[5] = Convert.ToByte(0);
            buffer[6] = Convert.ToByte(0);
            buffer[7] = Convert.ToByte(0);
            buffer[8] = Convert.ToByte(0);
            buffer[9] = Convert.ToByte(0);
            buffer[10] = Convert.ToByte(0);
            buffer[11] = Convert.ToByte(4);
            int intReturnASCII = 0;
            char charReturnValue = (Char)intReturnASCII;
            currentPort.Open();
            currentPort.Write(buffer, 0, 12);
            Thread.Sleep(1500);
            int count = currentPort.BytesToRead;
            string returnMessage = "";
            while (count > 0)
            {
                intReturnASCII = currentPort.ReadByte();
                returnMessage = returnMessage + Convert.ToChar(intReturnASCII);
                count--;
            }
            currentPort.Close();
            if (returnMessage.Contains("Calibration completed"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }

    /*
     *  Set rotate steps and direction for stepper motor
     *  
     */
    public bool setDataStepper(Boolean dir_0, int numSteps_0, Boolean dir_1, int numSteps_1, Boolean dir_2, int numSteps_2)
    {
        try
        {
            int temp = 0;
            byte[] buffer = new byte[12];
            buffer[0] = Convert.ToByte(16);
            buffer[1] = Convert.ToByte(130); //code 130

            buffer[2] = Convert.ToByte(dir_0);
            temp = numSteps_0 / 256;
            buffer[3] = Convert.ToByte(temp);
            buffer[4] = Convert.ToByte(numSteps_0 % 256);

            buffer[5] = Convert.ToByte(dir_1);
            temp = numSteps_1 / 256;
            buffer[6] = Convert.ToByte(temp);
            buffer[7] = Convert.ToByte(numSteps_1 % 256);

            buffer[8] = Convert.ToByte(dir_2);
            temp = numSteps_2 / 256;
            buffer[9] = Convert.ToByte(temp);
            buffer[10] = Convert.ToByte(numSteps_2 % 256);

            buffer[11] = Convert.ToByte(4);

            currentPort.Open();
            currentPort.Write(buffer, 0, 12);
            Thread.Sleep(1500);

            int intReturnASCII = 0;
            char charReturnValue = (Char)intReturnASCII;
            int count = currentPort.BytesToRead;
            string returnMessage = "";
            while (count > 0)
            {
                intReturnASCII = currentPort.ReadByte();
                returnMessage = returnMessage + Convert.ToChar(intReturnASCII);
                count--;
            }
            Console.WriteLine(returnMessage);
            currentPort.Close();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    /*
     * test kinematics 
     */
    public bool testKinematics()
    {
        try
        {
            byte[] buffer = new byte[12];
            buffer[0] = Convert.ToByte(16);
            buffer[1] = Convert.ToByte(133); //code 133
            buffer[2] = Convert.ToByte(0);
            buffer[3] = Convert.ToByte(0);
            buffer[4] = Convert.ToByte(0);
            buffer[5] = Convert.ToByte(0);
            buffer[6] = Convert.ToByte(0);
            buffer[7] = Convert.ToByte(0);
            buffer[8] = Convert.ToByte(0);
            buffer[9] = Convert.ToByte(0);
            buffer[10] = Convert.ToByte(0);
            buffer[11] = Convert.ToByte(4);
            int intReturnASCII = 0;
            char charReturnValue = (Char)intReturnASCII;
            currentPort.Open();
            currentPort.Write(buffer, 0, 12);
            Thread.Sleep(1500);
            int count = currentPort.BytesToRead;
            string returnMessage = "";
            while (count > 0)
            {
                intReturnASCII = currentPort.ReadByte();
                returnMessage = returnMessage + Convert.ToChar(intReturnASCII);
                count--;
            }
            currentPort.Close();
            if (returnMessage.Contains("Move completed"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }

    /*
     * Get value from pin
     */
    public bool getData(int pinNumber, out string data)
    {
        try
        {
            byte[] buffer = new byte[12];
            buffer[0] = Convert.ToByte(16);
            buffer[1] = Convert.ToByte(129); //code 129
            buffer[2] = Convert.ToByte(pinNumber);
            buffer[3] = Convert.ToByte(0);
            buffer[4] = Convert.ToByte(0);
            buffer[5] = Convert.ToByte(0);
            buffer[6] = Convert.ToByte(0);
            buffer[7] = Convert.ToByte(0);
            buffer[8] = Convert.ToByte(0);
            buffer[9] = Convert.ToByte(0);
            buffer[10] = Convert.ToByte(0);
            buffer[11] = Convert.ToByte(4);
            int intReturnASCII = 0;
            char charReturnValue = (Char)intReturnASCII;
            currentPort.Open();
            currentPort.Write(buffer, 0, 12);
            Thread.Sleep(1000);
            int count = currentPort.BytesToRead;
            string returnMessage = "";
            while (count > 0)
            {
                intReturnASCII = currentPort.ReadByte();
                returnMessage = returnMessage + Convert.ToChar(intReturnASCII);
                count--;
            }
            data = returnMessage;
            currentPort.Close();
            if (returnMessage.Contains("GET SUCCESS"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            data = "";
            return false;
        }
    }

    private bool DetectArduino()
    {
        try
        {
            //The below setting are for the Hello handshake
            byte[] buffer = new byte[12];
            buffer[0] = Convert.ToByte(16);
            buffer[1] = Convert.ToByte(128); //code 128
            buffer[2] = Convert.ToByte(0);
            buffer[3] = Convert.ToByte(0);
            buffer[4] = Convert.ToByte(0);
            buffer[5] = Convert.ToByte(0);
            buffer[6] = Convert.ToByte(0);
            buffer[7] = Convert.ToByte(0);
            buffer[8] = Convert.ToByte(0);
            buffer[9] = Convert.ToByte(0);
            buffer[10] = Convert.ToByte(0);
            buffer[11] = Convert.ToByte(4);
            int intReturnASCII = 0;
            char charReturnValue = (Char)intReturnASCII;
            currentPort.Open();
            currentPort.Write(buffer, 0, 12);
            Thread.Sleep(1000);
            int count = currentPort.BytesToRead;
            string returnMessage = "";
            while (count > 0)
            {
                intReturnASCII = currentPort.ReadByte();
                returnMessage = returnMessage + Convert.ToChar(intReturnASCII);
                count--;
            }
            //ComPort.name = returnMessage;
            currentPort.Close();
            if (returnMessage.Contains("HELLO FROM ARDUINO"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }

    /*
     * Init port by name
     */
    public bool initPort(string portName)
    {

        currentPort = new SerialPort(portName, 9600);
        try
        {
            currentPort.Open();
            currentPort.Close();
            portFound = true;
            return true;
        }
        catch (Exception ex)
        {
            portFound = false;
            return false;
        }
    }
    /*
     * Close connection
     */
    public bool closePort()
    {
        try
        {
            currentPort.Close();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}