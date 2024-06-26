// See https://aka.ms/new-console-template for more information


int[][] arrayDeArrays = new int[20][];
Random random = new Random();
List<int> tijolosCortados = new List<int> ();
int valorFinal = 99;

for (int i = 0; i < 20; i++)
{
    arrayDeArrays[i] = GerarSubArray(random);
}

// Exibindo os arrays gerados
for (int i = 0; i < arrayDeArrays.Length; i++)
{
    foreach (int valor in arrayDeArrays[i])
    {
        Console.Write(valor + " ");
    }
    Console.WriteLine();
}

for (int rodada = 0; rodada < 29; rodada++) //A rodada de verificação vai somente até 29 pois o 30 seria o canto direito da parede, que sempre daria 0.
{
    int qtdCortados = 0;

    for (int i = 0; i < arrayDeArrays.Length; i++)
    {
        int soma = 0;
        int valor;
        for (int j = 0; j <= rodada; j++)
        {
            if (arrayDeArrays[i].Length > j)
            {
                valor = arrayDeArrays[i][j];
                if (valor > rodada + 1)
                {
                    qtdCortados++;
                    break;
                }
                else if(soma + valor != rodada + 1)
                {
                    soma += arrayDeArrays[i][j];

                    if(soma > rodada + 1)
                    {
                        qtdCortados++;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
    tijolosCortados.Add(qtdCortados);
}



foreach (int valor in tijolosCortados)
{
    if (valorFinal > valor)
        valorFinal = valor;
}

Console.WriteLine();
Console.WriteLine("Menor quantidade de tijolos cortados:" + valorFinal);

static int[] GerarSubArray(Random random)
{
    int max_int = 30;
    int numeroDeElementos = random.Next(1, max_int);
    int[] subArray = new int[numeroDeElementos];

    for (int i = 0; i < numeroDeElementos - 1; i++)
    {
        subArray[i] = random.Next(1, max_int - (numeroDeElementos - i - 1) + 1);
        max_int -= subArray[i];
    }

    subArray[numeroDeElementos - 1] = max_int;

    // O trecho abaixo é para dar uma embaralhada nos tijolos
    for (int i = 0; i < subArray.Length; i++)
    {
        int j = random.Next(i, subArray.Length);
        int temp = subArray[i];
        subArray[i] = subArray[j];
        subArray[j] = temp;
    }

    return subArray;
}

Console.ReadLine();