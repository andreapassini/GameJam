using UnityEngine;
using System.Collections;

public class TextSound : MonoBehaviour
{
    public float waitTime = 3f;

    public AudioSource AudioSource;

    private void Start()
    {
        StartCoroutine(PatrolSound());
    }

    public IEnumerator PatrolSound()
    {
        while (true)
        {
            AudioSource.Play();

            yield return new WaitForSeconds(waitTime);
        }
        
    }
}
