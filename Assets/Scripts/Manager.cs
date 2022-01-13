using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject ant, camera;
    public GameObject floor;
    public float antMaxSpeed = 0;
    public float antSteerStrength;
    public float antWanderStrength;
    public int worldRadius, antPopulation;
    const float CAMERAPOSITIONRATIO = 1.7f;
    const int PLANERATIO = 5;
    // Start is called before the first frame update

    private void Awake()
    {
        var instantiatedFloor = Instantiate(floor);
        instantiatedFloor.transform.localScale = new Vector3(worldRadius/PLANERATIO, 1, worldRadius/ PLANERATIO);
        instantiatedFloor.transform.position = Vector3.zero;
        camera.transform.position = new Vector3(0, 0, -worldRadius * CAMERAPOSITIONRATIO);
        Ant.maxSpeed = antMaxSpeed;
        Ant.steerStrength = antSteerStrength;
        Ant.wanderStrength = antWanderStrength;
        Ant.wanderRadius = worldRadius;
        for (int i = 0; i < antPopulation; i++)
        {
            var instantiatedAnt = Instantiate(ant, Vector3.zero, Quaternion.Euler(-90, 0, 0));
        }
    }
}
