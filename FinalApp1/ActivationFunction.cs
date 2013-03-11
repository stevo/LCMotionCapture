using System;

namespace FinalApp1
{
	/// <summary>
	/// Klasa definiujaca funkcje aktywacji dla neuronow
	/// </summary>
	
	public interface iActivationFunction
	{
		//metody do implementacji
		double CalculateFunctionValue(double Input);
		double CalculateFunctionDerivative(double Output);
	}
	
	public class LogisticCurve : iActivationFunction
	{
		public double Beta;

		//konstruktory
		public LogisticCurve() { Beta = 1.0; }
		public LogisticCurve(double B) { Beta = B; }

		//metody
		public double CalculateFunctionValue(double Input)
		{
			return (1.0 / (1.0 + Math.Pow(Math.E, -(Beta * Input))));
		}

		public double CalculateFunctionDerivative(double Output)
		{
			return Output * (1.0 - Output);
		}
	}
}
