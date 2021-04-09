using System;



namespace Calculadora.ConsoleApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string opcao = "";
            double segundoNumero = 0;
            double primeiroNumero = 0;
            string[] operacaoRealizada = new string[100];
            int contadorOperacao = 0;

            while (true)
            {
                MostrarMenu();

                opcao = Console.ReadLine();

                if (OpcaoVisualizar(opcao))
                {
                    if (contadorOperacao == 0)
                    {
                        MostrarMensagem("Não há operações");
                        Console.Clear();
                        continue;

                    }

                    else
                    {
                        Visualizar(operacaoRealizada, contadorOperacao);
                        continue;
                    }



                }

                if (Sair(opcao))
                {
                    break;
                }

                if (ValidaOpcao(opcao))
                {

                    MostrarMensagem("Tente novamente, opção inválida");
                    Console.Clear();

                    continue;
                }

                Console.Write("Digite o primeiro número:");

                primeiroNumero = Convert.ToDouble(Console.ReadLine());

                do
                {

                    Console.Write("Digita o segundo número:");
                    segundoNumero = Convert.ToDouble(Console.ReadLine());

                    if (ConfereDivisao(opcao, segundoNumero))
                    {
                        MostrarMensagem("Segundo número inválido! Tente novamente");

                    }

                } while (ConfereDivisao(opcao, segundoNumero));




                double resultado = CalculaResultado(opcao, segundoNumero, primeiroNumero);


                string operacao = $"{primeiroNumero} {ObterSimbolo(opcao)} {segundoNumero} = {resultado}";

                operacaoRealizada[contadorOperacao] = operacao;





                Console.WriteLine(resultado);
                contadorOperacao++;
                Console.ReadLine();
                Console.Clear();


            }

        }

        private static void Visualizar(string[] operacaoRealizada, int contadorOperacao)
        {
            for (int i = 0; i < contadorOperacao; i++)
            {
                Console.WriteLine(operacaoRealizada[i]);
            }
            Console.ReadLine();
            Console.Clear();
        }

        private static bool OpcaoVisualizar(string opcao)
        {
            return opcao.Equals("5");
        }

        private static bool Sair(string opcao)
        {
            return opcao.Equals("s", StringComparison.OrdinalIgnoreCase);
        }

        private static bool ConfereDivisao(string opcao, double segundoNumero)
        {
            return opcao == "4" && segundoNumero == 0;
        }

        private static double CalculaResultado(string opcao, double segundoNumero, double primeiroNumero)
        {
            double resultado = 0;
            switch (opcao)
            {
                case "1": resultado = primeiroNumero + segundoNumero;  break;
                case "2": resultado = primeiroNumero - segundoNumero;  break;
                case "3": resultado = primeiroNumero * segundoNumero;  break;
                case "4": resultado = primeiroNumero / segundoNumero; break;

                default:
                    break;
            }

            return resultado;
        }

        public static string ObterSimbolo(string opcao) {

            string simbolo = "";
            switch (opcao)
            {
                case "1": simbolo = "+"; break;
                case "2": simbolo = "-";  break;
                case "3": simbolo = "x"; break;
                case "4": simbolo = "÷"; break;

                default:
                    break;
            }
            return simbolo;
        }

        private static bool ValidaOpcao(string opcao)
        {
            return !opcao.Equals("1") && !opcao.Equals("2") && !opcao.Equals("3") && !opcao.Equals("4")
                                 && !opcao.Equals("5");
        }

        private static void MostrarMensagem(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();

           
        }

        private static void MostrarMenu()
        {
            Console.WriteLine("Calculadora 1.1");
            Console.WriteLine("Digite 1 para somar");
            Console.WriteLine("Digite 2 para subtrair");
            Console.WriteLine("Digite 3 para multiplicar");
            Console.WriteLine("Digite 4 para dividir");
            Console.WriteLine("Digite 5 para visualizar");
            Console.WriteLine("Digite S para sair");
        }
    }
}
