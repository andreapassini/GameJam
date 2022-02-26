using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float StartingHealth = 100f;

    private float _health;

    private Animator _animator;
    [SerializeField] private AudioSource _source;


    void Start()
    {
        _health = StartingHealth;

        _animator = GetComponent<Animator>();
        //_source = GetComponent<AudioSource>();
    }

	private void Update()
	{
        if (Input.GetMouseButtonDown(1))
            Die();
	}

	public void Die()
	{
        _source.Play();

        // PLay animation
        _animator.SetBool("isDead", true);

        // Destroy the object
        Destroy(gameObject);
	}
}
