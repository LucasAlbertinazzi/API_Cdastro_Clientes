namespace GestaoDeClientes.API.Model
{
    public class Cliente
    {
        public int ID { get; set; }
        public string? nome { get; set; }
        public string? sexo { get; set; }
        public string? cpf { get; set; }
        public int tipo { get; set; }
        public int situacao { get; set; }
    }
}
