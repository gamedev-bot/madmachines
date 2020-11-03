using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public float speed = 1500;

    public WheelJoint2D leftWheel;
    public WheelJoint2D rightWheel;

    private float movement = 0f;

    void Update()
    {
        movement = -1 * Input.GetAxisRaw("Horizontal") * speed;
    }

    private void FixedUpdate()
    {
        if (movement == 0f)
        {

            leftWheel.useMotor = false;
            rightWheel.useMotor = false;

        }
        else
        {

            leftWheel.useMotor = true;
            rightWheel.useMotor = true;

            JointMotor2D motor = new JointMotor2D
            {
                motorSpeed = movement,
                maxMotorTorque = 10000
            };

            rightWheel.motor = motor;
            leftWheel.motor = motor;
        }
    }
}
