using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public AudioClip mainMenuSong;

	void PlaySound()
	{
		audio.clip = mainMenuSong;
		audio.Play();
	}

	void onMouseDown()
	{

       // PlayerPrefs.SetInt("Level Completed", 0);
        //Application.LoadLevel(1);
	}

	bool moving = false;
	GameObject go;

	void Start()
	{
		audio.Play();
	}

	void Update(){
		if(Input.GetButtonDown("w"))
		{

			PlayerPrefs.SetInt("Level Completed", 0);
			Application.LoadLevel(1);
		}

		if (Input.GetKeyDown ("space")) 
		{
			
			PlayerPrefs.SetInt("Level Completed", 0);
			Application.LoadLevel(1);
		}

		if(Input.touchCount == 1)
		{    
			// touch on screen
			if(Input.GetTouch(0).phase == TouchPhase.Began)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
				RaycastHit hit = new RaycastHit();
				moving = Physics.Raycast (ray, out hit);
				if(moving)
				{
                    PlayerPrefs.SetInt("Level Completed", 0);
                    Application.LoadLevel(1);
				}
				
			}
			
			
			// release touch/dragging
			if((Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled) && go != null)
			{
                PlayerPrefs.SetInt("Level Completed", 0);
                Application.LoadLevel(1);
				moving = false;
				Debug.Log("Touch Released from : "+go.name);
			}
		}    
	}


   // void OnGUI()
  //  {
     //   GUI.skin = skin;
     //   GUI.Label(new Rect(10, 10, 400, 75), "Go Home");
     //   if (PlayerPrefs.GetInt("Level Completed") > 0)
      //  {
      //      if (GUI.Button(new Rect(10, 100, 100, 45), "Continue"))
       //     {
        //        Application.LoadLevel(PlayerPrefs.GetInt("Level Completed"));
       //     }
       // }
       // if (GUI.Button(new Rect(10, 155, 100, 45), "New Game"))
     //   {
     //       PlayerPrefs.SetInt("Level Completed", 0);
     //       Application.LoadLevel(0);
    //    }
    //    if (GUI.Button(new Rect(10, 210, 100, 45), "Quit"))
    //    {
    //        Application.Quit();
    //    }

    //}
}
