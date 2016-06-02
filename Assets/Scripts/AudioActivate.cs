using UnityEngine;
using System.Collections;

public class AudioActivate : MonoBehaviour {
    //activate the audio source when the player is close by
    // Use this for initialization
    public GameObject soundorigin;
    public bool by_stats; //depending on the status of the player
    public GameObject player;
    private float stress;

    void Start () {
        soundorigin.GetComponent<AudioSource>().mute = true;	
	}
	
	// Update is called once per frame
	void Update () {
       stress = player.GetComponent<PlayerStats>().Stresslevel;
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (stress > 50f && by_stats)
            {
                soundorigin.GetComponent<AudioSource>().mute = false;
            }
            else if (!by_stats)
            {

                soundorigin.GetComponent<AudioSource>().mute = false;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            soundorigin.GetComponent<AudioSource>().mute = true;
        }

    }

}
