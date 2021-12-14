using System.IO;
using UnityEngine;

public class DataController : MonoBehaviour
{
  public static DataController Instance;

  private UserData CurrentUser;

  private SavedHighScores AllScores;

  public void Awake()
  {
    if ( Instance != null && Instance != this )
    {
      Destroy( this.gameObject );
      return;
    }
    DontDestroyOnLoad( this.gameObject );
    CurrentUser = new UserData();
    AllScores = new SavedHighScores();
    Instance = this;
    LoadSaveData();
  }

  public void SetPlayerName(string name)
  {
    if ( string.IsNullOrWhiteSpace( name ) )
    {
      CurrentUser.UserName = "Player";
    }
    else
    {
      CurrentUser.UserName = name;
    }
  }

  public void SaveScores(long score)
  {
    CurrentUser.HighScore = score;
    if ( AllScores.TopEntry.HighScore < CurrentUser.HighScore )
    {
      AllScores.TopEntry = CurrentUser;
    }
    else
    {
      AllScores.SavedScores.Add( CurrentUser );
      AllScores.SavedScores = AllScores.SavedScores.GetRange( 0, 10 );
    }
    var serializedData = JsonUtility.ToJson( AllScores );
    File.WriteAllText( Application.persistentDataPath + "/highScores.json", serializedData );
  }

  public UserData GetTopScoreEntry()
  {
    if ( AllScores.TopEntry == null )
    {
      return new UserData();
    }
    else
    {
      return AllScores.TopEntry;
    }
  }

  public SavedHighScores GetSavedHighScores()
  {
    return AllScores;
  }

  public string GetCurrentUserName()
  {
    return CurrentUser.UserName;
  }

  public void LoadSaveData()
  {
    if ( File.Exists( Application.persistentDataPath + "/highScores.json" ) )
    {
      var data = File.ReadAllText( Application.persistentDataPath + "/highScores.json" );
      AllScores = JsonUtility.FromJson<SavedHighScores>( data );
    }
  }
}
