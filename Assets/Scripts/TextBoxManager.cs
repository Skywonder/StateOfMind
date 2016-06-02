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
    public bool endscreens;
    private bool isTyping = false;
    private bool cancelTyping = false;

    public float typeSpeed;

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
            if (!endscreens)
            {
                DisableTextBox();
            }
        }

    }
    void Update()
    {
        if (!isActive)
        {
            return;
        }

        //theText.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isTyping)
            {
                currentLine += 1;

                if (currentLine > endAtLine)
                {
                    if (!endscreens)
                    {
                        DisableTextBox();
                    }

                }
                else
                {
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }
            }
            else if (isTyping && !cancelTyping)
            {
                cancelTyping = true;

            }   
        }
        
    }

    private IEnumerator TextScroll(string lineOfText)
    {
        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < lineOfText.Length -1))
        {
            theText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);

        }
        theText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        StartCoroutine(TextScroll(textLines[currentLine]));
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
      
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
