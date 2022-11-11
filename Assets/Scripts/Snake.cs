using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.Events;

public class Snake : MonoBehaviour
{
    public List<Transform> Tails;
    [Range(0,3)]
    public float BallsDistance;
    public GameObject BallPrefab;
    [Range(0, 4)]
    public float Speed;
    private Transform _transform;

    public TextMeshProUGUI Counting;
    public int TailsCounting;

    public UnityEvent OnEat;
    public UnityEvent OnBlockHit;

    public GameObject LooseScreen;
    public GameObject WinScreen;

    public GameObject BackgroundMusic;
    public GameObject LooseSound;
    public GameObject WinSound;





    private void Start()
    {
        _transform = GetComponent<Transform>();
             
          
    }

    private void Update()
    {
            
            MoveSnake(_transform.position + _transform.forward * Speed);
            float angle = Input.GetAxis("Horizontal") * 220;
            _transform.rotation = Quaternion.Euler(0, angle / 4, 0);

            TailsCounting = Tails.Count;
            Counting.text = "" + TailsCounting;
        

        if(TailsCounting == 0)
        {
            
            LooseScreen.SetActive(true);
            Speed = 0;
            _transform.rotation = Quaternion.Euler(0, 0, 0);
            LooseSound.SetActive(true);
            BackgroundMusic.SetActive(false);
            

        }
    }
        
    private void MoveSnake(Vector3 newPosition)
    {
        float sqrDistance = BallsDistance * (BallsDistance/10);
        Vector3 previousPosition = _transform.position;

        foreach (var ball in Tails)
        {
            if ((ball.position - previousPosition).sqrMagnitude > sqrDistance)
            {
                var temp = ball.position;
                ball.position = previousPosition;
                previousPosition = temp;
            }
            else
            {
                break;
            }
            
        }

        _transform.position = newPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.name == "Food1")
        {
            Destroy(collision.gameObject);

            var ball = Instantiate(BallPrefab);
            Tails.Add(ball.transform);

            if (OnEat != null)
            {
                OnEat.Invoke();
            }
        }

        if (collision.gameObject.name == "Food2")
        {
            Destroy(collision.gameObject);

            var ball = Instantiate(BallPrefab);
            Tails.Add(ball.transform);       
            


            if (OnEat != null)
            {
                OnEat.Invoke();
            }
        }

        if (collision.gameObject.name == "Food2")
        {
            var ball = Instantiate(BallPrefab);
            Tails.Add(ball.transform);
                       
        }

        if (collision.gameObject.name == "Food3")
        {
            Destroy(collision.gameObject);

            var ball = Instantiate(BallPrefab);
            Tails.Add(ball.transform);
            

            if (OnEat != null)
            {
                OnEat.Invoke();
            }
        }

        if (collision.gameObject.name == "Food3")
        {
            var ball = Instantiate(BallPrefab);
            Tails.Add(ball.transform);
                       
        }

        if (collision.gameObject.name == "Food3")
        {
            var ball = Instantiate(BallPrefab);
            Tails.Add(ball.transform);

        }


        if (collision.gameObject.name == "Block1")
        {
            Destroy(collision.gameObject);
            Tails.Remove(Tails[0]);

            if (OnBlockHit != null)
            {
                OnBlockHit.Invoke();
            }
        }

        if (collision.gameObject.name == "Block2")
        {
            Destroy(collision.gameObject);
            Tails.Remove(Tails[0]);
            Tails.Remove(Tails[0]);

            if (OnBlockHit != null)
            {
                OnBlockHit.Invoke();
            }
        }

        if (collision.gameObject.name == "Block3")
        {
            Destroy(collision.gameObject);
            Tails.Remove(Tails[0]);
            Tails.Remove(Tails[0]);
            Tails.Remove(Tails[0]);

            if (OnBlockHit != null)
            {
                OnBlockHit.Invoke();
            }
        }

        if (collision.gameObject.name == "Block4")
        {
            Destroy(collision.gameObject);
            Tails.Remove(Tails[0]);
            Tails.Remove(Tails[0]);
            Tails.Remove(Tails[0]);
            Tails.Remove(Tails[0]);

            if (OnBlockHit != null)
            {
                OnBlockHit.Invoke();
            }
        }
                

    }

    void OnTriggerEnter(Collider other)
    {
        WinScreen.SetActive(true);
        Speed = 0;
        _transform.rotation = Quaternion.Euler(0, 0, 0);
        WinSound.SetActive(true);
        BackgroundMusic.SetActive(false);
        
    }


}
