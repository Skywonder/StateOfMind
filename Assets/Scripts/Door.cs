using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    // Smothly open a door
    public int smooth = 20;
    public int DoorOpenAngle = -89;
    private bool open;
    private bool enter;
    public bool specialdoor = true;//door that requires completing key component to unlock
    public bool ending;
    public string stage;
    public AudioClip dooropen;
    public AudioClip doorclose;
    public AudioClip doorlocked;
    public bool locked;


    private Vector3 defaultRot;
    private Vector3 openRot;

     void Start()
    {
       
        defaultRot = transform.eulerAngles;
        openRot = new Vector3(defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);
    }

    //Main function
    void Update()
    {
        if (open && !specialdoor)
        {
            //Open door
            
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);

            if (ending)
            {
                
                SceneManager.LoadScene(stage);
            }
        }
        else if (!specialdoor)
        {
            //Close door
           
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
        }


        if (Input.GetKeyDown(KeyCode.F) && enter && !specialdoor)
        {
            AudioSource.PlayClipAtPoint(dooropen, Camera.main.transform.position);
            //dooropen.GetComponent<AudioSource>().mute = false;
            open = !open;
        }
        else if (Input.GetKeyDown(KeyCode.F) && locked)
        {
            AudioSource.PlayClipAtPoint(doorlocked, Camera.main.transform.position);
            //doorlocked.GetComponent<AudioSource>().mute = false;
        }
        
    }

    void OnGUI()
    {
        if (enter)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 30), "Press 'F' to open the door");
        }
    }

    //Activate the Main function when player is near the door
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("True");
            enter = true;
        }
    }

    //Deactivate the Main function when player is go away from door
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("False");
            enter = false;
        }
    }
}
