using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject _player;
    public Vector2 _followShift = new Vector2(125, -100);
    public float _followLifeTime = 2;
    private float _followLifeTimer;
    private GameObject _dialBox;
    private GameObject _dialFollowBox;
    private GameObject _quizButton;
    private GameObject _currentPNJ = null;
    private GameObject _currentImportantPNJ = null;
    private TextMeshProUGUI _currentDialogue = null;
    private TextMeshProUGUI _currentFollowDialogue = null;
    private int _quizGoodOption = 0;

    private void Awake()
    {
        _dialBox = transform.Find("DialogueBox").gameObject;
        _dialFollowBox = transform.Find("DialogueFollowBox").gameObject;
        _quizButton = transform.Find("QuizButton").gameObject;
        if (!_player)
            transform.Find("ping").gameObject.SetActive(false);
        foreach (Transform child in _dialBox.transform)
            child.gameObject.SetActive(false);
        _dialBox.SetActive(false);
        _dialFollowBox.SetActive(false);
        _quizButton.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentPNJ) {
            Vector3 wantedPos = Camera.main.WorldToScreenPoint(_currentPNJ.transform.position);
            wantedPos.x -= _followShift.x;
            wantedPos.y -= _followShift.y;
            _dialFollowBox.transform.position = wantedPos;
            _followLifeTimer -= Time.deltaTime;
            if (_followLifeTimer <= 0) {
                _followLifeTimer = _followLifeTime;
                ++_currentFollowDialogue.pageToDisplay;
                if (_currentFollowDialogue.pageToDisplay > _currentFollowDialogue.textInfo.pageCount) {
                    _currentPNJ = null;
                    _dialFollowBox.SetActive(false);
                }
            }
        }
        if (_currentImportantPNJ) {
            if (!_quizButton.activeInHierarchy && (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began))) {
                ++_currentDialogue.pageToDisplay;
                if (_currentDialogue.pageToDisplay > _currentDialogue.textInfo.pageCount) {
                    if (!_currentImportantPNJ.GetComponent<APNJTalk>().ContinueTalk()) {
                        EndDial();
                    }
                }
            }
        }
    }

    public void SimpleDial(string dial, GameObject PNJ, string talkerName)
    {
        _currentImportantPNJ = PNJ;
        if (_player) {
            _player.GetComponent<PlayerMove>().Stop();
            _player.GetComponent<PlayerMove>().enabled = false;
        }
        _dialBox.SetActive(true);
        foreach (Transform child in _dialBox.transform)
            child.gameObject.SetActive(false);
        GameObject tmp = _dialBox.transform.Find("DialBasic").gameObject;
        tmp.SetActive(true);
        tmp.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = talkerName + ":";
        _currentDialogue = tmp.transform.Find("Dialogue").GetComponent<TextMeshProUGUI>();
        _currentDialogue.text = dial;
        _currentDialogue.pageToDisplay = 1;
    }

    public void SimpleDial(string dial, GameObject PNJ)
    {
        SimpleDial(dial, PNJ, PNJ.name);
    }
    
    public void SimpleDial(string dial, GameObject PNJ, GameObject talker)
    {
        SimpleDial(dial, PNJ, talker.name);
    }

    public void ChoiceDial(string dial, string[] choice, GameObject PNJ)
    {
    }

    public void FollowDial(string dial, GameObject PNJ)
    {
        _currentPNJ = PNJ;
        _followLifeTimer = _followLifeTime;
        _dialFollowBox.SetActive(true);
        _currentFollowDialogue = _dialFollowBox.transform.Find("Dialogue").GetComponent<TextMeshProUGUI>();
        _currentFollowDialogue.text = dial;
        _currentFollowDialogue.pageToDisplay = 1;
        Vector3 wantedPos = Camera.main.WorldToScreenPoint(PNJ.transform.position);
        wantedPos.x -= _followShift.x;
        wantedPos.y -= _followShift.y;
        _dialFollowBox.transform.position = wantedPos;
    }

    public void SetQuizButton(string goodOption, string badOption)
    {
        _quizButton.SetActive(true);
        _quizGoodOption = Random.Range(0, 2);
        if (_quizGoodOption == 0) {
            _quizButton.transform.Find("QuizChoice1").Find("Text").GetComponent<TextMeshProUGUI>().text = goodOption;
            _quizButton.transform.Find("QuizChoice2").Find("Text").GetComponent<TextMeshProUGUI>().text = badOption;
        } else {
            _quizButton.transform.Find("QuizChoice1").Find("Text").GetComponent<TextMeshProUGUI>().text = badOption;
            _quizButton.transform.Find("QuizChoice2").Find("Text").GetComponent<TextMeshProUGUI>().text = goodOption;
        }
    }

    public void OnClickQuizButton(int index)
    {
        if (index == _quizGoodOption) {
            _quizButton.SetActive(false);
            if (!_currentImportantPNJ.GetComponent<APNJTalk>().ContinueTalk()) {
                EndDial();
            }
        } else {
            //bad
        }
    }

    private void EndDial()
    {
        if (_player)
            _player.GetComponent<PlayerMove>().enabled = true;
        _dialBox.SetActive(false);
        _currentDialogue = null;
        _currentImportantPNJ = null;
    }
}
