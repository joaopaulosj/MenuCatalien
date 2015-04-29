using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

[XmlRoot("RankingXML")]
public class RankingXML
{
    [XmlArray("Ranking"), XmlArrayItem("Pontuacao")]
    public List<Pontuacao> Ranking;

    public void Save(List<Pontuacao> ranking, string path)
    {
        Ranking = ranking;

        var serializer = new XmlSerializer(typeof(RankingXML));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    public static RankingXML Load(string path)
    {
        var serializer = new XmlSerializer(typeof(RankingXML));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as RankingXML;
        }
    }
}
