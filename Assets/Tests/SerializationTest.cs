using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class SerializationTest
{
  // A Test behaves as an ordinary method
  [UnityTest]
  public IEnumerator ShouldRetainTenOrLessScoresOnly()
  {
    DataController dataController = UnityEngine.Object.Instantiate( Resources.Load<DataController>( "Prefabs/DataController" ) );
    dataController.Awake();
    yield return new WaitForFixedUpdate();
    dataController.SetPlayerName( "Player" );
    yield return new WaitForFixedUpdate();
    dataController.SerializeHighScores( 1 );
    dataController.SerializeHighScores( 2 );
    dataController.SerializeHighScores( 3 );
    dataController.SerializeHighScores( 4 );
    dataController.SerializeHighScores( 5 );
    dataController.SerializeHighScores( 6 );
    dataController.SerializeHighScores( 7 );
    dataController.SerializeHighScores( 8 );
    dataController.SerializeHighScores( 9 );
    dataController.SerializeHighScores( 10 );
    var json = dataController.SerializeHighScores( 11 );
    var scores = JsonUtility.FromJson<SavedHighScores>( json );
    Assert.IsTrue( scores.SavedScores.Count <= 10 );
    Object.Destroy( dataController.gameObject );
    yield return new WaitForFixedUpdate();
  }

  [UnityTest]
  public IEnumerator PlayerNameShouldBeValidAtStart()
  {
    DataController dataController = UnityEngine.Object.Instantiate( Resources.Load<DataController>( "Prefabs/DataController" ) );
    dataController.Awake();
    yield return new WaitForFixedUpdate();
    Assert.IsFalse( string.IsNullOrWhiteSpace( dataController.GetPlayerName() ) );
    Object.Destroy( dataController.gameObject );
    yield return new WaitForFixedUpdate();
  }

  [UnityTest]
  public IEnumerator PlayerNameShouldBeValidAfterEmptyRename()
  {
    DataController dataController = UnityEngine.Object.Instantiate( Resources.Load<DataController>( "Prefabs/DataController" ) );
    dataController.Awake();
    yield return new WaitForFixedUpdate();
    dataController.SetPlayerName( "" );
    yield return new WaitForFixedUpdate();
    Assert.IsFalse( string.IsNullOrWhiteSpace( dataController.GetPlayerName() ) );
    Object.Destroy( dataController.gameObject );
    yield return new WaitForFixedUpdate();
  }

  [UnityTest]
  public IEnumerator PlayerNameShouldMatchNewName()
  {
    DataController dataController = UnityEngine.Object.Instantiate( Resources.Load<DataController>( "Prefabs/DataController" ) );
    dataController.Awake();
    yield return new WaitForFixedUpdate();
    dataController.SetPlayerName( "Jane Doe" );
    yield return new WaitForFixedUpdate();
    Assert.IsTrue( dataController.GetPlayerName().Equals( "Jane Doe" ) );
    Object.Destroy( dataController.gameObject );
    yield return new WaitForFixedUpdate();
  }
}
