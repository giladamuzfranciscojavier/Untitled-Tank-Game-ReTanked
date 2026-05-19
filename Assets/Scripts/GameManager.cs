using System.Collections;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    static GameManager instance;

    [SerializeField] int lostScoreOnDeath;

    [SerializeField] CinemachineCamera cam;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject tankPrefab;

    [SerializeField] GenericModule hull;
    [SerializeField] GenericModule armor;
    [SerializeField] Engine engine;
    [SerializeField] GenericModule track;
    [SerializeField] Weapon pGun;
    [SerializeField] Weapon sGun;


    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] TextMeshProUGUI farmorTxt;
    [SerializeField] TextMeshProUGUI engineTxt;
    [SerializeField] TextMeshProUGUI hullTxt;
    [SerializeField] TextMeshProUGUI playerTxt;
    [SerializeField] TextMeshProUGUI ltrackTxt;
    [SerializeField] TextMeshProUGUI rtrackTxt;

    PlayerController player;
    TankController tank;

    public int Score { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else if (instance!=this) { 
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GetPlayer();
        GetTank();
        EnterTank();
    }

    public static GameManager GetInstance() 
    { 
        return instance;
    }

    public PlayerController GetPlayer() {
        if (player == null) { player = Instantiate(playerPrefab, new Vector3(0, -3, 0), Quaternion.identity).GetComponent<PlayerController>(); }
        return player;
    }

    public TankController GetTank() {
        if (tank == null) { 
            tank = Instantiate(tankPrefab, new Vector3(0, -3, 0), Quaternion.identity).GetComponent<TankController>();
            tank.hull.Setup(hull);
            tank.engine.Setup(engine);
            tank.rtrack.Setup(track);
            tank.ltrack.Setup(track);
            tank.armor.Setup(armor);
            tank.pGun.Setup(pGun);
            tank.sGun.Setup(sGun);
            tank.Setup();
            cam.Target.TrackingTarget = tank.transform;
        }
        return tank;
    }

    public void ExitTank() {
        tank.DisableControls();
        player.EnableControls();
    }

    public void EnterTank() {
        player.DisableControls();
        tank.EnableControls();
    }

    public void Die() {
        Destroy(tank);
        Destroy(player);
        if (Score > lostScoreOnDeath)
        {
            Score -= lostScoreOnDeath;
            StartCoroutine("Respawn", 1);
        }
        else {
            GameOver();
        }
    }

    public void AddScore(int score) {
        Score += score;
    }

    public Vector3 PlayerPos() {
        if (player == null) { return new Vector3(-999,-999,-999); }
        if (player.isInTank()) {
            return tank.transform.position;
        }
        else { return player.transform.position; }
    }


    IEnumerator Respawn(float time) {
        float t = 0;

        while (t < time) {
            Debug.Log(t);
            t += Time.deltaTime;
            yield return null;
        }
        Debug.Log("GO");
        GetPlayer();
        GetTank();
        EnterTank();

    }

    public void GameOver() {
        SceneManager.LoadScene(0);
    }

    private void OnGUI()
    {
        farmorTxt.text = "Front: "+tank.armor.getHP().ToString()+"("+ tank.armor.getArmor().ToString()+")";
        hullTxt.text = "Hull: "+tank.hull.getHP().ToString() + "(" + tank.hull.getArmor().ToString() + ")";
        ltrackTxt.text = "Left Track: "+tank.ltrack.getHP().ToString() + "(" + tank.ltrack.getArmor().ToString() + ")";
        rtrackTxt.text = "Right Track: "+tank.rtrack.getHP().ToString() + "(" + tank.rtrack.getArmor().ToString() + ")";
        engineTxt.text = "Engine: "+tank.engine.getHP().ToString() + "(" + tank.engine.getArmor().ToString() + ")";
        playerTxt.text = "Player: "+player.GetHealth().ToString();
        scoreTxt.text = "Score: "+Score;
    }

}
