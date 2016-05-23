using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameController.Instance.heroP = gameObject;
		GameController.Instance.subscribeScriptToGameEventUpdates(this);

	}
	
	// Update is called once per frame
	void OnDestroy(){
		GameController.Instance.doSubscribeScriptToGameEventUpdates(this);

	}

	void gameEventUpdated(){ //update on event --> when gamecontroller hits event, update the result accordingly by eventID
        //if player finishes event 2, let him dance
        //ofcourse...we can add triggers all over the places to trigger these events too   
        if (GameController.Instance.gameEventID == 1)
        {
            Debug.Log("Takes a sec to prepare");
        }

        if (GameController.Instance.gameEventID == 2)
		{
			Debug.Log("run the dancing animation");

		}

	}


}
