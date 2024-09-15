/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;
using System.Net.Configuration;

/**
 * When creating your message listeners you need to implement these two methods:
 *  - OnMessageArrived
 *  - OnConnectionEvent
 */



public class positionListener : MonoBehaviour
{
    public float X;
    public float Y;

    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {

        Debug.Log("Message arrived: " + msg);

        if (msg.IndexOf("X") != -1)
        {
            //print("hasX");
            msg = msg.Remove(msg.Length - 1);
            X = float.Parse(msg); 
            print(X);
        }
        else if (msg.IndexOf("Y") != -1)
        {
            //print("hasY");
            msg = msg.Remove(msg.Length - 1);
            Y = float.Parse(msg);
            print(Y);
        }
    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection 1 established");
        else
            Debug.Log("Connection 1 attempt failed or disconnection detected");
    }
}
