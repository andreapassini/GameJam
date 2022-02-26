using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float StartingHealth = 100f;

    private float _health;

    private Animator _animator;
    public GameObject ParticleDeath;


    void Start()
    {
        _health = StartingHealth;

        _animator = GetComponent<Animator>();
        //_source = GetComponent<AudioSource>();
    }

	public void Die()
	{
        Instantiate(ParticleDeath, transform.position, Quaternion.identity);

        // PLay animation
        _animator.SetBool("isDead", true);

        // Destroy the object
        Destroy(gameObject);
	}
}
