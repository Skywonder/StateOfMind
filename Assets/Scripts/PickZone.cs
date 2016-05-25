﻿using UnityEngine;
using System.Collections;

public class PickZone : MonoBehaviour {

    public GameObject medicine; //<-this is the item that will deactivate when player takes it ("F" key)
    private bool picked = false;
    private bool avaliable = true;
    public GameObject player;
    public PlayerStats playerstats;


    void Update() {
        playerstats = player.GetComponent<PlayerStats>();

        if (Input.GetKey(KeyCode.F) && avaliable == true)
        {
            medicine.SetActive(false);
            avaliable = false;
            playerstats.Stresslevel -= 25.0f;
            if (playerstats.Stresslevel < 0.0f)
            {
                playerstats.Stresslevel = 0.0f;
            }
            Debug.Log("Pick up medicine reduce stress level");
        }
    }


    void OnTriggerEnter(Collider player)
    {
        
        //target is gonna deactive from the original place
        if (avaliable == true)
        {
            Debug.Log("Pick up medicine valid");
            picked = true;
        }

    }
}