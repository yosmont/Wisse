using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinController : MonoBehaviour
{
    [TextArea(1, 1)]
    public string _title;

    [TextArea(1, 4)]
    public string _description;

    [Range(1, 12)]
    public int _missionCount;

    [ExecuteInEditMode]
    public string[] _sceneNames;

    public float _moveSpeed;

    private PolygonCollider2D _pinShape;

    private GameObject _missionStatement;
    private GameObject _player;
    private Text _missionTitle;
    private Text _missionBody;

    MenuPlayerMove mpm;

    // Start is called before the first frame update
    void Start()
    {
        _pinShape = GetComponent<PolygonCollider2D>();
        _player = GameObject.Find("Player");
        mpm = _player.GetComponent<MenuPlayerMove>();
        _missionStatement = GameObject.Find("MissionStatement");
        _missionTitle = GameObject.Find("MissionTitle").GetComponent<Text>();
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

            if (_pinShape.bounds.Contains(mpos))
            {
                _player.transform.position = Vector3.MoveTowards(_player.transform.position, transform.position, _moveSpeed * Time.deltaTime);
                if (_missionStatement.GetComponent<SlideAnimation>()._show == false)
                {
                    _missionStatement.GetComponent<SlideAnimation>()._show = true;
                }
                Debug.Log($"Pressed pin {name}");
                Debug.Log($"Setting title to {_title}");
                _missionStatement.GetComponentInChildren<MissionNodes>()._nodeCount = _missionCount;
                _missionStatement.GetComponentInChildren<MissionNodes>()._prefix = name;
                Debug.Log($"Setting Nodecount to {_missionStatement.GetComponentInChildren<MissionNodes>()._nodeCount}");
                mpm._destination = new Vector3(transform.position.x - 0.8f, transform.position.y + 0.65f, transform.position.z);
                mpm._moving = true;
                Debug.Log("Move player to pin coordinates");
                _missionTitle.text = _title;
                
            }
        }
    }
}
