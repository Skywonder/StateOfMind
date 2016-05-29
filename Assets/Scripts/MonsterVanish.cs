using UnityEngine;
using System.Collections;

public class MonsterVanish : MonoBehaviour {
    private Vector3 position;
    private Vector3 curPos;
	// Update is called once per frame
	void Update () {
        curPos = position;
	    if (curPos != position) {
            WaitForSeconds(2);
            render.enabled = false;
        }
	}
}
