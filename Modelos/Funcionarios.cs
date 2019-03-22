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

        /*[BsonElement("dataNascimento")]
        public System.DateTime dataNascimento {get; set;}*/

        [BsonElement("funcao")]
        public string funcao {get; set;}
    }
}