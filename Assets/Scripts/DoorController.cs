using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public string nextLevel;
    public GameObject player;
    public float activationDistance;
    Transform door;
    BoxCollider doorPanelCollider;
    public AudioSource soundEffect;
    float doorRotation;
    public float openDoorAngle = 90;
    public Vector3 rotationAxis = new Vector3(-0.9f, 0, 0);

    bool interactionEnabled;
    // Use this for initialization
    void Start()
    {
        door = transform.FindChild("Inside");
        doorPanelCollider = door.FindChild("panel").GetComponent<BoxCollider>();
        doorRotation = 0;
        interactionEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player pressed E and is close enough to interact with the door
        bool keyPressed = Input.GetKeyDown(KeyCode.E);
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (interactionEnabled && keyPressed && dist < activationDistance)
        {
            // Start coroutine that handles door animation and scene loading
            StartCoroutine("OpenDoor");
            // Disable interaction with the door
            interactionEnabled = false;
        }
    }

    IEnumerator OpenDoor()
    {
        // Disable door panel collider - prevents awkward collision with player
        doorPanelCollider.enabled = false;
        // Start sound effect
        soundEffect.Play();
        // Rotate until the openDoorAngle is reached
        while (doorRotation < openDoorAngle)
        {
            // Rotate door inside
            door.RotateAround(transform.position + rotationAxis, Vector3.up, openDoorAngle * Time.deltaTime);
            
            // Update doorRotation
            doorRotation += openDoorAngle * Time.deltaTime;
            // Wait for one frame
            yield return null;
        }        
        // Suspend execution for 2 seconds
        yield return new WaitForSeconds(2);
        // Load next level
        Application.LoadLevel(nextLevel);
    }
}
