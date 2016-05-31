using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {
    public GameObject textBox;
    public Text theText;
    public TextAsset textFile;
    public string[] textLines;
    public int currentLine;
    public int endAtLine;
    public bool isActive;
    public PlayerStats player;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        if (isActive)
        {
            EnableTextBox();
        }
        else {
            DisableTextBox();
        }

    }
    void Update()
    {
        if (!isActive)
        {
            return;
        }
        theText.text = textLines[currentLine];
        if (Input.GetKeyDown(KeyCode.F))
        {
            currentLine += 1;
        }
        if (currentLine > endAtLine)
        {
            DisableTextBox();
        }

    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }


}
