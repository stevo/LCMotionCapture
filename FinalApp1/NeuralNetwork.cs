using System;


namespace FinalApp1
{
	/// <summary>
	/// Klasa definiujaca siec neuronowa
	/// </summary>
	public class NeuralNetwork
	{

		public NeuralNetworkLayer               inputLayer, outputLayer;
		public NeuralNetworkLayer               []hiddenLayers;

		public NeuralNetwork (int inputSize, int hiddenLayersSize, int outputSize,
							  int hiddenLayersCount, iActivationFunction f)
            {
                  // tworzenie odpowiednich warstw...

                  inputLayer = new NeuralNetworkLayer(inputSize, f); //****
                  outputLayer = new NeuralNetworkLayer(outputSize, f);
                  hiddenLayers = new NeuralNetworkLayer[hiddenLayersCount];

                  for (int i=0; i<hiddenLayersCount; i++)
					{ hiddenLayers[i] = new NeuralNetworkLayer(hiddenLayersSize, f); }

                  // ...i laczenie ich ze soba.

                  //wyjsciowej z ukrytymi
                  outputLayer.AttachToLayer(hiddenLayers[hiddenLayersCount-1]);

				  //ukrytych ze sob¹
                  for (int i=(hiddenLayersCount-1); i>0; i--)

                  {
                        hiddenLayers[i].AttachToLayer(hiddenLayers[i-1]);
                  }
	
				  //ukrytych z wejœciow¹
                  hiddenLayers[0].AttachToLayer(inputLayer);
            }
		

		public void DrawWeights(double Min, double Max)
		{
			Random Rand = new Random();
			outputLayer.DrawWeights(Min, Max, Rand);
			for (int i=0; i<hiddenLayers.Length; i++)
			{
				hiddenLayers[i].DrawWeights(Min, Max, Rand);
			}
		}
		

		public double[] Calculate(double []Input)
		{
			//ustawiamy wyjscia warstwy wejsciowej
			inputLayer.SetOutput(Input);

			for (int i=0; i<hiddenLayers.Length; i++)
			{
				hiddenLayers[i].CalculateLayerOutput();
			}

			outputLayer.CalculateLayerOutput();

			return outputLayer.returnOutput();
		}


		public void TrainNetwork(double []correctOutput, double []Input, double trainingFactor)
		{
	    	outputLayer.ClearErrors();

			for (int i=0; i<hiddenLayers.Length; i++)
			{ 
				hiddenLayers[i].ClearErrors(); 
			}

			Calculate(Input);

			outputLayer.CalculateErros(correctOutput);

			outputLayer.BackPropagateErrors();

			for (int i=(hiddenLayers.Length-1); i>0; i--)
			{ 
				hiddenLayers[i].BackPropagateErrors(); 
			}

			outputLayer.CorrectWeights(trainingFactor);

			for (int i=0; i<hiddenLayers.Length; i++)
			{ 
				hiddenLayers[i].CorrectWeights(trainingFactor); 
			}

		}
	}
}
