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

    [Range(1, 12)]
    public int MissionCount;

    public float moveSpeed;

    PolygonCollider2D pinShape;

    GameObject MissionStatement;
    GameObject player;
    Text missionTitle;
    Text missionBody;

    MenuPlayerMove mpm;

    // Start is called before the first frame update
    void Start()
    {
        pinShape = GetComponent<PolygonCollider2D>();
        player = GameObject.Find("Player");
        mpm = player.GetComponent<MenuPlayerMove>();
        MissionStatement = GameObject.Find("MissionStatement");
        missionTitle = GameObject.Find("MissionTitle").GetComponent<Text>();
        //missionBody = GameObject.Find("MissionBody").GetComponent<Text>();
        //Debug.Log(missionBody.text);
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
                player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, moveSpeed * Time.deltaTime);
                if (MissionStatement.GetComponent<SlideAnimation>().show == false)
                {
                    MissionStatement.GetComponent<SlideAnimation>().show = true;
                }
                Debug.Log($"Pressed pin {name}");
                Debug.Log($"Setting title to {Title}");
                MissionStatement.GetComponentInChildren<MissionNodes>().NodeCount = MissionCount;
                Debug.Log($"Setting Nodecount to {MissionStatement.GetComponentInChildren<MissionNodes>().NodeCount}");
                mpm.destination = new Vector3(transform.position.x - 0.6f, transform.position.y - 0.2f, transform.position.z);
                mpm.moving = true;
                Debug.Log("Move player to pin coordinates");
                missionTitle.text = Title;
                
            }
        }
    }
}
