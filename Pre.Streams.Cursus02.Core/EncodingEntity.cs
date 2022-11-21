using System.Text;

namespace Pre.Streams.Cursus02.Core;

public class EncodingEntity
{
    public Encoding CharacterSet { get; }
    public string CharacterSetName { get; }

    public EncodingEntity(Encoding characterSet, string characterSetName)
    {
        CharacterSet = characterSet;
        CharacterSetName = characterSetName;
    }

    public override string ToString()
    {
        return CharacterSetName;
    }
}