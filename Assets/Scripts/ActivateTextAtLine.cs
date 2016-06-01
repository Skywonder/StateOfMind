using UnityEngine;
using System.Collections;

public class ActivateTextAtLine : MonoBehaviour {
    public TextAsset theText;

    public int startLine;
    public int endLine;

    public TextBoxManager theTextBox;
    public bool destroyWhenActivated;

    public bool requireButtonPress;
    private bool waitForPress;

	// Use this for initialization
	void Start () {
        theTextBox = FindObjectOfType<TextBoxManager>();
	}
	
	// Update is called once per frame
    /*
    make sure to leave a empty line before the starting line. line 0 should be empty -> start (1) -> 2 3 4 5 
    */
	void Update () {
        if (waitForPress && Input.GetKeyDown(KeyCode.F))
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

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            if (requireButtonPress)
            {
                waitForPress = true;
                return;
            }

            if (!requireButtonPress)
            {
                theTextBox.ReloadScript(theText);
                theTextBox.currentLine = startLine + 1;
                theTextBox.endAtLine = endLine;
                theTextBox.EnableTextBox();

                if (destroyWhenActivated)
                {
                    Destroy(gameObject);
                }

            } 
        }
    }

    void OnTriggerExist(Collider other)
    {
        if (other.name == "Player")
        {
            waitForPress = false;

        }
    }
}
