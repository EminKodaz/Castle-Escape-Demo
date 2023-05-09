using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] private HingeJoint hj;
    JointMotor motor;
    public float velocity;
    public float angle;


    void Start()
    {
        
        motor = hj.motor;
    }


    void Update()
    {
        angle = hj.angle;
        motor.targetVelocity = -angle;
        hj.motor = motor;
    }
}
