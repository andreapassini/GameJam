using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeVariation : MonoBehaviour
{
    public float MinTime;
    public float MaxTime;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        StartCoroutine(ReScale());
    }
    public IEnumerator ReScale()
    {
        while (true)
        {
            switch (Random.Range(0, 4)) 
            {
                case 0:
                    _animator.SetTrigger("0");
                    break;

                case 1:
                    _animator.SetTrigger("1");
                    break;

                case 2:
                    _animator.SetTrigger("2");
                    break;

                case 3:
                    _animator.SetTrigger("3");
                    break;

                case 4:
                    _animator.SetTrigger("4");
                    break;
            }

            yield return new WaitForSeconds(Random.Range(MinTime, MaxTime));
        }
        
    }
}
