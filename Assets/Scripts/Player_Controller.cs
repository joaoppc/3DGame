using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
   public float speed = 8; // velocidade do jogador
   public float gravity = -9.8f; // valor da gravidade
   public LayerMask groundMask;
   CharacterController character;
   Vector3 velocity;
   bool isGrounded;
   public Animator animator;
   bool moving, tesouro;
   BoxCollider castleEntrance;
   GameObject castleE;
   public Animator canvasAnimator;
   public GameObject Winner;
   public GameObject Instrucoes;
   
 
   void Start()
   {
       character = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
        canvasAnimator = gameObject.GetComponent<Animator>();
        castleEntrance = castleE.GetComponent<BoxCollider>();
        moving = false;
        tesouro = false;
        
         
         
       
   }
  
 
   void Update()
   {
       StartCoroutine(Inicio());
 
       // Verifica se encostando no chão (o centro do objeto deve ser na base)
       isGrounded = Physics.CheckSphere(transform.position, 0.2f, groundMask);
      
       // Se no chão e descendo, resetar velocidade
       if(isGrounded && velocity.y < 0.0f) {
           velocity.y = -1.0f;
       }
 
       float x = Input.GetAxis("Horizontal");
       float z = Input.GetAxis("Vertical");
 
       // Rotaciona personagem
       transform.Rotate(0, x * speed * 10 * Time.deltaTime, 0);
 
       // Move personagem
       Vector3 move = transform.forward * z;
       character.Move(move * Time.deltaTime * speed);
       if (move != Vector3.zero){
           if (moving == false){
               //checa se o personagem está movendo para animação
               animator.SetBool("moving",true);
               moving = true;
           }
           
       }else{
           if (moving == true){
               animator.SetBool("moving",false);
               
               moving = false;
           } 
           
       }
 
       // Aplica gravidade no personagem
       velocity.y += gravity * Time.deltaTime;
       character.Move(velocity * Time.deltaTime);
   }

   private void OnTriggerEnter(Collider other) {
       //entra no castelo
        if(other.tag == "castle")
        {
            //transição
            canvasAnimator.SetBool("fadeout", true);
            StartCoroutine(Transicao());
           
        }
        // checa se encontrou o tesouro
        if(other.tag == "treasure"){
            if (tesouro == false){
                animator.SetBool("findTreasure", true);
                tesouro = true;
            }
            
            StartCoroutine(Vitoria());
        }


   }
   

   IEnumerator Transicao() {
       //espera a transição
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(2);
        
    } 
    IEnumerator Vitoria() {
       //espera um tempo antes de carregar o menu
        Winner.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
        
    } 
    IEnumerator Inicio() {
       //da um tempo as instucoes
        yield return new WaitForSeconds(5f);
        Destroy(Instrucoes);
       
    }

    

   
}

