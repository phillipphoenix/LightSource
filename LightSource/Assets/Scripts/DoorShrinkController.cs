using UnityEngine;
using System.Collections;

public class DoorShrinkController : MonoBehaviour {

    public float startingDistance = 100;
    public float endingDistance = 10;
    public Vector3 startScale = new Vector3(100, 100, 100);
    public GameObject player;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        if(dist >= startingDistance)
        {
            transform.localScale = Vector3.one + startScale;
        }
        else if (dist < endingDistance)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            float frac = Mathf.Abs(dist - endingDistance) / Mathf.Abs(startingDistance - endingDistance);
            transform.localScale = Vector3.one + startScale * Mathf.Pow(frac, 2);
        }
    }
}
