using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Objects/ObstacleData")]
public class ObstacleData : ScriptableObject
{
    public string teamName;
    public List<string> teamMembers;
    public bool isFirstPeriod;
    public Color color;
    public Material material;
    public Texture xEquation;
    public Texture yEquation;
    public Texture zEquation;
}
