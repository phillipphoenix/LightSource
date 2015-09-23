using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CylinderToyController : MonoBehaviour
{
    public float permutationDistance = 30;
    public GameObject player;
    public List<GameObject> cylinders;
    List<Vector3> positions;
    public bool useSoundEffect = true;

    AudioSource soundEffect;
    bool playerFar;

    // Use this for initialization
    void Start()
    {
        positions = new List<Vector3>();
        // Store initial cylinder positions
        foreach (GameObject c in cylinders)
        {
            positions.Add(c.transform.position);
        }
        // Initialise state flag
        playerFar = true;

        // Get AudioSource component
        soundEffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerFar && Vector3.Distance(player.transform.position, transform.position) < permutationDistance)
        {            
            playerFar = false;
        }
        else if(!playerFar && Vector3.Distance(player.transform.position, transform.position) >= permutationDistance)
        {
            PermutateCylinders();
            if(useSoundEffect && !soundEffect.isPlaying)
            {
                soundEffect.Play();
            }
            
            playerFar = true;
        }
    }

    void PermutateCylinders()
    {
        // Initialise game object index
        int goIndex = 0;
        for (int i = cylinders.Count - 1; i >= 0; --i)
        {
            // Take one of the remaining positions at random
            int posIndex = Random.Range(0, i);
            // Assign that position to one of the cylinders
            cylinders[goIndex].transform.position = positions[posIndex];
            // Remove position from list
            positions.RemoveAt(posIndex);
            // Increments game object index
            ++goIndex;
        }
        // Store positions in list
        foreach (GameObject c in cylinders)
        {
            positions.Add(c.transform.position);
        }
    }
}
