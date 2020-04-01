using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatInterface : MonoBehaviour
{
    // Is player in the boat
    [SerializeField]
    private bool inBoat = false;

    // Is player in range of boat
    [SerializeField]
    private bool nearBoat = false;

    // Boat to enter/exit
    [SerializeField]
    private GameObject boat;

    // OVRPlayerController inside boat
    public GameObject boatPlayer;

    // Boat transform before being entered
    private Transform boatTrans;

    // Player transform before entering boat
    private Transform playerTrans;

    // On land movement script
    private OVRPlayerController playerMovement;

    // Boat movement script
    private SimpleCapsuleWithStickMovement boatMovement;

    void Start()
    {
        playerTrans = transform;
        playerMovement = GetComponent<OVRPlayerController>();
    }

    void Update()
    {
        
         
        // If player presses a main button, they either enter or exit the boat
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            
            // Runs if player is standing near boat
            if (inBoat == false && nearBoat == true)
            {
                /* Tracking space freaks out and the player's transform changes but doesn't match what was set
                 * Temporarily changing over to a two ovr player controller toggle system
                 
                // Record player location prior to entering
                playerTrans = transform;

                // Record boat location prior to being entered
                boatTrans = boat.transform;

                // Turn off player movement
                playerMovement.enabled = false;

                // Turn on boat movement
                boatMovement.enabled = true;

                // Parent player to boat
                transform.parent = boatTrans;

                // Move player to boat
                transform.position = boatTrans.position;
                inBoat = true;
                */

                // Made two seperate ovr player controllers to toggle between, one stand alone and another parented to a boat
                boatPlayer.SetActive(true);
                gameObject.SetActive(false);

                Debug.Log("Entered boat!");
            }        
            // Runs if player is already in boat
            else if (inBoat == true)
            {
                inBoat = false;

                /*
                // Unparent player from boat
                transform.parent = null;

                // Moves player back to where they entered the boat
                transform.position = playerTrans.position;

                // Moves and orients boat back to where it was when entered
                boat.transform.position = boatTrans.position;
                boat.transform.rotation = boatTrans.rotation;

                playerMovement.enabled = true;

                boatMovement.enabled = false;
                */

                GameObject.FindGameObjectWithTag("Player").SetActive(true);
                gameObject.SetActive(false);

                Debug.Log("Can find Player: " + (GameObject.FindGameObjectWithTag("Player") == null));
                Debug.Log("Exit boat!");
            }

            Debug.Log("Got A down!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "boat")
        {
            boat = other.gameObject;
            Debug.Log("Is boatPlayer null: " + (boatPlayer == null));
            // boatMovement = boat.GetComponent<SimpleCapsuleWithStickMovement>();
            nearBoat = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "boat")
        {
            nearBoat = false;
        }
    }

}
