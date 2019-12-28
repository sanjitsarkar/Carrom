using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class striker : MonoBehaviour
{
   Vector3 startpos,endpos,offset,targetdir;
   
    public AudioSource[] breakshots;
    public AudioClip[] hitsound,breaksound,hits,pocketfillsound,movesound;
    Camera cm;
    public GameObject board;
    LineRenderer lr;
    
      public GameObject game_over;
      public Text game_over_text;
       public Text black_no;
       public Text white_no;
    bool player=false;
    public int black,white,red;
    public Color r=Color.red;
    public Slider move_slider;
    GameObject start;
    
    Rigidbody2D rb;
     bool hit = false;
    public bool st = false; 
    public bool movestriker = false;
    public bool turn=false;
    // public int red,black,white;
    //  start st;
    //   Collider2D col;
    //  public GameObject start;
    Vector3 camoffset = new Vector3(0,0,0);
    [SerializeField] AnimationCurve ac;

    // public GameObject ball;
       // Start is called before the first frame update
    void Start()
    {
        // col = GetComponent<Collider2D>();
                start = GameObject.Find("start");

        cm = Camera.main;
// st = GetComponent<start>();
lr = GetComponent<LineRenderer>();
rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      black_no.text = black+"";
      white_no.text = white+"";
    //  Debug.Log("Black: "+get_black()+" White: "+get_white()+" Red: "+get_red());
     if(black==9 && red==1)
     {
       game_over.SetActive(true);
            game_over_text.text = "Opponent Won";

     }
     else if(white==9 && red==1)
     {
      game_over.SetActive(true); 
            game_over_text.text = "You Won";

     }
    //   if(Input.touchCount>0)
    //   {
    //  Debug.Log("tich_position"+Input.GetTouch(0).position.y);
       
    //   }
      //  Debug.Log("tich_position"+Input.mousePosition.y);
      if(rb.velocity== Vector2.zero)
      {
        return_striker();
        //  move_striker();
        if(movestriker==false)
        {
        breakshots[3].Stop();
 control();
        if(st==false)
        {
        // turn = true;
        
       
        // if(st==true)
        // {
        // Destroy(this.gameObject);
        // }
      
        // start.GetComponent<start>().init();

      }
//       else if(st==true)
//       {
//       if(turn==false)
//       {
// turn=true;
//       }
//      if(turn==true)
//       {
//       turn=false;
//       }
//           return_striker();
//       }
      }
      }
        
}
public void move_striker(bool t)
{
  if(rb.velocity==Vector2.zero)
  {
  if(t==false)
  {
// move_slider.value = 
this.transform.position=new Vector3(move_slider.value,-1.575f,0);

  }
  else{
this.transform.position=new Vector3(move_slider.value,1.575f,0);

  } 
  }
  player=t;
  
  // return t;
  
// Debug.Log(this.transform.position.y);
// move_slider.value+=this.transform.position.x;

// movestriker=true;
}
public bool get_striker()
{
return player;
}
private void control()
{
//  Input.mousePosition = new Vector3(Input.mousePosition.x,Mathf.Clamp(60,61,60),Input.mousePosition.z);
if(Input.mousePosition.y>150f)
{                                                                                                                                                                                                                                                                                                                                                                                                               
  // start.GetComponent<start>().init();
  startpos = this.transform.position+camoffset;
        // Debug.Log(startpos);

        // if(Input.GetMouseButtonDown(0) )
        // {
//                             if(lr == null)
// {
//     lr = gameObject.AddComponent<LineRenderer>();

// }

lr.positionCount = 2;
lr.widthCurve = ac;
lr.numCapVertices = 10;
lr.enabled = false;
lr.SetPosition(0,startpos);
// lr.SetRotation(0,0,0);s
lr.useWorldSpace = true;
        // }
          if(Input.GetMouseButton(0)|| (Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
              lr.enabled = true;
            endpos = cm.ScreenToWorldPoint(Input.mousePosition)+camoffset;
          
            lr.SetPosition(1,endpos);
        }
          if(Input.GetMouseButtonUp(0)|| (Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
       
            lr.enabled = false;
              hit = true;
  st= true;
    // Debug.Log("End:"+endpos);
           targetdir =  -startpos+endpos;
          //  Debug.Log("Distance"+targetdir.magnitude);
          
           if(targetdir.magnitude>10.007f)
           {
lr.material.color = r;
           
          breakshots[2].clip=hitsound[Random.Range(0,hitsound.Length)];
             breakshots[2].Play();
          
            rb.AddForce(targetdir*200);
            if(player==true && this.GetComponent<pocket>().get_st()==false)
            {
              player=false;
            }
            else if(player==false && this.GetComponent<pocket>().get_st()==false){
              player=true;
            }
            // turn=true;
            
//             if(player=true)
//             {
//             move_striker(false);
//             }
//             else{
// move_striker(true);
//             }

           }
      
        }
          
      breakshots[3].clip=movesound[Random.Range(0,movesound.Length)];
        //  Debug.Log(this.GetComponent<Rigidbody2D>().velocity.sqrMagnitude);
          if(this.GetComponent<Rigidbody2D>().velocity.sqrMagnitude/200>1)
   {
     breakshots[3].volume = 1f;
   }
   else{
     breakshots[3].volume = this.GetComponent<Rigidbody2D>().velocity.sqrMagnitude/200;
   }
         breakshots[3].Play();
}
}
public void return_striker()
{
  if(player==false)
  {
 
  // this.transform.position = new Vector3(0,-1.743f,0);
     move_striker(false);
    //  player=true;
  
  }
  else{
   
    // this.transform.position = new Vector3(0,1.743f,0);
     move_striker(true);
    //  player=false;
    // turn = false;
  }

}
    
    private void OnCollisionEnter2D(Collision2D other)
    {
       if(other.gameObject.tag=="black" || other.gameObject.tag=="white" ||other.gameObject.tag=="red" )
       {
        
         if( board.GetComponent<Collider2D>().enabled == false)
         {
        //  Debug.Log(other.relativeVelocity.magnitude/20);
           breakshots[1].clip=hits[Random.Range(0,hits.Length)];
            if(other.relativeVelocity.magnitude/30>1)
   {
     breakshots[1].volume = 1f;
   }
   else{
     breakshots[1].volume = other.relativeVelocity.magnitude/30;
   }
         breakshots[1].Play();
         }
       }
    }
    void OnTriggerEnter2D(Collider2D other) {
             if(other.gameObject.tag=="board")
        {
            // Debug.Log("Striked");
                  //  breakshots[0].volume = 
   if(this.GetComponent<Rigidbody2D>().velocity.sqrMagnitude/200>1)
   {
     breakshots[0].volume = 1f;
   }
   else{
     breakshots[0].volume = this.GetComponent<Rigidbody2D>().velocity.sqrMagnitude/200;
   }
   board.GetComponent<Collider2D>().enabled = false;
       breakshots[0].Play();
            // Destroy(this.gameObject);
        }
    }
  public int set_black(int b)
  {
black=b;
return black;
  }
   public int set_white(int w)
  {
white=w;
return white;
  }
   public  int set_red(int r)
  {
red=r;
return red;
  }

  public int get_black()
  {
    return black;
  }
  public int get_red()
  {
    return red;
  }
  public int get_white()
  {
    return white;
  }
}
