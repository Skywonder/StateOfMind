using UnityEngine;
using System.Collections;

public class MonsterVanish : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        Vector3 position = transform.position;
        WaitForSeconds(2);
        monster1.enabled = false;
	}
}
