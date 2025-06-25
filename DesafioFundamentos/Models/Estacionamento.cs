namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
           
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

              if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Por favor, digite uma placa.");
                return;
            }

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine($"O veículo com a placa '{placa}' já está estacionado.");
            }
            else
            {
                veiculos.Add(placa);
                Console.WriteLine($"Veículo '{placa}' estacionado com sucesso!");
            }
        
        }

       public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

        
            string placa = Console.ReadLine();

            
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                
                int horas = 0;
                
                if (!int.TryParse(Console.ReadLine(), out horas) || horas < 0)
                {
                    Console.WriteLine("Quantidade de horas inválida. Por favor, digite um número inteiro não negativo.");
                    return; 
                }

                decimal valorTotal = precoInicial + (precoPorHora * horas);

                
                veiculos.RemoveAll(x => x.ToUpper() == placa.ToUpper()); 

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:F2}"); 
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        public void ListarVeiculos()
        {
           
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                
                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"Vaga {i + 1}: {veiculos[i]}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
