using UnityEngine;
using System.Collections;

public class TransformTrigger : MonoBehaviour {
    //script intended to translate players to new position
    // Use this for initialization
    public GameObject item; //<-this is the item that will translate to target location
    public GameObject targetLocation;
    public int counter = 1;

    // Update is called once per frame
    void Update()
    { 
    }

    void OnTriggerEnter(Collider player)
    {
        if (counter == 1)
        { 
            item.transform.position = targetLocation.transform.position;
            counter -= 1;  
        }
        

    }
}
