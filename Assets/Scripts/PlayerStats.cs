using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {
    public GameObject player;
    //public GameObject continuePanel;
   // public GameObject medicine;
    public float stressRate;
    bool pausescript;
    public float Stresslevel = 0f;
    private float maxStresslevel = 100f;
    private bool Paused = false;
    public string stage;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject faint;
    

	// Use this for initialization
	void Start () {
        //continuePanel.SetActive(false);
        heart1.GetComponent<AudioSource>().mute = false;
        heart2.GetComponent<AudioSource>().mute = true;
        heart3.GetComponent<AudioSource>().mute = true;
        faint.GetComponent<AudioSource>().mute = true;
    }

    // Update is called once per frame
    void Update() {
        
        pausescript = GameObject.Find("PauseManager").GetComponent<PauseScript>().isPaused;

        if (Paused == false && !pausescript)//if this is false
        {
            Stresslevel += stressRate; //every sec the player stress level is increased by 0.5f
            Debug.Log(Stresslevel);
        }

        if (Stresslevel >= 100)
        {
            PauseGame(Paused);
        }

        if (Time.timeScale == 0)
            return;

        if (Stresslevel <= 30)
        {
            heart1.GetComponent<AudioSource>().mute = false;
            heart2.GetComponent<AudioSource>().mute = true;
            heart3.GetComponent<AudioSource>().mute = true;
        }
        else if (Stresslevel > 30 && Stresslevel <= 70)
        {
            heart1.GetComponent<AudioSource>().mute = true;
            heart2.GetComponent<AudioSource>().mute = false;
            heart3.GetComponent<AudioSource>().mute = true;
        }
        else if (Stresslevel > 70)
        {
            heart1.GetComponent<AudioSource>().mute = true;
            heart2.GetComponent<AudioSource>().mute = true;
            heart3.GetComponent<AudioSource>().mute = false;
        }
        else
        {
            faint.GetComponent<AudioSource>().mute = false;
        }
    }

     void PauseGame(bool state)
    {
            //stop stress meter 
            Debug.Log("The player fainted");
            SceneManager.LoadScene(stage);
        //pause the game and dispaly continue menu
        //continuePanel.SetActive(true);
        //Paused = true;
        //Time.timeScale = 0.0f; 
        //this.gameObject.SetActive(false);

    }

    //label gameobjects in the game scene with stress tag
    //As long as the player touches or is in area within the
    //stress zone...stress the player

    void OnTriggerEnter(Collider _collision) {
        if (_collision.gameObject.tag == "stress") //stress can be anything as long as its a stress object
        {
            Debug.Log("Stress encounter" + _collision);
            Stresslevel += 1f;

        }
        /*
        if (_collision.gameObject.tag == "mid_stress")
        {
            Debug.Log("Mid Stress Encounter" + _collision);
            Stresslevel += 5f;
        }

        //etc
        */
    }

}
