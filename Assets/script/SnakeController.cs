

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SnakeController : MonoBehaviour
{

    public float MoveSpeed;
    public float SteerSpeed;
    public int Gap;
    public int score;
    public Text Scoretext;
    public GameObject GoText;
    public GameObject resetbutton;
   

    public GameObject Bodyprefab;
    List<GameObject> BodyParts = new List<GameObject>();
    List<Vector3> PositionHistory = new List<Vector3>();


    private void Start()
    {
        GoText.SetActive(false);
        resetbutton.SetActive(false);
    }




    void Update()
    {


        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        float SteerDirection = Input.GetAxis("Horizontal");
     
        transform.Rotate(Vector3.up * SteerDirection * SteerSpeed * Time.deltaTime);
     
        PositionHistory.Insert(0, transform.position);
        int index = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionHistory[Mathf.Clamp(index *Gap,0,PositionHistory.Count-1)];
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * MoveSpeed * Time.deltaTime;
            body.transform.LookAt(point);
            index++;
        }


        Scoretext.text = score.ToString();


        
    }



   

    void GrowSnake()
    {
        GameObject body = Instantiate(Bodyprefab);
        BodyParts.Add(body);



    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag=="food")
        {
            GrowSnake();
            Destroy(other.gameObject);
            foodControl.isThereFood = false;
            score++;

        }

       if(other.gameObject.tag=="wall")
        {
            GoText.SetActive(true);
            Time.timeScale = 0;
            resetbutton.SetActive(true);
        }
        if (other.gameObject.tag=="body")
        {
            //OYUN BÝTTÝ
            GoText.SetActive(true);
            Time.timeScale = 0;
            resetbutton.SetActive(true);

        }

        
       





         



    }



    public void  Resetbutton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }








    

    
    
      


    

  




}
