using System;

class Program
{
    static void Ejercicio1()
    {
        //Matriz Bidimensional
        int[,] matriz = 
        {
            //5 filas, 5 columnas.
            {0, 2, 5, 7, 6}, 
            {0, 0, 0, 3, 8}, 
            {2, 9, 6, 3, 4},
            {1, 5, 6, 1, 4},
            {0, 9, 2, 5 ,0}, 
        };
        Console.WriteLine("La matriz en cuestion es:");
        for(int i = 0; i < 5; i++)
        {
            
            for(int j = 0; j < 5; j++)
            {
                Console.Write($"{matriz[i,j],4}");
            }
            Console.WriteLine("");
        }
        /*
        Bucle, cada que se alcanza la fila maxima, se aumenta una fila. 
        
        en este en particular, se comprueba
        la cantidad de filas existentes para evitar que 
        I solicite una fila que no existe, como la fila 6.
        ej:  {0, 2, 5, 7, 8} (horizontalmente) seria 1 fila. por lo que
        en la matriz, solo hay 5. 
        */
        for(int i = 0; i < matriz.GetLength(0); i++)
        {
            int conteo = 0;
        /*
        Aca se comprueba la cantidad de columnas para hacer lo mismo.
        Solo se mueve la columna primero para evitar que se dejen datos sin comprobar
        por filas.
        Una vez llegado al limite, se reinica en 0 para comprobar la nueva fila.
        */ 
            for(int j = 0;  j < matriz.GetLength(1); j++)
            {
                /*
                Todo esto con el solo objetivo de realizar
                una peticion de coordenadas usando i como X y J como Y.
                Ej: 0 , 1. 4, 4. 3, 2.
                En la matriz, 0,0 seria el primer 0 ({0, 2, 5, 7, 6})
                y 0,1 seria 2. 0,2 seria 5. 0,3 seria 7. 
                y 1,0 seria 0. (fila 2 {0, 0, 0, 3, 8})
                */ 
                if(matriz[i,j] == 0)
                {
                    conteo++;
                }
            }
            //Esto imprime el resultado del conteo cada que una fila se completa.
            //El valor de la fila es i + 1 por que las filas empiezan por 0 y terminan en 4.
            Console.WriteLine($"La fila {i + 1} tiene {conteo} ceros.");
        }
    }
    static void Ejercicio2()
    {
        bool val = true;
        //Se crea la matriz bidimensional segun lo solicite el usuario
        
        int fila = 0;
        while(true)
        {
            try
            {
                Console.WriteLine("Introduce la cantidad de filas y columnas que tendra la matriz: ");
                fila = Convert.ToInt32(Console.ReadLine());
                break;
            }
            catch(System.Exception)
            {
                Console.WriteLine("!!!Solo debes poner numeros enteros!!!");
            }
        }

        int columna = fila;
        Console.WriteLine($"La matriz sera un {fila} x {columna}");
        int[,] matriz = new int[fila,columna];
        //El bucle para dar el dato de la fila
        for(int i = 0; i < fila; i++)
        {
            //El bucle para dar el dato de la columna
            for(int j = 0; j < columna; j++)
            {
                //El usuario introduce el dato por coordenada de matriz
                
                while(true)
                {
                    try
                    {
                        Console.WriteLine($"Introduce el valor para la posicion {i + 1} * {j + 1}");
                        matriz[i,j] = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch(System.Exception)
                    {
                        Console.WriteLine("!!!Solo debes poner numeros enteros!!!");
                    }
                }
                
            }
            
        }
        
        Console.WriteLine($"Los valores introducidos son: ");
        //Simple comprobacion para validar que todos los datos existen
        for (int i = 0; i < fila; i++)
        {
            for(int j = 0; j < columna; j ++)
            {
                Console.Write($"{matriz[i,j],4}");
            }
            Console.WriteLine();
        }
        int n = matriz.GetLength(0);
        int sumaMagi = n * (n * n + 1) / 2;

        //Si todos los valores coinciden, Es un cuadrado magico.
        if(comprobar(matriz, sumaMagi, n) == true)
        {
            Console.WriteLine($"La matriz es un cuadrado magico \nla constante magica es {sumaMagi}");
        }
        //Sino, no lo es.
        else
        {
            Console.WriteLine("La matriz NO es un cuadrado magico");
        }
    }

    static bool comprobar(int[,] matriz, int sumaMagi, int n)
    {
        //Suma de filas
        for (int i = 0; i < n; i++)
        {
            int sumarFila = 0;
            for(int j = 0; j < n; j ++)
            {
                sumarFila += matriz[i,j];
            }
            if(sumarFila != sumaMagi)
            {
                return false;
            }
        }
        //Suma de columnas
        for (int j = 0; j < n; j++)
        {
            int sumarColumna = 0;
            for(int i = 0; i < n; i++)
            {
                sumarColumna += matriz[i,j];
            }
            if(sumarColumna != sumaMagi)
            {
                return false;
            }
        }
        //Se suma la primera diagonal (izquierda a derecha)
        int sumaDiagonal1 = 0;
        for (int i = 0; i < n; i++)
        {
            sumaDiagonal1 += matriz[i, i];
        }

        if (sumaDiagonal1 != sumaMagi)
        {
            return false;
        }
        //Se suma la segunda diagonal (Derecha a izquierda)
        int sumaDiagonal2 = 0;
        for (int i = 0; i < n; i++)
        {
            sumaDiagonal2 += matriz[i, n - i - 1];
        }

        if (sumaDiagonal2 != sumaMagi)
        {
            return false;
        }
        //Si todos los valores coinciden, se considera un cudrado magico
        return true;
    }
    //Operaciones de matrices
    static void Ejercicio3()
    {
        //Menu para operaciones de matrices
        Console.WriteLine("Que operacion deseas realizar?\n 1.Suma \n 2.Resta \n 3.Multiplicacion \n 4.Division");
        string conf = Console.ReadLine();
        //En caso de que el usuario no introduzca una operacion valida, evita que se ejecute.
        if(conf == "1" || conf == "2" || conf == "3" || conf == "4")
        {
            //Son double para poder dividir.
            double[,] matriz = new double[2,2];
            double[,] matriz2 = new double[2,2];
            //La matriz resultado
            double[,] matriz3 = new double[2,2];
            //Almacenamiento temporal de los resultados
            double resu = 0;
            //Se solicitan datos para la primera matriz
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    //El usuario introduce el dato por coordenada de matriz
                    while(true)
                    {
                        try
                        {
                            Console.WriteLine($"Introduce el valor para la posicion {i + 1} * {j + 1} de la matriz 1");
                            matriz[i,j] = Convert.ToDouble(Console.ReadLine());
                            break;
                        }
                        catch(System.Exception)
                        {
                            Console.WriteLine("!!!Solo debes poner numeros enteros!!!");
                        }
                    }

                }
                
            }
            //Se solicitan datos para la segunda matriz
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    while(true)
                    {
                        try
                        {
                            //El usuario introduce el dato por coordenada de matriz
                            Console.WriteLine($"Introduce el valor para la posicion {i + 1} * {j + 1} de la matriz 2");
                            matriz2[i,j] = Convert.ToDouble(Console.ReadLine());
                            break;
                        }
                        catch(System.Exception)
                        {
                            Console.WriteLine("!!!Solo debes poner numeros enteros!!!");
                        }
                    }


                }
                
            }
            Console.WriteLine("La matriz 1 introducida es: ");
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    Console.Write($"{matriz[i,j],4}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("La matriz 2 introducida es: ");
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    Console.Write($"{matriz2[i,j],4}");
                }
                Console.WriteLine();
            }
            //Operar las matrices
            for(int i = 0; i < 2; i++)
            {
                
                for(int j = 0; j < 2; j++)
                {
                    if(conf == "1")
                    {
                        resu = matriz[i,j] + matriz2[i,j];
                    }
                    else if(conf == "2")
                    {
                        resu = matriz[i,j] - matriz2[i,j];
                    }
                    else if(conf == "3")
                    {
                        resu = matriz[i,j] * matriz2[i,j];
                    }
                    else if(conf == "4")
                    {
                        resu = matriz[i,j] / matriz2[i,j];
                    }
                    matriz3[i,j] = resu;
                }
            }
            Console.WriteLine($"El resultado es de la operacion es: ");
            //Imprimir resultado
            for(int i = 0; i < 2; i++)
            {
                
                for(int j = 0; j < 2; j++)
                {
                    Console.Write($"{matriz3[i,j],4}");
                }
                Console.WriteLine("");
            }
        }
        else
        {
            Console.WriteLine("Introduce una operacion valida.");
        }
    }
    static void Ejercicio4()
    {
        int n = 0;
        while(true)
        {
            try
            {
                //Se crea la matriz bidimensional segun lo solicite el usuario
                Console.WriteLine("Introduce la cantidad de filas y columnas que tendra la matriz: ");
                n = Convert.ToInt32(Console.ReadLine());
                break;
            }
            catch(System.Exception)
            {
                Console.WriteLine("!!!Solo debes poner numeros enteros!!!");
            }
        }

        Console.WriteLine($"La matriz sera un {n} x {n}");
        int[,] matriz = new int[n,n];
        //Rellenando la matriz
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < n; j++)
            {
                //Cualquier otro dato que no sea diagonal, es 0.
                matriz[i,j] = 0;
                //Se rellenan solo los datos diagonales.
                matriz[i,i] = 1;
            }
            
        }
        //Imprimir el resultado
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < n; j++)
            {
                Console.Write($"{matriz[i,j], 4}"); //Se usa especificamente el Console.Write para imprimir correctamente todas las variables de cada fila
            }
            Console.WriteLine(); //Esto genera una nueva linea para que se va estetico y con mas forma de tabla
        }

    }
    static void Ejercicio5()
    {
        //La matriz 5x10 que pidio la maestra
        int[,] matriz = new int[5,10];
        //La array que guarda la suma de cada fila (las 10 variables por cada 5 filas)
        int[] A = new int[5]; 
        //La array que guarda el promedio de cada fila (la cual dividimos entre 10, ya que hay n maximo de 10 valores por fila)
        double[] B = new double[5]; //Double para sacar bien el promedio
        //Array que guarda la suma de las columnas 
        int[] C = new int[10];
        //Array que guarda el promedio de las columnas (la cual dividimos entre 5, ya que hay hasta un maximo de 5 valores por columna.)
        double[] D = new double[10]; //Double con el mismo proposito
        Random random = new Random(); //Esto nomas genera datos aleatorios
        //Se crea la matriz y se dan primero los datos de suma de filas y promedio de filas
        for(int i = 0; i < 5; i++)
        {
            int sumarFila = 0;
            for(int j = 0; j < 10; j++)
            {
                matriz[i,j] = random.Next(1,10); //Un dato entero aleatorio entre 1 y 10 es generado e insertado por coordenada.
                sumarFila += matriz[i,j]; //La suma de la fila almacena cada dato generado y lo suma con el nuevo que entra.
            }
            A[i] = sumarFila; //Cada que se llega al limite de columnas, el valor de acumulador de sumarFila se guarda aca para evitar perderse al cambiar de fila.
            B[i] = (double)sumarFila / 10; //Cuando llega la mismo limite, Esto saca el promedio por fila y lo guarda.
            
        }
        for(int j = 0; j < 10; j++)
        {
            int sumarColumna = 0;
            for(int i = 0; i < 5; i++)
            {
                sumarColumna += matriz[i,j];
            }
            C[j] = sumarColumna;
            D[j] = (double)sumarColumna / 5;
            
        }
        // Imprimir la matriz en formato de tabla
        Console.WriteLine("Matriz (5x10):");
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                // Imprimir con 4 espacios para una alineación correcta
                Console.Write($"{matriz[i, j],4}");
            }
            Console.WriteLine(); // Nueva línea después de cada fila
        }

        // Imprimir el arreglo A (Sumas de las filas)
        Console.WriteLine("\nArreglo A (Suma de las filas):");
        for (int i = 0; i < A.Length; i++)
        {
            Console.WriteLine($"Fila {i + 1}: {A[i]}");
        }

        // Imprimir el arreglo B (Promedios de las filas)
        Console.WriteLine("\nArreglo B (Promedios de las filas):");
        for (int i = 0; i < B.Length; i++)
        {
            Console.WriteLine($"Fila {i + 1}: {B[i]:0.0}");
        }

        // Imprimir el arreglo C (Sumas de las columnas)
        Console.WriteLine("\nArreglo C (Suma de las columnas):");
        for (int j = 0; j < C.Length; j++)
        {
            Console.WriteLine($"Columna {j + 1}: {C[j]}");
        }

        // Imprimir el arreglo D (Promedios de las columnas)
        Console.WriteLine("\nArreglo D (Promedios de las columnas):");
        for (int j = 0; j < D.Length; j++)
        {
            Console.WriteLine($"Columna {j + 1}: {D[j]:0.0}");
        }
    }
    static void Ejercicio6()
    {
        string mes = "";
        string dia = "";
        int[,] matriz = new int[12,5]
        {
            {5,16,10,12,24},
            {40,55,10,11,18},
            {15,41,78,14,51},
            {35,22,81,15,12},
            {50,12,71,10,20},
            {70,40,60,28,22},
            {50,50,50,36,25},
            {40,70,40,11,20},
            {20,20,30,12,18},
            {10,40,32,13,16},
            {50,3,24,15,82},
            {40,46,15,46,22}
        };
        Console.WriteLine("Tabla de ventas:");
        for(int i = 0; i < 12; i++)
        {
            
            for(int j = 0; j < 5; j++)
            {
                Console.Write($"{matriz[i,j],4}");
            }
            Console.WriteLine("");
        }
        int menVen = matriz[0,0];
        int mayVen = 0;
        int ventaTota = 0;
        //Calcula la venta menor
        for(int i = 0; i < 12; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                ventaTota += matriz[i,j];
                if(menVen > matriz[i,j])
                {
                    menVen = matriz[i,j];
                    mes = (i+1).ToString();
                    dia = (j+1).ToString();
                }
                else
                {
                    menVen = menVen;
                    mes = mes;
                    dia = dia;
                }
            }
            
        }
        Console.WriteLine($"La menor venta realiza ha sido: ${menVen} \nrealizada el mes {compMes(mes)} y el dia {compDia(dia)}");
        //calcular Venta mayor
        for(int i = 0; i < 12; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                if(mayVen < matriz[i,j])
                {
                    mayVen = matriz[i,j];
                    mes = (i+1).ToString();
                    dia = (j+1).ToString();
                }
                else
                {
                    mayVen = mayVen;
                    mes = mes;
                    dia = dia;
                }
            }
            
        }
        Console.WriteLine($"La mayor venta realiza ha sido: ${mayVen} \nrealizada el mes {compMes(mes)} y el dia {compDia(dia)}");
        Console.WriteLine($"La venta total ha sido de: ${ventaTota}");
        //Suma de columnas
        for (int j = 0; j < 5; j++)
        {
            int sumarColumna = 0;
            for(int i = 0; i < 12; i++)
            {
                sumarColumna += matriz[i,j];
                dia = (j+1).ToString();
            }
            Console.WriteLine($"La venta total por dia {compDia(dia)} fue de ${sumarColumna}");
        }
    }
    static string compMes(string mes)
    {
        switch (mes)
        {
            case "1":
            mes = "Enero";
            break;
            case "2":
            mes = "Febrero";
            break;
            case "3":
            mes = "Marzo";
            break;
            case "4":
            mes = "Abril";
            break;
            case "5":
            mes = "Mayo";
            break;
            case "6":
            mes = "Junio";
            break;
            case "7":
            mes = "Julio";
            break;
            case "8":
            mes = "Agosto";
            break;
            case "9":
            mes = "Septiembre";
            break;
            case "10":
            mes = "Octubre";
            break;
            case "11":
            mes = "Novimebre";
            break;
            case "12":
            mes = "Diciembre";
            break;
        }
        return mes;
    }
    static string compDia(string dia)
    {
        switch (dia)
        {
            case "1":
            dia = "Lunes";
            break;
            case "2":
            dia = "Martes";
            break;
            case "3":
            dia = "Miercoles";
            break;
            case "4":
            dia = "Jueves";
            break;
            case "5":
            dia = "Viernes";
            break;
        }
        return dia;
    }
    static void Ejercicio7()
    {
        // Datos
        double[,] calificaciones = {
            { 5.5, 8.6, 10.0 },
            { 8.0, 5.5, 10.0 },
            { 9.0, 4.1, 7.8 },
            { 10.2, 8.1, 9.0 },
            { 7.0, 9.2, 7.1 },
            { 9.0, 4.0, 6.0 },
            { 6.5, 5.0, 5.0 },
            { 4.0, 7.0, 4.0 },
            { 8.0, 8.0, 9.0 },
            { 10.0, 9.2, 9.4 },
            { 9.0, 4.6, 7.5 }
        };
        Console.WriteLine("Calificaciones:");
        for(int i = 0; i < 11; i++)
        {
            
            for(int j = 0; j < 3; j++)
            {
                Console.Write($"{calificaciones[i,j],8}");
            }
            Console.WriteLine("");
        }
        int estudiantes = calificaciones.GetLength(0); // Numero de estudiantes
        int materias = calificaciones.GetLength(1); // Cantidad de parciales por estudiantes

        double[] promedios = new double[estudiantes]; // Guardar promedio
        double promedioAlto = double.MinValue;
        double promedioBajo = double.MaxValue;
        int materiasRepro = 0;
        int[] calficacionesDistri = new int[6]; // Distribucion del 1 - 10

        Console.WriteLine("Promedio por cada estudiante:");
        for (int i = 0; i < estudiantes; i++)
        {
            double sum = 0;
            for (int j = 0; j < materias; j++)
            {
                sum += calificaciones[i, j];

                // Conteo de las materias reprobadas
                if (calificaciones[i, j] < 7.0)
                {
                    materiasRepro++;
                }
                // Distribucion de calificaciones
                if (calificaciones[i, j] >= 9.0) 
                {
                    calficacionesDistri[5]++;
                }
                else if (calificaciones[i, j] >= 8.0)
                {
                    calficacionesDistri[4]++;
                }
                else if (calificaciones[i, j] >= 7.0) 
                {
                    calficacionesDistri[3]++;
                }
                else if (calificaciones[i, j] >= 6.0) 
                {
                    calficacionesDistri[2]++;
                }
                else if (calificaciones[i, j] >= 5.0)
                {
                     calficacionesDistri[1]++;
                }
                else 
                {
                    calficacionesDistri[0]++;
                }
            }

            // Calcular promedio por estudiante
            double promedio = sum / materias;
            promedios[i] = promedio;
            Console.WriteLine($"Estudiante {i + 1}: {promedio:F2}");

            // Comprobar promedios mas bajos y altos
            if (promedio > promedioAlto)
            {
                promedioAlto = promedio;
            }
            else if (promedio < promedioBajo)
            {
                promedioBajo = promedio;
            }
        }

        // Imprimer los resultados mas bajos y altos
        Console.WriteLine($"\nPromedios mas altos: {promedioAlto:F2}");
        Console.WriteLine($"\nPromedios mas bajos: {promedioBajo:F2}");

        // Mostrar la cantidad de parciales reprobados
        Console.WriteLine($"\nCantidad de materias reprobadas (con menos de 7.0): {materiasRepro}");

        // Mostrar distribucion de calificaciones
        Console.WriteLine("\nDistribucion de las calficaciones:");
        Console.WriteLine($"0.0 - 4.9: {calficacionesDistri[0]} estudiantes");
        Console.WriteLine($"5.0 - 5.9: {calficacionesDistri[1]} estudiantes");
        Console.WriteLine($"6.0 - 6.9: {calficacionesDistri[2]} estudiantes");
        Console.WriteLine($"7.0 - 7.9: {calficacionesDistri[3]} estudiantes");
        Console.WriteLine($"8.0 - 8.9: {calficacionesDistri[4]} estudiantes");
        Console.WriteLine($"9.0 - 10: {calficacionesDistri[5]} estudiantes");
    }
    
    //Menu del programa
    static void menu(string confirma)
    {
        switch (confirma)
        {  
            //Contar ceros
            case "1":
            Ejercicio1();
            break;
            //Cuadrado Magico
            case "2":
            Ejercicio2();
            break;
            //Operando Matrices
            case "3":
            Ejercicio3();
            break;
            //Rellenado de 0 y 1
            case "4":
            Ejercicio4();
            break;
            //matriz 5 x 10
            case "5":
            Ejercicio5();
            break;
            //Ventas del año
            case "6":
            Ejercicio6();
            break;
            case"7":
            Ejercicio7();
            break;
            case "8":
            //salida
            Console.WriteLine("Saliendo del programa...");
            break;
            default:
            //Evitar que el usuario rompa el programa
            Console.WriteLine("Opcion invalida.");
            break;
        }
    }
    static void Main(string[] args)
    {
        //Lo que pide el usuario en el menu
        string confirma = "";
        do
        {
            //Menu
            Console.WriteLine("Elige que accion deseas realizar. \n 1.Conteo de ceros. \n 2.Cuadrado Magico.\n 3.Operaciones de matrices \n 4.Relleno de matriz \n 5.Matriz aleatoria \n 6.Ventas del año \n 7.Alumnos\n 8.Salir");
            confirma = Console.ReadLine()??null;
            menu(confirma);        
        }
        while(confirma != "8");
    } 
}