using TMPro;
using UnityEngine;

public class HighScoreListController : MonoBehaviour
{
  public RectTransform ScoreListParent;

  private DataController DataController;

  public float yOffsetInterval = 5;
  public void Start()
  {
    DataController = DataController.Instance;
    GenerateHighScoreList();
  }

  public void GenerateHighScoreList()
  {
    var savedScores = DataController.GetSavedHighScores().SavedScores;
    for ( var i = 0; i < 10 && i < savedScores.Count; i++ )
    {
      var scoreText = Instantiate( new GameObject(), ScoreListParent.transform )
                      .AddComponent<TextMeshProUGUI>();
      scoreText.gameObject.name = "Score: " + i;
      var position = scoreText.transform.position;
      scoreText.transform.position = new Vector3( position.x, position.y - (yOffsetInterval * i), position.z );
      scoreText.text = savedScores[i].UserName + " : " + savedScores[i].HighScore;
    }
  }
}
