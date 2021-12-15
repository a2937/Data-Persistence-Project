using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainManager : MonoBehaviour
{
  public Brick BrickPrefab;
  public int LineCount = 6;
  public Rigidbody Ball;

  public TextMeshProUGUI TopScoreText;
  public TextMeshProUGUI ScoreText;
  public TextMeshProUGUI GameOverText;

  private bool m_Started = false;
  private int m_Points;

  private bool m_GameOver = false;

  private DataController DataController;

  private UserData TopScoreEntry;

  private string CurrentName = "";
  // Start is called before the first frame update
  public void Start()
  {
    DataController = DataController.Instance;
    CurrentName = DataController.GetPlayerName();
    GameOverText.gameObject.SetActive( false );
    const float step = 0.6f;
    int perLine = Mathf.FloorToInt( 4.0f / step );
    TopScoreEntry = DataController.GetTopScoreEntry();
    TopScoreText.text = "Best Score: " + TopScoreEntry.UserName + " : " + TopScoreEntry.Score;
    int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
    for ( int i = 0; i < LineCount; ++i )
    {
      for ( int x = 0; x < perLine; ++x )
      {
        Vector3 position = new Vector3( -1.5f + (step * x), 2.5f + (i * 0.3f), 0 );
        var brick = Instantiate( BrickPrefab, position, Quaternion.identity );
        brick.PointValue = pointCountArray[i];
        brick.OnDestroyed.AddListener( AddPoint );
      }
    }
  }

  public void Update()
  {
    if ( !m_Started )
    {
      if ( Input.GetButtonDown( "Restart" ) )
      {
        m_Started = true;
        float randomDirection = Random.Range( -1.0f, 1.0f );
        Vector3 forceDir = new Vector3( randomDirection, 1, 0 );
        forceDir.Normalize();

        Ball.transform.SetParent( null );
        Ball.AddForce( forceDir * 2.0f, ForceMode.VelocityChange );
      }
    }
    else if ( m_GameOver )
    {
      DataController.SaveScores( m_Points );
      if ( Input.GetButtonDown( "Restart" ) )
      {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
      }
    }
  }

  public void AddPoint(int point)
  {
    m_Points += point;
    ScoreText.text = $"Score : {CurrentName} : {m_Points}";
    if ( m_Points > TopScoreEntry.Score )
    {
      TopScoreText.text = "Best Score: " + CurrentName + " : " + m_Points;
    }
  }

  public void GameOver()
  {
    m_GameOver = true;
    GameOverText.gameObject.SetActive( true );
  }
}
