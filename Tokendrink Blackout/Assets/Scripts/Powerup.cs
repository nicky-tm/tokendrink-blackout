using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerup : MonoBehaviour
{
    bool eventStarted = false;

    public Text type;
    string Type = "type";

    public Text year;
    string Year = "S18";

    public Text succeed;
    string Succeed = "S18";

    public Text defeat;
    string Defeat = "S18";

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

    public Image beerMug;
    float loadBeer = 0.3f;

    public Image sodaGlass;
    float loadSoda = 0.7f;

    public Image bigBeerMug;
    public Image bigSodaGlass;

    public Transform smallBeerTransform, bigBeerTransform, smallSodaTransform, bigSodaTransform, typeTransform, timeProgressTransform, succeedTransform, defeatTransform;

    


    // Start is called before the first frame update
    void Start() {
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
            type.text = (Type);
            year.text = (Year);
            beer.text = (BeerCurrent + "/" + BeerGoal);
            soda.text = (SodaCurrent + "/" + SodaGoal);
            bigBeer.text = (BeerCurrent + "/" + BeerGoal);
            bigSoda.text = (SodaCurrent + "/" + SodaGoal);

            loadBeer = (float)BeerCurrent / (float)BeerGoal;
            loadSoda = (float)SodaCurrent / (float)SodaGoal;

            this.timeLeft -= Time.deltaTime;

            time.fillAmount = timeLeft / timeMax;
            beerMug.fillAmount = (loadBeer);
            bigBeerMug.fillAmount = (loadBeer);
            sodaGlass.fillAmount = (loadSoda);
            bigSodaGlass.fillAmount = (loadSoda);
        }
    }

    void StartEvent (string powerup, int sourceGen, int targetGen, int timeGoal, int beerGoal, int sodaGoal) {
        this.timeMax = timeGoal;
        this.timeLeft = timeGoal;
        this.BeerGoal = beerGoal;
        this.SodaGoal = sodaGoal;
        this.Type = powerup;
        this.BeerCurrent = 0;
        this.SodaCurrent = 0;

        typeTransform.gameObject.SetActive(true);
        timeProgressTransform.gameObject.SetActive(true);
        succeedTransform.gameObject.SetActive(false);
        defeatTransform.gameObject.SetActive(false);

        if(sourceGen == 0){
            this.Year = "OLD";
            this.Succeed = "OLD";
            this.Defeat = "OLD";
        } else{
            this.Year = "S" + sourceGen.ToString().Substring(2);
            this.Succeed = "S" + sourceGen.ToString().Substring(2);
            this.Defeat = "S" + sourceGen.ToString().Substring(2);
        }

        if (BeerGoal == 0) {
            bigSodaTransform.gameObject.SetActive(true);
        } else if (SodaGoal == 0) {
            bigBeerTransform.gameObject.SetActive(true);
        } else {
            smallSodaTransform.gameObject.SetActive(true);
            smallBeerTransform.gameObject.SetActive(true);
        }

        eventStarted = true;
    }

    void DuringEvent (int beers, int sodas) {
        this.BeerCurrent = beers;
        this.SodaCurrent = sodas;
    }

    void FinalEvent (bool completed) {
        typeTransform.gameObject.SetActive(false);
        timeProgressTransform.gameObject.SetActive(false);
        bigSodaTransform.gameObject.SetActive(false);
        bigBeerTransform.gameObject.SetActive(false);
        smallSodaTransform.gameObject.SetActive(false);
        smallBeerTransform.gameObject.SetActive(false);

        // if (SUCCEEDED) {
        //     succeedTransform.gameObject.SetActive(true);
        // } else {
        //     defeatTransform.gameObject.SetActive(true);
        // }

        eventStarted = false;
    }
}
