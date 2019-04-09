using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGen : MonoBehaviour
{


    public GameObject PlatformPrefab01;
    public GameObject PlatformPrefab02;
    public GameObject PlatformPrefab03;
    public GameObject PlatformPrefab04;
    public GameObject PlatformPrefab05;
    public GameObject platformGenPoint;
    public GameObject FakePlatformPrefab;
    public GameObject UltraPlatformPrefab;
    public GameObject SpikesPlatformPrefab;
    public GameObject doge;
    public GameObject dogeling;
    public GameObject dogeCoin;
    public GameObject flyLeaf;
    public GameObject meat;
    public GameObject bigMeat;
    public GameObject spikes;
    public GameObject nullBonus;

    public int difficultSelected;

    private GameObject bonusPrefab;
    private GameObject PlatformPrefabMaster;


    public bool respawnBonuses;
    bool noRepFlyLeaf;
    bool firstBonus;
    bool firstSpike = false;
    bool increaseDifficult = true;

    public Vector3 offset;


    public float minY = 0.1f;
    public float maxY = 0.5f;

    int wichPlatformPrefab = 1;
    int randomBonus = 0;
    int wichBonusPrefab = 0;
    int normalFakeOrUltra = 100;
    int fakeOrSpikes = 100;
    int coinOrNullBonus = 100;
    int noRep;
    int randomBonusMaxCounter = 7;
    int percentChanceSpikes;
    int percentChanceForCoin = 100;
    int inicialPercentChanceSpikes;
    float randomRangeY;
    float randomRangeYForDoubles;


    int oneOrTwoPlatforms = 0;
    int bonusLeftOrRightFor2P;

    Vector3 spawnPosition = new Vector3();
    Vector3 bonusSpawnPosition = new Vector3();


    void Start()
    {
        noRep = 0;
        PlatformPrefabMaster = null;
        bonusPrefab = null;
        noRepFlyLeaf = false;
        firstBonus = false;


        difficultSelected = PlayerPrefs.GetInt("difficultSelectedPrefs");


        StartCoroutine(FirstBonus());
        StartCoroutine(FirstSpike());
        StartCoroutine(DifficultIncreasement());
        



    }


    void Update()
    {


        if (transform.position.y < platformGenPoint.transform.position.y)
        {

            if (firstBonus == true)
            {
                StartCoroutine(RandomBonus());
            }

            oneOrTwoPlatforms = Random.Range(1, 4);
            randomRangeY = Random.Range(1.5f, 2f);
            spawnPosition.y = randomRangeY + transform.position.y;
            spawnPosition.x = Random.Range(-2.75f, 2.75f);


            if (spawnPosition.x <= 0f)
            {
                spawnPosition.x = Random.Range(-2.75f, -0.75f);
            }
            else
            {
                spawnPosition.x = Random.Range(0.75f, 2.75f);
            }



            ///Platforms gen below.
            ///

            if (normalFakeOrUltra >= 60)
            //Generate NORMAL platforms
            {
                WichPlatformPrefabMethod();

                if (oneOrTwoPlatforms >= 2)
                {
                    GenerateTwoPlatforms();
                }
                else if (oneOrTwoPlatforms == 1)
                {
                    GenerateOnePlatform();
                }
            }

            else if (normalFakeOrUltra >= 10)
            //Generate FAKE or SPIKE platform

            {
                if (fakeOrSpikes <= percentChanceSpikes)
                {
                    if (doge.GetComponent<BonusItems>().isFlying==false)
                    {
                        Instantiate(SpikesPlatformPrefab, spawnPosition, Quaternion.identity);
                        noRep = noRep + 1;
                    }
                    
                }
                else if (fakeOrSpikes <= 100)
                {
                    Instantiate(FakePlatformPrefab, spawnPosition, Quaternion.identity);
                    noRep = noRep + 1;
                }





            }

            else if (normalFakeOrUltra >= 1)
            //Generate ULTRA platform

            {
                Instantiate(UltraPlatformPrefab, spawnPosition, Quaternion.identity);
                noRep = noRep + 1;

            }

            normalFakeOrUltra = Random.Range(1, 101);
            if (firstSpike)
            {
                fakeOrSpikes = Random.Range(1, 101);

            }


            if (noRep > 0)
            {
                normalFakeOrUltra = 100;

                noRep = 0;
            }



            transform.position = new Vector3(transform.position.x, spawnPosition.y, transform.position.z);

            // randomBonus = 0;

        }


    }



    void GenerateOnePlatform()
    {
        Instantiate(PlatformPrefabMaster, spawnPosition, Quaternion.identity);

        if (randomBonus >= randomBonusMaxCounter)
        {
            WhichBonusPrefabMethod();
            bonusSpawnPosition.x = spawnPosition.x;
            if (respawnBonuses)
            {
                Instantiate(bonusPrefab, bonusSpawnPosition, Quaternion.identity);

            }

            //randomBonus = 0;

        }

    }

    void GenerateTwoPlatforms()
    {
        bonusLeftOrRightFor2P = Random.Range(1, 3);

        spawnPosition.x = Random.Range(-2.75f, -0.75f);
        Instantiate(PlatformPrefabMaster, spawnPosition, Quaternion.identity);

        if (randomBonus >= randomBonusMaxCounter && bonusLeftOrRightFor2P == 1)
        {
            WhichBonusPrefabMethod();
            bonusSpawnPosition.x = spawnPosition.x;
            if (respawnBonuses)
            {
                Instantiate(bonusPrefab, bonusSpawnPosition, Quaternion.identity);

            }
            //randomBonus = 0;


        }


        randomRangeYForDoubles = Random.Range(0.4f, 1f);


        spawnPosition.y = spawnPosition.y + randomRangeYForDoubles;

        spawnPosition.x = Random.Range(0.75f, 2.75f);

        Instantiate(PlatformPrefabMaster, spawnPosition, Quaternion.identity);


        if (randomBonus >= randomBonusMaxCounter && bonusLeftOrRightFor2P == 2)
        {
            WhichBonusPrefabMethod();
            bonusSpawnPosition.x = spawnPosition.x;

            if (respawnBonuses)
            {
                Instantiate(bonusPrefab, bonusSpawnPosition, Quaternion.identity);

            }


            //randomBonus = 0;


        }

    }

    void WichPlatformPrefabMethod()
    {
        wichPlatformPrefab = Random.Range(1, 6);
        if (wichPlatformPrefab == 1)
        {
            PlatformPrefabMaster = PlatformPrefab01;
        }
        else if (wichPlatformPrefab == 2)
        {
            PlatformPrefabMaster = PlatformPrefab02;
        }
        else if (wichPlatformPrefab == 3)
        {
            PlatformPrefabMaster = PlatformPrefab03;
        }
        else if (wichPlatformPrefab == 4)
        {
            PlatformPrefabMaster = PlatformPrefab04;
        }
        else
        {
            PlatformPrefabMaster = PlatformPrefab05;
        }
    }

    void WhichBonusPrefabMethod()
    {

        wichBonusPrefab = Random.Range(1, 101);

        if (wichBonusPrefab <= 22)
        {
            bonusPrefab = meat;
            bonusSpawnPosition.y = spawnPosition.y + 0.55f;

        }
        else if (wichBonusPrefab <= 62)
        {
            coinOrNullBonus = Random.Range(1, 101);

            if (coinOrNullBonus <= percentChanceForCoin)
            {
                bonusPrefab = dogeCoin;
            }
            else
            {
                bonusPrefab = nullBonus;
            }

            bonusSpawnPosition.y = spawnPosition.y + 0.8f;

        }
        else if (wichBonusPrefab <= 82)
        {
            bonusPrefab = dogeling;
            bonusSpawnPosition.y = spawnPosition.y + 0.55f;
        }
        else if (wichBonusPrefab <= 93)
        {

            bonusPrefab = bigMeat;
            bonusSpawnPosition.y = spawnPosition.y + .65f;
        }


        else if (wichBonusPrefab <= 100 && noRepFlyLeaf == true)
        {
            bonusPrefab = flyLeaf;
            bonusSpawnPosition.y = spawnPosition.y + 0.55f;

            noRepFlyLeaf = false;


            StartCoroutine(NoRepFlyLeaf());

        }

    }



    IEnumerator NoRepFlyLeaf()
    {
        yield return new WaitForSeconds(8f);
        noRepFlyLeaf = true;

    }

    IEnumerator FirstBonus()
    {
        yield return new WaitForSeconds(2f);
        firstBonus = true;
        respawnBonuses = true;
        yield return new WaitForSeconds(8f);
        noRepFlyLeaf = true;



    }

    IEnumerator RandomBonus()
    {
        yield return new WaitForSeconds(0.5f);
        randomBonus = Random.Range(1, 11);


    }

    IEnumerator FirstSpike()
    {
        yield return new WaitForSeconds(6);
        if (difficultSelected == 1)
        {
            percentChanceSpikes = 15;

        }
        else if (difficultSelected == 2)
        {
            percentChanceSpikes = 20;

        }
        else if (difficultSelected == 3)
        {
            percentChanceSpikes = 25;

        }
        inicialPercentChanceSpikes = percentChanceSpikes;
        firstSpike = true;
    }

    IEnumerator DifficultIncreasement()
    {
        yield return new WaitForSeconds(3.5f);

        while (percentChanceSpikes < (inicialPercentChanceSpikes + 20))
        {
            for (int i = 0; i < 20; i++)
            {
                if (increaseDifficult)
                {
                    percentChanceSpikes++;
                    percentChanceForCoin--;


                    //Debug.Log(percentChanceSpikes);
                    // Debug.Log(percentChanceForCoin);

                }

                increaseDifficult = false;

                yield return new WaitForSeconds(14);
                increaseDifficult = true;

            }




        }



    }
}




