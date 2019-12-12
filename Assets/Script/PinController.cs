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

    [ExecuteInEditMode]
    public string[] SceneNames;

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
                MissionStatement.GetComponentInChildren<MissionNodes>().prefix = name;
                Debug.Log($"Setting Nodecount to {MissionStatement.GetComponentInChildren<MissionNodes>().NodeCount}");
                mpm.destination = new Vector3(transform.position.x - 0.8f, transform.position.y + 0.65f, transform.position.z);
                mpm.moving = true;
                Debug.Log("Move player to pin coordinates");
                missionTitle.text = Title;
                
            }
        }
    }
}
