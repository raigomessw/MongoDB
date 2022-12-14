using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MongoExample.Models;

public class  Playlist {

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]

    public string? Id {get; set; }
     [BsonElement("username")]
     [JsonPropertyName("username")]
    public string Username {get; set; } = null!;


    [BsonElement("items")]
    [JsonPropertyName("items")]
    public List<string> MovieIds {get; set; } = null!;


} 
