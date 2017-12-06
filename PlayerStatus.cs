using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//class refactoring/creation by Brennan
//A class that tracks and updates the player's status; things like score, if they have a ball, etc.
public class PlayerStatus : MonoBehaviour {


    public GameObject rightHand;
    public GameObject PlayerBall;
    private bool hasBall = true;
    private int playerScore = 0;
    private int throwPower = 100;

    private bool catchStatus = false;

    private float catchStatusDuration = 1.0f;
    private float catchTime = 0;

    private float catchTimeCDDuration = 2.0f;
    private float catchTimeCD = 0;

    public Text scoreText;
    public Image playerBallIcon;

    //temporarily set this as target
    public GameObject aimer;

    public int getScore()
    {
        return playerScore;
    }

    //Function by Lewis

    public void catchTimerSet()
    {
        catchTime = Time.time + catchStatusDuration;
    }

    //Function by Lewis

    public void catchTimerCDSet()
    {
        catchTimeCD = catchTime + catchTimeCDDuration;
    }


    //Function by Lewis

    public void catchTimer()
    {
        if(catchStatus == true)
        {
            catchTimerSet();

            if(Time.time > catchTime)
            {
                setCatchStatusFalse();
            }
        }
    }

    //Function by Lewis

    public void catchTimerCD()
    {
        if(Time.time > catchTimeCD)
        {
            if (gethasBall() != true)
            {
                catchTimer();
                setCatchStatusTrue();
            }
        }
    }

    //Function by Lewis

    public void setCatchStatusTrue()
    {
        catchStatus = true;
    }

    public void setCatchStatusFalse()
    {
        catchStatus = false;
    }

    //Function by Lewis

    public bool getCatchStatus()
    {
        return catchStatus;
    }

    //Pass though int. 0 decreases score. 1 Increases score.
    public void changeScore(int x)
    {
        switch (x)
        {
            case 0:
                playerScore -= 250;
                break;

            case 1:
                playerScore += 500;
                break;

            default:
                break;
        }
    }

    public bool gethasBall()
    {
        return hasBall;
    }

    public void sethasBall(int x)
    {
        if (x == 0)
        {
            hasBall = false;
            playerBallIcon.gameObject.SetActive(false);
        }
        if (x == 1)
        {
            hasBall = true;
            playerBallIcon.gameObject.SetActive(true);
        }
    }
    //Function by Lewis, refactoring by Brennan
    public void fireBall()
    {
        Vector3 offset;
        offset.x = -3;
        offset.y = 0;
        offset.z = 0;

        GameObject tempBall;
        tempBall = Instantiate(PlayerBall, rightHand.transform.position - offset, rightHand.transform.rotation);

        Vector3 vectTowardTarget = aimer.transform.position - rightHand.transform.position;

        Rigidbody tempRigidBody;
        tempRigidBody = tempBall.GetComponent<Rigidbody>();
        tempRigidBody.AddForce(vectTowardTarget * throwPower, ForceMode.Force);

        sethasBall(0);
        Destroy(tempBall, 1.125f);
    }

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
    //Scoring logic created by Lewis.
	void Update () {

        scoreText.text = "Score: " + playerScore.ToString("00000");

    }
}
