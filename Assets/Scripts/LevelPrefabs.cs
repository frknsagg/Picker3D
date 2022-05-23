using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ListLevel",menuName = "ListLevel")]
public class LevelPrefabs : ScriptableObject
{
   public List<GameObject> LevelList;
}
