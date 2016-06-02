using UnityEngine;
using System.Collections;

public class KeyPickUp : MonoBehaviour {
    public GameObject key;
    public GameObject player;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Picked up key");
            player.GetComponent<PlayerGUI>().key_count += 1;
            key.SetActive(false);
        }

    }

}
