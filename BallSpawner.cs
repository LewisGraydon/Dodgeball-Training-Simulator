using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class and Logic by Lewis
public class BallSpawner : MonoBehaviour {

    public GameObject Ball;
    public GameObject PlayerNeck;
    public GameObject Spawner1;
    public GameObject Spawner2;
    public GameObject Spawner3;
    public GameObject Spawner4;
    public GameObject Spawner5;
    public GameObject Spawner6;
    public GameObject Spawner7;

    public bool ballIsCaught;

    public float fireRate;
    public float ballPower;

    private float nextFire;

    Transform[] randSpawn = new Transform[7];

    // Use this for initialization
    void Start ()
    {
        randSpawn[0] = Spawner1.transform;
        randSpawn[1] = Spawner2.transform;
        randSpawn[2] = Spawner3.transform;
        randSpawn[3] = Spawner4.transform;
        randSpawn[4] = Spawner5.transform;
        randSpawn[5] = Spawner6.transform;
        randSpawn[6] = Spawner7.transform;
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            System.Random rand = new System.Random();
            int indice = rand.Next(0, 7);
            Vector3 offset;
            offset.x = 3;
            offset.y = 0;
            offset.z = 0;

            GameObject tempBall;
            tempBall = Instantiate(Ball, randSpawn[indice].position - offset, randSpawn[indice].rotation);

            Vector3 vectTowardPlayer = PlayerNeck.transform.position - randSpawn[indice].transform.position;

            Rigidbody tempRigidBody;
            tempRigidBody = tempBall.GetComponent<Rigidbody>();
            tempRigidBody.AddForce(vectTowardPlayer * ballPower, ForceMode.Force);      

            if(!ballIsCaught)
            {
                Destroy(tempBall,1.5f);
            }

            else
            {
                Destroy(tempBall, 0.25f);
            }
        }
	}
}
