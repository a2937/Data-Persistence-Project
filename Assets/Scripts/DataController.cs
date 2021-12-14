using System.Collections.Generic;
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
  public string SerializeHighScores(long score)
  {
    CurrentUser.Score = score;
    if ( AllScores.TopEntry.Score < CurrentUser.Score )
    {
      AllScores.TopEntry = CurrentUser;
      AllScores.SavedScores.Add( CurrentUser );
      var properScoreList = new List<UserData>();
      for ( int i = 0; i < 10 && i < AllScores.SavedScores.Count; i++ )
      {
        properScoreList.Add( AllScores.SavedScores[i] );
      }
      AllScores.SavedScores = properScoreList;
    }
    return JsonUtility.ToJson( AllScores );
  }

  public void SaveScores(long score)
  {
    string serializedData = SerializeHighScores( score );
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

  public string GetPlayerName()
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
    else
    {
      AllScores = new SavedHighScores();
    }
  }
}
