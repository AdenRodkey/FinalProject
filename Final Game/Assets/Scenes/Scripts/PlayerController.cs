/*Aden Rodkey
 * 4/30/22
 * A script to control the player.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    //Variables, public and private
    //Singleton.
    public static PlayerController player { get; private set; }
    public Slider hp;
    public Slider stamina;
    public float movespeed;
    public float rotateSpeed;
    public float sprintspeed;
    public Text hptext;
    public Text staminatext;


    private bool IsSprinting;
    private Rigidbody rb;
    public float playerangle;
    public Transform playertrans;
    public GameObject navMesh;
    private GameObject[] enemyarray;
    public Collider coll;
    private EnemyController enemy;
    private SpawnEnemy enemyspawn;
    private LightManager timeloopvalue;
    private int enemyspawncounter;

    //Uses awake for singleton.
    private void Awake()
    {
        if (player != null && player != this)
            {
                Destroy(this);
            }
            else
            {
                player = this;
            }
       
    }
    // Start is called before the first frame update
    void Start()
    {
        //enemyspawncounter  = enemyspawn.enemyspawned;
        //Debug.Log(enemyspawncounter);
        //enemyarray = GameObject.FindGameObjectsWithTag("enemy");
        /*foreach(GameObject obj in enemyarray)
        {
            coll = GetComponent<CapsuleCollider>();
            
        } */
        //Sets all values for appropriate variables
        //Cursor is confined, rotatesped, etc.
        Cursor.lockState = CursorLockMode.Confined;
        rotateSpeed = 500f;
        rb = GetComponent<Rigidbody>();
        movespeed = 35f;
        IsSprinting = Input.GetKeyDown(KeyCode.LeftShift);
        hp.value = 100;
        stamina.value = 100;
        //Ignores the collision of the navmesh with its capsule collider to sit on the procedural map. (probably why pathfinding doesnt work)
        Physics.IgnoreCollision(navMesh.GetComponent<MeshCollider>(), GetComponent<CapsuleCollider>());
        

    }

    // Update is called once per frame
    void Update()
    {
        //Sets the text values, calls athe playerotation for the camera.)
        hptext.text = "Health: " +  hp.value;
        staminatext.text = "Stamina: " + stamina.value;
        //PlayerDamage();
        PlayerRotation();
        
        //Check statements to check if W or S is down, then move in said direction.
        if(Input.GetKeyDown(KeyCode.W))
        {
           rb.velocity = transform.forward * movespeed;
        }
        
        else if(Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity = transform.forward * movespeed * -1;
        }
        //Check statmeent if Leftshift is down for the sprint function. (Works but buggy)
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            
            if(!IsSprinting)
            {
                movespeed = 50f;
                StartCoroutine(StaminaDeplete());
            }
         
            //Debug.Log("Shift pressed");
           
            //Debug.Log(IsSprinting);
           
            //Debug.Log(movespeed);
            
            

        }
        //Another check if the leftshift is up to return to normal.
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {

            //stamina.value++;
            movespeed = 35f;
           
        }
        //Check statmenets for the lose screen. 
        if (player.transform.position.y < 0)
        {
            SceneManager.LoadScene(2);
        }
        if (hp.value <= 0)
        {
            SceneManager.LoadScene(2);
        }

        /*else if (!Input.GetKeyDown(KeyCode.LeftShift))
        {
            movespeed = 35f;
            if(stamina.value >= 0 && stamina.value < 100)
            {
                stamina.value++;
            }
        }*/
    }

    //Player rotation so that the camera moves with the mouse cursor on the X axis. (Cannot look up and down.)
    void PlayerRotation()
    {
        playerangle += Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        
        playertrans.localRotation = Quaternion.AngleAxis(playerangle, Vector3.up);
    }
    //Coroutine for the stamina depletion, buggy.
    IEnumerator StaminaDeplete()
    {
        while(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("in loop");
            if (stamina.value >= 0)
            {
                stamina.value--; 
                yield return new WaitForSeconds(0.5f);
            }
                
            
        }
        
    }

    
    /*void PlayerDamage()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("In Mouse Button if");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            

            if (coll.GetComponent<CapsuleCollider>().Raycast(ray, out hit, 100.0f))
            {
                Debug.Log("In Raycast.");
                enemy.enemyhealth -= 10;
                Debug.Log(enemy.enemyhealth);
            }
        }
    } */

    //Collision event to see if you touch an enemy, if you do, l ose health, destroy the enemy and then decrement the spawncounter.
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("enemy"))
        {
            
            hp.value -= 10;
            Destroy(collision.gameObject);
            enemyspawncounter--;
            
           
        }
    }
    

}
