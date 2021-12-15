using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamInfoDisplay : MonoBehaviour
{
    public Text teamNameText;
    public Text teamMembersText;
    public RawImage xEquation;
    public RawImage yEquation;
    public RawImage zEquation;

    private ObstacleData _teamData;
    public ObstacleData TeamData {
        get => _teamData;
        set {
            _teamData = value;
            if (value != null) {
                UpdateView();
            }
        }
    }

    private Image _background;

    void Awake()
    {
        _background = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateView() {
        teamNameText.text = _teamData.teamName;
        teamMembersText.text = "";
        foreach (string name in _teamData.teamMembers) {
            teamMembersText.text += name + '\n';
        }
        xEquation.texture = _teamData.xEquation;
        if (_teamData.xEquation != null) {
            xEquation.rectTransform.sizeDelta = new Vector2(40f/_teamData.xEquation.height * _teamData.xEquation.width, 40);
        }
        yEquation.texture = _teamData.yEquation;
        if (_teamData.yEquation != null) {
            yEquation.rectTransform.sizeDelta = new Vector2(40f/_teamData.yEquation.height * _teamData.yEquation.width, 40);
        }
        zEquation.texture = _teamData.zEquation;
        if (_teamData.zEquation != null) {
            zEquation.rectTransform.sizeDelta = new Vector2(40f/_teamData.zEquation.height * _teamData.zEquation.width, 40);
        }

        Color teamColor = _teamData.color;
        teamColor.a = 0.1f;
        _background.color = teamColor;
    }
}
