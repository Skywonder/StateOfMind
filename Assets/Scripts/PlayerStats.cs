using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public int Stresslevel;
    private int maxStresslevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Stresslevel += 1; 
        Debug.Log(Stresslevel);




        if(Stresslevel == 100)
        {
            Debug.Log("The player fainted");
        
        }
	}

}
