using NUnit.Framework;
using System.Collections;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;

public class DisplayTests
{
  private const string bestScorePattern = @"Best Score: Player : \d+";

  private const string scorePattern = @"Score : Player : \d+";

  [Test]
  public void EnsureScorePatternOnlyMatchesOneLine()
  {
    Regex regex = new Regex( scorePattern );
    Assert.False( regex.IsMatch( @"Score : Player : \n 100" ) );
  }

  [Test]
  public void EnsureBestScorePatternOnlyMatchesOneLine()
  {
    Regex regex = new Regex( bestScorePattern );
    Assert.False( regex.IsMatch( @"Best Score : Player : \n 100" ) );
  }

  [UnityTest]
  public IEnumerator HighScoreDisplayShouldOnlyBeOneLineAtStart()
  {
    DataController dataController = Object.Instantiate( Resources.Load<DataController>( "Prefabs/DataController" ) );
    dataController.Awake();
    yield return new WaitForFixedUpdate();
    MainManager mainManager = Object.Instantiate( Resources.Load<MainManager>( "Prefabs/MainManager" ) );
    mainManager.TopScoreText = Object.Instantiate( Resources.Load<TextMeshProUGUI>( "Prefabs/Top Score" ) );
    mainManager.ScoreText = Object.Instantiate( Resources.Load<TextMeshProUGUI>( "Prefabs/Score Text" ) );
    mainManager.GameOverText = Object.Instantiate( Resources.Load<TextMeshProUGUI>( "Prefabs/Game Over Text" ) );
    mainManager.Start();
    yield return new WaitForFixedUpdate();
    Regex regex = new Regex( bestScorePattern );
    try
    {
      Assert.IsTrue( regex.IsMatch( mainManager.TopScoreText.text ) );
    }
    catch
    {
      Debug.LogError( mainManager.TopScoreText.text );
      throw;
    }
    Object.Destroy( dataController );
    yield return new WaitForFixedUpdate();
  }


  [UnityTest]
  public IEnumerator HighScoreDisplayShouldOnlyBeOneLineInPlay()
  {
    DataController dataController = Object.Instantiate( Resources.Load<DataController>( "Prefabs/DataController" ) );
    dataController.Awake();
    yield return new WaitForFixedUpdate();
    MainManager mainManager = Object.Instantiate( Resources.Load<MainManager>( "Prefabs/MainManager" ) );
    mainManager.TopScoreText = Object.Instantiate( Resources.Load<TextMeshProUGUI>( "Prefabs/Top Score" ) );
    mainManager.ScoreText = Object.Instantiate( Resources.Load<TextMeshProUGUI>( "Prefabs/Score Text" ) );
    mainManager.GameOverText = Object.Instantiate( Resources.Load<TextMeshProUGUI>( "Prefabs/Game Over Text" ) );
    mainManager.Start();
    yield return new WaitForFixedUpdate();
    mainManager.AddPoint( 99 );
    yield return new WaitForFixedUpdate();
    Regex regex = new Regex( bestScorePattern );
    try
    {
      Assert.IsTrue( regex.IsMatch( mainManager.TopScoreText.text ) );
    }
    catch
    {
      Debug.LogError( mainManager.TopScoreText.text );
      throw;
    }
    Object.Destroy( dataController );
    yield return new WaitForFixedUpdate();
  }

  [UnityTest]
  public IEnumerator ScoreDisplayShouldOnlyBeOneLineAtStart()
  {
    DataController dataController = Object.Instantiate( Resources.Load<DataController>( "Prefabs/DataController" ) );
    dataController.Awake();
    yield return new WaitForFixedUpdate();
    MainManager mainManager = Object.Instantiate( Resources.Load<MainManager>( "Prefabs/MainManager" ) );
    mainManager.ScoreText = Object.Instantiate( Resources.Load<TextMeshProUGUI>( "Prefabs/Score Text" ) );
    mainManager.TopScoreText = Object.Instantiate( Resources.Load<TextMeshProUGUI>( "Prefabs/Top Score" ) );
    mainManager.GameOverText = Object.Instantiate( Resources.Load<TextMeshProUGUI>( "Prefabs/Game Over Text" ) );
    mainManager.Start();
    yield return new WaitForFixedUpdate();
    Regex regex = new Regex( scorePattern );
    try
    {
      Assert.IsTrue( regex.IsMatch( mainManager.ScoreText.text ) );
    }
    catch
    {
      Debug.LogError( mainManager.ScoreText.text );
      throw;
    }
    Object.Destroy( dataController );
    yield return new WaitForFixedUpdate();
  }

