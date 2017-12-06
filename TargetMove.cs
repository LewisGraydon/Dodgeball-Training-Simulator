using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class and Logic by Lewis
public class TargetMove : MonoBehaviour {

    public GameObject target;
    public GameObject targetLft;
    public GameObject targetRght;
    public GameObject gameState;
    public int difficulty = 2;

    private GameObject currentPos;

	// Use this for initialization
	void Start () {
        currentPos = targetRght;
	}
	
	// Update is called once per frame
	void Update () {
        if (target.transform.position.z == targetRght.transform.position.z)
        {
            currentPos = targetLft;
        }
        else if (target.transform.position.z == targetLft.transform.position.z) {
            currentPos = targetRght;
        }

        target.transform.position = Vector3.MoveTowards(transform.position, currentPos.transform.position, Time.deltaTime * difficulty);
        difficulty = gameState.GetComponent<DodgeballGameState>().GetDifficulty();
	}

    //public void increaseDifficulty() {
    //    if (difficulty == 3) {
    //        return;
    //    }
    //    difficulty++;
    //}

    //public void decreaseDifficulty() {
    //    if (difficulty == 1) {
    //        return;
    //    }
    //    difficulty--;
    //}

    //public void resetDifficulty() {
    //    difficulty = 2;
    //}

    //public void easyDifficulty() {
    //    difficulty = 1;
    //}

    //public void hardDifficulty() {
    //    difficulty = 3;
    //}
}
