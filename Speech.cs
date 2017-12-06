using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speech : MonoBehaviour {

    RecoSpeechManager speech;
    bool hasSpoken = false;
    public GameObject target;
    public GameObject gameManager;
    TargetMove targetMove;
    DodgeballGameState gameState;

    private bool stage1pause = false;

    public GameObject Player;

    public GameObject leftHand;
    public GameObject leftElbow;
    public GameObject leftShoulder;

    public GameObject rightHand;
    public GameObject rightElbow;
    public GameObject rightShoulder;

    private Vector3 leftHandPos;
    private Vector3 leftElbowPos;
    private Vector3 leftShoulderPos;

    private Vector3 rightHandPos;
    private Vector3 rightElbowPos;
    private Vector3 rightShoulderPos;

    // Use this for initialization
    void Start()
    {
        speech = FindObjectOfType<RecoSpeechManager>(); //SLOW AF
        Debug.Log("Found script: " + speech.name);

        targetMove =  target.GetComponent<TargetMove>();
        gameState = gameManager.GetComponent<DodgeballGameState>();
    }

    // Update is called once per frame
    void Update()
    {
        leftHandPos = leftHand.transform.position;
        leftElbowPos = leftElbow.transform.position;
        leftShoulderPos = leftShoulder.transform.position;

        rightHandPos = rightHand.transform.position;
        rightElbowPos = rightElbow.transform.position;
        rightShoulderPos = rightShoulder.transform.position;

        string command = speech.UDPGetPacket();

        if ((rightHandPos.y > rightShoulderPos.y) && (leftHandPos.y > leftShoulderPos.y))
        {
            Debug.Log("MAKING MY WAY DOWN TOWN");
            stage1pause = true;
        }
        else
        {
            stage1pause = false;
        }
 
        if (stage1pause == true && command == "pause")
        {
            gameState.setPause(1);
            stage1pause = false;
        }

        if(command == "reset")
        {
            speech.closeReco();
            gameState.StartGame();
        }

        if (command == "resume" || command == "continue") {
            gameState.setPause(0);
        }

        if (command == "difficulty up" || command == "speed up") {
            gameState.ChangeDifficulty(3);
        }

        if (command == "difficulty down" || command == "speed down") {
            gameState.ChangeDifficulty(4);
        }

        if (command == "difficulty reset" || command == "difficulty normal") {
            gameState.ChangeDifficulty(0);
        }

        if (command == "difficulty easy") {
            gameState.ChangeDifficulty(1);
        }

        if (command == "difficulty hard") {
            gameState.ChangeDifficulty(2);
        }

        if (command == "exit" || command == "quit" /*|| command == "end"*/) {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
            speech.closeReco();
        }

        speech.clearSpeech();
    }
}
