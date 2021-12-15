using UnityEngine;

public class Ball : MonoBehaviour
{
  private Rigidbody Rigidbody;

  private AudioSource BounceSoundEffect;

  public void Start()
  {
    Rigidbody = GetComponent<Rigidbody>();
    BounceSoundEffect = GetComponent<AudioSource>();
  }

  public void OnCollisionExit(Collision other)
  {
    if ( other.gameObject.GetComponent<Brick>() == null )
    {
      // If it's a brick; the bounce sound will override the break sound.
      BounceSoundEffect.Play();
    }

    var velocity = Rigidbody.velocity;
    //after a collision we accelerate a bit
    velocity += velocity.normalized * 0.01f;

    //check if we are not going totally vertically as this would lead to being stuck, we add a little vertical force
    if ( Vector3.Dot( velocity.normalized, Vector3.up ) < 0.1f )
    {
      velocity += velocity.y > 0 ? Vector3.up * 0.5f : Vector3.down * 0.5f;
    }

    //max velocity
    if ( velocity.magnitude > 3.0f )
    {
      velocity = velocity.normalized * 3.0f;
    }

    Rigidbody.velocity = velocity;
  }

  public void Reset()
  {
    if ( GetComponent<Rigidbody>() == null )
    {
      gameObject.AddComponent<Rigidbody>();
    }
    if ( GetComponent<AudioSource>() == null )
    {
      AudioSource audioSource = gameObject.AddComponent<AudioSource>();
      audioSource.playOnAwake = false;
      audioSource.loop = false;
    }
  }
}
