using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinController : MonoBehaviour
{
    [TextArea(1, 1)]
    public string Title;

    [TextArea(1, 4)]
    public string Description;

    PolygonCollider2D pinShape;

    GameObject MissionStatement;
    Text missionTitle;
    Text missionBody;

    // Start is called before the first frame update
    void Start()
    {
        pinShape = GetComponent<PolygonCollider2D>();
        MissionStatement = GameObject.Find("MissionStatement");
        missionTitle = GameObject.Find("MissionTitle").GetComponent<Text>();
        missionBody = GameObject.Find("MissionBody").GetComponent<Text>();
        Debug.Log(missionBody.text);
        Debug.Log(missionTitle.text);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 wpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mpos;
            mpos.x = wpos.x;
            mpos.y = wpos.y;

            if (pinShape.bounds.Contains(mpos))
            {
                if (MissionStatement.GetComponent<SlideAnimation>().show == false)
                {
                    MissionStatement.GetComponent<SlideAnimation>().show = true;
                }
                Debug.Log($"Pressed pin {name}");
                Debug.Log($"Setting title to {Title}");
                Debug.Log($"Setting body to {Description}");
                missionTitle.text = Title;
                missionBody.text = Description;
                
            }
        }
    }
}
