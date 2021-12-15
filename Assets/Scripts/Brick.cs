using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
  public UnityEvent<int> OnDestroyed;

  public int PointValue;

  public AudioClip destroyNoise;

  private AudioSource audioSource;

  public void Start()
  {
    var renderer = GetComponentInChildren<Renderer>();
    audioSource = GetComponent<AudioSource>();
    var block = new MaterialPropertyBlock();
    switch ( PointValue )
    {
      case 1:
        block.SetColor( "_BaseColor", Color.green );
        break;
      case 2:
        block.SetColor( "_BaseColor", Color.yellow );
        break;
      case 5:
        block.SetColor( "_BaseColor", Color.blue );
        break;
      default:
        block.SetColor( "_BaseColor", Color.red );
        break;
    }
    renderer.SetPropertyBlock( block );
  }

  public void OnCollisionEnter(Collision other)
  {
    OnDestroyed.Invoke( PointValue );
    audioSource.clip = destroyNoise;
    audioSource.Play();
    //slight delay to be sure the ball have time to bounce
    Destroy( gameObject, 0.2f );
  }

  public void Reset()
  {
    if ( GetComponent<AudioSource>() == null )
    {
      AudioSource audioSource = gameObject.AddComponent<AudioSource>();
      audioSource.playOnAwake = false;
      audioSource.loop = false;
    }
  }
}
