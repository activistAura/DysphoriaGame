using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public Text scoreText;
    public Text msText; //milestones text
    public Text selfloveText; //exactlywhatitsaysonthetin
    public Text endGameText;
    public bool collectionMode = false;
    public GameObject vs;

    //public string genderidentity = ""; 
    public Renderer rend;
    public float pcr;
    public float pcg;
    public float pcb;
    public bool initiateDeath;

    private AudioSource source;
    private Rigidbody playerrb;
    private int score;
    private int speed = 10;

    private string[] milestones = new string[16]; //list of milestones in one possible transgender woman's experience
    private System.Random rand = new System.Random();
    private int index;

    private string[] selfLove = new string[6];

    //Color variables for death 'animation'



    void Start ()
    {

        source = vs.GetComponent<AudioSource>();
		playerrb = GetComponent<Rigidbody>();		

        score = 20;
        //setScoreText(scoreText);
        
        //genderidentity = "woman";        

		endGameText.text = "";
		msText.text = "";
		selfloveText.text = "";
		scoreText.text = "";

        rend = GetComponent<Renderer>();
        initiateDeath = false;
        pcr = rend.material.color.r;
        pcg = rend.material.color.g;
        pcb = rend.material.color.b;

        index = 0;

        milestones[0] = "\twhat if i'm not 100% <i>sure</i> i'm a woman?";
        milestones[1] = "\twhat if i regret medically transitioning? what if i don't like the changes?";
        milestones[2] = "\tif this is my 'truth', why do i feel so ashamed?";
        milestones[3] = "\tam i really trans? what if i'm making this all up?";
        milestones[4] = "\tif i had just figured this out sooner, i could have been happy.";
        milestones[5] = "\twhat if i'm never perceived as a woman by those around me?";
        milestones[6] = "\twhy did it have to be <i>me</i>? why couldn't i just be <i>normal</i>?";
        milestones[7] = "\twill i always feels like this?";
        milestones[8] = "\twhat if it never 'gets better'?";
        milestones[9] = "\t";
        milestones[10] = "";
        milestones[11] = "\twhat the fuck was the point of transitioning if i still hate myself?";
        milestones[12] = "";
        milestones[13] = "";
        milestones[14] = "";
        milestones[15] = "";



        //you know that someday, you'll be able to wake up and just <i>be</i> a woman. no dysphoria to hold you back, maybe it'll even be someday soon
        //society can burn for all you care. even on your worst days, you know you are beautiful
        //you know, deep down, that you love some part of yourself
        //on good days, you find yourself thinking your body's not so bad after all
        //who says all girls have to look a certain way? you're wonderful just the way you are
        //you are not just your body. even on your worst days, you are beautiful

        Shuffle(milestones, rand);

		StartCoroutine(birthCoRoutine());
    }

    void Update () //called before rendering a frame
    {
        if (initiateDeath)
        {
            pcr -= 0.005f;
            pcg -= 0.005f;
            pcb -= 0.005f;
            rend.material.color = new Color(pcr, pcg, pcb);
        }

    }

    void FixedUpdate () //called just before performing any physics operations
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool moveUp = Input.GetKey("space");
        bool moveDown = Input.GetKey("right shift");
        bool moveMoreDown = Input.GetKey("left shift");
       
        if (initiateDeath)
        {
            speed = 0;
        }

        if (moveUp && !initiateDeath) {
            playerrb.AddForce(new Vector3(0, 5, 0));
        }
        if ((moveDown || moveMoreDown) && !initiateDeath) //movement in the y axis
        {
            playerrb.AddForce(new Vector3(0, -5, 0)); //movement in the y axis
        }

        Vector3 movement = new Vector3(moveHorizontal * speed, 0, moveVertical * speed); // movement in the xz plane
        playerrb.AddForce(movement);
    }

    void OnTriggerEnter(Collider other)
    {
        int step = 1;
        /*if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
        }*/

        if (other.gameObject.CompareTag("Pickup"))
        {            
            collectionMode = true;
            other.gameObject.SetActive(false);
            score += step;
            //setScoreText(scoreText);
            updateMSText(msText);
            source.Play();
            StartCoroutine(waitCoRoutine());
            if (score >= (20 + 17 * step))
            {
                StartCoroutine(maybeCoRoutine());
            }
            collectionMode = false;
        }
        if (other.gameObject.CompareTag("the light 1"))
        {
            selfloveText.text += "\r\n";
        }
        if (other.gameObject.CompareTag("the light 2"))
        {
            selfloveText.text += "\r\n";
        }
        if (other.gameObject.CompareTag("the light 3"))
        {
            selfloveText.text += "\r\n";
        }
        if (other.gameObject.CompareTag("the light 4"))
        {
            selfloveText.text += "\r\n";
        }
        if (other.gameObject.CompareTag("the light 5"))
        {
            selfloveText.text += "\r\n";
        }
        if (other.gameObject.CompareTag("the light 6"))
        {
            selfloveText.text += "\r\n";
        }

    }

    IEnumerator waitCoRoutine()
    {
        //This is a coroutine
        float zero = 0;
        float origdrag = playerrb.drag;
        playerrb.drag = 1 / zero;
        speed = 0;
        yield return new WaitForSeconds(1);    
        playerrb.drag = origdrag;

        speed = 10;
    }

     IEnumerator deathCoRoutine()
     {
         yield return new WaitForSeconds(2);
         msText.text += "\r\ni can't take this anymore";
         yield return new WaitForSeconds(5);    
         msText.text += "\r\nfuck... EVERYTHING";
         yield return new WaitForSeconds(5);    
         msText.text += "\r\ni give up";
         yield return new WaitForSeconds(5);    
         endGameText.text = "congratulations, you died";
         scoreText.text = "";
         initiateDeath = true;
     }

	IEnumerator birthCoRoutine()
	{
		float zero = 0;
		float origdrag = 0;
		origdrag = playerrb.drag;
		playerrb.drag = 1 / zero;
		speed = 0;
		yield return new WaitForSeconds(1);
		endGameText.text += "\r\nit's hitting you Hard today.";
		yield return new WaitForSeconds(3);    
		endGameText.text = "\r\nthoughts swirl around in your mind";
		yield return new WaitForSeconds(3);    
		endGameText.text = "\r\nmaking you doubt yourself,";
		yield return new WaitForSeconds(3);    
		endGameText.text = "\r\nmaking you wish you were anyone else";
		yield return new WaitForSeconds(4);
		endGameText.text = "";
		playerrb.drag = origdrag;
		speed = 10;
		msText.text = "it's hitting you Hard today. thoughts swirl around in your mind\r\nmaking you doubt yourself, making you wish you were anyone else\r\n\r\nthoughts like...\r\n";
	}

    IEnumerator maybeCoRoutine() 
	{
		yield return new WaitForSeconds(1);
        //This is a coroutine
        float zero = 0;
        float origdrag = playerrb.drag;

		playerrb.drag = 1 / zero;
		speed = 0;
        msText.enabled = false;
        endGameText.text = "it's scary to have these thoughts\r\n";
		yield return new WaitForSeconds(2);
        endGameText.text = "but so many of us do.\r\nthey drain us, popping up again and again";
		yield return new WaitForSeconds(2);
		endGameText.text = "each of us has our own way to deal with dysphoria,\r\nand all the uncertainty, doubt, and fear that comes with it.\r\n";
		yield return new WaitForSeconds(2);
		endGameText.text = "sometimes it's impossible to overcome in the moment,";
		yield return new WaitForSeconds(2);
		endGameText.text += "\r\nsometimes it blindsides us,\r\n";
		yield return new WaitForSeconds(2);
		endGameText.text += "and there's nothing we can do about it\r\n but survive until it passes";
		yield return new WaitForSeconds(2);
		endGameText.text = "other times, we turn to friends, to loved ones, or to ourselves, waiting out the storm.";
		yield return new WaitForSeconds(2);
		endGameText.text = "Or, we turn to art. To creating something, anything, to express the pain we feel.";
		yield return new WaitForSeconds(2);
		endGameText.text = "Or we find some other way: we try to understand it, or fight it, or placate it.";
		yield return new WaitForSeconds(2);
		endGameText.text = "but so many of us do,\r\nthey pop up over and over,\r\nyear after year";
		endGameText.text = "";
 
   
        yield return new WaitForSeconds(1);    
		msText.enabled = true;        
		playerrb.drag = origdrag;
		speed = 10;   
    }


    void setScoreText(Text st)
    {
        st.text = "Age: " + score.ToString();
    }

    void updateMSText(Text ms)
    {
        ms.text = ms.text + (milestones[index++] + "\r\n");
    }

    public static void Swap(string[] list, int i, int j)
    {
        var temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }

    public static void Shuffle(string[] list, System.Random rnd)
    {
        for (var i = 0; i < list.Length; i++)
            Swap(list, i, rnd.Next(i, list.Length));
    }


}
   
