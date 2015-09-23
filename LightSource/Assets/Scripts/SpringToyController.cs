using UnityEngine;
using System.Collections;

public class SpringToyController : MonoBehaviour
{
    public GameObject player;
    bool interactionEnabled;
    public float springDistance = 10;
    public float maxAngle = 25;
    public float angleInc = 1;
    public float posInc = 1;
    public GameObject spring;
    public Transform segment1;
    public Transform segment2;
    public Transform segment3;
    public Transform segment4;
    public Transform segment5;

    // Use this for initialization
    void Start()
    {
        interactionEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(interactionEnabled && Vector3.Distance(transform.position, player.transform.position) < springDistance)
        {
            // Start animation
            StartCoroutine("SpringHead");
            // Disable interaction
            interactionEnabled = false;
        }
    }

    IEnumerator SpringHead()
    {
        // Reveal phase
        spring.SetActive(true);
        while(spring.transform.localPosition.y < 0)
        {            
            spring.transform.position += new Vector3(0, posInc, 0);
            yield return null;
        }

        // Rotation phase
        float currentAngle = 0;
        float sign = 1;

        while(true)
        {
            // Rotate
            segment1.RotateAround(segment1.position, transform.right, sign * angleInc);
            segment2.RotateAround(segment2.position, transform.right, sign * angleInc);
            segment3.RotateAround(segment3.position, transform.right, sign * angleInc);
            segment4.RotateAround(segment4.position, transform.right, sign * angleInc);
            segment5.RotateAround(segment5.position, transform.right, sign * angleInc);
            currentAngle += sign * angleInc;
            // Change rotation direction if the max angle has been reached
            if(Mathf.Abs(currentAngle) >= maxAngle)
            {
                sign *= -1;
            }
            yield return null;
        }
    }
}
