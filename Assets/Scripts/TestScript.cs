using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public GameObject leftWheel;
    public GameObject rightWheel;

    private float maxspeed = 301.0f;
    private float accel = 100.0f;

    private WheelJoint2D hinge1;
    private WheelJoint2D hinge2;
    private JointMotor2D motor1;
    private JointMotor2D motor2;

    void Start()
    {
        hinge1 = leftWheel.GetComponent<WheelJoint2D>();
        hinge2 = rightWheel.GetComponent<WheelJoint2D>();
        motor1 = hinge1.motor;
        motor2 = hinge2.motor;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (motor1.motorSpeed <= maxspeed)
            {
                if (motor1.motorSpeed < 0f)
                {
                    motor1.motorSpeed = 0f;
                    hinge1.motor = motor1;
                }
                else
                {
                    hinge1.useMotor = true;
                    motor1.motorSpeed = motor1.motorSpeed + accel * Time.deltaTime;
                    hinge1.motor = motor1;
                }
            }

            if (motor2.motorSpeed <= maxspeed)
            {
                if (motor2.motorSpeed < 0f)
                {
                    motor2.motorSpeed = 0f;
                    hinge2.motor = motor2;
                }
                else
                {
                    hinge2.useMotor = true;
                    motor2.motorSpeed = motor2.motorSpeed + accel * Time.deltaTime;
                    hinge2.motor = motor2;
                }
            }

        } else if (Input.GetKey(KeyCode.A)) {
            if (motor1.motorSpeed > 0f)
            {
                motor1.motorSpeed = 0f;
                hinge1.motor = motor1;
            }
            else
            {
                hinge1.useMotor = true;
                motor1.motorSpeed = motor1.motorSpeed - accel * Time.deltaTime;
                hinge1.motor = motor1;
            }

            if (motor2.motorSpeed > 0f)
            {
                motor2.motorSpeed = 0f;
                hinge2.motor = motor2;
            }
            else
            {
                hinge2.useMotor = true;
                motor2.motorSpeed = motor2.motorSpeed - accel * Time.deltaTime;
                hinge2.motor = motor2;
            }
        }
        else
        {
            motor1.motorSpeed = 0f;
            motor2.motorSpeed = 0f;
            hinge1.motor = motor1;
            hinge2.motor = motor2;
        }
    }
}
