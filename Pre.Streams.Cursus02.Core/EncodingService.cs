using System.Text;

namespace Pre.Streams.Cursus02.Core;

public class EncodingService
{
    public List<EncodingEntity> AvailableCharSets { get; set; }

    public EncodingService()
    {
        AvailableCharSets = new List<EncodingEntity>();
        AvailableCharSets.Add(new EncodingEntity(Encoding.UTF8, "UTF-8"));
        AvailableCharSets.Add(new EncodingEntity(Encoding.GetEncoding("iso-8859-1"), "Ansi"));
    }
}