  [UnityTest]
  public IEnumerator ScoreDisplayShouldOnlyBeOneLineDuringGamePlay()
  {
    DataController dataController = Object.Instantiate( Resources.Load<DataController>( "Prefabs/DataController" ) );
    dataController.Awake();
    yield return new WaitForFixedUpdate();
    MainManager mainManager = Object.Instantiate( Resources.Load<MainManager>( "Prefabs/MainManager" ) );
    mainManager.ScoreText = Object.Instantiate( Resources.Load<TextMeshProUGUI>( "Prefabs/Score Text" ) );
    mainManager.TopScoreText = Object.Instantiate( Resources.Load<TextMeshProUGUI>( "Prefabs/Top Score" ) );
    mainManager.GameOverText = Object.Instantiate( Resources.Load<TextMeshProUGUI>( "Prefabs/Game Over Text" ) );
    mainManager.Start();
    yield return new WaitForFixedUpdate();
    mainManager.AddPoint( 99 );
    yield return new WaitForFixedUpdate();
    Regex regex = new Regex( scorePattern );
    try
    {
      Assert.IsTrue( regex.IsMatch( mainManager.ScoreText.text ) );
    }
    catch
    {
      Debug.LogError( mainManager.ScoreText.text );
      throw;
    }
    Object.Destroy( dataController );
    yield return new WaitForFixedUpdate();
  }


  [UnityTest]
  public IEnumerator GameOverTextShouldNotBeVisibleDuringNormalPlay()
  {
    DataController dataController = Object.Instantiate( Resources.Load<DataController>( "Prefabs/DataController" ) );
    dataController.Awake();
    yield return new WaitForFixedUpdate();
    MainManager mainManager = Object.Instantiate( Resources.Load<MainManager>( "Prefabs/MainManager" ) );
    mainManager.ScoreText = Object.Instantiate( Resources.Load<TextMeshProUGUI>( "Prefabs/Score Text" ) );
    mainManager.TopScoreText = Object.Instantiate( Resources.Load<TextMeshProUGUI>( "Prefabs/Top Score" ) );
    mainManager.GameOverText = Object.Instantiate( Resources.Load<TextMeshProUGUI>( "Prefabs/Game Over Text" ) );
    mainManager.GameOverText.gameObject.SetActive( true );
    mainManager.Start();
    yield return new WaitForFixedUpdate();
    Assert.IsFalse( mainManager.GameOverText.gameObject.activeInHierarchy );
    Object.Destroy( dataController );
    yield return new WaitForFixedUpdate();
  }

  [UnityTest]
  public IEnumerator GameOverTextShouldBeVisibleWhenItIsGameOver()
  {
    DataController dataController = Object.Instantiate( Resources.Load<DataController>( "Prefabs/DataController" ) );
    dataController.Awake();
    yield return new WaitForFixedUpdate();
    MainManager mainManager = Object.Instantiate( Resources.Load<MainManager>( "Prefabs/MainManager" ) );
    mainManager.ScoreText = Object.Instantiate( Resources.Load<TextMeshProUGUI>( "Prefabs/Score Text" ) );
    mainManager.TopScoreText = Object.Instantiate( Resources.Load<TextMeshProUGUI>( "Prefabs/Top Score" ) );
    mainManager.GameOverText = Object.Instantiate( Resources.Load<TextMeshProUGUI>( "Prefabs/Game Over Text" ) );
    mainManager.Start();
    yield return new WaitForFixedUpdate();
    mainManager.GameOver();
    Assert.IsTrue( mainManager.GameOverText.gameObject.activeInHierarchy );
    Object.Destroy( dataController );
    yield return new WaitForFixedUpdate();
  }
}
