using System;
using System.Collections.Generic;

[Serializable]
public class SavedHighScores
{
  public UserData TopEntry = new UserData();

  public List<UserData> SavedScores = new List<UserData>();
}
