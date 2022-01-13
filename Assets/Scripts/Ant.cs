using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{
    public static float maxSpeed;
    public static float steerStrength;
    public static float wanderStrength;
    public static int wanderRadius;
    public GameObject prefab;
    Transform target;

    Vector2 position;
    Vector2 desiredDirection;
    Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        //target = prefab.GetComponent<Transform>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(position.x)>wanderRadius || Mathf.Abs(position.y)>wanderRadius)
        {
            desiredDirection = ((Vector2.zero - position) + Random.insideUnitCircle * wanderStrength).normalized;   
        }
        else
        {
            desiredDirection = (desiredDirection + Random.insideUnitCircle * wanderStrength).normalized;
        }
        
        
        Vector2 desiredVelocity = desiredDirection * maxSpeed;
        Vector2 accelartion = Vector2.ClampMagnitude((desiredVelocity - velocity) * steerStrength, steerStrength)/1;
        velocity = Vector2.ClampMagnitude(velocity + accelartion * Time.deltaTime, maxSpeed);
        position += velocity*Time.deltaTime;

        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        transform.SetPositionAndRotation(position, Quaternion.Euler(0,0, angle)); 
    }
}
