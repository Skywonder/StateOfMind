using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerGUI : MonoBehaviour {

    private float stress = 0;
    public Text stresslevel;
    public GameObject player;
    public PlayerStats playerstats;


	// Update is called once per frame
	void Update () {
        playerstats = player.GetComponent<PlayerStats>();
        stresslevel.text = playerstats.Stresslevel.ToString();
	}
}
