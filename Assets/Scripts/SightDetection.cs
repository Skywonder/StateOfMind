using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class SightDetection : MonoBehaviour
{

    /*
	To use this script, attach it to the player object with a camera component.
	Next, set the layer mask so that the raycast will not hit the player.
	The mask needs to be set up to hit walls and the objects you want to check on.

	If you want to find out whether the player can see an object, call 'PlayerSight.AmISeen(this.gameObject)' from
	a script on that object.

	Credits - Avi Miller
	*/

    [SerializeField]
    float sightRange = 15f;
    [SerializeField]
    LayerMask mask;
    Camera cam;

    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    public bool AmISeen(Collider targetCollider, Vector3 target)
    {   //performs a raycast on 'target' to see if it hits an object with 'tag'.
        RaycastHit hit;
        if (Physics.Raycast(transform.position,
                           target - transform.position,
                           out hit,
                           sightRange,
                           mask))
        {
            if (hit.collider == targetCollider)
            {
                if (Vector3.Angle(transform.forward, hit.point - transform.position) <= cam.fieldOfView / 2)
                {
                    return true;
                }
            }
        }
        return false;
    }
}

public static class PlayerSight
{
    public static SightDetection player;

    //A game object with a collider can ask if it is in the player's FOV -and- in the player's sight range.
    public static bool AmISeen(GameObject target)
    {
        return player.AmISeen(target.GetComponent<Collider>(), target.transform.position);
    }

    //Overload to allow for offsetting
    public static bool AmISeen(GameObject target, Vector3 offset)
    {
        return player.AmISeen(target.GetComponent<Collider>(), target.transform.position + offset);
    }

    //A collider can ask if it is in the player's FOV -and- in the player's sight range.
    public static bool AmISeen(Collider target)
    {
        return player.AmISeen(target, target.transform.position);
    }

    //Overload to allow for offsetting
    public static bool AmISeen(Collider target, Vector3 offset)
    {
        return player.AmISeen(target, target.transform.position + offset);
    }
}
