using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
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
        Cursor.lockState = CursorLockMode.Confined;
        rotateSpeed = 500f;
        rb = GetComponent<Rigidbody>();
        movespeed = 35f;
        IsSprinting = Input.GetKeyDown(KeyCode.LeftShift);
        hp.value = 100;
        stamina.value = 100;
        Physics.IgnoreCollision(navMesh.GetComponent<MeshCollider>(), GetComponent<CapsuleCollider>());
        

    }

    // Update is called once per frame
    void Update()
    {
        hptext.text = "Health: " +  hp.value;
        staminatext.text = "Stamina: " + stamina.value;
        //PlayerDamage();
        PlayerRotation();
        
        if(Input.GetKeyDown(KeyCode.W))
        {
           rb.velocity = transform.forward * movespeed;
        }
        
        else if(Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity = transform.forward * movespeed * -1;
        }
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
        
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {

            //stamina.value++;
            movespeed = 35f;
           
        }
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

    void PlayerRotation()
    {
        playerangle += Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        
        playertrans.localRotation = Quaternion.AngleAxis(playerangle, Vector3.up);
    }
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
