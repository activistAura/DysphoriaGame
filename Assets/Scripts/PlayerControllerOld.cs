//using System.Collections;
//using UnityEngine.UI;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerController : MonoBehaviour {

//    private Rigidbody playerrb;
//    private int score;
//    public Text scoreText;
//    public Text msText; //milestones text
//    public Text selfloveText; //exactlywhatitsaysonthetin
//    public Text endGameText;
//    private int speed = 10;

//    private string[] milestones = new string[16]; //list of milestones in one possible transgender woman's experience
//    private System.Random rand = new System.Random();
//    private int index;

//    private string[] selfLove = new string[6];

//    //Color variables for death 'animation'
//    public Renderer rend;
//    public float pcr;
//    public float pcg;
//    public float pcb;
//    public bool initiateDeath;

//    void Start ()
//    {
//        playerrb = GetComponent<Rigidbody>();
//        score = 20;
//        setScoreText(scoreText);
//        endGameText.text = "";
//        msText.text = "so far, you've completed the following steps in your transition:\r\nfinally come out to yourself\r\n";
//        selfloveText.text = "";

        

//        rend = GetComponent<Renderer>();
//        initiateDeath = false;
//        pcr = rend.material.color.r;
//        pcg = rend.material.color.g;
//        pcb = rend.material.color.b;

//        index = 0;

//        milestones[0] = "asked yourself: what if i'm not 100% <i>sure</i> i'm a woman?";
//        milestones[1] = "underwent hormone replacement therapy";
//        milestones[2] = "had genital affirmation surgery";
//        milestones[3] = "had facial feminization surgery";
//        milestones[4] = "tried so, so hard to train your voice to be more feminine";
//        milestones[5] = "compared yourself to every single other person you know, and found yourself lacking";
//        milestones[6] = "purchased a whole new wardrobe";
//        milestones[7] = "asked yourself: am i really trans? what if i'm making this all up?";
//        milestones[8] = "come out to your parents";
//        milestones[9] = "told yourself: if i had just figured this out sooner, i would be happy";
//        milestones[10] = "got new shoes, again";
//        milestones[11] = "asked yourself: what if i regret my medical transition?";
//        milestones[12] = "hated yourself";
//        milestones[13] = "experienced intense disassociation from your body";
//        milestones[14] = "asked yourself: if this is my 'truth', why do i feel so ashamed?";
//        milestones[15] = "got your ears pierced";



//        //you know that someday, you'll be able to wake up and just <i>be</i> a woman. no dysphoria to hold you back, maybe it'll even be someday soon
//        //society can burn for all you care. even on your worst days, you know you are beautiful
//        //you know, deep down, that you love some part of yourself
//        //on good days, you find yourself thinking your body's not so bad after all
//        //who says all girls have to look a certain way? you're wonderful just the way you are
//        //you are not just your body. even on your worst days, you are beautiful

//        Shuffle(milestones, rand);
//    }

//    void Update () //called before rendering a frame
//    {
//        if (initiateDeath)
//        {
//            pcr -= 0.005f;
//            pcg -= 0.005f;
//            pcb -= 0.005f;
//            rend.material.color = new Color(pcr, pcg, pcb);
//        }

//    }

//    void FixedUpdate () //called just before performing any physics operations
//    {
//        float moveHorizontal = Input.GetAxis("Horizontal");
//        float moveVertical = Input.GetAxis("Vertical");
//        bool moveUp = Input.GetKey("space");
//        bool moveDown = Input.GetKey("right shift");
//        bool moveMoreDown = Input.GetKey("left shift");
       
//        if (initiateDeath)
//        {
//            speed = 0;
//        }

//        if (moveUp && !initiateDeath) {
//            playerrb.AddForce(new Vector3(0, 5, 0));
//        }
//        if ((moveDown || moveMoreDown) && !initiateDeath) //movement in the y axis
//        {
//            playerrb.AddForce(new Vector3(0, -5, 0)); //movement in the y axis
//        }

//        Vector3 movement = new Vector3(moveHorizontal * speed, 0, moveVertical * speed); // movement in the xz plane
//        playerrb.AddForce(movement);
//    }

//    void OnTriggerEnter(Collider other)
//    {
//        int step = 1;
//        /*if (other.gameObject.CompareTag("Pickup"))
//        {
//            other.gameObject.SetActive(false);
//        }*/
//        if (other.gameObject.CompareTag("Pickup"))
//        {
//            other.gameObject.SetActive(false);
//            score += step;
//            setScoreText(scoreText);
//            updateMSText(msText);
//            StartCoroutine(waitCoRoutine());
//            if (score >= (20 + 16 * step))
//            {
//                StartCoroutine(deathCoRoutine());
//            }
//            else
//            {
//                if (score >= (20 + 16 * step))
//                {
//                    StartCoroutine(maybeCoRoutine());
//                }
//            }
//        }
//        if (other.gameObject.CompareTag("the light 1"))
//        {
//            selfloveText.text += "\r\n";
//        }
//        if (other.gameObject.CompareTag("the light 2"))
//        {
//            selfloveText.text += "\r\n";
//        }
//        if (other.gameObject.CompareTag("the light 3"))
//        {
//            selfloveText.text += "\r\n";
//        }
//        if (other.gameObject.CompareTag("the light 4"))
//        {
//            selfloveText.text += "\r\n";
//        }
//        if (other.gameObject.CompareTag("the light 5"))
//        {
//            selfloveText.text += "\r\n";
//        }
//        if (other.gameObject.CompareTag("the light 6"))
//        {
//            selfloveText.text += "\r\n";
//        }
//    }

