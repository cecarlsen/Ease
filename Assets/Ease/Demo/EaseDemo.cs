/*
	Copyright © Carl Emil Carlsen 2021
	http://cec.dk
*/

using System;
using System.Collections.Generic;
using UnityEngine;

public class EaseDemo : MonoBehaviour
{
	[Range(0,1)] public float speed = 0.3f;
	public Color idleColor = Color.gray;
	public Color selectedColor = Color.white;

	Dictionary<string,MethodElement> _methodLookup = new Dictionary<string,MethodElement>();
	LineRenderer _line;
	float _t;
	float _tableHeight;

	MethodElement _selectedElement = null;

	const float rowHeight = 0.1f;
	const int fontSize = 100;
	const float rowSpacing = 0.06f;
	const float elementSpacing = 0.2f;
	const float easeDistance = 8;

	class MethodElement
	{
		public Func<float,float> method;
		public TextMesh textMesh;
		public Transform sphereTransform;

		public MethodElement( Func<float,float> method )
		{
			this.method = method;

			textMesh = new GameObject( method.Method.Name ).AddComponent<TextMesh>();
			textMesh.fontSize = fontSize;
			textMesh.characterSize = 10 * rowHeight / (float) fontSize;
			textMesh.alignment = TextAlignment.Right;
			textMesh.anchor = TextAnchor.MiddleRight;
			textMesh.text = method.Method.Name;
			textMesh.gameObject.AddComponent<BoxCollider>();

			sphereTransform = GameObject.CreatePrimitive( PrimitiveType.Sphere ).transform;
			Destroy( sphereTransform.gameObject.GetComponent<Collider>() );
			sphereTransform.name = "Sphere";
		}

		public void SetColor( Color color )
		{
			textMesh.color = color;
			sphereTransform.GetComponent<Renderer>().material.color = color;
		}
	}


	void Awake()
	{
		AddEasingFunction( Ease.SmoothStart2 );
		AddEasingFunction( Ease.SmoothStart3 );
		AddEasingFunction( Ease.SmoothStart4 );
		AddEasingFunction( Ease.SmoothStart5 );
		AddEasingFunction( Ease.SmoothStart6 );
		AddEasingFunction( Ease.SmoothStart7 );
		AddEasingFunction( Ease.SmoothStart8 );
		AddEasingFunction( Ease.SmoothStart9 );
		AddEasingFunction( Ease.SmoothStart10 );
		AddEasingFunction( Ease.SmoothStop2 );
		AddEasingFunction( Ease.SmoothStop3 );
		AddEasingFunction( Ease.SmoothStop4 );
		AddEasingFunction( Ease.SmoothStop5 );
		AddEasingFunction( Ease.SmoothStop6 );
		AddEasingFunction( Ease.SmoothStop7 );
		AddEasingFunction( Ease.SmoothStop8 );
		AddEasingFunction( Ease.SmoothStop9 );
		AddEasingFunction( Ease.SmoothStop10 );
		AddEasingFunction( Ease.SmoothStep2 );
		AddEasingFunction( Ease.SmoothStep3 );
		AddEasingFunction( Ease.SmoothStep4 );
		AddEasingFunction( Ease.SmoothStep5 );
		AddEasingFunction( Ease.SmoothStep6 );
		AddEasingFunction( Ease.SmoothStep7 );
		AddEasingFunction( Ease.SmoothStep8 );
		AddEasingFunction( Ease.SmoothStep9 );
		AddEasingFunction( Ease.SmoothStep10 );
		AddEasingFunction( Ease.Arch2 );
		AddEasingFunction( Ease.SmoothStartArch3 );
		AddEasingFunction( Ease.SmoothStopArch3 );
		AddEasingFunction( Ease.SmoothStepArch4 );
		AddEasingFunction( Ease.BellCurve6 );
		//AddEasingFunction( Ease.ElasticStop );

		void AddEasingFunction( Func<float,float> f ){
			_methodLookup.Add( f.Method.Name, new MethodElement( f ) );
		}

		int i = 0;
		foreach( MethodElement me in _methodLookup.Values )
		{
			Vector3 position = Vector3.down * ( i * ( rowHeight + rowSpacing ) );

			me.textMesh.transform.SetParent( transform );
			me.textMesh.transform.position = position + Vector3.left * elementSpacing;
			me.textMesh.gameObject.AddComponent<BoxCollider>();
			me.textMesh.color = idleColor;

			me.sphereTransform.SetParent( me.textMesh.transform );
			me.sphereTransform.localPosition = Vector3.zero;
			me.sphereTransform.localScale = Vector3.one * rowHeight;

			me.SetColor( idleColor );

			i++;
		}

		_line = new GameObject( "Line" ).AddComponent<LineRenderer>();
		_line.positionCount = 100;
		_line.startWidth = rowHeight * 0.2f;
		_line.endWidth = _line.startWidth;
		_line.material = new Material( Shader.Find( "Unlit/Color" ) );

		_tableHeight = _methodLookup.Count * ( rowHeight + rowSpacing ) - rowSpacing; 
	}


	void Update()
	{
		// Move spheres.
		_t = ( _t + Time.deltaTime * speed )  % 1f;
		foreach( MethodElement me in _methodLookup.Values )
		{
			float r = me.method.Invoke( _t );
			me.sphereTransform.localPosition = Vector3.right * ( elementSpacing + r * easeDistance );
		}

		// Update interaction.
		Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
		RaycastHit hit;
		if( Physics.Raycast( ray, out hit ) ) {
			MethodElement me;
			if( _methodLookup.TryGetValue( hit.collider.name, out me ) ) {
				if( me != _selectedElement ) {
					if( _selectedElement != null ) _selectedElement.SetColor( idleColor );
					for( int i = 0; i < _line.positionCount; i++ ) {
						float xn = i / ( _line.positionCount - 1f );
						float yn = me.method.Invoke( xn );
						_line.SetPosition( i, new Vector3( xn * easeDistance, yn * _tableHeight - _tableHeight ) ); 
					}
					_selectedElement = me;
					_selectedElement.SetColor( selectedColor );
				}
			}
		}
	}
}