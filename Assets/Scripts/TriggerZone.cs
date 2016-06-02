using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour {

	// Use this for initialization
    public GameObject item; //<-this is the item that will appear at target location
    public GameObject targetLocation;
    public float spawntime = 5f;
    public float despawntime = 2f;
    public bool istriggered = false;


	// Update is called once per frame
	void Update () {
	    
	}



    void OnTriggerEnter(Collider player)
    {

        //target is gonna disappear from the original place
        item.SetActive(false);
      

        //reappear after a few sec at the target location
        if (istriggered == false)
        {
            if (Time.deltaTime < spawntime)
            {
                item.transform.position = targetLocation.transform.position;
                item.SetActive(true);
                istriggered = true;
            }
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (Time.deltaTime < despawntime)
        {
            item.SetActive(false);
            
        }
    }
}
