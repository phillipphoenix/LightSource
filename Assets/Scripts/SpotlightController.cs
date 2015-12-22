using UnityEngine;
using System.Collections;

public class SpotlightController : MonoBehaviour
{
    public Light spotlight;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            spotlight.color = Color.red;
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            spotlight.color = Color.green;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            spotlight.color = Color.blue;
        }
    }
}
