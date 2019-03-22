using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FuncsApi.Modelos
{
    public class Funcionarios
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set;}

        [BsonElement("nome")]
        public string funcNome { get; set;}

        [BsonElement("idade")]
        public double idade {get; set;}

        [BsonElement("dataNascimento")]
        [BsonDateTimeOptions]
        public DateTime dataNascimento {get; set;}

        [BsonElement("funcao")]
        public string funcao {get; set;}
    }
}