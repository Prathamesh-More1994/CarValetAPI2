using Geolocation;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

public class CustomSerializer : SerializerBase<Coordinate>
{
    public override Coordinate Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        context.Reader.ReadStartArray();
        var latitude = context.Reader.ReadDouble();
        var longitude = context.Reader.ReadDouble();
        context.Reader.ReadEndArray();

        return new Coordinate() { Longitude = (float)longitude, Latitude = (float)latitude };
    }
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Coordinate value)
    {
        context.Writer.WriteStartArray();
        context.Writer.WriteDouble(value.Latitude);
        context.Writer.WriteDouble(value.Longitude);
        context.Writer.WriteEndArray();
    }
}