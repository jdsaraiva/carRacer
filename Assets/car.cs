/*
using UnityEngine;
using System.Collections;

public class car : MonoBehaviour {

	public float speed = 90f;
	public float turnSpeed = 1f; 
	private float powerInput;
	private float turnInput;
	private Rigidbody carRigidbody;


	void Awake () 
	{
		carRigidbody = GetComponent <Rigidbody>();
	}

	void Update () 
	{
		powerInput = Input.GetAxis ("Vertical");
		turnInput = Input.GetAxis ("Horizontal");
	}

	void FixedUpdate()
	{

		carRigidbody.AddRelativeForce(0f, 0f, powerInput * speed);
		carRigidbody.transform.Rotate (0f, turnInput * turnSpeed, 0f);
	}
}
*/

﻿using UnityEngine;
using System.Collections;

public class car : MonoBehaviour {

	public bool Ligado;
	float Rate;
	float SelecEm;

	public float Velocidade;
	public float MaximaDirecao;
	public float FordaDeAceleracao;
	public float ForcaDeFreio;
	public WheelCollider RodaFE;
	public WheelCollider RodaFD;
	public WheelCollider RodaTE;
	public WheelCollider RodaTD;

	void Start () {
		Ligado = false;
		SelecEm = 0.3f;
	}
	void FixedUpdate () {
		Rate += Time.deltaTime;
		RodaFE.steerAngle = Input.GetAxis ("Horizontal") * MaximaDirecao;
		RodaFD.steerAngle = Input.GetAxis ("Horizontal") * MaximaDirecao;

		if (Ligado && Input.GetKeyDown(KeyCode.F) && Rate>SelecEm){
			Ligado = false; Rate = 0;}

		if (!Ligado && Input.GetKeyDown(KeyCode.F) && Rate>SelecEm){
			Ligado = true; Rate = 0;}

		Velocidade = GetComponent<Rigidbody>().velocity.magnitude;
		if (Ligado) {
			RodaTE.motorTorque = Input.GetAxis ("Vertical") * FordaDeAceleracao;
			RodaTD.motorTorque = Input.GetAxis ("Vertical") * FordaDeAceleracao;
			RodaTE.brakeTorque = 0; RodaTD.brakeTorque = 0;}
		if (Input.GetKey (KeyCode.Space)) {
			RodaTE.brakeTorque = ForcaDeFreio; RodaTD.brakeTorque = ForcaDeFreio;}
	}
}
