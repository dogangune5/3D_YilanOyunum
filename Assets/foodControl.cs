using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodControl : MonoBehaviour
{
    [SerializeField] GameObject foodPrefab;
    private float xEks, zEks;
    public static bool isThereFood;

    private void Start()
    {
        isThereFood = false;
        

    }
    private void Update()
    {
        CreateFood();
    }
    void CreateFood()
    {
        xEks = Random.Range(-6.4f, 6.4f);
        zEks = Random.Range(-6.5f, 6.5f);
        if (!isThereFood)
        {
            GameObject foodeat = Instantiate(foodPrefab, new Vector3(xEks, -0.812f, zEks), Quaternion.identity);
            isThereFood = true;
        }

    }


    















}
