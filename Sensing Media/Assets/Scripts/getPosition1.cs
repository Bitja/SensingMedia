using UnityEngine;
using System.Collections;

public class getPosition1 : MonoBehaviour {

    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    // private ParticleSystem centerParticle;   //Idea: have the center particle hidden when moving mouse

    void Update() {
       
        // ParticleCenter is hidden, ParticleTail is displayed
        if (Input.GetMouseButton(0)) {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
            //gameObject.GetComponent<ParticleSystem>().enableEmission = false;
            //Debug.Log(mousePosition);
        }
        /* If no touch detected: ParticleCenter is displayed
        else{
            gameObject.GetComponent<ParticleSystem>().enableEmission = true;
        } */
    }
}
