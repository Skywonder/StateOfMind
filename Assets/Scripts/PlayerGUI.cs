using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerGUI : MonoBehaviour {
    public GameObject door;
    private float stress = 0;
    public Text stresslevel;
    public Text key;
    public int key_count = 0;
    public GameObject player;
    public PlayerStats playerstats;


	// Update is called once per frame
	void Update () {
        playerstats = player.GetComponent<PlayerStats>();
        
        stresslevel.text =  playerstats.Stresslevel.ToString();
        key.text = "Key: " + key_count.ToString() + "/2";

        if (key_count == 2)
        {
            door.GetComponent<Door>().specialdoor = false;
        }
	}
}
