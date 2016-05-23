using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameController : MonoBehaviour {
    

	public GameObject heroP;
    public List<MonoBehaviour> eventSubscribedScripts = new List<MonoBehaviour>();
    public int gameEventID = 0;

    private static GameController instance;


    public static GameController Instance {
        get {
            if (instance == null)
            {
                instance = FindObjectOfType<GameController>();
#if UNITY_EDITOR
            }
           
            return instance;
#endif
        }

    }
	// Use this for initialization
	void Start ()
    { //use this place to start event sequence...realistically we would trigger these events in Update() via a condition (EX. if (GameObject.activeSelf == true) run these gameEventID)
        DontDestroyOnLoad(gameObject);
        //sample event sequence demo (Log) --> see character.cs
        Invoke("playerPassedEvent", 2f); 
        Invoke("playerPassedEvent", 4f);
	}

    public void subscribeScriptToGameEventUpdates(MonoBehaviour pScript) {
        eventSubscribedScripts.Add(pScript);
    }


    public void doSubscribeScriptToGameEventUpdates(MonoBehaviour pScript)
    {
        while (eventSubscribedScripts.Contains(pScript))
        {
            eventSubscribedScripts.Remove(pScript);
        }
    }
    // Update is called once per frame
    public void playerPassedEvent() { //for testing purpose....we can invoke the gameEventUpdated when we need to in Update()
        gameEventID++;
        foreach (MonoBehaviour _script in eventSubscribedScripts)
        {
            _script.Invoke("gameEventUpdated", 0);
        }
    }
}
