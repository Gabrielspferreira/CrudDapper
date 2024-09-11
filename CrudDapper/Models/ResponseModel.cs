namespace CrudDapper.Models
{
    public class ResponseModel<T>
    {
        public T? Dados { get; set; } 
        public string Mensagem { get; set; } = string.Empty;
        public bool Situacao { get; set; } = true;
    }
}
