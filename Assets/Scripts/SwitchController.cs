using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour
{
    public GameObject player;
    public float activationDistance;
	public Transform handle;
	public BoxCollider col;
	float handleAngle;
    public float targetAngle = 90;
	public GameObject Light;
	public Vector3 rotationCenter;
    //public Vector3 rotationAxis = new Vector3(-0.9f, 0, 0);

    bool interactionEnabled;
    // Use this for initialization
    void Start()
    {
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
			StartCoroutine("RotateHandle");
            // Disable interaction with the door
            interactionEnabled = false;
        }
    }

    IEnumerator RotateHandle()
    {
        // Disable door panel collider - prevents awkward collision with player
        col.enabled = false;
        // Rotate until the openDoorAngle is reached
		while (handleAngle < targetAngle)
        {
            // Rotate switch
			handle.RotateAround(transform.position, transform.right, targetAngle * Time.deltaTime);
			//handle.Rotate(-transform.right,targetAngle * Time.deltaTime);
            // Update doorRotation
			handleAngle += targetAngle * Time.deltaTime;
            // Wait for one frame
            yield return null;
        }        
        // Turn on light
		Light.SetActive(true);
    }
}