//    IEnumerator waitCoRoutine()
//    {
//        //This is a coroutine
//        float zero = 0;
//        float origdrag = playerrb.drag;
//        playerrb.drag = 1 / zero;
//        speed = 0;
//        yield return new WaitForSeconds(1);    
//        playerrb.drag = origdrag;

//        speed = 10;
//    }

//    IEnumerator deathCoRoutine()
//    {
//        yield return new WaitForSeconds(2);
//        msText.text += "\r\nlived presenting as a woman, without fully understanding that you really, truly are one";
//        yield return new WaitForSeconds(5);    
//        msText.text += "\r\ncontinued to hate yourself. your face, your body, your soul";
//        yield return new WaitForSeconds(5);    
//        msText.text += "\r\ngiven up all hope";
//        yield return new WaitForSeconds(5);    
//        endGameText.text = "congratulations, you died";
//        scoreText.text = "";
//        initiateDeath = true;
//    }

//    IEnumerator maybeCoRoutine() 
//    {
//        //This is a coroutine
//        float zero = 0;
//        float origdrag = 0;
//        playerrb.drag = 1 / zero;

//        speed = 0;
//        msText.enabled = false;
//        endGameText.text = "wait";
        
//        yield return new WaitForSeconds(1);    
//        origdrag = playerrb.drag;
//        playerrb.drag = 1 / zero;
//        yield return new WaitForSeconds(2);
//        endGameText.text = "are these really the things\r\nthat will make you happy?";
//        yield return new WaitForSeconds(3);
//        endGameText.text = "are these the true problems\r\nholding you back from loving yourself?";
//        //yield return new WaitForSeconds(3);    
//        //endGameText.text = "aren't you,";
//        //yield return new WaitForSeconds(3);    
//        //endGameText.text = "the <i>real</i> you.";
//        //yield return new WaitForSeconds(3);    
//        //endGameText.text += "\r\nshe who answers to the name 'I'";
//        //yield return new WaitForSeconds(3);    
//        //endGameText.text += "\r\nimportant?";
//        yield return new WaitForSeconds(5);    
//        endGameText.text = "why are you transitioning?";
//        yield return new WaitForSeconds(5);    
//        endGameText.text = "to feel at home in your own skin?";
//        yield return new WaitForSeconds(5);    
//        endGameText.text = "to finally wake up,\r\nlook in the mirror,\r\n and love yourself?";
//        yield return new WaitForSeconds(5);    
//        endGameText.text = "why don't you love yourself <i>now</i>?";
//        yield return new WaitForSeconds(5);    
//        endGameText.text = "is it because you\r\ndon't look 'feminine' enough?";
//        yield return new WaitForSeconds(5);    
//        endGameText.text = "what is 'feminine'?";
//        yield return new WaitForSeconds(5);
//        endGameText.text = "and who the fuck\r\ngets to say what is and is not\r\nfeminine?";
//        yield return new WaitForSeconds(5);
//        endGameText.text = "you are a girl.\r\nyou are a woman.";
//        yield return new WaitForSeconds(5);
//        endGameText.text = "<b>you</b>\r\nin that head of yours.\r\nshe who answers to the name of 'I'";
//        yield return new WaitForSeconds(5);
//        endGameText.text = "you have always, always been a girl;\r\n a woman.";
//        yield return new WaitForSeconds(5);
//        endGameText.text = "and if you're a woman\r\nin your head,\r\nin your heart,\r\nthen you're a woman\r\nin the flesh, too.";
//        yield return new WaitForSeconds(5);    
//        endGameText.text = "transitioning is important";
//        yield return new WaitForSeconds(5);
//        endGameText.text = "i'm not saying it's wrong, or less-right";
//        yield return new WaitForSeconds(5);
//        endGameText.text = "i'm just wondering:\r\nwithout self acceptance,\r\nwhat the fuck good is it?";
//        yield return new WaitForSeconds(5);
//        endGameText.text = "if you complete your transition,\r\nwithout addressing your shame,";
//        yield return new WaitForSeconds(5);
//        endGameText.text = "without understanding the\r\ninternalized societal bullshit";
//        yield return new WaitForSeconds(5);
//        endGameText.text = "that's been drilled\r\ninto your head since birth,";
//        yield return new WaitForSeconds(5);
//        endGameText.text = "you might come to regret\r\nbeing yourself.";
//        yield return new WaitForSeconds(5);
//        endGameText.text = "and that would be \r\nthe most heartbreaking thing\r\nyou could possibly do.";
//        yield return new WaitForSeconds(5);
//        endGameText.text = "try something else. please.";
//        yield return new WaitForSeconds(3);
//        endGameText.text = "you are not bound to this corporeal plane.";
//        playerrb.drag = origdrag;
//        yield return new WaitForSeconds(1);    
//        speed = 10;
//        yield return new WaitForSeconds(2);    
//        endGameText.text = "";
//        yield return new WaitForSeconds(1);    
//        msText.enabled = true;
//    }


//    void setScoreText(Text st)
//    {
//        st.text = "Age: " + score.ToString();
//    }

//    void updateMSText(Text ms)
//    {
//        ms.text = ms.text + (milestones[index++] + "\r\n");
//    }

//    public static void Swap(string[] list, int i, int j)
//    {
//        var temp = list[i];
//        list[i] = list[j];
//        list[j] = temp;
//    }

//    public static void Shuffle(string[] list, System.Random rnd)
//    {
//        for (var i = 0; i < list.Length; i++)
//            Swap(list, i, rnd.Next(i, list.Length));
//    }


//}
   
