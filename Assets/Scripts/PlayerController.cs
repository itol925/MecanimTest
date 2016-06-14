using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	Animator m_animator;
	// Use this for initialization
	void Start () {
		this.m_animator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){		
		var h = Input.GetAxis ("Horizontal");
		var v = Input.GetAxis ("Vertical");
		this.m_animator.SetFloat ("Speed", v);
		this.m_animator.SetFloat ("SideMove", h);
	}
}
