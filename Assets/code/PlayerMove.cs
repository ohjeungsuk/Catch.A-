using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    SpriteRenderer sr;
    Animator ani;
    float speed;
    public GameObject[] effect;
    public AudioSource audio;
    public AudioSource audioRun;
    public AudioClip[] efx;
    public GameM GM;
    bool isRun;

    void ShowEffect(Collision2D col , int num,float showTime,string tag, float getTime, int score)
    {
        
        if (col.gameObject.CompareTag(tag))
        {


            Destroy(col.gameObject);
            GameObject effect1 = Instantiate
                (effect[num], transform.position, Quaternion.identity);
            Destroy(effect1,showTime);
            PlaySingle(efx[num]);
            GM.hp.fillAmount += getTime / 10.0f;
            GM.score = GM.score + score;
        }
    }

    void PlaySingle(AudioClip clip)
    {
        audio.clip = clip;
        audio.Play();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        ShowEffect(collision, 0, 1.5f, "A",0.5f,5);
        ShowEffect(collision, 1, 2f,"F",-1.0f,-10);

       
    }

    void Start()
    {
        audioRun = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        speed = 3.0f;
        isRun = false;




    }
    void Move(KeyCode A , Vector2 v2,bool filp)
    {
        if(Input.GetKey(A))
        {
            sr.flipX = filp;
            transform.Translate(v2 * speed * Time.deltaTime);
            ani.SetBool("Run", true);
            isRun = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        Move(KeyCode.RightArrow, Vector2.right, true);
        Move(KeyCode.LeftArrow, Vector2.left, false);

        float h = Input.GetAxisRaw("Horizontal");
        if (h == 0)
        {
            isRun = false;
            ani.SetBool("Run", false);
        }
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -2.9f, 2.9f),
            transform.position.y);

        if(isRun)
        {
            if(!audioRun.isPlaying)
            {
                audioRun.Play();
            }
        }else
        {
            audioRun.Stop();
        }
    }
}
