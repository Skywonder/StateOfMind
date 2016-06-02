using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {

    public GameObject keySpawner;
    public GameObject key;
    public GameObject player;
    
    private float stress;

	// Use this for initialization
	void Start () {
        key.SetActive(false);//set the key to be off at start
	}
	
	// Update is called once per frame
	void Update () {
        stress = player.GetComponent<PlayerStats>().Stresslevel;
        if (stress >= 70f)
        {
            key.SetActive(true);
            keySpawner.SetActive(false);
        }
        else
        {
            key.SetActive(false);
        }
	}
}
