using UnityEngine;

public class EffectObject : MonoBehaviour
{
    public float duration;

    void Start()
    {
        Destroy(gameObject, duration);
    }
}
