using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voiceCommands : MonoBehaviour
{
    public AudioSource[] geluiden;
    bool isDone;
    bool started = false; 
    int prev;

    // Start is called before the first frame update
    void Start()
    {
        isDone = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDone && started)
        {
            isDone = false;
            StartCoroutine(playerRandomSound());
        }
    }

    public IEnumerator playerRandomSound()
    {
        int randomAudio = Random.Range(0, geluiden.Length);
        while (randomAudio == prev)
        {
            randomAudio = Random.Range(0, geluiden.Length);
        }
        prev = randomAudio;
        yield return new WaitForSeconds(Random.Range(3,9));
        geluiden[randomAudio].Play();
        isDone = true;
    }

    public void start()
    {
        started = true;
    }
    public void stop()
    {
        started = false;
    }
}
