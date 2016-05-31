using UnityEngine;
using System.Collections;

public class ActivateTextAtLine : MonoBehaviour {
    public TextAsset theText;

    public int startLine;
    public int endLine;

    public TextBoxManager theTextBox;
    public bool destroyWhenActivated;

	// Use this for initialization
	void Start () {
        theTextBox = FindObjectOfType<TextBoxManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {

            if (Input.GetKeyDown(KeyCode.F))
            {

                theTextBox.ReloadScript(theText);
                theTextBox.currentLine = startLine;
                theTextBox.endAtLine = endLine;
                theTextBox.EnableTextBox();


                if (destroyWhenActivated)
                {
                    Destroy(gameObject);
                }
            }
        }
    }


}
