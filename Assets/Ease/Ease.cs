/*
	General purpose easing functions.

	All input values should be normalized (0.0 to 1.0).

	Implementation based on the ideas presented in the GDC talk: 
	"Math for Game Programmers: Fast and Funky 1D Nonlinear Transformations" by Squirrel Eiserloh.
	https://www.youtube.com/watch?v=mr5xkf6zSzk

	We avoid using internal method calls because it slows down C#.

	The MIT License (MIT)

		Copyright (c) 2018-2021, Carl Emil Carlsen http://cec.dk

		Permission is hereby granted, free of charge, to any person obtaining a copy
		of this software and associated documentation files (the "Software"), to deal
		in the Software without restriction, including without limitation the rights
		to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
		copies of the Software, and to permit persons to whom the Software is
		furnished to do so, subject to the following conditions:

		The above copyright notice and this permission notice shall be included in
		all copies or substantial portions of the Software.

		THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
		IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
		FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
		AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
		LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
		OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
		THE SOFTWARE.
*/

using System.Runtime.CompilerServices;

public static class Ease
{
	// Quadratic.
	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStart2( float t ){
		return t*t;
	}

	// Cubic.
	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStart3( float t ){
		return t*t*t;
	}

	// Quartic.
	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStart4( float t ){
		return t*t*t*t;
	}

	// Quintic.
	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStart5( float t ){
		return t*t*t*t*t;
	}

	// Sextic.
	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStart6( float t ){
		return t*t*t*t*t*t;
	}

	// Septic.
	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStart7( float t ){
		return t*t*t*t*t*t*t;
	}

	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStart8( float t ){
		return t*t*t*t*t*t*t*t;
	}

	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStart9( float t ){
		return t*t*t*t*t*t*t*t*t;
	}

	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStop2( float t ){
		t = 1-t;
		return 1 - t*t;
	}

	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStop3( float t ){
		t = 1-t;
		return 1 - t*t*t;
	}

	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStop4( float t ){
		t = 1-t;
		return 1 - t*t*t*t;
	}

	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStop5( float t ){
		t = 1-t;
		return 1 - t*t*t*t*t;
	}

	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStop6( float t ){
		t = 1-t;
		return 1 - t*t*t*t*t*t;
	}

	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStop7( float t ){
		t = 1-t;
		return 1 - t*t*t*t*t*t*t;
	}

	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStop8( float t ){
		t = 1-t;
		return 1 - t*t*t*t*t*t*t*t;
	}

	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStop9( float t ){
		t = 1-t;
		return 1 - t*t*t*t*t*t*t*t*t;
	}

	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStep2( float t ){
		float i = 1-t;
		float a = t*t;
		return a + ( ( 1 - i*i ) - a ) * t;
	}

	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStep3( float t ){
		float i = 1-t;
		float a = t*t*t;
		return a + ( ( 1 - i*i*i ) - a ) * t;
	}

	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStep4( float t ){
		float i = 1-t;
		float a = t*t*t*t;
		return a + ( ( 1 - i*i*i*i ) - a ) * t;
	}

	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStep5( float t ){
		float i = 1-t;
		float a = t*t*t*t*t;
		return a + ( ( 1 - i*i*i*i*i ) - a ) * t;
	}

	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStep6( float t ){
		float i = 1-t;
		float a = t*t*t*t*t*t;
		return a + ( ( 1 - i*i*i*i*i*i ) - a ) * t;
	}

	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStep7( float t ){
		float i = 1-t;
		float a = t*t*t*t*t*t*t;
		return a + ( ( 1 - i*i*i*i*i*i*i ) - a ) * t;
	}

	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStep8( float t ){
		float i = 1-t;
		float a = t*t*t*t*t*t*t*t;
		return a + ( ( 1 - i*i*i*i*i*i*i*i ) - a ) * t;
	}

	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStep9( float t ){
		float i = 1-t;
		float a = t*t*t*t*t*t*t*t*t;
		return a + ( ( 1 - i*i*i*i*i*i*i*i*i ) - a ) * t;
	}

	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float Arch2( float t ){
		return -t * (t-1) * 4;
	}

	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStartArch3( float t ){
		return - t*t * (t-1) * 6.75f;
	}

	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStopArch3( float t ){
		t = 1-t;
		return SmoothStartArch3( t );
	}

	/// <summary>
	/// Approximates sinusoidal wave.
	/// </summary>
	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float SmoothStepArch4( float t ){
		return -(t-1) * t * Arch2( t ) * 4;
	}

	/// <summary>
	/// Approximates bell curve.
	/// </summary>
	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float BellCurve6( float t ){
		return SmoothStartArch3(t) * SmoothStopArch3(t) * 1.4046f;
	}

	/*
	// NOT PERFECT YET.
	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	public static float ElasticStop( float t )
	{
		float l = t * 1.5f;
		if( l > 1f ) l = 1f;
		float s = ( t - 0.666f ) * 3f;
		if( s < 0f ) s = 0;
		return 
			SmoothStep2( SmoothStart2( l ) ) + 
			( SmoothStepArch4( ( t * 9 ) % 1f ) - 0.5f ) * ( SmoothStopArch3( s ) ) * 0.2f;
	}

	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	static float Lerp( float a, float b, float t )
	{
		return a + ( b - a ) * t;
	}

	[MethodImpl( MethodImplOptions.AggressiveInlining )]
	static float InverseLerpClamped( float a, float b, float t )
	{
		t = ( t - a ) / ( b - a );
		if( t < 0f ) t = 0f;
		else if( t > 1f ) t = 1f;
		return a + ( b - a ) * t;
	}
	*/
}