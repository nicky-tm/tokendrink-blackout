using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerup : MonoBehaviour
{
    bool eventStarted = false;

    public Text type;
    string TypeString = "type";

    public Text year;
    string Year = "S18";

    public Text succeed;
    string SucceedString = "S18";
    public Text typeActivated;
    string TypeActivated = "Type activated";

    public Text defeat;
    string DefeatString = "S18";
    public Text typeFailed;
    string TypeFailed = "Type failed";

    public Text beer;
    public Text bigBeer;
    public int BeerCurrent = 7;
    public int BeerGoal = 29;

    public Text soda;
    public Text bigSoda;
    public int SodaCurrent = 15;
    public int SodaGoal = 17;

    public Image time;
    public float timeLeft = 120.0f;
    float timeMax;
    float loadTime = 0.5f;
    

    float loadBeer = 0.3f;
    float loadSoda = 0.7f;

    private GameObject _smallBeer = null;
    private string _smallBeerName;


    public GameObject SmallBeer {
        get {
            if (_smallBeer == null) {
                _smallBeer = GameObject.Find(_smallBeerName);
            }
            return _smallBeer;
        }
        set {
            _smallBeer = value;
            _smallBeerName = value.name;
        }
    }

    private GameObject _smallSoda = null;
    private string _smallSodaName;

    public GameObject SmallSoda {
        get {
            if (_smallSoda == null) {
                _smallSoda = GameObject.Find(_smallSodaName);
            }
            return _smallSoda;
        }
        set {
            _smallSoda = value;
            _smallSodaName = value.name;
        }
    }

    private GameObject _bigBeer = null;
    private string _bigBeerName;

    public GameObject BigBeer {
        get {
            if (_bigBeer == null) {
                _bigBeer = GameObject.Find(_bigBeerName);
            }
            return _bigBeer;
        }
        set {
            _bigBeer = value;
            _bigBeerName = value.name;
        }
    }

    private GameObject _bigSoda = null;
    private string _bigSodaName;

    public GameObject BigSoda {
        get {
            if (_bigSoda == null) {
                _bigSoda = GameObject.Find(_bigSodaName);
            }
            return _bigSoda;
        }
        set {
            _bigSoda = value;
            _bigSodaName = value.name;
        }
    }

    private GameObject _type = null;
    private string _typeName;

    public GameObject Type {
        get {
            if (_type == null) {
                _type = GameObject.Find(_typeName);
            }
            return _type;
        }
        set {
            _type = value;
            _typeName = value.name;
        }
    }

    private GameObject _timeProgress = null;
    private string _timeProgressName;

    public GameObject TimeProgress {
        get {
            if (_timeProgress == null) {
                _timeProgress = GameObject.Find(_timeProgressName);
            }
            return _timeProgress;
        }
        set {
            _timeProgress = value;
            _timeProgressName = value.name;
        }
    }

    private GameObject _loadingBar = null;
    private string _loadingBarName;

    public GameObject LoadingBar {
        get {
            if (_timeProgress == null) {
                _timeProgress = GameObject.Find(_timeProgressName);
            }
            return _timeProgress;
        }
        set {
            _timeProgress = value;
            _timeProgressName = value.name;
        }
    }

    private GameObject _succeed = null;
    private string _succeedName;

    public GameObject Succeed {
        get {
            if (_succeed == null) {
                _succeed = GameObject.Find(_succeedName);
            }
            return _succeed;
        }
        set {
            _succeed = value;
            _succeedName = value.name;
        }
    }

    private GameObject _defeat = null;
    private string _defeatName;

    public GameObject Defeat {
        get {
            if (_defeat == null) {
                _defeat = GameObject.Find(_defeatName);
            }
            return _defeat;
        }
        set {
            _defeat = value;
            _defeatName = value.name;
        }
    }


    // Start is called before the first frame update
    void Start() {

        SmallBeer = GameObject.FindGameObjectWithTag("beer");
        BigBeer = GameObject.FindGameObjectWithTag("bigbeer");
        SmallSoda = GameObject.FindGameObjectWithTag("soda");
        BigSoda = GameObject.FindGameObjectWithTag("bigsoda");
        Type = GameObject.FindGameObjectWithTag("type");
        TimeProgress = GameObject.FindGameObjectWithTag("time");
        Defeat = GameObject.FindGameObjectWithTag("defeat");
        Succeed = GameObject.FindGameObjectWithTag("succeed");

        SmallBeer.SetActive(false);
        BigBeer.SetActive(false);
        SmallSoda.SetActive(false);
        BigSoda.SetActive(false);
        Type.SetActive(false);
        TimeProgress.SetActive(false);
        Succeed.SetActive(false);
        Defeat.SetActive(false);



        GameManager.PowerupEvent -= StartEvent;
        GameManager.PowerupEvent += StartEvent;

        GameManager.PowerupDuring -= DuringEvent;
        GameManager.PowerupDuring += DuringEvent;

        GameManager.PowerupFinal -= FinalEvent;
        GameManager.PowerupFinal += FinalEvent;
    }

    // Update is called once per frame
    void Update()
    {
        if(eventStarted){
            type.text = (TypeString);
            year.text = (Year);
            beer.text = (BeerCurrent + "/" + BeerGoal);
            soda.text = (SodaCurrent + "/" + SodaGoal);
            bigBeer.text = (BeerCurrent + "/" + BeerGoal);
            bigSoda.text = (SodaCurrent + "/" + SodaGoal);
            typeActivated.text = (TypeActivated);
            typeFailed.text = (TypeFailed);

            loadBeer = (float)BeerCurrent / (float)BeerGoal;
            loadSoda = (float)SodaCurrent / (float)SodaGoal;

            this.timeLeft -= Time.deltaTime;

            time.fillAmount = timeLeft / timeMax;
            SmallBeer.GetComponent<Image>().fillAmount = (loadBeer);
            BigBeer.GetComponent<Image>().fillAmount = (loadBeer);
            SmallSoda.GetComponent<Image>().fillAmount = (loadSoda);
            BigSoda.GetComponent<Image>().fillAmount = (loadSoda);
        }
    }

    void StartEvent (string powerup, int sourceGen, int targetGen, int timeGoal, int beerGoal, int sodaGoal) {
        this.timeMax = timeGoal;
        this.timeLeft = timeGoal;
        this.BeerGoal = beerGoal;
        this.SodaGoal = sodaGoal;
        this.TypeString = powerup;
        this.BeerCurrent = 0;
        this.SodaCurrent = 0;
        this.TypeActivated = powerup + " activated";
        this.TypeFailed = powerup + " failed";

        TimeProgress.SetActive(true);
        Type.SetActive(true);
        Succeed.SetActive(false);
        Defeat.SetActive(false);

        if(sourceGen == 0){
            this.Year = "OLD";
            this.SucceedString = "OLD";
            this.DefeatString = "OLD";
        } else{
            this.Year = "S" + sourceGen.ToString().Substring(2);
            this.SucceedString = "S" + sourceGen.ToString().Substring(2);
            this.DefeatString = "S" + sourceGen.ToString().Substring(2);
        }

        if (BeerGoal == 0) {
            BigSoda.SetActive(true);
        } else if (SodaGoal == 0) {
            BigBeer.SetActive(true);
        } else {
            SmallSoda.SetActive(true);
            SmallBeer.SetActive(true);
        }

        eventStarted = true;
    }

    void DuringEvent (int beers, int sodas) {
        this.BeerCurrent = beers;
        this.SodaCurrent = sodas;
    }

    void FinalEvent (bool completed) {
        Type.SetActive(false);
        TimeProgress.SetActive(false);
        BigSoda.SetActive(false);
        BigBeer.SetActive(false);
        SmallSoda.SetActive(false);
        SmallBeer.SetActive(false);

        if (completed == true) {
            Succeed.SetActive(true);
        } else {
            Defeat.SetActive(true);
        }

        eventStarted = false;
    }
}
